using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO;
using System.Data.SqlClient;
using System.Configuration;


namespace WebThemeforest2.Models
{
    public class NimoDataFile
    {
        // Data source file location
        private string fileName = AppDomain.CurrentDomain.BaseDirectory + @"\Models\vw_area_flow.csv";

        // Connection string
        public string ConnectionString { get; set; }
        public string Message { get; set; }

        public NimoDataFile()
        {
        }
        public List<NimoAreaFlow> GetData(DateTime start, DateTime end, string area)
        {
            List<NimoAreaFlow> list = File.ReadLines(fileName)
                .Skip(1)
                .Where(s => s != "")
                .Select(s => s.Split(new[] { ',' }))
                .Select(a => new NimoAreaFlow
                {
                    AREA = Convert.ToString(a[0]),
                    DATE_STAMP = DateTime.Parse(a[1]),
                    FLOW = Double.Parse(a[2]),
                })
                .ToList();
            list = list.FindAll(delegate(NimoAreaFlow f) { return f.DATE_STAMP >= start && f.DATE_STAMP < end && f.AREA == area; });
            return list;
        }

        private int getDay(DateTime start, DateTime date)
        {
            int retval = 0;
            TimeSpan timeSpan = date - start;
            retval = timeSpan.Days + 1;
            return retval;
        }
        public CapacityUtilizationValue GetDataWeek(DateTime end, string area)
        {
            CapacityUtilizationValue retval = new CapacityUtilizationValue();
            DateTime start = end.AddDays(-7);
            List<NimoAreaFlow> list = File.ReadLines(fileName)
                .Skip(1)
                .Where(s => s != "")
                .Select(s => s.Split(new[] { ',' }))
                .Select(a => new NimoAreaFlow
                {
                    AREA = Convert.ToString(a[0]),
                    DATE_STAMP = DateTime.Parse(a[1]),
                    FLOW = Double.Parse(a[2]),
                })
                .ToList();
            List<NimoAreaFlow> listAllArea = list.FindAll(delegate(NimoAreaFlow f) { return f.DATE_STAMP >= start && f.DATE_STAMP < end; });
            list = list.FindAll(delegate(NimoAreaFlow f) { return f.DATE_STAMP >= start && f.DATE_STAMP < end && f.AREA == area; });
            double flowAllArea = listAllArea.Sum(o => o.FLOW);
            double flowArea = list.Sum(o => o.FLOW);

            List<CapacityUtilizationCount> list2 = new List<CapacityUtilizationCount>();
            foreach (NimoAreaFlow l in list)
            {
                CapacityUtilizationCount c = new CapacityUtilizationCount { datetime = l.DATE_STAMP, day = getDay(start, l.DATE_STAMP), hour = l.DATE_STAMP.Hour + 1, value = l.FLOW };
                list2.Add(c);
            }

            retval.Items = list2;
            retval.TotalFlow = flowArea;
            retval.TotalFlowAllArea = flowAllArea;
            retval.TotalFlowSBU = 0.0;

            return retval;
        }

        public CapacityUtilizationValue GetDataWeekFromDatabase(DateTime start,DateTime end, string area)
        {
            CapacityUtilizationValue retval = new CapacityUtilizationValue();
            //DateTime start = end.AddDays(-7);

            // Get connection string from web.config
            this.ConnectionString = ConfigurationManager.ConnectionStrings["DatabaseConnection"].ConnectionString;

            using (var conn = new SqlConnection(this.ConnectionString))
            {
                try
                {
                    Message = "";
                    conn.Open();
                    string query = string.Format("SELECT * FROM fn_get_averagetotalflow_perarea_perday('{0}', '{1}', null, null) " +
                                                        "  WHERE id_unit_usaha = '{2}'" +
                                                        "  ORDER BY id_unit_usaha, daynumber, hour", start, end, area);
                    SqlCommand command = new SqlCommand(query, conn);
                    command.CommandType = System.Data.CommandType.Text;
                    SqlDataReader reader = command.ExecuteReader();


                    Double countdays = (end - start).TotalDays;

                    retval.CountDays = countdays;

                    List<CapacityUtilizationCount> list2 = new List<CapacityUtilizationCount>();
                    List<CapacityUtilizationCount> list3 = new List<CapacityUtilizationCount>();
                    //List<NimoAreaFlow> list = new List<NimoAreaFlow>();

                    while (reader.Read())
                    {
                        //
                        CapacityUtilizationCount c = new CapacityUtilizationCount
                        {
                            datetime = Convert.ToDateTime(reader[6]),  // fdatetime column
                            AreaName = Convert.ToString(reader[0]), // area column
                            AreaCode = Convert.ToString(reader[1]), // id_unit_usaha column
                            DayName = Convert.ToString(reader[3]), // dayname column
                            day = Convert.ToInt16(reader[4]), // daynumber column
                            hour = Convert.ToInt16(reader[5]),
                            value = Convert.ToDouble(reader[7]) / 1.0, // averagetotalflow column
                            AverageTotalFlow = Convert.ToDouble(reader[7])


                        };
                        list2.Add(c);


                        double maxtf = list2.Max(r => r.AverageTotalFlow);
                        retval.MaxTotalFlow = maxtf;
            
                        // totalflowperarea column
                        retval.TotalFlow = Convert.ToDouble(reader[8]); // totalflowperarea column
                        retval.TotalFlowSBU = Convert.ToDouble(reader[9]); // totalflowperregion column
                        retval.TotalFlowAllArea = Convert.ToDouble(reader[10]); // totalflowall column
                        

                    }

                    retval.Items = list2;

                   

                }
                catch (Exception ex)
                {
                    Message = ex.Message;
                }
            }

            return retval;
        }


        
    }
}