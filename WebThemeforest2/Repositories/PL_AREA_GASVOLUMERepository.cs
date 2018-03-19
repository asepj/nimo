using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using WebThemeforest2.Models;

namespace WebThemeforest2.Repositories
{
	public partial class PL_AREA_GASVOLUMERepository
	{
		private string connString;
		public string Message { get; set; }

		public PL_AREA_GASVOLUMERepository(string connectionString)
		{
			connString = connectionString;
		}

		public void Add(PL_AREA_GASVOLUME pl_area_gasvolume)
		{
			using (var conn = new SqlConnection(connString))
			{
				try
				{
					Message = "";
					conn.Open();
					SqlCommand command = new SqlCommand("INSERT INTO PL_AREA_GASVOLUME ([DATETIME_ID], [FDATETIME], [AREA_ID], [TOTAL_FDVC]) VALUES(@DATETIME_ID, @FDATETIME, @AREA_ID, @TOTAL_FDVC)", conn);
					command.CommandType = System.Data.CommandType.Text;
					if (pl_area_gasvolume.DATETIME_ID != null) { command.Parameters.AddWithValue("@DATETIME_ID", pl_area_gasvolume.DATETIME_ID); } else { command.Parameters.AddWithValue("@DATETIME_ID", DBNull.Value); } 
					if (pl_area_gasvolume.FDATETIME != null) { command.Parameters.AddWithValue("@FDATETIME", pl_area_gasvolume.FDATETIME); } else { command.Parameters.AddWithValue("@FDATETIME", DBNull.Value); } 
					if (pl_area_gasvolume.AREA_ID != null) { command.Parameters.AddWithValue("@AREA_ID", pl_area_gasvolume.AREA_ID); } else { command.Parameters.AddWithValue("@AREA_ID", DBNull.Value); } 
					if (pl_area_gasvolume.TOTAL_FDVC != null) { command.Parameters.AddWithValue("@TOTAL_FDVC", pl_area_gasvolume.TOTAL_FDVC); } else { command.Parameters.AddWithValue("@TOTAL_FDVC", DBNull.Value); } 
					command.ExecuteNonQuery();
				}
				catch (Exception ex)
				{
					Message = ex.Message;
				}
			}
		}

