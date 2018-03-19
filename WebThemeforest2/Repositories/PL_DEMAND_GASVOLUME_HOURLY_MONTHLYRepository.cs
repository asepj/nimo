using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using WebThemeforest2.Models;

namespace WebThemeforest2.Repositories
{
	public partial class PL_DEMAND_GASVOLUME_HOURLY_MONTHLYRepository
	{
		private string connString;
		public string Message { get; set; }

		public PL_DEMAND_GASVOLUME_HOURLY_MONTHLYRepository(string connectionString)
		{
			connString = connectionString;
		}

		public void Add(PL_DEMAND_GASVOLUME_HOURLY_MONTHLY pl_demand_gasvolume_hourly_monthly)
		{
			using (var conn = new SqlConnection(connString))
			{
				try
				{
					Message = "";
					conn.Open();
					SqlCommand command = new SqlCommand("INSERT INTO PL_DEMAND_GASVOLUME_HOURLY_MONTHLY ([ID_UNIT_USAHA], [IDREFPELANGGAN], [NAMA], [FHOUR], [FMONTH], [FYEAR], [TOTAL_FDVC], [AVERAGE_FDVC], [AVERAGE_FDVC_24]) VALUES(@ID_UNIT_USAHA, @IDREFPELANGGAN, @NAMA, @FHOUR, @FMONTH, @FYEAR, @TOTAL_FDVC, @AVERAGE_FDVC, @AVERAGE_FDVC_24)", conn);
					command.CommandType = System.Data.CommandType.Text;
					if (pl_demand_gasvolume_hourly_monthly.ID_UNIT_USAHA != null) { command.Parameters.AddWithValue("@ID_UNIT_USAHA", pl_demand_gasvolume_hourly_monthly.ID_UNIT_USAHA); } else { command.Parameters.AddWithValue("@ID_UNIT_USAHA", DBNull.Value); } 
					if (pl_demand_gasvolume_hourly_monthly.IDREFPELANGGAN != null) { command.Parameters.AddWithValue("@IDREFPELANGGAN", pl_demand_gasvolume_hourly_monthly.IDREFPELANGGAN); } else { command.Parameters.AddWithValue("@IDREFPELANGGAN", DBNull.Value); } 
					if (pl_demand_gasvolume_hourly_monthly.NAMA != null) { command.Parameters.AddWithValue("@NAMA", pl_demand_gasvolume_hourly_monthly.NAMA); } else { command.Parameters.AddWithValue("@NAMA", DBNull.Value); } 
					if (pl_demand_gasvolume_hourly_monthly.FHOUR != null) { command.Parameters.AddWithValue("@FHOUR", pl_demand_gasvolume_hourly_monthly.FHOUR); } else { command.Parameters.AddWithValue("@FHOUR", DBNull.Value); } 
                    //if (pl_demand_gasvolume_hourly_monthly.FMONTH != null) { command.Parameters.AddWithValue("@FMONTH", pl_demand_gasvolume_hourly_monthly.FMONTH); } else { command.Parameters.AddWithValue("@FMONTH", DBNull.Value); } 
                    //if (pl_demand_gasvolume_hourly_monthly.FYEAR != null) { command.Parameters.AddWithValue("@FYEAR", pl_demand_gasvolume_hourly_monthly.FYEAR); } else { command.Parameters.AddWithValue("@FYEAR", DBNull.Value); } 
					if (pl_demand_gasvolume_hourly_monthly.TOTAL_FDVC != null) { command.Parameters.AddWithValue("@TOTAL_FDVC", pl_demand_gasvolume_hourly_monthly.TOTAL_FDVC); } else { command.Parameters.AddWithValue("@TOTAL_FDVC", DBNull.Value); } 
					if (pl_demand_gasvolume_hourly_monthly.AVERAGE_FDVC != null) { command.Parameters.AddWithValue("@AVERAGE_FDVC", pl_demand_gasvolume_hourly_monthly.AVERAGE_FDVC); } else { command.Parameters.AddWithValue("@AVERAGE_FDVC", DBNull.Value); } 
					if (pl_demand_gasvolume_hourly_monthly.AVERAGE_FDVC_24 != null) { command.Parameters.AddWithValue("@AVERAGE_FDVC_24", pl_demand_gasvolume_hourly_monthly.AVERAGE_FDVC_24); } else { command.Parameters.AddWithValue("@AVERAGE_FDVC_24", DBNull.Value); } 
					command.ExecuteNonQuery();
				}
				catch (Exception ex)
				{
					Message = ex.Message;
				}
			}
		}

