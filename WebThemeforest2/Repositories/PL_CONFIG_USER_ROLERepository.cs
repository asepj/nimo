using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using WebThemeforest2.Models;

namespace WebThemeforest2.Repositories
{
	public partial class PL_CONFIG_USER_ROLERepository
	{
		private string connString;
		public string Message { get; set; }

		public PL_CONFIG_USER_ROLERepository(string connectionString)
		{
			connString = connectionString;
		}

		public void Add(PL_CONFIG_USER_ROLE pl_config_user_role)
		{
			using (var conn = new SqlConnection(connString))
			{
				try
				{
					Message = "";
					conn.Open();
					SqlCommand command = new SqlCommand("INSERT INTO PL_CONFIG_USER_ROLE ( [USER_NAME], [USER_ROLE]) VALUES(@USER_NAME, @USER_ROLE)", conn);
					command.CommandType = System.Data.CommandType.Text;
					
					if (pl_config_user_role.USER_NAME != null) { command.Parameters.AddWithValue("@USER_NAME", pl_config_user_role.USER_NAME); } else { command.Parameters.AddWithValue("@USER_NAME", DBNull.Value); } 
					if (pl_config_user_role.USER_ROLE != null) { command.Parameters.AddWithValue("@USER_ROLE", pl_config_user_role.USER_ROLE); } else { command.Parameters.AddWithValue("@USER_ROLE", DBNull.Value); } 
					command.ExecuteNonQuery();
				}
				catch (Exception ex)
				{
					Message = ex.Message;
				}
			}
		}

