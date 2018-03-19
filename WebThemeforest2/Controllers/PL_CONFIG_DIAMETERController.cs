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
    public class PL_CONFIG_DIAMETERController : ApiController
    {
        private string connectionString = ConfigurationManager.ConnectionStrings["DatabaseConnection"].ConnectionString;
        [HttpGet]


        public IQueryable<PL_CONFIG_DIAMETER> Get()
        {
            PL_CONFIG_DIAMETERRepository rep = new PL_CONFIG_DIAMETERRepository(connectionString);
            List<PL_CONFIG_DIAMETER> list = rep.GetData();
            return list.AsQueryable();
        }

        [Route("api/PL_CONFIG_CALCULATOR_DIAMETER/ID/{id}")]
        [HttpGet]
        public IQueryable<PL_CONFIG_DIAMETER> GetByID(int id)
        {
            PL_CONFIG_DIAMETERRepository rep = new PL_CONFIG_DIAMETERRepository(connectionString);
            List<PL_CONFIG_DIAMETER> list = rep.GetDataByID(id);
            return list.AsQueryable();
        }

        public void Post(PL_CONFIG_DIAMETER pl_config_calculator_diameter)
        {
            PL_CONFIG_DIAMETERRepository rep = new PL_CONFIG_DIAMETERRepository(connectionString);
            rep.Add(pl_config_calculator_diameter);
        }

        public void Put(PL_CONFIG_DIAMETER pl_config_calculator_diameter)
        {
            PL_CONFIG_DIAMETERRepository rep = new PL_CONFIG_DIAMETERRepository(connectionString);
            rep.Update(pl_config_calculator_diameter);
        }

        public void Delete(PL_CONFIG_DIAMETER pl_config_calculator_diameter)
        {
            PL_CONFIG_DIAMETERRepository rep = new PL_CONFIG_DIAMETERRepository(connectionString);
            rep.Remove(pl_config_calculator_diameter);
        }

    }
}