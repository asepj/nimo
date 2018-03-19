using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Device.Location;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using WebThemeforest2.Models;
using WebThemeforest2.Models.GoogleGeocode;
using NimoMap = WebThemeforest2.Models.GeojsonPipe;

using WebThemeforest2.Repositories;
using System.Configuration;
using System.Threading;
using System.Globalization;
namespace WebThemeforest2.Controllers
{
    public class PipeCalculatorMapController : ApiController
    {
        private string connectionString = ConfigurationManager.ConnectionStrings["DatabaseConnection"].ConnectionString;
        private string ToAbsoluteUrl(string relativeUrl)
        {
            if (string.IsNullOrEmpty(relativeUrl))
                return relativeUrl;

            if (HttpContext.Current == null)
                return relativeUrl;

            if (relativeUrl.StartsWith("/"))
                relativeUrl = relativeUrl.Insert(0, "~");
            if (!relativeUrl.StartsWith("~/"))
                relativeUrl = relativeUrl.Insert(0, "~/");

            var url = HttpContext.Current.Request.Url;
            var port = url.Port != 80 ? (":" + url.Port) : String.Empty;

            return String.Format("{0}://{1}{2}{3}",
                url.Scheme, url.Host, port, VirtualPathUtility.ToAbsolute(relativeUrl));
        }




        private string API_KEY = "AIzaSyBxCxd-VaQFaL6B0xu1r4vXhyFsBbVsKXM"; //scadaprimacipta


        //calculate otomatis

        public NimoMap.RootObject Get(string category)
        {
            Thread.CurrentThread.CurrentCulture = CultureInfo.GetCultureInfo("en-US");
            int myRowNumber = 0;
            string myMessage = "";
            PositionParam val = new PositionParam();

            PL_CONFIG_CALC_AREARepository rep = new PL_CONFIG_CALC_AREARepository(connectionString);
            //List<PL_CONFIG_CALC_AREA> list = rep.GetData();
            List<PL_CONFIG_CALC_AREA> list = rep.GetDataByCATEGORY(category);

            NimoMap.RootObject retval = new NimoMap.RootObject();
            retval.features = new List<NimoMap.Feature>();
            foreach (PL_CONFIG_CALC_AREA item in list)
            {
                string urlarea = "~/Scripts/" + item.FILE_NAME; // "Jakarta-Industri.js";
                string myUrl = ToAbsoluteUrl(urlarea);
                var json = new WebClient().DownloadString(myUrl);
                NimoMap.RootObject myRootObject = JsonConvert.DeserializeObject<NimoMap.RootObject>(json);

                if (retval.features.Count == 0)
                {
                    retval.crs = myRootObject.crs;
                    retval.type = myRootObject.type;
                }

                retval.features.AddRange(myRootObject.features);
            }


            return retval;
        }

        public NimoMap.RootObject Post(PositionParam origin)
        {
            Thread.CurrentThread.CurrentCulture = CultureInfo.GetCultureInfo("en-US");
            int myRowNumber = 0;
            string myMessage = "";
            PositionParam val = new PositionParam();

            PL_CONFIG_CALC_AREARepository rep = new PL_CONFIG_CALC_AREARepository(connectionString);
            List<PL_CONFIG_CALC_AREA> list = rep.GetDataByCATEGORY(origin.category);
            
            NimoMap.RootObject retval = new NimoMap.RootObject();
            retval.features = new List<NimoMap.Feature>();
            foreach(PL_CONFIG_CALC_AREA item in list)
            {
                string urlarea = "~/Scripts/" + item.FILE_NAME; // "Jakarta-Industri.js";
                string myUrl = ToAbsoluteUrl(urlarea);
                var json = new WebClient().DownloadString(myUrl);
                NimoMap.RootObject myRootObject = JsonConvert.DeserializeObject<NimoMap.RootObject>(json);

                if (retval.features.Count==0)
                {
                    retval.crs = myRootObject.crs;
                    retval.type = myRootObject.type;
                }

                retval.features.AddRange(myRootObject.features);
            }


            return retval;
        }





    }
}
