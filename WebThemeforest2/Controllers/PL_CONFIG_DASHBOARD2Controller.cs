using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Configuration;
using WebThemeforest2.Models;
using WebThemeforest2.Repositories;

namespace WebThemeforest2.Controllers
{
    public class PL_CONFIG_DASHBOARD2Controller : ApiController
    {
        private string connectionString = ConfigurationManager.ConnectionStrings["DatabaseConnection"].ConnectionString;

        public IHttpActionResult Post(PL_CONFIG_DASHBOARD PL_CONFIG_DASHBOARD)
        {
            PL_CONFIG_DASHBOARDRepository rep = new PL_CONFIG_DASHBOARDRepository(connectionString);
            string result = rep.GetMaxCap(PL_CONFIG_DASHBOARD);

            return Ok(new { CAPACITY_MAX = result });
        }



        [HttpGet]
        public IQueryable<PL_CONFIG_DASHBOARD> GetDataArea()
        {
            PL_CONFIG_DASHBOARDRepository rep = new PL_CONFIG_DASHBOARDRepository(connectionString);
            List<PL_CONFIG_DASHBOARD> list = rep.GetDataArea();
            return list.AsQueryable();

        }


        
        public void Delete(PL_CONFIG_DASHBOARD PL_CONFIG_DASHBOARD)
        {
            PL_CONFIG_DASHBOARDRepository rep = new PL_CONFIG_DASHBOARDRepository(connectionString);
            rep.Remove(PL_CONFIG_DASHBOARD);
        }
    }
}
