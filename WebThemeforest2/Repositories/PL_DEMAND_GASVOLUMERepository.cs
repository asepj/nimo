using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using WebThemeforest2.Models;

namespace WebThemeforest2.Repositories
{
	public partial class PL_DEMAND_GASVOLUMERepository
	{
		private string connString;
		public string Message { get; set; }

		public PL_DEMAND_GASVOLUMERepository(string connectionString)
		{
			connString = connectionString;
		}

		public void Add(PL_DEMAND_GASVOLUME pl_demand_gasvolume)
		{
			using (var conn = new SqlConnection(connString))
			{
				try
				{
					Message = "";
					conn.Open();
					SqlCommand command = new SqlCommand("INSERT INTO PL_DEMAND_GASVOLUME ([DATE_ID], [FDATETIME], [IDREFPELANGGAN], [ID_UNIT_USAHA], [NAMA], [TOTAL_FDVC]) VALUES(@DATE_ID, @FDATETIME, @IDREFPELANGGAN, @ID_UNIT_USAHA, @NAMA, @TOTAL_FDVC)", conn);
					command.CommandType = System.Data.CommandType.Text;
					if (pl_demand_gasvolume.DATE_ID != null) { command.Parameters.AddWithValue("@DATE_ID", pl_demand_gasvolume.DATE_ID); } else { command.Parameters.AddWithValue("@DATE_ID", DBNull.Value); } 
					if (pl_demand_gasvolume.FDATETIME != null) { command.Parameters.AddWithValue("@FDATETIME", pl_demand_gasvolume.FDATETIME); } else { command.Parameters.AddWithValue("@FDATETIME", DBNull.Value); } 
					if (pl_demand_gasvolume.IDREFPELANGGAN != null) { command.Parameters.AddWithValue("@IDREFPELANGGAN", pl_demand_gasvolume.IDREFPELANGGAN); } else { command.Parameters.AddWithValue("@IDREFPELANGGAN", DBNull.Value); } 
					if (pl_demand_gasvolume.ID_UNIT_USAHA != null) { command.Parameters.AddWithValue("@ID_UNIT_USAHA", pl_demand_gasvolume.ID_UNIT_USAHA); } else { command.Parameters.AddWithValue("@ID_UNIT_USAHA", DBNull.Value); } 
					if (pl_demand_gasvolume.NAMA != null) { command.Parameters.AddWithValue("@NAMA", pl_demand_gasvolume.NAMA); } else { command.Parameters.AddWithValue("@NAMA", DBNull.Value); } 
					if (pl_demand_gasvolume.TOTAL_FDVC != null) { command.Parameters.AddWithValue("@TOTAL_FDVC", pl_demand_gasvolume.TOTAL_FDVC); } else { command.Parameters.AddWithValue("@TOTAL_FDVC", DBNull.Value); } 
					command.ExecuteNonQuery();
				}
				catch (Exception ex)
				{
					Message = ex.Message;
				}
			}
		}

