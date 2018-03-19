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
    public class PL_CONFIG_PIPELINEController : ApiController
    {
        private string connectionString = ConfigurationManager.ConnectionStrings["DatabaseConnection"].ConnectionString;
        [HttpGet]
        public IQueryable<PL_CONFIG_PIPELINE> Get()
        {
            PL_CONFIG_PIPELINERepository rep = new PL_CONFIG_PIPELINERepository(connectionString);
            List<PL_CONFIG_PIPELINE> list = rep.GetData();
            return list.AsQueryable();
        }

        [Route("api/PL_CONFIG_PIPELINE/ID/{id}")]
        [HttpGet]
        public IQueryable<PL_CONFIG_PIPELINE> GetByID(int id)
        {
            PL_CONFIG_PIPELINERepository rep = new PL_CONFIG_PIPELINERepository(connectionString);
            List<PL_CONFIG_PIPELINE> list = rep.GetDataByID(id);
            return list.AsQueryable();
        }

        public void Post(PL_CONFIG_PIPELINE PL_CONFIG_PIPELINE)
        {
            PL_CONFIG_PIPELINERepository rep = new PL_CONFIG_PIPELINERepository(connectionString);
            rep.Add(PL_CONFIG_PIPELINE);
        }

        public void Put(PL_CONFIG_PIPELINE PL_CONFIG_PIPELINE)
        {
            PL_CONFIG_PIPELINERepository rep = new PL_CONFIG_PIPELINERepository(connectionString);
            rep.Update(PL_CONFIG_PIPELINE);
        }

        public void Delete(PL_CONFIG_PIPELINE PL_CONFIG_PIPELINE)
        {
            PL_CONFIG_PIPELINERepository rep = new PL_CONFIG_PIPELINERepository(connectionString);
            rep.Remove(PL_CONFIG_PIPELINE);
        }

    }
}