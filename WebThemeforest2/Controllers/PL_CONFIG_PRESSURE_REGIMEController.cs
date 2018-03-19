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
	public class PL_CONFIG_PRESSURE_REGIMEController : ApiController
	{
		private string connectionString = ConfigurationManager.ConnectionStrings["connectionStringFDC"].ConnectionString;
		[HttpGet]
		public IQueryable<PL_CONFIG_PRESSURE_REGIME> Get()
		{
			PL_CONFIG_PRESSURE_REGIMERepository rep = new PL_CONFIG_PRESSURE_REGIMERepository(connectionString);
			List<PL_CONFIG_PRESSURE_REGIME> list = rep.GetData();
			return list.AsQueryable();
		}

		[Route("api/PL_CONFIG_PRESSURE_REGIME/REGIME_NAME/{regime_name}")]
		[HttpGet]
		public IQueryable<PL_CONFIG_PRESSURE_REGIME> GetByREGIME_NAME(string regime_name)
		{
			PL_CONFIG_PRESSURE_REGIMERepository rep = new PL_CONFIG_PRESSURE_REGIMERepository(connectionString);
			List<PL_CONFIG_PRESSURE_REGIME> list = rep.GetDataByREGIME_NAME(regime_name);
			return list.AsQueryable();
		}

		public void Post(PL_CONFIG_PRESSURE_REGIME pl_config_pressure_regime)
		{
			PL_CONFIG_PRESSURE_REGIMERepository rep = new PL_CONFIG_PRESSURE_REGIMERepository(connectionString);
			rep.Add(pl_config_pressure_regime);
		}

		public void Put(PL_CONFIG_PRESSURE_REGIME pl_config_pressure_regime)
		{
			PL_CONFIG_PRESSURE_REGIMERepository rep = new PL_CONFIG_PRESSURE_REGIMERepository(connectionString);
			rep.Update(pl_config_pressure_regime);
		}

		public void Delete(PL_CONFIG_PRESSURE_REGIME pl_config_pressure_regime)
		{
			PL_CONFIG_PRESSURE_REGIMERepository rep = new PL_CONFIG_PRESSURE_REGIMERepository(connectionString);
			rep.Remove(pl_config_pressure_regime);
		}

	}
}