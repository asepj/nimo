using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using WebThemeforest2.Models;

namespace WebThemeforest2.Repositories
{
	public partial class PL_CONFIG_CONSTANTRepository
	{
		private string connString;
		public string Message { get; set; }

		public PL_CONFIG_CONSTANTRepository(string connectionString)
		{
			connString = connectionString;
		}

		public void Add(PL_CONFIG_CONSTANT pl_config_constant)
		{
			using (var conn = new SqlConnection(connString))
			{
				try
				{
					Message = "";
					conn.Open();
					SqlCommand command = new SqlCommand("INSERT INTO PL_CONFIG_CONSTANT ( [CONSTANT_NAME], [VALUE]) VALUES( @CONSTANT_NAME, @VALUE)", conn);
					command.CommandType = System.Data.CommandType.Text;
					
					if (pl_config_constant.CONSTANT_NAME != null) { command.Parameters.AddWithValue("@CONSTANT_NAME", pl_config_constant.CONSTANT_NAME); } else { command.Parameters.AddWithValue("@CONSTANT_NAME", DBNull.Value); } 
					if (pl_config_constant.VALUE != null) { command.Parameters.AddWithValue("@VALUE", pl_config_constant.VALUE); } else { command.Parameters.AddWithValue("@VALUE", DBNull.Value); } 
					command.ExecuteNonQuery();
				}
				catch (Exception ex)
				{
					Message = ex.Message;
				}
			}
		}

