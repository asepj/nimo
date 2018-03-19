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
	public class PL_CONFIG_CONSTANTController : ApiController
	{
        private string connectionString = ConfigurationManager.ConnectionStrings["DatabaseConnection"].ConnectionString;
		[HttpGet]
		public IQueryable<PL_CONFIG_CONSTANT> Get()
		{
			PL_CONFIG_CONSTANTRepository rep = new PL_CONFIG_CONSTANTRepository(connectionString);
			List<PL_CONFIG_CONSTANT> list = rep.GetData();
			return list.AsQueryable();
		}

		[Route("api/PL_CONFIG_CONSTANT/ID/{id}")]
		[HttpGet]
		public IQueryable<PL_CONFIG_CONSTANT> GetByID(int id)
		{
			PL_CONFIG_CONSTANTRepository rep = new PL_CONFIG_CONSTANTRepository(connectionString);
			List<PL_CONFIG_CONSTANT> list = rep.GetDataByID(id);
			return list.AsQueryable();
		}

		public void Post(PL_CONFIG_CONSTANT pl_config_constant)
		{
			PL_CONFIG_CONSTANTRepository rep = new PL_CONFIG_CONSTANTRepository(connectionString);
			rep.Add(pl_config_constant);
		}

		public void Put(PL_CONFIG_CONSTANT pl_config_constant)
		{
			PL_CONFIG_CONSTANTRepository rep = new PL_CONFIG_CONSTANTRepository(connectionString);
			rep.Update(pl_config_constant);
		}

		public void Delete(PL_CONFIG_CONSTANT pl_config_constant)
		{
			PL_CONFIG_CONSTANTRepository rep = new PL_CONFIG_CONSTANTRepository(connectionString);
			rep.Remove(pl_config_constant);
		}

	}
}