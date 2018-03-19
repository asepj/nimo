using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using WebThemeforest2.Models;

namespace WebThemeforest2.Repositories
{
	public partial class PL_AREA_REGIONALRepository
	{
		private string connString;
		public string Message { get; set; }

		public PL_AREA_REGIONALRepository(string connectionString)
		{
			connString = connectionString;
		}

		public void Add(PL_AREA_REGIONAL pl_area_regional)
		{
			using (var conn = new SqlConnection(connString))
			{
				try
				{
					Message = "";
					conn.Open();
					SqlCommand command = new SqlCommand("INSERT INTO PL_AREA_REGIONAL ([AREA], [ID_UNIT_USAHA], [ID_REGION]) VALUES(@AREA, @ID_UNIT_USAHA, @ID_REGION)", conn);
					command.CommandType = System.Data.CommandType.Text;
					if (pl_area_regional.AREA != null) { command.Parameters.AddWithValue("@AREA", pl_area_regional.AREA); } else { command.Parameters.AddWithValue("@AREA", DBNull.Value); } 
					if (pl_area_regional.ID_UNIT_USAHA != null) { command.Parameters.AddWithValue("@ID_UNIT_USAHA", pl_area_regional.ID_UNIT_USAHA); } else { command.Parameters.AddWithValue("@ID_UNIT_USAHA", DBNull.Value); } 
					if (pl_area_regional.ID_REGION != null) { command.Parameters.AddWithValue("@ID_REGION", pl_area_regional.ID_REGION); } else { command.Parameters.AddWithValue("@ID_REGION", DBNull.Value); } 
					command.ExecuteNonQuery();
				}
				catch (Exception ex)
				{
					Message = ex.Message;
				}
			}
		}