		public void AddMany(List<PL_DEMAND_GASVOLUME_HOURLY_MONTHLY> pl_demand_gasvolume_hourly_monthly)
		{
			using (var conn = new SqlConnection(connString))
			{
				try
				{
					Message = "";
					conn.Open();
					int pos = 0;
					foreach(PL_DEMAND_GASVOLUME_HOURLY_MONTHLY item in pl_demand_gasvolume_hourly_monthly)
					{
						SqlCommand command = new SqlCommand("INSERT INTO PL_DEMAND_GASVOLUME_HOURLY_MONTHLY ([ID_UNIT_USAHA], [IDREFPELANGGAN], [NAMA], [FHOUR], [FMONTH], [FYEAR], [TOTAL_FDVC], [AVERAGE_FDVC], [AVERAGE_FDVC_24]) VALUES(@ID_UNIT_USAHA, @IDREFPELANGGAN, @NAMA, @FHOUR, @FMONTH, @FYEAR, @TOTAL_FDVC, @AVERAGE_FDVC, @AVERAGE_FDVC_24)", conn);
						command.CommandType = System.Data.CommandType.Text;
						if (pl_demand_gasvolume_hourly_monthly[pos].ID_UNIT_USAHA != null) { command.Parameters.AddWithValue("@ID_UNIT_USAHA", pl_demand_gasvolume_hourly_monthly[pos].ID_UNIT_USAHA); } else { command.Parameters.AddWithValue("@ID_UNIT_USAHA", DBNull.Value); } 
						if (pl_demand_gasvolume_hourly_monthly[pos].IDREFPELANGGAN != null) { command.Parameters.AddWithValue("@IDREFPELANGGAN", pl_demand_gasvolume_hourly_monthly[pos].IDREFPELANGGAN); } else { command.Parameters.AddWithValue("@IDREFPELANGGAN", DBNull.Value); } 
						if (pl_demand_gasvolume_hourly_monthly[pos].NAMA != null) { command.Parameters.AddWithValue("@NAMA", pl_demand_gasvolume_hourly_monthly[pos].NAMA); } else { command.Parameters.AddWithValue("@NAMA", DBNull.Value); } 
						if (pl_demand_gasvolume_hourly_monthly[pos].FHOUR != null) { command.Parameters.AddWithValue("@FHOUR", pl_demand_gasvolume_hourly_monthly[pos].FHOUR); } else { command.Parameters.AddWithValue("@FHOUR", DBNull.Value); } 
                        //if (pl_demand_gasvolume_hourly_monthly[pos].FMONTH != null) { command.Parameters.AddWithValue("@FMONTH", pl_demand_gasvolume_hourly_monthly[pos].FMONTH); } else { command.Parameters.AddWithValue("@FMONTH", DBNull.Value); } 
                        //if (pl_demand_gasvolume_hourly_monthly[pos].FYEAR != null) { command.Parameters.AddWithValue("@FYEAR", pl_demand_gasvolume_hourly_monthly[pos].FYEAR); } else { command.Parameters.AddWithValue("@FYEAR", DBNull.Value); } 
						if (pl_demand_gasvolume_hourly_monthly[pos].TOTAL_FDVC != null) { command.Parameters.AddWithValue("@TOTAL_FDVC", pl_demand_gasvolume_hourly_monthly[pos].TOTAL_FDVC); } else { command.Parameters.AddWithValue("@TOTAL_FDVC", DBNull.Value); } 
						if (pl_demand_gasvolume_hourly_monthly[pos].AVERAGE_FDVC != null) { command.Parameters.AddWithValue("@AVERAGE_FDVC", pl_demand_gasvolume_hourly_monthly[pos].AVERAGE_FDVC); } else { command.Parameters.AddWithValue("@AVERAGE_FDVC", DBNull.Value); } 
						if (pl_demand_gasvolume_hourly_monthly[pos].AVERAGE_FDVC_24 != null) { command.Parameters.AddWithValue("@AVERAGE_FDVC_24", pl_demand_gasvolume_hourly_monthly[pos].AVERAGE_FDVC_24); } else { command.Parameters.AddWithValue("@AVERAGE_FDVC_24", DBNull.Value); } 
						command.ExecuteNonQuery();
						pos = pos + 1;
					}
				}
				catch (Exception ex)
				{
					Message = ex.Message;
				}
			}
		}

