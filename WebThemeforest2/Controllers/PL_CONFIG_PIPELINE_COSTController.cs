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
	public class PL_CONFIG_PIPELINE_COSTController : ApiController
	{
        private string connectionString = ConfigurationManager.ConnectionStrings["DatabaseConnection"].ConnectionString;
		[HttpGet]
		public IQueryable<PL_CONFIG_PIPELINE_COST> Get()
		{
			PL_CONFIG_PIPELINE_COSTRepository rep = new PL_CONFIG_PIPELINE_COSTRepository(connectionString);
			List<PL_CONFIG_PIPELINE_COST> list = rep.GetData();
			return list.AsQueryable();
		}

		public void Post(PL_CONFIG_PIPELINE_COST pl_config_pipeline_cost)
		{
			PL_CONFIG_PIPELINE_COSTRepository rep = new PL_CONFIG_PIPELINE_COSTRepository(connectionString);
			rep.Add(pl_config_pipeline_cost);
		}

		public void Put(PL_CONFIG_PIPELINE_COST pl_config_pipeline_cost)
		{
			PL_CONFIG_PIPELINE_COSTRepository rep = new PL_CONFIG_PIPELINE_COSTRepository(connectionString);
			rep.Update(pl_config_pipeline_cost);
		}

		public void Delete(PL_CONFIG_PIPELINE_COST pl_config_pipeline_cost)
		{
			PL_CONFIG_PIPELINE_COSTRepository rep = new PL_CONFIG_PIPELINE_COSTRepository(connectionString);
			rep.Remove(pl_config_pipeline_cost);
		}

	}
}