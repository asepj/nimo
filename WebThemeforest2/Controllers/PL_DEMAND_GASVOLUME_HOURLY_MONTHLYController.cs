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
    public class PL_DEMAND_GASVOLUME_HOURLY_MONTHLYController : ApiController
    {
        private string connectionString = ConfigurationManager.ConnectionStrings["DatabaseConnection"].ConnectionString;
        [HttpGet]
        public IQueryable<PL_DEMAND_GASVOLUME_HOURLY_MONTHLY> Get()
        {
            PL_DEMAND_GASVOLUME_HOURLY_MONTHLYRepository rep = new PL_DEMAND_GASVOLUME_HOURLY_MONTHLYRepository(connectionString);
            List<PL_DEMAND_GASVOLUME_HOURLY_MONTHLY> list = rep.GetData();
            return list.AsQueryable();
        }

        public void Post(PL_DEMAND_GASVOLUME_HOURLY_MONTHLY pl_demand_gasvolume_hourly_monthly)
        {
            PL_DEMAND_GASVOLUME_HOURLY_MONTHLYRepository rep = new PL_DEMAND_GASVOLUME_HOURLY_MONTHLYRepository(connectionString);
            rep.Add(pl_demand_gasvolume_hourly_monthly);
        }

        public void Put(PL_DEMAND_GASVOLUME_HOURLY_MONTHLY pl_demand_gasvolume_hourly_monthly)
        {
            PL_DEMAND_GASVOLUME_HOURLY_MONTHLYRepository rep = new PL_DEMAND_GASVOLUME_HOURLY_MONTHLYRepository(connectionString);
            rep.Update(pl_demand_gasvolume_hourly_monthly);
        }

        public void Delete(PL_DEMAND_GASVOLUME_HOURLY_MONTHLY pl_demand_gasvolume_hourly_monthly)
        {
            PL_DEMAND_GASVOLUME_HOURLY_MONTHLYRepository rep = new PL_DEMAND_GASVOLUME_HOURLY_MONTHLYRepository(connectionString);
            rep.Remove(pl_demand_gasvolume_hourly_monthly);
        }

        [Route("api/PL_DEMAND_GASVOLUME_HOURLY_MONTHLY/ByHour")]
        [HttpPost]
        public IQueryable<PL_DEMAND_GASVOLUME_HOURLY_MONTHLY> ByHour([FromBody]PL_DEMAND_GASVOLUME_HOURLY_MONTHLY pl_demand_gasvolume_hourly_monthly)
        {
            PL_DEMAND_GASVOLUME_HOURLY_MONTHLYRepository rep = new PL_DEMAND_GASVOLUME_HOURLY_MONTHLYRepository(connectionString);
            List<PL_DEMAND_GASVOLUME_HOURLY_MONTHLY> list = rep.Getbyhour(pl_demand_gasvolume_hourly_monthly);
            return list.AsQueryable();
        }



    }
}