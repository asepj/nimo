using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using WebThemeforest2.Models;

namespace WebThemeforest2.Repositories
{
	public partial class PL_CONFIG_PIPELINE_CONSTRUCTIONRepository
	{
		private string connString;
		public string Message { get; set; }

		public PL_CONFIG_PIPELINE_CONSTRUCTIONRepository(string connectionString)
		{
			connString = connectionString;
		}

		public void Add(PL_CONFIG_PIPELINE_CONSTRUCTION pl_config_pipeline_construction)
		{
			using (var conn = new SqlConnection(connString))
			{
				try
				{
					Message = "";
					conn.Open();
					SqlCommand command = new SqlCommand("INSERT INTO PL_CONFIG_PIPELINE_CONSTRUCTION ([ID_CONSTRUCTION], [DESCRIPTION]) VALUES(@ID_CONSTRUCTION, @DESCRIPTION)", conn);
					command.CommandType = System.Data.CommandType.Text;
					if (pl_config_pipeline_construction.ID_CONSTRUCTION != null) { command.Parameters.AddWithValue("@ID_CONSTRUCTION", pl_config_pipeline_construction.ID_CONSTRUCTION); } else { command.Parameters.AddWithValue("@ID_CONSTRUCTION", DBNull.Value); } 
					if (pl_config_pipeline_construction.DESCRIPTION != null) { command.Parameters.AddWithValue("@DESCRIPTION", pl_config_pipeline_construction.DESCRIPTION); } else { command.Parameters.AddWithValue("@DESCRIPTION", DBNull.Value); } 
					command.ExecuteNonQuery();
				}
				catch (Exception ex)
				{
					Message = ex.Message;
				}
			}
		}

