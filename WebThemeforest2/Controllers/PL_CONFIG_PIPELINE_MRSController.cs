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
    public class PL_CONFIG_PIPELINE_MRSController : ApiController
    {
        private string connectionString = ConfigurationManager.ConnectionStrings["DatabaseConnection"].ConnectionString;
        [HttpGet]
        public IQueryable<PL_CONFIG_PIPELINE_MRS> Get()
        {
            PL_CONFIG_PIPELINE_MRSRepository rep = new PL_CONFIG_PIPELINE_MRSRepository(connectionString);
            List<PL_CONFIG_PIPELINE_MRS> list = rep.GetData();
            return list.AsQueryable();
        }

        [Route("api/PL_CONFIG_PIPELINE_MRS/ID_MRS/{id_mrs}")]
        [HttpGet]
        public IQueryable<PL_CONFIG_PIPELINE_MRS> GetByID_MRS(int id_mrs)
        {
            PL_CONFIG_PIPELINE_MRSRepository rep = new PL_CONFIG_PIPELINE_MRSRepository(connectionString);
            List<PL_CONFIG_PIPELINE_MRS> list = rep.GetDataByID_MRS(id_mrs);
            return list.AsQueryable();
        }

        public void Post(PL_CONFIG_PIPELINE_MRS pl_config_pipeline_mrs)
        {
            PL_CONFIG_PIPELINE_MRSRepository rep = new PL_CONFIG_PIPELINE_MRSRepository(connectionString);
            rep.Add(pl_config_pipeline_mrs);
        }

        public void Put(PL_CONFIG_PIPELINE_MRS pl_config_pipeline_mrs)
        {
            PL_CONFIG_PIPELINE_MRSRepository rep = new PL_CONFIG_PIPELINE_MRSRepository(connectionString);
            rep.Update(pl_config_pipeline_mrs);
        }

        public void Delete(PL_CONFIG_PIPELINE_MRS pl_config_pipeline_mrs)
        {
            PL_CONFIG_PIPELINE_MRSRepository rep = new PL_CONFIG_PIPELINE_MRSRepository(connectionString);
            rep.Remove(pl_config_pipeline_mrs);
        }

    }
}