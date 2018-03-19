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
	public class PL_CONFIG_PIPELINE_CONSTRUCTIONController : ApiController
	{
        private string connectionString = ConfigurationManager.ConnectionStrings["DatabaseConnection"].ConnectionString;
		[HttpGet]
		public IQueryable<PL_CONFIG_PIPELINE_CONSTRUCTION> Get()
		{
			PL_CONFIG_PIPELINE_CONSTRUCTIONRepository rep = new PL_CONFIG_PIPELINE_CONSTRUCTIONRepository(connectionString);
			List<PL_CONFIG_PIPELINE_CONSTRUCTION> list = rep.GetData();
			return list.AsQueryable();
		}

		public void Post(PL_CONFIG_PIPELINE_CONSTRUCTION pl_config_pipeline_construction)
		{
			PL_CONFIG_PIPELINE_CONSTRUCTIONRepository rep = new PL_CONFIG_PIPELINE_CONSTRUCTIONRepository(connectionString);
			rep.Add(pl_config_pipeline_construction);
		}

		public void Put(PL_CONFIG_PIPELINE_CONSTRUCTION pl_config_pipeline_construction)
		{
			PL_CONFIG_PIPELINE_CONSTRUCTIONRepository rep = new PL_CONFIG_PIPELINE_CONSTRUCTIONRepository(connectionString);
			rep.Update(pl_config_pipeline_construction);
		}

		public void Delete(PL_CONFIG_PIPELINE_CONSTRUCTION pl_config_pipeline_construction)
		{
			PL_CONFIG_PIPELINE_CONSTRUCTIONRepository rep = new PL_CONFIG_PIPELINE_CONSTRUCTIONRepository(connectionString);
			rep.Remove(pl_config_pipeline_construction);
		}


        [Route("api/PL_CONFIG_PIPELINE_CONSTRUCTION/GetDescription")]
        [HttpPost]
        public IQueryable<PL_CONFIG_PIPELINE_CONSTRUCTION> GetDescription([FromBody]PL_CONFIG_PIPELINE_CONSTRUCTION pl_config_pipeline_construction)
        {
            PL_CONFIG_PIPELINE_CONSTRUCTIONRepository rep1 = new PL_CONFIG_PIPELINE_CONSTRUCTIONRepository(connectionString);
            List<PL_CONFIG_PIPELINE_CONSTRUCTION> list = rep1.GetDataDescription(pl_config_pipeline_construction);
            return list.AsQueryable();
        }

	}
}