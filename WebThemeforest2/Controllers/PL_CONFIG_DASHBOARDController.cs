using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Configuration;
using WebThemeforest2.Models;
using WebThemeforest2.Repositories;

namespace WebThemeforest2
{
    public class PL_CONFIG_DASHBOARDController : ApiController
    {
        private string connectionString = ConfigurationManager.ConnectionStrings["DatabaseConnection"].ConnectionString;
        [HttpGet]


        public IQueryable<PL_CONFIG_DASHBOARD> Get()
        {
            PL_CONFIG_DASHBOARDRepository rep = new PL_CONFIG_DASHBOARDRepository(connectionString);
            List<PL_CONFIG_DASHBOARD> list = rep.GetData();
            return list.AsQueryable();
        }

        public void Post(PL_CONFIG_DASHBOARD PL_CONFIG_DASHBOARD)
        {
            PL_CONFIG_DASHBOARDRepository rep = new PL_CONFIG_DASHBOARDRepository(connectionString);
            rep.Add(PL_CONFIG_DASHBOARD);
        }

        public void Put(PL_CONFIG_DASHBOARD PL_CONFIG_DASHBOARD)
        {
            PL_CONFIG_DASHBOARDRepository rep = new PL_CONFIG_DASHBOARDRepository(connectionString);
            rep.Update(PL_CONFIG_DASHBOARD);
        }

        public void Delete(PL_CONFIG_DASHBOARD PL_CONFIG_DASHBOARD)
        {
            PL_CONFIG_DASHBOARDRepository rep = new PL_CONFIG_DASHBOARDRepository(connectionString);
            rep.Remove(PL_CONFIG_DASHBOARD);
        }

    }
}