		public void Update(PL_DEMAND_GASVOLUME_HOURLY_MONTHLY pl_demand_gasvolume_hourly_monthly)
		{
			using (var conn = new SqlConnection(connString))
			{
				try
				{
					Message = "";
					conn.Open();
					SqlCommand command = new SqlCommand("UPDATE PL_DEMAND_GASVOLUME_HOURLY_MONTHLY SET  WHERE ", conn);
					command.CommandType = System.Data.CommandType.Text;
					command.ExecuteNonQuery();
				}
				catch (Exception ex)
				{
					Message = ex.Message;
				}
			}
		}

		public void UpdateMany(List<PL_DEMAND_GASVOLUME_HOURLY_MONTHLY> pl_demand_gasvolume_hourly_monthlys)
		{
			using (var conn = new SqlConnection(connString))
			{
				try
				{
					Message = "";
					conn.Open();
					foreach(PL_DEMAND_GASVOLUME_HOURLY_MONTHLY item in pl_demand_gasvolume_hourly_monthlys)
					{
						SqlCommand command = new SqlCommand("UPDATE PL_DEMAND_GASVOLUME_HOURLY_MONTHLY SET  WHERE ", conn);
						command.CommandType = System.Data.CommandType.Text;
						command.ExecuteNonQuery();
					}
				}
				catch (Exception ex)
				{
					Message = ex.Message;
				}
			}
		}

		public void Remove(PL_DEMAND_GASVOLUME_HOURLY_MONTHLY id)
		{
			using (var conn = new SqlConnection(connString))
			{
				try
				{
					Message = "";
					conn.Open();
					SqlCommand command = new SqlCommand("DELETE PL_DEMAND_GASVOLUME_HOURLY_MONTHLY WHERE ", conn);
					command.CommandType = System.Data.CommandType.Text;
					command.ExecuteNonQuery();
				}
				catch (Exception ex)
				{
					Message = ex.Message;
				}
			}
		}

