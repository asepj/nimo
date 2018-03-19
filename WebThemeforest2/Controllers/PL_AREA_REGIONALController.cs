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
	public class PL_AREA_REGIONALController : ApiController
	{
        private string connectionString = ConfigurationManager.ConnectionStrings["DatabaseConnection"].ConnectionString;
		[HttpGet]
		public IQueryable<PL_AREA_REGIONAL> Get()
		{
			PL_AREA_REGIONALRepository rep = new PL_AREA_REGIONALRepository(connectionString);
			List<PL_AREA_REGIONAL> list = rep.GetData();
			return list.AsQueryable();
		}

		public void Post(PL_AREA_REGIONAL pl_area_regional)
		{
			PL_AREA_REGIONALRepository rep = new PL_AREA_REGIONALRepository(connectionString);
			rep.Add(pl_area_regional);
		}

		public void Put(PL_AREA_REGIONAL pl_area_regional)
		{
			PL_AREA_REGIONALRepository rep = new PL_AREA_REGIONALRepository(connectionString);
			rep.Update(pl_area_regional);
		}

		public void Delete(PL_AREA_REGIONAL pl_area_regional)
		{
			PL_AREA_REGIONALRepository rep = new PL_AREA_REGIONALRepository(connectionString);
			rep.Remove(pl_area_regional);
		}

	}
}