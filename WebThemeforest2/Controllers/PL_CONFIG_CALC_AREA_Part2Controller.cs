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
	public class PL_CONFIG_CALC_AREA_Part2Controller : ApiController
	{
        private string connectionString = ConfigurationManager.ConnectionStrings["DatabaseConnection"].ConnectionString;
		[HttpGet]
		public IQueryable<PL_CONFIG_CALC_AREA> Get()
		{
			PL_CONFIG_CALC_AREARepository rep = new PL_CONFIG_CALC_AREARepository(connectionString);
			List<PL_CONFIG_CALC_AREA> list = rep.GetData_Alternative();
			return list.AsQueryable();
		}

		[Route("api/PL_CONFIG_CALC_AREA/ID/{id}")]
		[HttpGet]
		public IQueryable<PL_CONFIG_CALC_AREA> GetByID(int id)
		{
			PL_CONFIG_CALC_AREARepository rep = new PL_CONFIG_CALC_AREARepository(connectionString);
			List<PL_CONFIG_CALC_AREA> list = rep.GetDataByID(id);
			return list.AsQueryable();
		}

		public void Post(PL_CONFIG_CALC_AREA pl_config_calc_area)
		{
			PL_CONFIG_CALC_AREARepository rep = new PL_CONFIG_CALC_AREARepository(connectionString);
			rep.Add(pl_config_calc_area);
		}

		public void Put(PL_CONFIG_CALC_AREA pl_config_calc_area)
		{
			PL_CONFIG_CALC_AREARepository rep = new PL_CONFIG_CALC_AREARepository(connectionString);
			rep.Update(pl_config_calc_area);
		}

		public void Delete(PL_CONFIG_CALC_AREA pl_config_calc_area)
		{
			PL_CONFIG_CALC_AREARepository rep = new PL_CONFIG_CALC_AREARepository(connectionString);
			rep.Remove(pl_config_calc_area);
		}


        [Route("api/PL_CONFIG_CALC_AREA_Part2/Category")]
        [HttpPost]
        public IQueryable Category([FromBody] PL_CONFIG_CALC_AREA CATEGORY)
        {

            PL_CONFIG_CALC_AREARepository rep0 = new PL_CONFIG_CALC_AREARepository(connectionString);

            List<PL_CONFIG_CALC_AREA> list2 = rep0.GetDataByCATEGORY(CATEGORY.CATEGORY);

            return list2.AsQueryable();

        }

        [Route("api/PL_CONFIG_CALC_AREA_Part2/GetRegime")]
        [HttpPost]
        public IQueryable<PL_CONFIG_CALC_AREA> GetRegime([FromBody]PL_CONFIG_CALC_AREA pl_config_calc_area)
        {
            PL_CONFIG_CALC_AREARepository rep = new PL_CONFIG_CALC_AREARepository(connectionString);
            List<PL_CONFIG_CALC_AREA> list = rep.GetDataByRegime(pl_config_calc_area);
            return list.AsQueryable();
        }


	}
}