using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using WebThemeforest2.Models;

namespace WebThemeforest2.Repositories
{
	public partial class PL_CONFIG_PRESSURE_REGIMERepository
	{
		private string connString;
		public string Message { get; set; }

		public PL_CONFIG_PRESSURE_REGIMERepository(string connectionString)
		{
			connString = connectionString;
		}

		public void Add(PL_CONFIG_PRESSURE_REGIME pl_config_pressure_regime)
		{
			using (var conn = new SqlConnection(connString))
			{
				try
				{
					Message = "";
					conn.Open();
					SqlCommand command = new SqlCommand("INSERT INTO PL_CONFIG_PRESSURE_REGIME ([REGIME_NAME], [MIN], [MAX]) VALUES(@REGIME_NAME, @MIN, @MAX)", conn);
					command.CommandType = System.Data.CommandType.Text;
					if (pl_config_pressure_regime.REGIME_NAME != null) { command.Parameters.AddWithValue("@REGIME_NAME", pl_config_pressure_regime.REGIME_NAME); } else { command.Parameters.AddWithValue("@REGIME_NAME", DBNull.Value); } 
					if (pl_config_pressure_regime.MIN != null) { command.Parameters.AddWithValue("@MIN", pl_config_pressure_regime.MIN); } else { command.Parameters.AddWithValue("@MIN", DBNull.Value); } 
					if (pl_config_pressure_regime.MAX != null) { command.Parameters.AddWithValue("@MAX", pl_config_pressure_regime.MAX); } else { command.Parameters.AddWithValue("@MAX", DBNull.Value); } 
					command.ExecuteNonQuery();
				}
				catch (Exception ex)
				{
					Message = ex.Message;
				}
			}
		}

