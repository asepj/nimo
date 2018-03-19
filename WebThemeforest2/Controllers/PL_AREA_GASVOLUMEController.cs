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
	public class PL_AREA_GASVOLUMEController : ApiController
	{
        private string connectionString = ConfigurationManager.ConnectionStrings["DatabaseConnection"].ConnectionString;
		[HttpGet]
		public IQueryable<PL_AREA_GASVOLUME> Get()
		{
			PL_AREA_GASVOLUMERepository rep = new PL_AREA_GASVOLUMERepository(connectionString);
			List<PL_AREA_GASVOLUME> list = rep.GetData();
			return list.AsQueryable();
		}

		[Route("api/PL_AREA_GASVOLUME/DATETIME_ID/{datetime_id}")]
		[HttpGet]
		public IQueryable<PL_AREA_GASVOLUME> GetByDATETIME_ID(int datetime_id)
		{
			PL_AREA_GASVOLUMERepository rep = new PL_AREA_GASVOLUMERepository(connectionString);
			List<PL_AREA_GASVOLUME> list = rep.GetDataByDATETIME_ID(datetime_id);
			return list.AsQueryable();
		}

		public void Post(PL_AREA_GASVOLUME pl_area_gasvolume)
		{
			PL_AREA_GASVOLUMERepository rep = new PL_AREA_GASVOLUMERepository(connectionString);
			rep.Add(pl_area_gasvolume);
		}

		public void Put(PL_AREA_GASVOLUME pl_area_gasvolume)
		{
			PL_AREA_GASVOLUMERepository rep = new PL_AREA_GASVOLUMERepository(connectionString);
			rep.Update(pl_area_gasvolume);
		}

		public void Delete(PL_AREA_GASVOLUME pl_area_gasvolume)
		{
			PL_AREA_GASVOLUMERepository rep = new PL_AREA_GASVOLUMERepository(connectionString);
			rep.Remove(pl_area_gasvolume);
		}

	}
}