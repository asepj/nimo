using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebThemeforest2.Models;

namespace WebThemeforest2.Controllers
{
    public class RiskController : ApiController
    {

        [HttpGet]
        public IQueryable<RiskValue> Get()
        {
            List<RiskValue> list = new List<RiskValue>();

            RiskValue rv = new RiskValue { consequence = "A" , Likelihood = 3.0};

            list.Add(rv);
           

            return list.AsQueryable();
        }

    
        public RiskValue Post(RiskValue param)
        {
           

            // Get data from database

            param.Likelihood = param.Likelihood * 2.0;
            param.consequence = param.consequence + "X";
           
            return param;
        }

    }
}