		public void AddMany(List<PL_CONFIG_CONSTANT> pl_config_constant)
		{
			using (var conn = new SqlConnection(connString))
			{
				try
				{
					Message = "";
					conn.Open();
					int pos = 0;
					foreach(PL_CONFIG_CONSTANT item in pl_config_constant)
					{
						SqlCommand command = new SqlCommand("INSERT INTO PL_CONFIG_CONSTANT ([ID], [CONSTANT_NAME], [VALUE]) VALUES(@ID, @CONSTANT_NAME, @VALUE)", conn);
						command.CommandType = System.Data.CommandType.Text;
						if (pl_config_constant[pos].ID != null) { command.Parameters.AddWithValue("@ID", pl_config_constant[pos].ID); } else { command.Parameters.AddWithValue("@ID", DBNull.Value); } 
						if (pl_config_constant[pos].CONSTANT_NAME != null) { command.Parameters.AddWithValue("@CONSTANT_NAME", pl_config_constant[pos].CONSTANT_NAME); } else { command.Parameters.AddWithValue("@CONSTANT_NAME", DBNull.Value); } 
						if (pl_config_constant[pos].VALUE != null) { command.Parameters.AddWithValue("@VALUE", pl_config_constant[pos].VALUE); } else { command.Parameters.AddWithValue("@VALUE", DBNull.Value); } 
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

		public void Update(PL_CONFIG_CONSTANT pl_config_constant)
		{
			using (var conn = new SqlConnection(connString))
			{
				try
				{
					Message = "";
					conn.Open();
					SqlCommand command = new SqlCommand("UPDATE PL_CONFIG_CONSTANT SET CONSTANT_NAME = @CONSTANT_NAME, VALUE = @VALUE WHERE ID = @ID", conn);
					command.CommandType = System.Data.CommandType.Text;
					if (pl_config_constant.ID != null) { command.Parameters.AddWithValue("@ID", pl_config_constant.ID); } else { command.Parameters.AddWithValue("@ID", DBNull.Value); } 
					if (pl_config_constant.CONSTANT_NAME != null) { command.Parameters.AddWithValue("@CONSTANT_NAME", pl_config_constant.CONSTANT_NAME); } else { command.Parameters.AddWithValue("@CONSTANT_NAME", DBNull.Value); } 
					if (pl_config_constant.VALUE != null) { command.Parameters.AddWithValue("@VALUE", pl_config_constant.VALUE); } else { command.Parameters.AddWithValue("@VALUE", DBNull.Value); } 
					command.ExecuteNonQuery();
				}
				catch (Exception ex)
				{
					Message = ex.Message;
				}
			}
		}

		public void UpdateMany(List<PL_CONFIG_CONSTANT> pl_config_constants)
		{
			using (var conn = new SqlConnection(connString))
			{
				try
				{
					Message = "";
					conn.Open();
					foreach(PL_CONFIG_CONSTANT item in pl_config_constants)
					{
						SqlCommand command = new SqlCommand("UPDATE PL_CONFIG_CONSTANT SET CONSTANT_NAME = @CONSTANT_NAME, VALUE = @VALUE WHERE ID = @ID", conn);
						command.CommandType = System.Data.CommandType.Text;
						if (item.ID != null) { command.Parameters.AddWithValue("@ID", item.ID); } else { command.Parameters.AddWithValue("@ID", DBNull.Value); } 
						if (item.CONSTANT_NAME != null) { command.Parameters.AddWithValue("@CONSTANT_NAME", item.CONSTANT_NAME); } else { command.Parameters.AddWithValue("@CONSTANT_NAME", DBNull.Value); } 
						if (item.VALUE != null) { command.Parameters.AddWithValue("@VALUE", item.VALUE); } else { command.Parameters.AddWithValue("@VALUE", DBNull.Value); } 
						command.ExecuteNonQuery();
					}
				}
				catch (Exception ex)
				{
					Message = ex.Message;
				}
			}
		}

		public void Remove(PL_CONFIG_CONSTANT id)
		{
			using (var conn = new SqlConnection(connString))
			{
				try
				{
					Message = "";
					conn.Open();
					SqlCommand command = new SqlCommand("DELETE PL_CONFIG_CONSTANT WHERE ID = @ID", conn);
					command.CommandType = System.Data.CommandType.Text;
					if (id.ID != null) { command.Parameters.AddWithValue("@ID", id.ID); } else { command.Parameters.AddWithValue("@ID", DBNull.Value); } 
					command.ExecuteNonQuery();
				}
				catch (Exception ex)
				{
					Message = ex.Message;
				}
			}
		}

		public List<PL_CONFIG_CONSTANT> GetData()
		{
			List<PL_CONFIG_CONSTANT> items = new List<PL_CONFIG_CONSTANT>();
			using (var conn = new SqlConnection(connString))
			{
				Message = "";
				try
				{
					conn.Open();
					SqlCommand command = new SqlCommand("SELECT [ID], [CONSTANT_NAME], [VALUE] FROM PL_CONFIG_CONSTANT", conn);
					SqlDataReader reader = command.ExecuteReader();
					PL_CONFIG_CONSTANT item = new PL_CONFIG_CONSTANT();
					while(reader.Read())
					{
						item = new PL_CONFIG_CONSTANT();
						if (reader[0] != DBNull.Value) { item.ID = Convert.ToInt32(reader[0]); }
						if (reader[1] != DBNull.Value) { item.CONSTANT_NAME = Convert.ToString(reader[1]); }
						if (reader[2] != DBNull.Value) { item.VALUE = Convert.ToDouble(reader[2]); }
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


        public List<PL_CONFIG_CONSTANT> GetDataTemperature()
        {
            List<PL_CONFIG_CONSTANT> items = new List<PL_CONFIG_CONSTANT>();
            using (var conn = new SqlConnection(connString))
            {
                Message = "";
                try
                {
                    conn.Open();
                    SqlCommand command = new SqlCommand(" SELECT  [VALUE] FROM PL_CONFIG_CONSTANT WHERE CONSTANT_NAME = 'TEMPERATURE' ", conn);
                    SqlDataReader reader = command.ExecuteReader();
                    PL_CONFIG_CONSTANT item = new PL_CONFIG_CONSTANT();
                    while (reader.Read())
                    {
                        item = new PL_CONFIG_CONSTANT();

                        if (reader[0] != DBNull.Value) { item.VALUE = Convert.ToInt32(reader[0]); }
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

		public List<PL_CONFIG_CONSTANT> GetDataByID(int ID)
		{
			List<PL_CONFIG_CONSTANT> items = new List<PL_CONFIG_CONSTANT>();
			using (var conn = new SqlConnection(connString))
			{
				Message = "";
				try
				{
					conn.Open();
					SqlCommand command = new SqlCommand("SELECT [ID], [CONSTANT_NAME], [VALUE] FROM PL_CONFIG_CONSTANT WHERE ID = @ID", conn);
					command.Parameters.AddWithValue("@ID", ID);
					SqlDataReader reader = command.ExecuteReader();
					PL_CONFIG_CONSTANT item = new PL_CONFIG_CONSTANT();
					while(reader.Read())
					{
						item = new PL_CONFIG_CONSTANT();
						if (reader[0] != DBNull.Value) { item.ID = Convert.ToInt32(reader[0]); }
						if (reader[1] != DBNull.Value) { item.CONSTANT_NAME = Convert.ToString(reader[1]); }
                        if (reader[2] != DBNull.Value) { item.VALUE = Convert.ToDouble(reader[2]); }
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

		public void RemoveByID(int id)
		{
			using (var conn = new SqlConnection(connString))
			{
				try
				{
					Message = "";
					conn.Open();
					SqlCommand command = new SqlCommand("DELETE PL_CONFIG_CONSTANT WHERE ID = @ID", conn);
					command.CommandType = System.Data.CommandType.Text;
					if (id != null) { command.Parameters.AddWithValue("@ID", id); } else { command.Parameters.AddWithValue("@ID", DBNull.Value); } 
					command.ExecuteNonQuery();
				}
				catch (Exception ex)
				{
					Message = ex.Message;
				}
			}
		}

		public DataTable GetDataTable(List<PL_CONFIG_CONSTANT> pl_config_constant)
		{
			DataTable dt = new DataTable("PL_CONFIG_CONSTANT");

			DataColumn c1 = new DataColumn("ID", typeof(int)); 
			dt.Columns.Add(c1);
			DataColumn c2 = new DataColumn("CONSTANT_NAME", typeof(string)); c2.AllowDBNull = true;
			dt.Columns.Add(c2);
			DataColumn c3 = new DataColumn("VALUE", typeof(double)); c3.AllowDBNull = true;
			dt.Columns.Add(c3);

			foreach (PL_CONFIG_CONSTANT v in pl_config_constant)
			{
				DataRow dr = dt.NewRow();
				if (v.ID != null) { dr[0] = v.ID; } else { dr[0] = DBNull.Value; }
				if (v.CONSTANT_NAME != null) { dr[1] = v.CONSTANT_NAME; } else { dr[1] = DBNull.Value; }
				if (v.VALUE != null) { dr[2] = v.VALUE; } else { dr[2] = DBNull.Value; }
				dt.Rows.Add(dr);
			}
			dt.AcceptChanges();

			return dt;
		}

		public void AddManyBulk(List<PL_CONFIG_CONSTANT> pl_config_constant)
		{
			using (var conn = new SqlConnection(connString))
			{
				try
				{
					Message = "";
					conn.Open();

					DataTable dt = GetDataTable(pl_config_constant);
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