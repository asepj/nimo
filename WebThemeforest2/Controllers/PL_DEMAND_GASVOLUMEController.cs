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
	public class PL_DEMAND_GASVOLUMEController : ApiController
	{
        private string connectionString = ConfigurationManager.ConnectionStrings["DatabaseConnection"].ConnectionString;
		[HttpGet]
		public IQueryable<PL_DEMAND_GASVOLUME> Get()
		{
			PL_DEMAND_GASVOLUMERepository rep = new PL_DEMAND_GASVOLUMERepository(connectionString);
			List<PL_DEMAND_GASVOLUME> list = rep.GetData();
			return list.AsQueryable();
		}

		[Route("api/PL_DEMAND_GASVOLUME/DATE_ID/{date_id}")]
		[HttpGet]
		public IQueryable<PL_DEMAND_GASVOLUME> GetByDATE_ID(int date_id)
		{
			PL_DEMAND_GASVOLUMERepository rep = new PL_DEMAND_GASVOLUMERepository(connectionString);
			List<PL_DEMAND_GASVOLUME> list = rep.GetDataByDATE_ID(date_id);
			return list.AsQueryable();
		}

		public void Post(PL_DEMAND_GASVOLUME pl_demand_gasvolume)
		{
			PL_DEMAND_GASVOLUMERepository rep = new PL_DEMAND_GASVOLUMERepository(connectionString);
			rep.Add(pl_demand_gasvolume);
		}

		public void Put(PL_DEMAND_GASVOLUME pl_demand_gasvolume)
		{
			PL_DEMAND_GASVOLUMERepository rep = new PL_DEMAND_GASVOLUMERepository(connectionString);
			rep.Update(pl_demand_gasvolume);
		}

		public void Delete(PL_DEMAND_GASVOLUME pl_demand_gasvolume)
		{
			PL_DEMAND_GASVOLUMERepository rep = new PL_DEMAND_GASVOLUMERepository(connectionString);
			rep.Remove(pl_demand_gasvolume);
		}

	}
}