		public void AddMany(List<PL_CONFIG_PRESSURE_REGIME> pl_config_pressure_regime)
		{
			using (var conn = new SqlConnection(connString))
			{
				try
				{
					Message = "";
					conn.Open();
					int pos = 0;
					foreach(PL_CONFIG_PRESSURE_REGIME item in pl_config_pressure_regime)
					{
						SqlCommand command = new SqlCommand("INSERT INTO PL_CONFIG_PRESSURE_REGIME ([REGIME_NAME], [MIN], [MAX]) VALUES(@REGIME_NAME, @MIN, @MAX)", conn);
						command.CommandType = System.Data.CommandType.Text;
						if (pl_config_pressure_regime[pos].REGIME_NAME != null) { command.Parameters.AddWithValue("@REGIME_NAME", pl_config_pressure_regime[pos].REGIME_NAME); } else { command.Parameters.AddWithValue("@REGIME_NAME", DBNull.Value); } 
						if (pl_config_pressure_regime[pos].MIN != null) { command.Parameters.AddWithValue("@MIN", pl_config_pressure_regime[pos].MIN); } else { command.Parameters.AddWithValue("@MIN", DBNull.Value); } 
						if (pl_config_pressure_regime[pos].MAX != null) { command.Parameters.AddWithValue("@MAX", pl_config_pressure_regime[pos].MAX); } else { command.Parameters.AddWithValue("@MAX", DBNull.Value); } 
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

		public void Update(PL_CONFIG_PRESSURE_REGIME pl_config_pressure_regime)
		{
			using (var conn = new SqlConnection(connString))
			{
				try
				{
					Message = "";
					conn.Open();
					SqlCommand command = new SqlCommand("UPDATE PL_CONFIG_PRESSURE_REGIME SET MIN = @MIN, MAX = @MAX WHERE REGIME_NAME = @REGIME_NAME", conn);
					command.CommandType = System.Data.CommandType.Text;
					if (pl_config_pressure_regime.REGIME_NAME != null) { command.Parameters.AddWithValue("@REGIME_NAME", pl_config_pressure_regime.REGIME_NAME); } else { command.Parameters.AddWithValue("@REGIME_NAME", DBNull.Value); } 
					if (pl_config_pressure_regime.MIN != null) { command.Parameters.AddWithValue("@MIN", pl_config_pressure_regime.MIN); } else { command.Parameters.AddWithValue("@MIN", DBNull.Value); } 
					if (pl_config_pressure_regime.MAX != null) { command.Parameters.AddWithValue("@MAX", pl_config_pressure_regime.MAX); } else { command.Parameters.AddWithValue("@MAX", DBNull.Value); } 
					command.ExecuteNonQuery();
				}
				catch (Exception ex)
				{
					Message = ex.Message;
				}
			}
		}

		public void UpdateMany(List<PL_CONFIG_PRESSURE_REGIME> pl_config_pressure_regimes)
		{
			using (var conn = new SqlConnection(connString))
			{
				try
				{
					Message = "";
					conn.Open();
					foreach(PL_CONFIG_PRESSURE_REGIME item in pl_config_pressure_regimes)
					{
						SqlCommand command = new SqlCommand("UPDATE PL_CONFIG_PRESSURE_REGIME SET MIN = @MIN, MAX = @MAX WHERE REGIME_NAME = @REGIME_NAME", conn);
						command.CommandType = System.Data.CommandType.Text;
						if (item.REGIME_NAME != null) { command.Parameters.AddWithValue("@REGIME_NAME", item.REGIME_NAME); } else { command.Parameters.AddWithValue("@REGIME_NAME", DBNull.Value); } 
						if (item.MIN != null) { command.Parameters.AddWithValue("@MIN", item.MIN); } else { command.Parameters.AddWithValue("@MIN", DBNull.Value); } 
						if (item.MAX != null) { command.Parameters.AddWithValue("@MAX", item.MAX); } else { command.Parameters.AddWithValue("@MAX", DBNull.Value); } 
						command.ExecuteNonQuery();
					}
				}
				catch (Exception ex)
				{
					Message = ex.Message;
				}
			}
		}

		public void Remove(PL_CONFIG_PRESSURE_REGIME id)
		{
			using (var conn = new SqlConnection(connString))
			{
				try
				{
					Message = "";
					conn.Open();
					SqlCommand command = new SqlCommand("DELETE PL_CONFIG_PRESSURE_REGIME WHERE REGIME_NAME = @REGIME_NAME", conn);
					command.CommandType = System.Data.CommandType.Text;
					if (id.REGIME_NAME != null) { command.Parameters.AddWithValue("@REGIME_NAME", id.REGIME_NAME); } else { command.Parameters.AddWithValue("@REGIME_NAME", DBNull.Value); } 
					command.ExecuteNonQuery();
				}
				catch (Exception ex)
				{
					Message = ex.Message;
				}
			}
		}

		public List<PL_CONFIG_PRESSURE_REGIME> GetData()
		{
			List<PL_CONFIG_PRESSURE_REGIME> items = new List<PL_CONFIG_PRESSURE_REGIME>();
			using (var conn = new SqlConnection(connString))
			{
				Message = "";
				try
				{
					conn.Open();
					SqlCommand command = new SqlCommand("SELECT [REGIME_NAME], [MIN], [MAX] FROM PL_CONFIG_PRESSURE_REGIME", conn);
					SqlDataReader reader = command.ExecuteReader();
					PL_CONFIG_PRESSURE_REGIME item = new PL_CONFIG_PRESSURE_REGIME();
					while(reader.Read())
					{
						item = new PL_CONFIG_PRESSURE_REGIME();
						if (reader[0] != DBNull.Value) { item.REGIME_NAME = Convert.ToString(reader[0]); }
						if (reader[1] != DBNull.Value) { item.MIN = Convert.ToDouble(reader[1]); }
						if (reader[2] != DBNull.Value) { item.MAX = Convert.ToDouble(reader[2]); }
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

		public List<PL_CONFIG_PRESSURE_REGIME> GetDataByREGIME_NAME(string REGIME_NAME)
		{
			List<PL_CONFIG_PRESSURE_REGIME> items = new List<PL_CONFIG_PRESSURE_REGIME>();
			using (var conn = new SqlConnection(connString))
			{
				Message = "";
				try
				{
					conn.Open();
					SqlCommand command = new SqlCommand("SELECT [REGIME_NAME], [MIN], [MAX] FROM PL_CONFIG_PRESSURE_REGIME WHERE REGIME_NAME = @REGIME_NAME", conn);
					command.Parameters.AddWithValue("@REGIME_NAME", REGIME_NAME);
					SqlDataReader reader = command.ExecuteReader();
					PL_CONFIG_PRESSURE_REGIME item = new PL_CONFIG_PRESSURE_REGIME();
					while(reader.Read())
					{
						item = new PL_CONFIG_PRESSURE_REGIME();
						if (reader[0] != DBNull.Value) { item.REGIME_NAME = Convert.ToString(reader[0]); }
						if (reader[1] != DBNull.Value) { item.MIN = Convert.ToDouble(reader[1]); }
						if (reader[2] != DBNull.Value) { item.MAX = Convert.ToDouble(reader[2]); }
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

		public void RemoveByREGIME_NAME(string id)
		{
			using (var conn = new SqlConnection(connString))
			{
				try
				{
					Message = "";
					conn.Open();
					SqlCommand command = new SqlCommand("DELETE PL_CONFIG_PRESSURE_REGIME WHERE REGIME_NAME = @REGIME_NAME", conn);
					command.CommandType = System.Data.CommandType.Text;
					if (id != null) { command.Parameters.AddWithValue("@REGIME_NAME", id); } else { command.Parameters.AddWithValue("@REGIME_NAME", DBNull.Value); } 
					command.ExecuteNonQuery();
				}
				catch (Exception ex)
				{
					Message = ex.Message;
				}
			}
		}

		public DataTable GetDataTable(List<PL_CONFIG_PRESSURE_REGIME> pl_config_pressure_regime)
		{
			DataTable dt = new DataTable("PL_CONFIG_PRESSURE_REGIME");

			DataColumn c1 = new DataColumn("REGIME_NAME", typeof(string)); 
			dt.Columns.Add(c1);
			DataColumn c2 = new DataColumn("MIN", typeof(double)); c2.AllowDBNull = true;
			dt.Columns.Add(c2);
			DataColumn c3 = new DataColumn("MAX", typeof(double)); c3.AllowDBNull = true;
			dt.Columns.Add(c3);

			foreach (PL_CONFIG_PRESSURE_REGIME v in pl_config_pressure_regime)
			{
				DataRow dr = dt.NewRow();
				if (v.REGIME_NAME != null) { dr[0] = v.REGIME_NAME; } else { dr[0] = DBNull.Value; }
				if (v.MIN != null) { dr[1] = v.MIN; } else { dr[1] = DBNull.Value; }
				if (v.MAX != null) { dr[2] = v.MAX; } else { dr[2] = DBNull.Value; }
				dt.Rows.Add(dr);
			}
			dt.AcceptChanges();

			return dt;
		}

		public void AddManyBulk(List<PL_CONFIG_PRESSURE_REGIME> pl_config_pressure_regime)
		{
			using (var conn = new SqlConnection(connString))
			{
				try
				{
					Message = "";
					conn.Open();

					DataTable dt = GetDataTable(pl_config_pressure_regime);
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