using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using WebThemeforest2.Models;

namespace WebThemeforest2.Repositories
{
	public partial class PL_CONFIG_DIAMETERRepository
	{
		private string connString;
		public string Message { get; set; }

		public PL_CONFIG_DIAMETERRepository(string connectionString)
		{
			connString = connectionString;
		}

		public void Add(PL_CONFIG_DIAMETER pl_config_calculator_diameter)
		{
			using (var conn = new SqlConnection(connString))
			{
				try
				{
					Message = "";
					conn.Open();
					SqlCommand command = new SqlCommand("INSERT INTO PL_CONFIG_CALCULATOR_DIAMETER ( [DIAMETER]) VALUES( @DIAMETER)", conn);
					command.CommandType = System.Data.CommandType.Text;
					
					if (pl_config_calculator_diameter.DIAMETER != null) { command.Parameters.AddWithValue("@DIAMETER", pl_config_calculator_diameter.DIAMETER); } else { command.Parameters.AddWithValue("@DIAMETER", DBNull.Value); } 
					command.ExecuteNonQuery();
				}
				catch (Exception ex)
				{
					Message = ex.Message;
				}
			}
		}

		public void AddMany(List<PL_CONFIG_DIAMETER> pl_config_calculator_diameter)
		{
			using (var conn = new SqlConnection(connString))
			{
				try
				{
					Message = "";
					conn.Open();
					int pos = 0;
					foreach(PL_CONFIG_DIAMETER item in pl_config_calculator_diameter)
					{
						SqlCommand command = new SqlCommand("INSERT INTO PL_CONFIG_CALCULATOR_DIAMETER ([ID], [DIAMETER]) VALUES(@ID, @DIAMETER)", conn);
						command.CommandType = System.Data.CommandType.Text;
						if (pl_config_calculator_diameter[pos].ID != null) { command.Parameters.AddWithValue("@ID", pl_config_calculator_diameter[pos].ID); } else { command.Parameters.AddWithValue("@ID", DBNull.Value); } 
						if (pl_config_calculator_diameter[pos].DIAMETER != null) { command.Parameters.AddWithValue("@DIAMETER", pl_config_calculator_diameter[pos].DIAMETER); } else { command.Parameters.AddWithValue("@DIAMETER", DBNull.Value); } 
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

		public void Update(PL_CONFIG_DIAMETER pl_config_calculator_diameter)
		{
			using (var conn = new SqlConnection(connString))
			{
				try
				{
					Message = "";
					conn.Open();
					SqlCommand command = new SqlCommand("UPDATE PL_CONFIG_CALCULATOR_DIAMETER SET DIAMETER = @DIAMETER WHERE ID = @ID", conn);
					command.CommandType = System.Data.CommandType.Text;
					if (pl_config_calculator_diameter.ID != null) { command.Parameters.AddWithValue("@ID", pl_config_calculator_diameter.ID); } else { command.Parameters.AddWithValue("@ID", DBNull.Value); } 
					if (pl_config_calculator_diameter.DIAMETER != null) { command.Parameters.AddWithValue("@DIAMETER", pl_config_calculator_diameter.DIAMETER); } else { command.Parameters.AddWithValue("@DIAMETER", DBNull.Value); } 
					command.ExecuteNonQuery();
				}
				catch (Exception ex)
				{
					Message = ex.Message;
				}
			}
		}

		public void UpdateMany(List<PL_CONFIG_DIAMETER> pl_config_calculator_diameters)
		{
			using (var conn = new SqlConnection(connString))
			{
				try
				{
					Message = "";
					conn.Open();
					foreach(PL_CONFIG_DIAMETER item in pl_config_calculator_diameters)
					{
						SqlCommand command = new SqlCommand("UPDATE PL_CONFIG_CALCULATOR_DIAMETER SET DIAMETER = @DIAMETER WHERE ID = @ID", conn);
						command.CommandType = System.Data.CommandType.Text;
						if (item.ID != null) { command.Parameters.AddWithValue("@ID", item.ID); } else { command.Parameters.AddWithValue("@ID", DBNull.Value); } 
						if (item.DIAMETER != null) { command.Parameters.AddWithValue("@DIAMETER", item.DIAMETER); } else { command.Parameters.AddWithValue("@DIAMETER", DBNull.Value); } 
						command.ExecuteNonQuery();
					}
				}
				catch (Exception ex)
				{
					Message = ex.Message;
				}
			}
		}

		public void Remove(PL_CONFIG_DIAMETER id)
		{
			using (var conn = new SqlConnection(connString))
			{
				try
				{
					Message = "";
					conn.Open();
					SqlCommand command = new SqlCommand("DELETE PL_CONFIG_CALCULATOR_DIAMETER WHERE ID = @ID", conn);
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

		public List<PL_CONFIG_DIAMETER> GetData()
		{
			List<PL_CONFIG_DIAMETER> items = new List<PL_CONFIG_DIAMETER>();
			using (var conn = new SqlConnection(connString))
			{
				Message = "";
				try
				{
					conn.Open();
					SqlCommand command = new SqlCommand("SELECT [ID], [DIAMETER] FROM PL_CONFIG_CALCULATOR_DIAMETER order by DIAMETER ASC", conn);
					SqlDataReader reader = command.ExecuteReader();
					PL_CONFIG_DIAMETER item = new PL_CONFIG_DIAMETER();
					while(reader.Read())
					{
						item = new PL_CONFIG_DIAMETER();
						if (reader[0] != DBNull.Value) { item.ID = Convert.ToInt32(reader[0]); }
						if (reader[1] != DBNull.Value) { item.DIAMETER = Convert.ToInt32(reader[1]); }
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

		public List<PL_CONFIG_DIAMETER> GetDataByID(int ID)
		{
			List<PL_CONFIG_DIAMETER> items = new List<PL_CONFIG_DIAMETER>();
			using (var conn = new SqlConnection(connString))
			{
				Message = "";
				try
				{
					conn.Open();
					SqlCommand command = new SqlCommand("SELECT [ID], [DIAMETER] FROM PL_CONFIG_CALCULATOR_DIAMETER WHERE ID = @ID", conn);
					command.Parameters.AddWithValue("@ID", ID);
					SqlDataReader reader = command.ExecuteReader();
					PL_CONFIG_DIAMETER item = new PL_CONFIG_DIAMETER();
					while(reader.Read())
					{
						item = new PL_CONFIG_DIAMETER();
						if (reader[0] != DBNull.Value) { item.ID = Convert.ToInt32(reader[0]); }
						if (reader[1] != DBNull.Value) { item.DIAMETER = Convert.ToInt32(reader[1]); }
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
					SqlCommand command = new SqlCommand("DELETE PL_CONFIG_CALCULATOR_DIAMETER WHERE ID = @ID", conn);
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

		public DataTable GetDataTable(List<PL_CONFIG_DIAMETER> pl_config_calculator_diameter)
		{
			DataTable dt = new DataTable("PL_CONFIG_CALCULATOR_DIAMETER");

			DataColumn c1 = new DataColumn("ID", typeof(int)); 
			dt.Columns.Add(c1);
			DataColumn c2 = new DataColumn("DIAMETER", typeof(int)); c2.AllowDBNull = true;
			dt.Columns.Add(c2);

			foreach (PL_CONFIG_DIAMETER v in pl_config_calculator_diameter)
			{
				DataRow dr = dt.NewRow();
				if (v.ID != null) { dr[0] = v.ID; } else { dr[0] = DBNull.Value; }
				if (v.DIAMETER != null) { dr[1] = v.DIAMETER; } else { dr[1] = DBNull.Value; }
				dt.Rows.Add(dr);
			}
			dt.AcceptChanges();

			return dt;
		}

		public void AddManyBulk(List<PL_CONFIG_DIAMETER> pl_config_calculator_diameter)
		{
			using (var conn = new SqlConnection(connString))
			{
				try
				{
					Message = "";
					conn.Open();

					DataTable dt = GetDataTable(pl_config_calculator_diameter);
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


        public List<PL_CONFIG_DIAMETER> GetDimeter()
        {
            List<PL_CONFIG_DIAMETER> items = new List<PL_CONFIG_DIAMETER>();
            using (var conn = new SqlConnection(connString))
            {
                Message = "";
                try
                {
                    conn.Open();
                    SqlCommand command = new SqlCommand("SELECT [DIAMETER] FROM PL_CONFIG_CALCULATOR_DIAMETER order by DIAMETER asc ", conn);
                    SqlDataReader reader = command.ExecuteReader();
                    //command.Parameters.AddWithValue("@AREA_NAME", pl_config_overview.AREA_NAME);
                    PL_CONFIG_DIAMETER item = new PL_CONFIG_DIAMETER();
                    while (reader.Read())
                    {
                        item = new PL_CONFIG_DIAMETER();
                        if (reader[0] != DBNull.Value) { item.DIAMETER = Convert.ToInt32(reader[0]); }
                        
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