		public void AddMany(List<PL_AREA_REGIONAL> pl_area_regional)
		{
			using (var conn = new SqlConnection(connString))
			{
				try
				{
					Message = "";
					conn.Open();
					int pos = 0;
					foreach(PL_AREA_REGIONAL item in pl_area_regional)
					{
						SqlCommand command = new SqlCommand("INSERT INTO PL_AREA_REGIONAL ([AREA], [ID_UNIT_USAHA], [ID_REGION]) VALUES(@AREA, @ID_UNIT_USAHA, @ID_REGION)", conn);
						command.CommandType = System.Data.CommandType.Text;
						if (pl_area_regional[pos].AREA != null) { command.Parameters.AddWithValue("@AREA", pl_area_regional[pos].AREA); } else { command.Parameters.AddWithValue("@AREA", DBNull.Value); } 
						if (pl_area_regional[pos].ID_UNIT_USAHA != null) { command.Parameters.AddWithValue("@ID_UNIT_USAHA", pl_area_regional[pos].ID_UNIT_USAHA); } else { command.Parameters.AddWithValue("@ID_UNIT_USAHA", DBNull.Value); } 
						if (pl_area_regional[pos].ID_REGION != null) { command.Parameters.AddWithValue("@ID_REGION", pl_area_regional[pos].ID_REGION); } else { command.Parameters.AddWithValue("@ID_REGION", DBNull.Value); } 
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

		public void Update(PL_AREA_REGIONAL pl_area_regional)
		{
			using (var conn = new SqlConnection(connString))
			{
				try
				{
					Message = "";
					conn.Open();
					SqlCommand command = new SqlCommand("UPDATE PL_AREA_REGIONAL SET AREA = @AREA, ID_UNIT_USAHA = @ID_UNIT_USAHA, ID_REGION = @ID_REGION WHERE ", conn);
					command.CommandType = System.Data.CommandType.Text;
					if (pl_area_regional.AREA != null) { command.Parameters.AddWithValue("@AREA", pl_area_regional.AREA); } else { command.Parameters.AddWithValue("@AREA", DBNull.Value); } 
					if (pl_area_regional.ID_UNIT_USAHA != null) { command.Parameters.AddWithValue("@ID_UNIT_USAHA", pl_area_regional.ID_UNIT_USAHA); } else { command.Parameters.AddWithValue("@ID_UNIT_USAHA", DBNull.Value); } 
					if (pl_area_regional.ID_REGION != null) { command.Parameters.AddWithValue("@ID_REGION", pl_area_regional.ID_REGION); } else { command.Parameters.AddWithValue("@ID_REGION", DBNull.Value); } 
					command.ExecuteNonQuery();
				}
				catch (Exception ex)
				{
					Message = ex.Message;
				}
			}
		}

		public void UpdateMany(List<PL_AREA_REGIONAL> pl_area_regionals)
		{
			using (var conn = new SqlConnection(connString))
			{
				try
				{
					Message = "";
					conn.Open();
					foreach(PL_AREA_REGIONAL item in pl_area_regionals)
					{
						SqlCommand command = new SqlCommand("UPDATE PL_AREA_REGIONAL SET AREA = @AREA, ID_UNIT_USAHA = @ID_UNIT_USAHA, ID_REGION = @ID_REGION WHERE ", conn);
						command.CommandType = System.Data.CommandType.Text;
						if (item.AREA != null) { command.Parameters.AddWithValue("@AREA", item.AREA); } else { command.Parameters.AddWithValue("@AREA", DBNull.Value); } 
						if (item.ID_UNIT_USAHA != null) { command.Parameters.AddWithValue("@ID_UNIT_USAHA", item.ID_UNIT_USAHA); } else { command.Parameters.AddWithValue("@ID_UNIT_USAHA", DBNull.Value); } 
						if (item.ID_REGION != null) { command.Parameters.AddWithValue("@ID_REGION", item.ID_REGION); } else { command.Parameters.AddWithValue("@ID_REGION", DBNull.Value); } 
						command.ExecuteNonQuery();
					}
				}
				catch (Exception ex)
				{
					Message = ex.Message;
				}
			}
		}

		public void Remove(PL_AREA_REGIONAL id)
		{
			using (var conn = new SqlConnection(connString))
			{
				try
				{
					Message = "";
					conn.Open();
					SqlCommand command = new SqlCommand("DELETE PL_AREA_REGIONAL WHERE ", conn);
					command.CommandType = System.Data.CommandType.Text;
					command.ExecuteNonQuery();
				}
				catch (Exception ex)
				{
					Message = ex.Message;
				}
			}
		}

		public List<PL_AREA_REGIONAL> GetData()
		{
			List<PL_AREA_REGIONAL> items = new List<PL_AREA_REGIONAL>();
			using (var conn = new SqlConnection(connString))
			{
				Message = "";
				try
				{
					conn.Open();
					SqlCommand command = new SqlCommand("SELECT [AREA], [ID_UNIT_USAHA], [ID_REGION] FROM PL_AREA_REGIONAL", conn);
					SqlDataReader reader = command.ExecuteReader();
					PL_AREA_REGIONAL item = new PL_AREA_REGIONAL();
					while(reader.Read())
					{
						item = new PL_AREA_REGIONAL();
						if (reader[0] != DBNull.Value) { item.AREA = Convert.ToString(reader[0]); }
						if (reader[1] != DBNull.Value) { item.ID_UNIT_USAHA = Convert.ToString(reader[1]); }
						if (reader[2] != DBNull.Value) { item.ID_REGION = Convert.ToString(reader[2]); }
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

		public DataTable GetDataTable(List<PL_AREA_REGIONAL> pl_area_regional)
		{
			DataTable dt = new DataTable("PL_AREA_REGIONAL");

			DataColumn c1 = new DataColumn("AREA", typeof(string)); c1.AllowDBNull = true;
			dt.Columns.Add(c1);
			DataColumn c2 = new DataColumn("ID_UNIT_USAHA", typeof(string)); c2.AllowDBNull = true;
			dt.Columns.Add(c2);
			DataColumn c3 = new DataColumn("ID_REGION", typeof(string)); c3.AllowDBNull = true;
			dt.Columns.Add(c3);

			foreach (PL_AREA_REGIONAL v in pl_area_regional)
			{
				DataRow dr = dt.NewRow();
				if (v.AREA != null) { dr[0] = v.AREA; } else { dr[0] = DBNull.Value; }
				if (v.ID_UNIT_USAHA != null) { dr[1] = v.ID_UNIT_USAHA; } else { dr[1] = DBNull.Value; }
				if (v.ID_REGION != null) { dr[2] = v.ID_REGION; } else { dr[2] = DBNull.Value; }
				dt.Rows.Add(dr);
			}
			dt.AcceptChanges();

			return dt;
		}

		public void AddManyBulk(List<PL_AREA_REGIONAL> pl_area_regional)
		{
			using (var conn = new SqlConnection(connString))
			{
				try
				{
					Message = "";
					conn.Open();

					DataTable dt = GetDataTable(pl_area_regional);
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