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
	public class PL_LOG_CALCULATORController : ApiController
	{
        private string connectionString = ConfigurationManager.ConnectionStrings["DatabaseConnection"].ConnectionString;
		[HttpGet]
		public IQueryable<PL_LOG_CALCULATOR> Get()
		{
			PL_LOG_CALCULATORRepository rep = new PL_LOG_CALCULATORRepository(connectionString);
			List<PL_LOG_CALCULATOR> list = rep.GetData();
			return list.AsQueryable();
		}

		[Route("api/PL_LOG_CALCULATOR/ID/{id}")]
		[HttpGet]
		public IQueryable<PL_LOG_CALCULATOR> GetByID(int id)
		{
			PL_LOG_CALCULATORRepository rep = new PL_LOG_CALCULATORRepository(connectionString);
			List<PL_LOG_CALCULATOR> list = rep.GetDataByID(id);
			return list.AsQueryable();
		}

		public void Post(PL_LOG_CALCULATOR pl_log_calculator)
		{
			PL_LOG_CALCULATORRepository rep = new PL_LOG_CALCULATORRepository(connectionString);
			rep.Add(pl_log_calculator);
		}

		public void Put(PL_LOG_CALCULATOR pl_log_calculator)
		{
			PL_LOG_CALCULATORRepository rep = new PL_LOG_CALCULATORRepository(connectionString);
			rep.Update(pl_log_calculator);
		}

		public void Delete(PL_LOG_CALCULATOR pl_log_calculator)
		{
			PL_LOG_CALCULATORRepository rep = new PL_LOG_CALCULATORRepository(connectionString);
			rep.Remove(pl_log_calculator);
		}

	}
}