		public void AddMany(List<PL_CONFIG_USER_ROLE> pl_config_user_role)
		{
			using (var conn = new SqlConnection(connString))
			{
				try
				{
					Message = "";
					conn.Open();
					int pos = 0;
					foreach(PL_CONFIG_USER_ROLE item in pl_config_user_role)
					{
						SqlCommand command = new SqlCommand("INSERT INTO PL_CONFIG_USER_ROLE ([ID], [USER_NAME], [USER_ROLE]) VALUES(@ID, @USER_NAME, @USER_ROLE)", conn);
						command.CommandType = System.Data.CommandType.Text;
						if (pl_config_user_role[pos].ID != null) { command.Parameters.AddWithValue("@ID", pl_config_user_role[pos].ID); } else { command.Parameters.AddWithValue("@ID", DBNull.Value); } 
						if (pl_config_user_role[pos].USER_NAME != null) { command.Parameters.AddWithValue("@USER_NAME", pl_config_user_role[pos].USER_NAME); } else { command.Parameters.AddWithValue("@USER_NAME", DBNull.Value); } 
						if (pl_config_user_role[pos].USER_ROLE != null) { command.Parameters.AddWithValue("@USER_ROLE", pl_config_user_role[pos].USER_ROLE); } else { command.Parameters.AddWithValue("@USER_ROLE", DBNull.Value); } 
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

		public void Update(PL_CONFIG_USER_ROLE pl_config_user_role)
		{
			using (var conn = new SqlConnection(connString))
			{
				try
				{
					Message = "";
					conn.Open();
					SqlCommand command = new SqlCommand("UPDATE PL_CONFIG_USER_ROLE SET USER_NAME = @USER_NAME, USER_ROLE = @USER_ROLE WHERE ID = @ID", conn);
					command.CommandType = System.Data.CommandType.Text;
					if (pl_config_user_role.ID != null) { command.Parameters.AddWithValue("@ID", pl_config_user_role.ID); } else { command.Parameters.AddWithValue("@ID", DBNull.Value); } 
					if (pl_config_user_role.USER_NAME != null) { command.Parameters.AddWithValue("@USER_NAME", pl_config_user_role.USER_NAME); } else { command.Parameters.AddWithValue("@USER_NAME", DBNull.Value); } 
					if (pl_config_user_role.USER_ROLE != null) { command.Parameters.AddWithValue("@USER_ROLE", pl_config_user_role.USER_ROLE); } else { command.Parameters.AddWithValue("@USER_ROLE", DBNull.Value); } 
					command.ExecuteNonQuery();
				}
				catch (Exception ex)
				{
					Message = ex.Message;
				}
			}
		}

		public void UpdateMany(List<PL_CONFIG_USER_ROLE> pl_config_user_roles)
		{
			using (var conn = new SqlConnection(connString))
			{
				try
				{
					Message = "";
					conn.Open();
					foreach(PL_CONFIG_USER_ROLE item in pl_config_user_roles)
					{
						SqlCommand command = new SqlCommand("UPDATE PL_CONFIG_USER_ROLE SET USER_NAME = @USER_NAME, USER_ROLE = @USER_ROLE WHERE ID = @ID", conn);
						command.CommandType = System.Data.CommandType.Text;
						if (item.ID != null) { command.Parameters.AddWithValue("@ID", item.ID); } else { command.Parameters.AddWithValue("@ID", DBNull.Value); } 
						if (item.USER_NAME != null) { command.Parameters.AddWithValue("@USER_NAME", item.USER_NAME); } else { command.Parameters.AddWithValue("@USER_NAME", DBNull.Value); } 
						if (item.USER_ROLE != null) { command.Parameters.AddWithValue("@USER_ROLE", item.USER_ROLE); } else { command.Parameters.AddWithValue("@USER_ROLE", DBNull.Value); } 
						command.ExecuteNonQuery();
					}
				}
				catch (Exception ex)
				{
					Message = ex.Message;
				}
			}
		}

		public void Remove(PL_CONFIG_USER_ROLE id)
		{
			using (var conn = new SqlConnection(connString))
			{
				try
				{
					Message = "";
					conn.Open();
					SqlCommand command = new SqlCommand("DELETE PL_CONFIG_USER_ROLE WHERE ID = @ID", conn);
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

		public List<PL_CONFIG_USER_ROLE> GetData()
		{
			List<PL_CONFIG_USER_ROLE> items = new List<PL_CONFIG_USER_ROLE>();
			using (var conn = new SqlConnection(connString))
			{
				Message = "";
				try
				{
					conn.Open();
					SqlCommand command = new SqlCommand("SELECT [ID], [USER_NAME], [USER_ROLE] FROM PL_CONFIG_USER_ROLE", conn);
					SqlDataReader reader = command.ExecuteReader();
					PL_CONFIG_USER_ROLE item = new PL_CONFIG_USER_ROLE();
					while(reader.Read())
					{
						item = new PL_CONFIG_USER_ROLE();
						if (reader[0] != DBNull.Value) { item.ID = Convert.ToInt32(reader[0]); }
						if (reader[1] != DBNull.Value) { item.USER_NAME = Convert.ToString(reader[1]); }
						if (reader[2] != DBNull.Value) { item.USER_ROLE = Convert.ToString(reader[2]); }
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

		public List<PL_CONFIG_USER_ROLE> GetDataByID(int ID)
		{
			List<PL_CONFIG_USER_ROLE> items = new List<PL_CONFIG_USER_ROLE>();
			using (var conn = new SqlConnection(connString))
			{
				Message = "";
				try
				{
					conn.Open();
					SqlCommand command = new SqlCommand("SELECT [ID], [USER_NAME], [USER_ROLE] FROM PL_CONFIG_USER_ROLE WHERE ID = @ID", conn);
					command.Parameters.AddWithValue("@ID", ID);
					SqlDataReader reader = command.ExecuteReader();
					PL_CONFIG_USER_ROLE item = new PL_CONFIG_USER_ROLE();
					while(reader.Read())
					{
						item = new PL_CONFIG_USER_ROLE();
						if (reader[0] != DBNull.Value) { item.ID = Convert.ToInt32(reader[0]); }
						if (reader[1] != DBNull.Value) { item.USER_NAME = Convert.ToString(reader[1]); }
						if (reader[2] != DBNull.Value) { item.USER_ROLE = Convert.ToString(reader[2]); }
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
					SqlCommand command = new SqlCommand("DELETE PL_CONFIG_USER_ROLE WHERE ID = @ID", conn);
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

		public DataTable GetDataTable(List<PL_CONFIG_USER_ROLE> pl_config_user_role)
		{
			DataTable dt = new DataTable("PL_CONFIG_USER_ROLE");

			DataColumn c1 = new DataColumn("ID", typeof(int)); 
			dt.Columns.Add(c1);
			DataColumn c2 = new DataColumn("USER_NAME", typeof(string)); c2.AllowDBNull = true;
			dt.Columns.Add(c2);
			DataColumn c3 = new DataColumn("USER_ROLE", typeof(string)); c3.AllowDBNull = true;
			dt.Columns.Add(c3);

			foreach (PL_CONFIG_USER_ROLE v in pl_config_user_role)
			{
				DataRow dr = dt.NewRow();
				if (v.ID != null) { dr[0] = v.ID; } else { dr[0] = DBNull.Value; }
				if (v.USER_NAME != null) { dr[1] = v.USER_NAME; } else { dr[1] = DBNull.Value; }
				if (v.USER_ROLE != null) { dr[2] = v.USER_ROLE; } else { dr[2] = DBNull.Value; }
				dt.Rows.Add(dr);
			}
			dt.AcceptChanges();

			return dt;
		}

		public void AddManyBulk(List<PL_CONFIG_USER_ROLE> pl_config_user_role)
		{
			using (var conn = new SqlConnection(connString))
			{
				try
				{
					Message = "";
					conn.Open();

					DataTable dt = GetDataTable(pl_config_user_role);
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