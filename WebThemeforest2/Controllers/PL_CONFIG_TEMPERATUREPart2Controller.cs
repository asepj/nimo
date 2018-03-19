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
    public class PL_CONFIG_TEMPERATUREPart2Controller  : ApiController
    {
        private string connectionString = ConfigurationManager.ConnectionStrings["DatabaseConnection"].ConnectionString;
        [HttpGet]


        public IQueryable<PL_CONFIG_CONSTANT> Get()
        {
            PL_CONFIG_CONSTANTRepository rep = new PL_CONFIG_CONSTANTRepository(connectionString);
            List<PL_CONFIG_CONSTANT> list = rep.GetDataTemperature();
            return list.AsQueryable();
        }

        

    }
}