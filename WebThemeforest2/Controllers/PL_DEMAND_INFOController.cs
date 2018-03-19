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
	public class PL_DEMAND_INFOController : ApiController
	{
		private string connectionString = ConfigurationManager.ConnectionStrings["DatabaseConnection"].ConnectionString;
		[HttpGet]
		public IQueryable<PL_DEMAND_INFO> Get()
		{
			PL_DEMAND_INFORepository rep = new PL_DEMAND_INFORepository(connectionString);
			List<PL_DEMAND_INFO> list = rep.GetData();
			return list.AsQueryable();
		}

		[Route("api/PL_DEMAND_INFO/IDRefPelanggan/{idrefpelanggan}")]
		[HttpGet]
		public IQueryable<PL_DEMAND_INFO> GetByIDRefPelanggan(string idrefpelanggan)
		{
			PL_DEMAND_INFORepository rep = new PL_DEMAND_INFORepository(connectionString);
			List<PL_DEMAND_INFO> list = rep.GetDataByIDRefPelanggan(idrefpelanggan);
			return list.AsQueryable();
		}

		[Route("api/PL_DEMAND_INFO/AreaID/{areaid}")]
		[HttpGet]
		public IQueryable<PL_DEMAND_INFO> GetByAreaID(string areaid)
		{
			PL_DEMAND_INFORepository rep = new PL_DEMAND_INFORepository(connectionString);
			List<PL_DEMAND_INFO> list = rep.GetDataByAreaID(areaid);
			return list.AsQueryable();
		}

		[Route("api/PL_DEMAND_INFO/Name/{name}")]
		[HttpGet]
		public IQueryable<PL_DEMAND_INFO> GetByName(string name)
		{
			PL_DEMAND_INFORepository rep = new PL_DEMAND_INFORepository(connectionString);
			List<PL_DEMAND_INFO> list = rep.GetDataByName(name);
			return list.AsQueryable();
		}

		public void Post(PL_DEMAND_INFO pl_demand_info)
		{
			PL_DEMAND_INFORepository rep = new PL_DEMAND_INFORepository(connectionString);
			rep.Add(pl_demand_info);
		}

		public void Put(PL_DEMAND_INFO pl_demand_info)
		{
			PL_DEMAND_INFORepository rep = new PL_DEMAND_INFORepository(connectionString);
			rep.Update(pl_demand_info);
		}

		public void Delete(PL_DEMAND_INFO pl_demand_info)
		{
			PL_DEMAND_INFORepository rep = new PL_DEMAND_INFORepository(connectionString);
			rep.Remove(pl_demand_info);
		}

	}
}