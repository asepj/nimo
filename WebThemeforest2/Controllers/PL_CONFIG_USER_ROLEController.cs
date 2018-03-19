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
	public class PL_CONFIG_USER_ROLEController : ApiController
	{
        private string connectionString = ConfigurationManager.ConnectionStrings["DatabaseConnection"].ConnectionString;
		[HttpGet]
		public IQueryable<PL_CONFIG_USER_ROLE> Get()
		{
			PL_CONFIG_USER_ROLERepository rep = new PL_CONFIG_USER_ROLERepository(connectionString);
			List<PL_CONFIG_USER_ROLE> list = rep.GetData();
			return list.AsQueryable();
		}

		[Route("api/PL_CONFIG_USER_ROLE/ID/{id}")]
		[HttpGet]
		public IQueryable<PL_CONFIG_USER_ROLE> GetByID(int id)
		{
			PL_CONFIG_USER_ROLERepository rep = new PL_CONFIG_USER_ROLERepository(connectionString);
			List<PL_CONFIG_USER_ROLE> list = rep.GetDataByID(id);
			return list.AsQueryable();
		}

		public void Post(PL_CONFIG_USER_ROLE pl_config_user_role)
		{
			PL_CONFIG_USER_ROLERepository rep = new PL_CONFIG_USER_ROLERepository(connectionString);
			rep.Add(pl_config_user_role);
		}

		public void Put(PL_CONFIG_USER_ROLE pl_config_user_role)
		{
			PL_CONFIG_USER_ROLERepository rep = new PL_CONFIG_USER_ROLERepository(connectionString);
			rep.Update(pl_config_user_role);
		}

		public void Delete(PL_CONFIG_USER_ROLE pl_config_user_role)
		{
			PL_CONFIG_USER_ROLERepository rep = new PL_CONFIG_USER_ROLERepository(connectionString);
			rep.Remove(pl_config_user_role);
		}

	}
}