		public void AddMany(List<PL_AREA_GASVOLUME> pl_area_gasvolume)
		{
			using (var conn = new SqlConnection(connString))
			{
				try
				{
					Message = "";
					conn.Open();
					int pos = 0;
					foreach(PL_AREA_GASVOLUME item in pl_area_gasvolume)
					{
						SqlCommand command = new SqlCommand("INSERT INTO PL_AREA_GASVOLUME ([DATETIME_ID], [FDATETIME], [AREA_ID], [TOTAL_FDVC]) VALUES(@DATETIME_ID, @FDATETIME, @AREA_ID, @TOTAL_FDVC)", conn);
						command.CommandType = System.Data.CommandType.Text;
						if (pl_area_gasvolume[pos].DATETIME_ID != null) { command.Parameters.AddWithValue("@DATETIME_ID", pl_area_gasvolume[pos].DATETIME_ID); } else { command.Parameters.AddWithValue("@DATETIME_ID", DBNull.Value); } 
						if (pl_area_gasvolume[pos].FDATETIME != null) { command.Parameters.AddWithValue("@FDATETIME", pl_area_gasvolume[pos].FDATETIME); } else { command.Parameters.AddWithValue("@FDATETIME", DBNull.Value); } 
						if (pl_area_gasvolume[pos].AREA_ID != null) { command.Parameters.AddWithValue("@AREA_ID", pl_area_gasvolume[pos].AREA_ID); } else { command.Parameters.AddWithValue("@AREA_ID", DBNull.Value); } 
						if (pl_area_gasvolume[pos].TOTAL_FDVC != null) { command.Parameters.AddWithValue("@TOTAL_FDVC", pl_area_gasvolume[pos].TOTAL_FDVC); } else { command.Parameters.AddWithValue("@TOTAL_FDVC", DBNull.Value); } 
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

		public void Update(PL_AREA_GASVOLUME pl_area_gasvolume)
		{
			using (var conn = new SqlConnection(connString))
			{
				try
				{
					Message = "";
					conn.Open();
					SqlCommand command = new SqlCommand("UPDATE PL_AREA_GASVOLUME SET FDATETIME = @FDATETIME, AREA_ID = @AREA_ID, TOTAL_FDVC = @TOTAL_FDVC WHERE DATETIME_ID = @DATETIME_ID", conn);
					command.CommandType = System.Data.CommandType.Text;
					if (pl_area_gasvolume.DATETIME_ID != null) { command.Parameters.AddWithValue("@DATETIME_ID", pl_area_gasvolume.DATETIME_ID); } else { command.Parameters.AddWithValue("@DATETIME_ID", DBNull.Value); } 
					if (pl_area_gasvolume.FDATETIME != null) { command.Parameters.AddWithValue("@FDATETIME", pl_area_gasvolume.FDATETIME); } else { command.Parameters.AddWithValue("@FDATETIME", DBNull.Value); } 
					if (pl_area_gasvolume.AREA_ID != null) { command.Parameters.AddWithValue("@AREA_ID", pl_area_gasvolume.AREA_ID); } else { command.Parameters.AddWithValue("@AREA_ID", DBNull.Value); } 
					if (pl_area_gasvolume.TOTAL_FDVC != null) { command.Parameters.AddWithValue("@TOTAL_FDVC", pl_area_gasvolume.TOTAL_FDVC); } else { command.Parameters.AddWithValue("@TOTAL_FDVC", DBNull.Value); } 
					command.ExecuteNonQuery();
				}
				catch (Exception ex)
				{
					Message = ex.Message;
				}
			}
		}

		public void UpdateMany(List<PL_AREA_GASVOLUME> pl_area_gasvolumes)
		{
			using (var conn = new SqlConnection(connString))
			{
				try
				{
					Message = "";
					conn.Open();
					foreach(PL_AREA_GASVOLUME item in pl_area_gasvolumes)
					{
						SqlCommand command = new SqlCommand("UPDATE PL_AREA_GASVOLUME SET FDATETIME = @FDATETIME, AREA_ID = @AREA_ID, TOTAL_FDVC = @TOTAL_FDVC WHERE DATETIME_ID = @DATETIME_ID", conn);
						command.CommandType = System.Data.CommandType.Text;
						if (item.DATETIME_ID != null) { command.Parameters.AddWithValue("@DATETIME_ID", item.DATETIME_ID); } else { command.Parameters.AddWithValue("@DATETIME_ID", DBNull.Value); } 
						if (item.FDATETIME != null) { command.Parameters.AddWithValue("@FDATETIME", item.FDATETIME); } else { command.Parameters.AddWithValue("@FDATETIME", DBNull.Value); } 
						if (item.AREA_ID != null) { command.Parameters.AddWithValue("@AREA_ID", item.AREA_ID); } else { command.Parameters.AddWithValue("@AREA_ID", DBNull.Value); } 
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

		public void Remove(PL_AREA_GASVOLUME id)
		{
			using (var conn = new SqlConnection(connString))
			{
				try
				{
					Message = "";
					conn.Open();
					SqlCommand command = new SqlCommand("DELETE PL_AREA_GASVOLUME WHERE DATETIME_ID = @DATETIME_ID", conn);
					command.CommandType = System.Data.CommandType.Text;
					if (id.DATETIME_ID != null) { command.Parameters.AddWithValue("@DATETIME_ID", id.DATETIME_ID); } else { command.Parameters.AddWithValue("@DATETIME_ID", DBNull.Value); } 
					command.ExecuteNonQuery();
				}
				catch (Exception ex)
				{
					Message = ex.Message;
				}
			}
		}

		public List<PL_AREA_GASVOLUME> GetData()
		{
			List<PL_AREA_GASVOLUME> items = new List<PL_AREA_GASVOLUME>();
			using (var conn = new SqlConnection(connString))
			{
				Message = "";
				try
				{
					conn.Open();
					SqlCommand command = new SqlCommand("SELECT [DATETIME_ID], [FDATETIME], [AREA_ID], [TOTAL_FDVC] FROM PL_AREA_GASVOLUME", conn);
					SqlDataReader reader = command.ExecuteReader();
					PL_AREA_GASVOLUME item = new PL_AREA_GASVOLUME();
					while(reader.Read())
					{
						item = new PL_AREA_GASVOLUME();
						if (reader[0] != DBNull.Value) { item.DATETIME_ID = Convert.ToInt32(reader[0]); }
						if (reader[1] != DBNull.Value) { item.FDATETIME = Convert.ToDateTime(reader[1]); }
						if (reader[2] != DBNull.Value) { item.AREA_ID = Convert.ToString(reader[2]); }
						if (reader[3] != DBNull.Value) { item.TOTAL_FDVC = Convert.ToDouble(reader[3]); }
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

		public List<PL_AREA_GASVOLUME> GetDataByDATETIME_ID(int DATETIME_ID)
		{
			List<PL_AREA_GASVOLUME> items = new List<PL_AREA_GASVOLUME>();
			using (var conn = new SqlConnection(connString))
			{
				Message = "";
				try
				{
					conn.Open();
					SqlCommand command = new SqlCommand("SELECT [DATETIME_ID], [FDATETIME], [AREA_ID], [TOTAL_FDVC] FROM PL_AREA_GASVOLUME WHERE DATETIME_ID = @DATETIME_ID", conn);
					command.Parameters.AddWithValue("@DATETIME_ID", DATETIME_ID);
					SqlDataReader reader = command.ExecuteReader();
					PL_AREA_GASVOLUME item = new PL_AREA_GASVOLUME();
					while(reader.Read())
					{
						item = new PL_AREA_GASVOLUME();
						if (reader[0] != DBNull.Value) { item.DATETIME_ID = Convert.ToInt32(reader[0]); }
						if (reader[1] != DBNull.Value) { item.FDATETIME = Convert.ToDateTime(reader[1]); }
						if (reader[2] != DBNull.Value) { item.AREA_ID = Convert.ToString(reader[2]); }
						if (reader[3] != DBNull.Value) { item.TOTAL_FDVC = Convert.ToDouble(reader[3]); }
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

		public void RemoveByDATETIME_ID(int id)
		{
			using (var conn = new SqlConnection(connString))
			{
				try
				{
					Message = "";
					conn.Open();
					SqlCommand command = new SqlCommand("DELETE PL_AREA_GASVOLUME WHERE DATETIME_ID = @DATETIME_ID", conn);
					command.CommandType = System.Data.CommandType.Text;
					if (id != null) { command.Parameters.AddWithValue("@DATETIME_ID", id); } else { command.Parameters.AddWithValue("@DATETIME_ID", DBNull.Value); } 
					command.ExecuteNonQuery();
				}
				catch (Exception ex)
				{
					Message = ex.Message;
				}
			}
		}

		public DataTable GetDataTable(List<PL_AREA_GASVOLUME> pl_area_gasvolume)
		{
			DataTable dt = new DataTable("PL_AREA_GASVOLUME");

			DataColumn c1 = new DataColumn("DATETIME_ID", typeof(int)); 
			dt.Columns.Add(c1);
			DataColumn c2 = new DataColumn("FDATETIME", typeof(DateTime)); c2.AllowDBNull = true;
			dt.Columns.Add(c2);
			DataColumn c3 = new DataColumn("AREA_ID", typeof(string)); c3.AllowDBNull = true;
			dt.Columns.Add(c3);
			DataColumn c4 = new DataColumn("TOTAL_FDVC", typeof(int)); c4.AllowDBNull = true;
			dt.Columns.Add(c4);

			foreach (PL_AREA_GASVOLUME v in pl_area_gasvolume)
			{
				DataRow dr = dt.NewRow();
				if (v.DATETIME_ID != null) { dr[0] = v.DATETIME_ID; } else { dr[0] = DBNull.Value; }
				if (v.FDATETIME != null) { dr[1] = v.FDATETIME; } else { dr[1] = DBNull.Value; }
				if (v.AREA_ID != null) { dr[2] = v.AREA_ID; } else { dr[2] = DBNull.Value; }
				if (v.TOTAL_FDVC != null) { dr[3] = v.TOTAL_FDVC; } else { dr[3] = DBNull.Value; }
				dt.Rows.Add(dr);
			}
			dt.AcceptChanges();

			return dt;
		}

		public void AddManyBulk(List<PL_AREA_GASVOLUME> pl_area_gasvolume)
		{
			using (var conn = new SqlConnection(connString))
			{
				try
				{
					Message = "";
					conn.Open();

					DataTable dt = GetDataTable(pl_area_gasvolume);
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