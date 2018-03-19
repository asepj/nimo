using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Configuration;
using WebThemeforest2.Models;
using WebThemeforest2.Repositories;
using WebThemeforest2.Models.GeoJsonPoint;
using Newtonsoft.Json;
using NimoMap = WebThemeforest2.Models.GeoJsonPoint;
namespace WebThemeforest2
{
    public class DemandMapController : ApiController
    {


        private List<FeatureProperties> listFateures;

        private List<string> Map = new List<string>();

        private string connectionString = ConfigurationManager.ConnectionStrings["DatabaseConnection"].ConnectionString;
        //[HttpGet]
        //public IQueryable<char> Get()
        //{

        //          PL_DEMAND_INFORepository repd = new PL_DEMAND_INFORepository(connectionString);

        //          listFateures = repd.GetDataDemand();

        //          RootObject root2 = new WebThemeforest2.Models.GeoJsonPoint.RootObject();

        //          root2.Populate(listFateures);
        //          string jsonString2 = JsonConvert.SerializeObject(root2, Newtonsoft.Json.Formatting.Indented, new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore, Formatting = Newtonsoft.Json.Formatting.Indented });

        //          //List<DemandMap> map = new List<DemandMap>();

        //          //DemandMap demandMap = new DemandMap();
        //          //demandMap.Map = jsonString2;

        //          //map.Add(demandMap);


        //          return jsonString2.AsQueryable() ;
        //}


        public NimoMap.RootObject Get()
        {

            NimoMap.RootObject retval = new NimoMap.RootObject();

            PL_DEMAND_INFORepository repd = new PL_DEMAND_INFORepository(connectionString);

            listFateures = repd.GetDataDemand();

            RootObject root2 = new WebThemeforest2.Models.GeoJsonPoint.RootObject();

            root2.Populate(listFateures);
            string jsonString2 = JsonConvert.SerializeObject(root2, Newtonsoft.Json.Formatting.Indented, new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore, Formatting = Newtonsoft.Json.Formatting.Indented });


            NimoMap.RootObject myRootObject = JsonConvert.DeserializeObject<NimoMap.RootObject>(jsonString2);

           

           


            return myRootObject;
        }
    }
}