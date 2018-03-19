using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebThemeforest2.Models;
namespace WebThemeforest2.BodyRequests
{
    public class PL_CONFIG_OVERVIEW_Req
    {

        public string Input { get; set; }
        
        public string AREA_NAME { get; set; }

        public PL_CONFIG_DASHBOARD Content { get; set; }

        public PL_CONFIG_OVERVIEW_Req()
        {

        }

    }
}