		public void AddMany(List<PL_DEMAND_GASVOLUME> pl_demand_gasvolume)
		{
			using (var conn = new SqlConnection(connString))
			{
				try
				{
					Message = "";
					conn.Open();
					int pos = 0;
					foreach(PL_DEMAND_GASVOLUME item in pl_demand_gasvolume)
					{
						SqlCommand command = new SqlCommand("INSERT INTO PL_DEMAND_GASVOLUME ([DATE_ID], [FDATETIME], [IDREFPELANGGAN], [ID_UNIT_USAHA], [NAMA], [TOTAL_FDVC]) VALUES(@DATE_ID, @FDATETIME, @IDREFPELANGGAN, @ID_UNIT_USAHA, @NAMA, @TOTAL_FDVC)", conn);
						command.CommandType = System.Data.CommandType.Text;
						if (pl_demand_gasvolume[pos].DATE_ID != null) { command.Parameters.AddWithValue("@DATE_ID", pl_demand_gasvolume[pos].DATE_ID); } else { command.Parameters.AddWithValue("@DATE_ID", DBNull.Value); } 
						if (pl_demand_gasvolume[pos].FDATETIME != null) { command.Parameters.AddWithValue("@FDATETIME", pl_demand_gasvolume[pos].FDATETIME); } else { command.Parameters.AddWithValue("@FDATETIME", DBNull.Value); } 
						if (pl_demand_gasvolume[pos].IDREFPELANGGAN != null) { command.Parameters.AddWithValue("@IDREFPELANGGAN", pl_demand_gasvolume[pos].IDREFPELANGGAN); } else { command.Parameters.AddWithValue("@IDREFPELANGGAN", DBNull.Value); } 
						if (pl_demand_gasvolume[pos].ID_UNIT_USAHA != null) { command.Parameters.AddWithValue("@ID_UNIT_USAHA", pl_demand_gasvolume[pos].ID_UNIT_USAHA); } else { command.Parameters.AddWithValue("@ID_UNIT_USAHA", DBNull.Value); } 
						if (pl_demand_gasvolume[pos].NAMA != null) { command.Parameters.AddWithValue("@NAMA", pl_demand_gasvolume[pos].NAMA); } else { command.Parameters.AddWithValue("@NAMA", DBNull.Value); } 
						if (pl_demand_gasvolume[pos].TOTAL_FDVC != null) { command.Parameters.AddWithValue("@TOTAL_FDVC", pl_demand_gasvolume[pos].TOTAL_FDVC); } else { command.Parameters.AddWithValue("@TOTAL_FDVC", DBNull.Value); } 
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

		public void Update(PL_DEMAND_GASVOLUME pl_demand_gasvolume)
		{
			using (var conn = new SqlConnection(connString))
			{
				try
				{
					Message = "";
					conn.Open();
					SqlCommand command = new SqlCommand("UPDATE PL_DEMAND_GASVOLUME SET FDATETIME = @FDATETIME, IDREFPELANGGAN = @IDREFPELANGGAN, ID_UNIT_USAHA = @ID_UNIT_USAHA, NAMA = @NAMA, TOTAL_FDVC = @TOTAL_FDVC WHERE DATE_ID = @DATE_ID", conn);
					command.CommandType = System.Data.CommandType.Text;
					if (pl_demand_gasvolume.DATE_ID != null) { command.Parameters.AddWithValue("@DATE_ID", pl_demand_gasvolume.DATE_ID); } else { command.Parameters.AddWithValue("@DATE_ID", DBNull.Value); } 
					if (pl_demand_gasvolume.FDATETIME != null) { command.Parameters.AddWithValue("@FDATETIME", pl_demand_gasvolume.FDATETIME); } else { command.Parameters.AddWithValue("@FDATETIME", DBNull.Value); } 
					if (pl_demand_gasvolume.IDREFPELANGGAN != null) { command.Parameters.AddWithValue("@IDREFPELANGGAN", pl_demand_gasvolume.IDREFPELANGGAN); } else { command.Parameters.AddWithValue("@IDREFPELANGGAN", DBNull.Value); } 
					if (pl_demand_gasvolume.ID_UNIT_USAHA != null) { command.Parameters.AddWithValue("@ID_UNIT_USAHA", pl_demand_gasvolume.ID_UNIT_USAHA); } else { command.Parameters.AddWithValue("@ID_UNIT_USAHA", DBNull.Value); } 
					if (pl_demand_gasvolume.NAMA != null) { command.Parameters.AddWithValue("@NAMA", pl_demand_gasvolume.NAMA); } else { command.Parameters.AddWithValue("@NAMA", DBNull.Value); } 
					if (pl_demand_gasvolume.TOTAL_FDVC != null) { command.Parameters.AddWithValue("@TOTAL_FDVC", pl_demand_gasvolume.TOTAL_FDVC); } else { command.Parameters.AddWithValue("@TOTAL_FDVC", DBNull.Value); } 
					command.ExecuteNonQuery();
				}
				catch (Exception ex)
				{
					Message = ex.Message;
				}
			}
		}

		public void UpdateMany(List<PL_DEMAND_GASVOLUME> pl_demand_gasvolumes)
		{
			using (var conn = new SqlConnection(connString))
			{
				try
				{
					Message = "";
					conn.Open();
					foreach(PL_DEMAND_GASVOLUME item in pl_demand_gasvolumes)
					{
						SqlCommand command = new SqlCommand("UPDATE PL_DEMAND_GASVOLUME SET FDATETIME = @FDATETIME, IDREFPELANGGAN = @IDREFPELANGGAN, ID_UNIT_USAHA = @ID_UNIT_USAHA, NAMA = @NAMA, TOTAL_FDVC = @TOTAL_FDVC WHERE DATE_ID = @DATE_ID", conn);
						command.CommandType = System.Data.CommandType.Text;
						if (item.DATE_ID != null) { command.Parameters.AddWithValue("@DATE_ID", item.DATE_ID); } else { command.Parameters.AddWithValue("@DATE_ID", DBNull.Value); } 
						if (item.FDATETIME != null) { command.Parameters.AddWithValue("@FDATETIME", item.FDATETIME); } else { command.Parameters.AddWithValue("@FDATETIME", DBNull.Value); } 
						if (item.IDREFPELANGGAN != null) { command.Parameters.AddWithValue("@IDREFPELANGGAN", item.IDREFPELANGGAN); } else { command.Parameters.AddWithValue("@IDREFPELANGGAN", DBNull.Value); } 
						if (item.ID_UNIT_USAHA != null) { command.Parameters.AddWithValue("@ID_UNIT_USAHA", item.ID_UNIT_USAHA); } else { command.Parameters.AddWithValue("@ID_UNIT_USAHA", DBNull.Value); } 
						if (item.NAMA != null) { command.Parameters.AddWithValue("@NAMA", item.NAMA); } else { command.Parameters.AddWithValue("@NAMA", DBNull.Value); } 
						if (item.TOTAL_FDVC != null) { command.Parameters.AddWithValue("@TOTAL_FDVC", item.TOTAL_FDVC); } else { command.Parameters.AddWithValue("@TOTAL_FDVC", DBNull.Value); } 
						command.ExecuteNonQuery();
					}
				}
				catch (Exception ex)
				{
					Message = ex.Message;
				}
			}
		}

		public void Remove(PL_DEMAND_GASVOLUME id)
		{
			using (var conn = new SqlConnection(connString))
			{
				try
				{
					Message = "";
					conn.Open();
					SqlCommand command = new SqlCommand("DELETE PL_DEMAND_GASVOLUME WHERE DATE_ID = @DATE_ID", conn);
					command.CommandType = System.Data.CommandType.Text;
					if (id.DATE_ID != null) { command.Parameters.AddWithValue("@DATE_ID", id.DATE_ID); } else { command.Parameters.AddWithValue("@DATE_ID", DBNull.Value); } 
					command.ExecuteNonQuery();
				}
				catch (Exception ex)
				{
					Message = ex.Message;
				}
			}
		}

		public List<PL_DEMAND_GASVOLUME> GetData()
		{
			List<PL_DEMAND_GASVOLUME> items = new List<PL_DEMAND_GASVOLUME>();
			using (var conn = new SqlConnection(connString))
			{
				Message = "";
				try
				{
					conn.Open();
					SqlCommand command = new SqlCommand("SELECT [DATE_ID], [FDATETIME], [IDREFPELANGGAN], [ID_UNIT_USAHA], [NAMA], [TOTAL_FDVC] FROM PL_DEMAND_GASVOLUME", conn);
					SqlDataReader reader = command.ExecuteReader();
					PL_DEMAND_GASVOLUME item = new PL_DEMAND_GASVOLUME();
					while(reader.Read())
					{
						item = new PL_DEMAND_GASVOLUME();
						if (reader[0] != DBNull.Value) { item.DATE_ID = Convert.ToInt32(reader[0]); }
						if (reader[1] != DBNull.Value) { item.FDATETIME = Convert.ToDateTime(reader[1].ToString());}
						if (reader[2] != DBNull.Value) { item.IDREFPELANGGAN = Convert.ToString(reader[2]); }
						if (reader[3] != DBNull.Value) { item.ID_UNIT_USAHA = Convert.ToString(reader[3]); }
						if (reader[4] != DBNull.Value) { item.NAMA = Convert.ToString(reader[4]); }
						if (reader[5] != DBNull.Value) { item.TOTAL_FDVC = Convert.ToDouble(reader[5]);}
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

		public List<PL_DEMAND_GASVOLUME> GetDataByDATE_ID(int DATE_ID)
		{
			List<PL_DEMAND_GASVOLUME> items = new List<PL_DEMAND_GASVOLUME>();
			using (var conn = new SqlConnection(connString))
			{
				Message = "";
				try
				{
					conn.Open();
					SqlCommand command = new SqlCommand("SELECT [DATE_ID], [FDATETIME], [IDREFPELANGGAN], [ID_UNIT_USAHA], [NAMA], [TOTAL_FDVC] FROM PL_DEMAND_GASVOLUME WHERE DATE_ID = @DATE_ID", conn);
					command.Parameters.AddWithValue("@DATE_ID", DATE_ID);
					SqlDataReader reader = command.ExecuteReader();
					PL_DEMAND_GASVOLUME item = new PL_DEMAND_GASVOLUME();
					while(reader.Read())
					{
						item = new PL_DEMAND_GASVOLUME();
						if (reader[0] != DBNull.Value) { item.DATE_ID = Convert.ToInt32(reader[0]); }
                        if (reader[1] != DBNull.Value) { item.FDATETIME = Convert.ToDateTime(reader[1]); }
						if (reader[2] != DBNull.Value) { item.IDREFPELANGGAN = Convert.ToString(reader[2]); }
						if (reader[3] != DBNull.Value) { item.ID_UNIT_USAHA = Convert.ToString(reader[3]); }
						if (reader[4] != DBNull.Value) { item.NAMA = Convert.ToString(reader[4]); }
						if (reader[5] != DBNull.Value) { item.TOTAL_FDVC = Convert.ToDouble(reader[5]);}
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

		public void RemoveByDATE_ID(int id)
		{
			using (var conn = new SqlConnection(connString))
			{
				try
				{
					Message = "";
					conn.Open();
					SqlCommand command = new SqlCommand("DELETE PL_DEMAND_GASVOLUME WHERE DATE_ID = @DATE_ID", conn);
					command.CommandType = System.Data.CommandType.Text;
					if (id != null) { command.Parameters.AddWithValue("@DATE_ID", id); } else { command.Parameters.AddWithValue("@DATE_ID", DBNull.Value); } 
					command.ExecuteNonQuery();
				}
				catch (Exception ex)
				{
					Message = ex.Message;
				}
			}
		}

		public DataTable GetDataTable(List<PL_DEMAND_GASVOLUME> pl_demand_gasvolume)
		{
			DataTable dt = new DataTable("PL_DEMAND_GASVOLUME");

			DataColumn c1 = new DataColumn("DATE_ID", typeof(int)); 
			dt.Columns.Add(c1);
			DataColumn c2 = new DataColumn("FDATETIME", typeof(DateTime)); c2.AllowDBNull = true;
			dt.Columns.Add(c2);
			DataColumn c3 = new DataColumn("IDREFPELANGGAN", typeof(string)); c3.AllowDBNull = true;
			dt.Columns.Add(c3);
			DataColumn c4 = new DataColumn("ID_UNIT_USAHA", typeof(string)); c4.AllowDBNull = true;
			dt.Columns.Add(c4);
			DataColumn c5 = new DataColumn("NAMA", typeof(string)); c5.AllowDBNull = true;
			dt.Columns.Add(c5);
			DataColumn c6 = new DataColumn("TOTAL_FDVC", typeof(double)); c6.AllowDBNull = true;
			dt.Columns.Add(c6);

			foreach (PL_DEMAND_GASVOLUME v in pl_demand_gasvolume)
			{
				DataRow dr = dt.NewRow();
				if (v.DATE_ID != null) { dr[0] = v.DATE_ID; } else { dr[0] = DBNull.Value; }
				if (v.FDATETIME != null) { dr[1] = v.FDATETIME; } else { dr[1] = DBNull.Value; }
				if (v.IDREFPELANGGAN != null) { dr[2] = v.IDREFPELANGGAN; } else { dr[2] = DBNull.Value; }
				if (v.ID_UNIT_USAHA != null) { dr[3] = v.ID_UNIT_USAHA; } else { dr[3] = DBNull.Value; }
				if (v.NAMA != null) { dr[4] = v.NAMA; } else { dr[4] = DBNull.Value; }
				if (v.TOTAL_FDVC != null) { dr[5] = v.TOTAL_FDVC; } else { dr[5] = DBNull.Value; }
				dt.Rows.Add(dr);
			}
			dt.AcceptChanges();

			return dt;
		}

		public void AddManyBulk(List<PL_DEMAND_GASVOLUME> pl_demand_gasvolume)
		{
			using (var conn = new SqlConnection(connString))
			{
				try
				{
					Message = "";
					conn.Open();

					DataTable dt = GetDataTable(pl_demand_gasvolume);
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