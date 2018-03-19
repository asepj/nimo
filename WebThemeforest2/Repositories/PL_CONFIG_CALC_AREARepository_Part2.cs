using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using WebThemeforest2.Models;

namespace WebThemeforest2.Repositories
{
	public partial class PL_CONFIG_CALC_AREARepository
	{


        public List<PL_CONFIG_CALC_AREA> GetData_Alternative()
        {
            List<PL_CONFIG_CALC_AREA> items = new List<PL_CONFIG_CALC_AREA>();
            using (var conn = new SqlConnection(connString))
            {
                Message = "";
                try
                {
                    conn.Open();
                    SqlCommand command = new SqlCommand("SELECT DISTINCT  [CATEGORY] FROM PL_CONFIG_CALC_AREA", conn);
                    SqlDataReader reader = command.ExecuteReader();
                    PL_CONFIG_CALC_AREA item = new PL_CONFIG_CALC_AREA();
                    while (reader.Read())
                    {
                        item = new PL_CONFIG_CALC_AREA();
                        if (reader[0] != DBNull.Value) { item.CATEGORY = Convert.ToString(reader[0]); }
                        //if (reader[1] != DBNull.Value) { item.AREA = Convert.ToString(reader[1]); }
                        //if (reader[2] != DBNull.Value) { item.REGIME = Convert.ToString(reader[2]); }
                        //if (reader[3] != DBNull.Value) { item.FILE_NAME = Convert.ToString(reader[3]); }
                        //if (reader[4] != DBNull.Value) { item.ENABLED = Convert.ToInt32(reader[4]); }
                        items.Add(item);
                    }
                }
                catch (Exception ex)
                {
                    Message = ex.Message;
                }
            }
            return items;
        }


	}
}