		public void AddMany(List<PL_CONFIG_PIPELINE_CONSTRUCTION> pl_config_pipeline_construction)
		{
			using (var conn = new SqlConnection(connString))
			{
				try
				{
					Message = "";
					conn.Open();
					int pos = 0;
					foreach(PL_CONFIG_PIPELINE_CONSTRUCTION item in pl_config_pipeline_construction)
					{
						SqlCommand command = new SqlCommand("INSERT INTO PL_CONFIG_PIPELINE_CONSTRUCTION ([ID_CONSTRUCTION], [DESCRIPTION]) VALUES(@ID_CONSTRUCTION, @DESCRIPTION)", conn);
						command.CommandType = System.Data.CommandType.Text;
						if (pl_config_pipeline_construction[pos].ID_CONSTRUCTION != null) { command.Parameters.AddWithValue("@ID_CONSTRUCTION", pl_config_pipeline_construction[pos].ID_CONSTRUCTION); } else { command.Parameters.AddWithValue("@ID_CONSTRUCTION", DBNull.Value); } 
						if (pl_config_pipeline_construction[pos].DESCRIPTION != null) { command.Parameters.AddWithValue("@DESCRIPTION", pl_config_pipeline_construction[pos].DESCRIPTION); } else { command.Parameters.AddWithValue("@DESCRIPTION", DBNull.Value); } 
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

		public void Update(PL_CONFIG_PIPELINE_CONSTRUCTION pl_config_pipeline_construction)
		{
			using (var conn = new SqlConnection(connString))
			{
				try
				{
					Message = "";
					conn.Open();
					SqlCommand command = new SqlCommand("UPDATE PL_CONFIG_PIPELINE_CONSTRUCTION SET  WHERE ", conn);
					command.CommandType = System.Data.CommandType.Text;
					command.ExecuteNonQuery();
				}
				catch (Exception ex)
				{
					Message = ex.Message;
				}
			}
		}

		public void UpdateMany(List<PL_CONFIG_PIPELINE_CONSTRUCTION> pl_config_pipeline_constructions)
		{
			using (var conn = new SqlConnection(connString))
			{
				try
				{
					Message = "";
					conn.Open();
					foreach(PL_CONFIG_PIPELINE_CONSTRUCTION item in pl_config_pipeline_constructions)
					{
						SqlCommand command = new SqlCommand("UPDATE PL_CONFIG_PIPELINE_CONSTRUCTION SET  WHERE ", conn);
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

		public void Remove(PL_CONFIG_PIPELINE_CONSTRUCTION id)
		{
			using (var conn = new SqlConnection(connString))
			{
				try
				{
					Message = "";
					conn.Open();
					SqlCommand command = new SqlCommand("DELETE PL_CONFIG_PIPELINE_CONSTRUCTION WHERE ", conn);
					command.CommandType = System.Data.CommandType.Text;
					command.ExecuteNonQuery();
				}
				catch (Exception ex)
				{
					Message = ex.Message;
				}
			}
		}

		public List<PL_CONFIG_PIPELINE_CONSTRUCTION> GetData()
		{
			List<PL_CONFIG_PIPELINE_CONSTRUCTION> items = new List<PL_CONFIG_PIPELINE_CONSTRUCTION>();
			using (var conn = new SqlConnection(connString))
			{
				Message = "";
				try
				{
					conn.Open();
					SqlCommand command = new SqlCommand("SELECT [ID_CONSTRUCTION], [DESCRIPTION], [CATEGORY] FROM PL_CONFIG_PIPELINE_CONSTRUCTION WHERE STATUS = 1", conn);
					SqlDataReader reader = command.ExecuteReader();
					PL_CONFIG_PIPELINE_CONSTRUCTION item = new PL_CONFIG_PIPELINE_CONSTRUCTION();
					while(reader.Read())
					{
						item = new PL_CONFIG_PIPELINE_CONSTRUCTION();
						if (reader[0] != DBNull.Value) { item.ID_CONSTRUCTION = Convert.ToInt32(reader[0]); }
						if (reader[1] != DBNull.Value) { item.DESCRIPTION = Convert.ToString(reader[1]); }
                        if (reader[2] != DBNull.Value) { item.CATEGORY = Convert.ToString(reader[2]); }
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



        public List<PL_CONFIG_PIPELINE_CONSTRUCTION> GetDataDescription(PL_CONFIG_PIPELINE_CONSTRUCTION pl_config_pipeline_construction)
        {
            List<PL_CONFIG_PIPELINE_CONSTRUCTION> items = new List<PL_CONFIG_PIPELINE_CONSTRUCTION>();
            using (var conn = new SqlConnection(connString))
            {
                Message = "";
                try
                {
                    conn.Open();
                    SqlCommand command = new SqlCommand("SELECT  [DESCRIPTION] FROM PL_CONFIG_PIPELINE_CONSTRUCTION where ID_CONSTRUCTION  = '" + pl_config_pipeline_construction.ID_CONSTRUCTION + "' and status = 1", conn);
                    SqlDataReader reader = command.ExecuteReader();
                    PL_CONFIG_PIPELINE_CONSTRUCTION item = new PL_CONFIG_PIPELINE_CONSTRUCTION();
                    while (reader.Read())
                    {
                        item = new PL_CONFIG_PIPELINE_CONSTRUCTION();
                        if (reader[0] != DBNull.Value) { item.DESCRIPTION = Convert.ToString(reader[0]); }
                       
                       
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

		public DataTable GetDataTable(List<PL_CONFIG_PIPELINE_CONSTRUCTION> pl_config_pipeline_construction)
		{
			DataTable dt = new DataTable("PL_CONFIG_PIPELINE_CONSTRUCTION");

			DataColumn c1 = new DataColumn("ID_CONSTRUCTION", typeof(int)); 
			dt.Columns.Add(c1);
			DataColumn c2 = new DataColumn("DESCRIPTION", typeof(string)); 
			dt.Columns.Add(c2);

			foreach (PL_CONFIG_PIPELINE_CONSTRUCTION v in pl_config_pipeline_construction)
			{
				DataRow dr = dt.NewRow();
				if (v.ID_CONSTRUCTION != null) { dr[0] = v.ID_CONSTRUCTION; } else { dr[0] = DBNull.Value; }
				if (v.DESCRIPTION != null) { dr[1] = v.DESCRIPTION; } else { dr[1] = DBNull.Value; }
				dt.Rows.Add(dr);
			}
			dt.AcceptChanges();

			return dt;
		}

		public void AddManyBulk(List<PL_CONFIG_PIPELINE_CONSTRUCTION> pl_config_pipeline_construction)
		{
			using (var conn = new SqlConnection(connString))
			{
				try
				{
					Message = "";
					conn.Open();

					DataTable dt = GetDataTable(pl_config_pipeline_construction);
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