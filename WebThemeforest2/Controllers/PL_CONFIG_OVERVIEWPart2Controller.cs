using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Configuration;
using WebThemeforest2.Models;
using WebThemeforest2.Repositories;
using WebThemeforest2.BodyRequests;

namespace WebThemeforest2
{
	public class PL_CONFIG_OVERVIEWPart2Controller : ApiController
	{
        private string connectionString = ConfigurationManager.ConnectionStrings["DatabaseConnection"].ConnectionString;

        //[Route("PL_CONFIG_OVERVIEWPart2/GetAreaName/{id}")]

        //public IQueryable<PL_CONFIG_OVERVIEW> GetAreaName(string pl_config_overview_req)
        //{
        //    PL_CONFIG_OVERVIEWRepository rep = new PL_CONFIG_OVERVIEWRepository(connectionString);
        //    //if (pl_config_overview_req.Input.Equals("SELECT"))
        //    //{
        //    List<PL_CONFIG_OVERVIEW> list = rep.GetDataByName(pl_config_overview_req);
        //    return list.AsQueryable();
        //    //}
        //    //else if (pl_config_overview_req.Input.Equals("SAVE"))
        //    //{
        //    //    return null;
        //    //}
        //    //else
        //    //{
        //    //    return null;
        //    //}


        //}




        //public IQueryable<PL_CONFIG_OVERVIEW> Post(PL_CONFIG_OVERVIEW_Req pl_config_overview_req)
        //{
        //    PL_CONFIG_OVERVIEWRepository rep = new PL_CONFIG_OVERVIEWRepository(connectionString);
        //    if (pl_config_overview_req.Input.Equals("SELECT"))
        //    {
        //        List<PL_CONFIG_OVERVIEW> list = rep.GetDataByName(pl_config_overview_req.AREA_NAME);
        //        return list.AsQueryable();
        //    }
        //    else if (pl_config_overview_req.Input.Equals("SAVE"))
        //    {
        //        return null;
        //    }
        //    else
        //    {
        //        return null;
        //    }


        //}

       
        public IHttpActionResult Post(PL_CONFIG_OVERVIEW PL_CONFIG_OVERVIEW)
        {
            PL_CONFIG_OVERVIEWRepository rep = new PL_CONFIG_OVERVIEWRepository(connectionString);
            List<PL_CONFIG_OVERVIEW> result = rep.GetDataByName(PL_CONFIG_OVERVIEW.AREA_NAME);


            
            
            return Ok(new { ID = result[0].ID, MIN = result[0].MIN, MAX = result[0].MAX, COLOUR = result[0].COLOUR, AREA_NAME = result[0].AREA_NAME });

          
           
        }



      

       

	}
}