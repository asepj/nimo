using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Web.Http;
using WebThemeforest2.Models;

namespace WebThemeforest2.Controllers
{
    public class AreaCapacityUtilizationController   : ApiController
    {
        [HttpGet]
        public IQueryable<CapacityUtilizationCount> Get()
        {
            List<CapacityUtilizationCount> list = new List<CapacityUtilizationCount>();

            DateTime start = new DateTime(2016, 5, 1);
            DateTime end = new DateTime(2016, 5, 7);
            string area = "014";
            NimoDataFile file1 = new NimoDataFile();
            //List<CapacityUtilizationCount> list2 = file1.GetDataWeek(end, area);
            CapacityUtilizationValue val = file1.GetDataWeek(end, area);

            return val.Items.AsQueryable();
        }

        private void ParseDateStamp(NimoParam param, out DateTime start, out DateTime end)
        {
            end = DateTime.Now;
            end = new DateTime(end.Year, end.Month, end.Day);
            start = end.AddDays(-6);

            string str = param.DATE_STAMP_STRING;
            string[] dates = str.Split('-');
            if (dates.Length == 2)
            {
                string strStart = dates[0];
                start = DateTime.Parse(strStart);
                string strEnd = dates[1];
                end = DateTime.Parse(strEnd);
            }

        }
        public CapacityUtilizationValue Post(NimoParam param)
        {
            Thread.CurrentThread.CurrentCulture = CultureInfo.GetCultureInfo("en-US");
            string myParameter = Newtonsoft.Json.JsonConvert.SerializeObject(param);

           
            //test
            //start = start.AddMonths(-2);
            //end = end.AddMonths(-2);

            NimoDataFile file1 = new NimoDataFile();
            //List<CapacityUtilizationCount> list = file1.GetDataWeek(end, param.AREA);
            //CapacityUtilizationValue val = file1.GetDataWeek(end, param.AREA);

            // Get data from database
            CapacityUtilizationValue val = file1.GetDataWeekFromDatabase(param.Start, param.End, param.AREA);

            //if (val.Items.Count == 0)
            //{
            //    val = file1.GetDataWeekFromDatabase(new DateTime(2017, 06, 22),new DateTime(2017, 06, 27),"014");
            //}

            return val;
        }

    }
}