		public List<PL_DEMAND_GASVOLUME_HOURLY_MONTHLY> GetData()
		{
			List<PL_DEMAND_GASVOLUME_HOURLY_MONTHLY> items = new List<PL_DEMAND_GASVOLUME_HOURLY_MONTHLY>();
			using (var conn = new SqlConnection(connString))
			{
				Message = "";
				try
				{
					conn.Open();
					SqlCommand command = new SqlCommand("SELECT [ID_UNIT_USAHA], [IDREFPELANGGAN], [NAMA], [FHOUR], [FMONTH], [FYEAR], [TOTAL_FDVC], [AVERAGE_FDVC], [AVERAGE_FDVC_24] FROM PL_DEMAND_GASVOLUME_HOURLY_MONTHLY", conn);
					SqlDataReader reader = command.ExecuteReader();
					PL_DEMAND_GASVOLUME_HOURLY_MONTHLY item = new PL_DEMAND_GASVOLUME_HOURLY_MONTHLY();
					while(reader.Read())
					{
						item = new PL_DEMAND_GASVOLUME_HOURLY_MONTHLY();
						if (reader[0] != DBNull.Value) { item.ID_UNIT_USAHA = Convert.ToString(reader[0]); }
						if (reader[1] != DBNull.Value) { item.IDREFPELANGGAN = Convert.ToString(reader[1]); }
						if (reader[2] != DBNull.Value) { item.NAMA = Convert.ToString(reader[2]); }
						if (reader[3] != DBNull.Value) { item.FHOUR = Convert.ToInt32(reader[3]); }
                        //if (reader[4] != DBNull.Value) { item.FMONTH = Convert.ToInt32(reader[4]); }
                        //if (reader[5] != DBNull.Value) { item.FYEAR = Convert.ToInt32(reader[5]); }
						if (reader[6] != DBNull.Value) { item.TOTAL_FDVC = Convert.ToDouble(reader[6]);}
						if (reader[7] != DBNull.Value) { item.AVERAGE_FDVC = Convert.ToDouble(reader[7]);}
                        if (reader[8] != DBNull.Value) { item.AVERAGE_FDVC_24 = Convert.ToDouble(reader[8]); }
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

        public List<PL_DEMAND_GASVOLUME_HOURLY_MONTHLY> Getbyhour(PL_DEMAND_GASVOLUME_HOURLY_MONTHLY pldp)
        {
            List<PL_DEMAND_GASVOLUME_HOURLY_MONTHLY> items = new List<PL_DEMAND_GASVOLUME_HOURLY_MONTHLY>();
            using (var conn = new SqlConnection(connString))
            {
                Message = "";
                try
                {
                    conn.Open();
                    string query = "SELECT *, ([dbo].[fn_GetMaxContractDaily](idref)/24) as kontrak_perjam, 100*total_fdvc/([dbo].[fn_GetMaxContractDaily](idref)/24) persen_utilisasi" +
        " FROM [dbo].[fn_get_totalflow_demand_perdayname]('"+pldp.start_date+"','"+pldp.end_date+"','" + pldp.ID_UNIT_USAHA + "'," + pldp.daynumber + "," + pldp.FHOUR + ")" + "ORDER BY id_unit_usaha, idref, fhour";
                    SqlCommand command = new SqlCommand(query, conn);
                    SqlDataReader reader = command.ExecuteReader();
                    PL_DEMAND_GASVOLUME_HOURLY_MONTHLY item = new PL_DEMAND_GASVOLUME_HOURLY_MONTHLY();
                    while (reader.Read())
                    {
                        item = new PL_DEMAND_GASVOLUME_HOURLY_MONTHLY();
                        if (reader[0] != DBNull.Value) { item.ID_UNIT_USAHA = Convert.ToString(reader[0]); }
                        if (reader[1] != DBNull.Value) { item.IDREFPELANGGAN = Convert.ToString(reader[1]); }
                        if (reader[2] != DBNull.Value) { item.NAMA = Convert.ToString(reader[2]); }
                        if (reader[3] != DBNull.Value) { item.daynumber = Convert.ToInt32(reader[3]); }
                        if (reader[4] != DBNull.Value) { item.dayofWeekName = Convert.ToString(reader[4]); }
                        if (reader[5] != DBNull.Value) { item.FHOUR = Convert.ToInt32(reader[5]); }
                        if (reader[6] != DBNull.Value) { item.TOTAL_FDVC = Convert.ToDouble(reader[6]); }
                        if (reader[7] != DBNull.Value) { item.AVERAGE_FDVC = Convert.ToDouble(reader[7]); }
                        if (reader[8] != DBNull.Value) { item.AVERAGE_FDVC_24 = Convert.ToDouble(reader[8]); }
                        if (reader[9] != DBNull.Value) { item.kontrak_perjam = Convert.ToDouble(reader[9]); }
                        if (reader[10] != DBNull.Value) { item.persen_utilisasi = Convert.ToDouble(reader[10]); }
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

		public DataTable GetDataTable(List<PL_DEMAND_GASVOLUME_HOURLY_MONTHLY> pl_demand_gasvolume_hourly_monthly)
		{
			DataTable dt = new DataTable("PL_DEMAND_GASVOLUME_HOURLY_MONTHLY");

			DataColumn c1 = new DataColumn("ID_UNIT_USAHA", typeof(string)); 
			dt.Columns.Add(c1);
			DataColumn c2 = new DataColumn("IDREFPELANGGAN", typeof(string)); 
			dt.Columns.Add(c2);
			DataColumn c3 = new DataColumn("NAMA", typeof(string)); 
			dt.Columns.Add(c3);
			DataColumn c4 = new DataColumn("FHOUR", typeof(int)); 
			dt.Columns.Add(c4);
			DataColumn c5 = new DataColumn("FMONTH", typeof(int)); 
			dt.Columns.Add(c5);
			DataColumn c6 = new DataColumn("FYEAR", typeof(int)); 
			dt.Columns.Add(c6);
			DataColumn c7 = new DataColumn("TOTAL_FDVC", typeof(double)); 
			dt.Columns.Add(c7);
			DataColumn c8 = new DataColumn("AVERAGE_FDVC", typeof(double)); 
			dt.Columns.Add(c8);
			DataColumn c9 = new DataColumn("AVERAGE_FDVC_24", typeof(double)); 
			dt.Columns.Add(c9);

			foreach (PL_DEMAND_GASVOLUME_HOURLY_MONTHLY v in pl_demand_gasvolume_hourly_monthly)
			{
				DataRow dr = dt.NewRow();
				if (v.ID_UNIT_USAHA != null) { dr[0] = v.ID_UNIT_USAHA; } else { dr[0] = DBNull.Value; }
				if (v.IDREFPELANGGAN != null) { dr[1] = v.IDREFPELANGGAN; } else { dr[1] = DBNull.Value; }
				if (v.NAMA != null) { dr[2] = v.NAMA; } else { dr[2] = DBNull.Value; }
				if (v.FHOUR != null) { dr[3] = v.FHOUR; } else { dr[3] = DBNull.Value; }
                //if (v.FMONTH != null) { dr[4] = v.FMONTH; } else { dr[4] = DBNull.Value; }
                //if (v.FYEAR != null) { dr[5] = v.FYEAR; } else { dr[5] = DBNull.Value; }
				if (v.TOTAL_FDVC != null) { dr[6] = v.TOTAL_FDVC; } else { dr[6] = DBNull.Value; }
				if (v.AVERAGE_FDVC != null) { dr[7] = v.AVERAGE_FDVC; } else { dr[7] = DBNull.Value; }
				if (v.AVERAGE_FDVC_24 != null) { dr[8] = v.AVERAGE_FDVC_24; } else { dr[8] = DBNull.Value; }
				dt.Rows.Add(dr);
			}
			dt.AcceptChanges();

			return dt;
		}

		public void AddManyBulk(List<PL_DEMAND_GASVOLUME_HOURLY_MONTHLY> pl_demand_gasvolume_hourly_monthly)
		{
			using (var conn = new SqlConnection(connString))
			{
				try
				{
					Message = "";
					conn.Open();

					DataTable dt = GetDataTable(pl_demand_gasvolume_hourly_monthly);
					using (SqlBulkCopy bulkCopy = new SqlBulkCopy(connString))
					{
						bulkCopy.DestinationTableName = dt.TableName;
						bulkCopy.WriteToServer(dt);
					}
				}
				catch (Exception ex)
				{
					Message = ex.Message;
				}
			}
		}

	}
}