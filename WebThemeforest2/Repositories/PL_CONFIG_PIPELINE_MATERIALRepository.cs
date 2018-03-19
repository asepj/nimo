using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using WebThemeforest2.Models;

namespace WebThemeforest2.Repositories
{
	public partial class PL_CONFIG_PIPELINE_MATERIALRepository
	{
		private string connString;
		public string Message { get; set; }

		public PL_CONFIG_PIPELINE_MATERIALRepository(string connectionString)
		{
			connString = connectionString;
		}

		public void Add(PL_CONFIG_PIPELINE_MATERIAL pl_config_pipeline_material)
		{
			using (var conn = new SqlConnection(connString))
			{
				try
				{
					Message = "";
					conn.Open();
					SqlCommand command = new SqlCommand("INSERT INTO PL_CONFIG_PIPELINE_MATERIAL ([MATERIAL_ID], [MATERIAL_CODE], [MATERIAL_NAME], [ROUGHNESS]) VALUES(@MATERIAL_ID, @MATERIAL_CODE, @MATERIAL_NAME, @ROUGHNESS)", conn);
					command.CommandType = System.Data.CommandType.Text;
					if (pl_config_pipeline_material.MATERIAL_ID != null) { command.Parameters.AddWithValue("@MATERIAL_ID", pl_config_pipeline_material.MATERIAL_ID); } else { command.Parameters.AddWithValue("@MATERIAL_ID", DBNull.Value); } 
					if (pl_config_pipeline_material.MATERIAL_CODE != null) { command.Parameters.AddWithValue("@MATERIAL_CODE", pl_config_pipeline_material.MATERIAL_CODE); } else { command.Parameters.AddWithValue("@MATERIAL_CODE", DBNull.Value); } 
					if (pl_config_pipeline_material.MATERIAL_NAME != null) { command.Parameters.AddWithValue("@MATERIAL_NAME", pl_config_pipeline_material.MATERIAL_NAME); } else { command.Parameters.AddWithValue("@MATERIAL_NAME", DBNull.Value); } 
					if (pl_config_pipeline_material.ROUGHNESS != null) { command.Parameters.AddWithValue("@ROUGHNESS", pl_config_pipeline_material.ROUGHNESS); } else { command.Parameters.AddWithValue("@ROUGHNESS", DBNull.Value); } 
					command.ExecuteNonQuery();
				}
				catch (Exception ex)
				{
					Message = ex.Message;
				}
			}
		}

		public void AddMany(List<PL_CONFIG_PIPELINE_MATERIAL> pl_config_pipeline_material)
		{
			using (var conn = new SqlConnection(connString))
			{
				try
				{
					Message = "";
					conn.Open();
					int pos = 0;
					foreach(PL_CONFIG_PIPELINE_MATERIAL item in pl_config_pipeline_material)
					{
						SqlCommand command = new SqlCommand("INSERT INTO PL_CONFIG_PIPELINE_MATERIAL ([MATERIAL_ID], [MATERIAL_CODE], [MATERIAL_NAME], [ROUGHNESS]) VALUES(@MATERIAL_ID, @MATERIAL_CODE, @MATERIAL_NAME, @ROUGHNESS)", conn);
						command.CommandType = System.Data.CommandType.Text;
						if (pl_config_pipeline_material[pos].MATERIAL_ID != null) { command.Parameters.AddWithValue("@MATERIAL_ID", pl_config_pipeline_material[pos].MATERIAL_ID); } else { command.Parameters.AddWithValue("@MATERIAL_ID", DBNull.Value); } 
						if (pl_config_pipeline_material[pos].MATERIAL_CODE != null) { command.Parameters.AddWithValue("@MATERIAL_CODE", pl_config_pipeline_material[pos].MATERIAL_CODE); } else { command.Parameters.AddWithValue("@MATERIAL_CODE", DBNull.Value); } 
						if (pl_config_pipeline_material[pos].MATERIAL_NAME != null) { command.Parameters.AddWithValue("@MATERIAL_NAME", pl_config_pipeline_material[pos].MATERIAL_NAME); } else { command.Parameters.AddWithValue("@MATERIAL_NAME", DBNull.Value); } 
						if (pl_config_pipeline_material[pos].ROUGHNESS != null) { command.Parameters.AddWithValue("@ROUGHNESS", pl_config_pipeline_material[pos].ROUGHNESS); } else { command.Parameters.AddWithValue("@ROUGHNESS", DBNull.Value); } 
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

		public void Update(PL_CONFIG_PIPELINE_MATERIAL pl_config_pipeline_material)
		{
			using (var conn = new SqlConnection(connString))
			{
				try
				{
					Message = "";
					conn.Open();
					SqlCommand command = new SqlCommand("UPDATE PL_CONFIG_PIPELINE_MATERIAL SET MATERIAL_CODE = @MATERIAL_CODE, MATERIAL_NAME = @MATERIAL_NAME WHERE MATERIAL_ID = @MATERIAL_ID AND ROUGHNESS = @ROUGHNESS", conn);
					command.CommandType = System.Data.CommandType.Text;
					if (pl_config_pipeline_material.MATERIAL_ID != null) { command.Parameters.AddWithValue("@MATERIAL_ID", pl_config_pipeline_material.MATERIAL_ID); } else { command.Parameters.AddWithValue("@MATERIAL_ID", DBNull.Value); } 
					if (pl_config_pipeline_material.ROUGHNESS != null) { command.Parameters.AddWithValue("@ROUGHNESS", pl_config_pipeline_material.ROUGHNESS); } else { command.Parameters.AddWithValue("@ROUGHNESS", DBNull.Value); } 
					if (pl_config_pipeline_material.MATERIAL_CODE != null) { command.Parameters.AddWithValue("@MATERIAL_CODE", pl_config_pipeline_material.MATERIAL_CODE); } else { command.Parameters.AddWithValue("@MATERIAL_CODE", DBNull.Value); } 
					if (pl_config_pipeline_material.MATERIAL_NAME != null) { command.Parameters.AddWithValue("@MATERIAL_NAME", pl_config_pipeline_material.MATERIAL_NAME); } else { command.Parameters.AddWithValue("@MATERIAL_NAME", DBNull.Value); } 
					command.ExecuteNonQuery();
				}
				catch (Exception ex)
				{
					Message = ex.Message;
				}
			}
		}

		public void UpdateMany(List<PL_CONFIG_PIPELINE_MATERIAL> pl_config_pipeline_materials)
		{
			using (var conn = new SqlConnection(connString))
			{
				try
				{
					Message = "";
					conn.Open();
					foreach(PL_CONFIG_PIPELINE_MATERIAL item in pl_config_pipeline_materials)
					{
						SqlCommand command = new SqlCommand("UPDATE PL_CONFIG_PIPELINE_MATERIAL SET MATERIAL_CODE = @MATERIAL_CODE, MATERIAL_NAME = @MATERIAL_NAME WHERE MATERIAL_ID = @MATERIAL_ID AND ROUGHNESS = @ROUGHNESS", conn);
						command.CommandType = System.Data.CommandType.Text;
						if (item.MATERIAL_ID != null) { command.Parameters.AddWithValue("@MATERIAL_ID", item.MATERIAL_ID); } else { command.Parameters.AddWithValue("@MATERIAL_ID", DBNull.Value); } 
						if (item.ROUGHNESS != null) { command.Parameters.AddWithValue("@ROUGHNESS", item.ROUGHNESS); } else { command.Parameters.AddWithValue("@ROUGHNESS", DBNull.Value); } 
						if (item.MATERIAL_CODE != null) { command.Parameters.AddWithValue("@MATERIAL_CODE", item.MATERIAL_CODE); } else { command.Parameters.AddWithValue("@MATERIAL_CODE", DBNull.Value); } 
						if (item.MATERIAL_NAME != null) { command.Parameters.AddWithValue("@MATERIAL_NAME", item.MATERIAL_NAME); } else { command.Parameters.AddWithValue("@MATERIAL_NAME", DBNull.Value); } 
						command.ExecuteNonQuery();
					}
				}
				catch (Exception ex)
				{
					Message = ex.Message;
				}
			}
		}

		public void Remove(PL_CONFIG_PIPELINE_MATERIAL id)
		{
			using (var conn = new SqlConnection(connString))
			{
				try
				{
					Message = "";
					conn.Open();
					SqlCommand command = new SqlCommand("DELETE PL_CONFIG_PIPELINE_MATERIAL WHERE MATERIAL_ID = @MATERIAL_ID AND ROUGHNESS = @ROUGHNESS", conn);
					command.CommandType = System.Data.CommandType.Text;
					if (id.MATERIAL_ID != null) { command.Parameters.AddWithValue("@MATERIAL_ID", id.MATERIAL_ID); } else { command.Parameters.AddWithValue("@MATERIAL_ID", DBNull.Value); } 
					if (id.ROUGHNESS != null) { command.Parameters.AddWithValue("@ROUGHNESS", id.ROUGHNESS); } else { command.Parameters.AddWithValue("@ROUGHNESS", DBNull.Value); } 
					command.ExecuteNonQuery();
				}
				catch (Exception ex)
				{
					Message = ex.Message;
				}
			}
		}

		public List<PL_CONFIG_PIPELINE_MATERIAL> GetData()
		{
			List<PL_CONFIG_PIPELINE_MATERIAL> items = new List<PL_CONFIG_PIPELINE_MATERIAL>();
			using (var conn = new SqlConnection(connString))
			{
				Message = "";
				try
				{
					conn.Open();
					SqlCommand command = new SqlCommand("SELECT [MATERIAL_ID], [MATERIAL_CODE], [MATERIAL_NAME], [ROUGHNESS] FROM PL_CONFIG_PIPELINE_MATERIAL", conn);
					SqlDataReader reader = command.ExecuteReader();
					PL_CONFIG_PIPELINE_MATERIAL item = new PL_CONFIG_PIPELINE_MATERIAL();
					while(reader.Read())
					{
						item = new PL_CONFIG_PIPELINE_MATERIAL();
						if (reader[0] != DBNull.Value) { item.MATERIAL_ID = Convert.ToInt32(reader[0]); }
						if (reader[1] != DBNull.Value) { item.MATERIAL_CODE = Convert.ToString(reader[1]); }
						if (reader[2] != DBNull.Value) { item.MATERIAL_NAME = Convert.ToString(reader[2]); }
						if (reader[3] != DBNull.Value) { item.ROUGHNESS = Convert.ToDouble(reader[3]); }
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

		public List<PL_CONFIG_PIPELINE_MATERIAL> GetDataByMATERIAL_ID(int MATERIAL_ID)
		{
			List<PL_CONFIG_PIPELINE_MATERIAL> items = new List<PL_CONFIG_PIPELINE_MATERIAL>();
			using (var conn = new SqlConnection(connString))
			{
				Message = "";
				try
				{
					conn.Open();
					SqlCommand command = new SqlCommand("SELECT [MATERIAL_ID], [MATERIAL_CODE], [MATERIAL_NAME], [ROUGHNESS] FROM PL_CONFIG_PIPELINE_MATERIAL WHERE MATERIAL_ID = @MATERIAL_ID", conn);
					command.Parameters.AddWithValue("@MATERIAL_ID", MATERIAL_ID);
					SqlDataReader reader = command.ExecuteReader();
					PL_CONFIG_PIPELINE_MATERIAL item = new PL_CONFIG_PIPELINE_MATERIAL();
					while(reader.Read())
					{
						item = new PL_CONFIG_PIPELINE_MATERIAL();
						if (reader[0] != DBNull.Value) { item.MATERIAL_ID = Convert.ToInt32(reader[0]); }
						if (reader[1] != DBNull.Value) { item.MATERIAL_CODE = Convert.ToString(reader[1]); }
						if (reader[2] != DBNull.Value) { item.MATERIAL_NAME = Convert.ToString(reader[2]); }
						if (reader[3] != DBNull.Value) { item.ROUGHNESS = Convert.ToDouble(reader[3]); }
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

		public List<PL_CONFIG_PIPELINE_MATERIAL> GetDataByROUGHNESS(double ROUGHNESS)
		{
			List<PL_CONFIG_PIPELINE_MATERIAL> items = new List<PL_CONFIG_PIPELINE_MATERIAL>();
			using (var conn = new SqlConnection(connString))
			{
				Message = "";
				try
				{
					conn.Open();
					SqlCommand command = new SqlCommand("SELECT [MATERIAL_ID], [MATERIAL_CODE], [MATERIAL_NAME], [ROUGHNESS] FROM PL_CONFIG_PIPELINE_MATERIAL WHERE ROUGHNESS = @ROUGHNESS", conn);
					command.Parameters.AddWithValue("@ROUGHNESS", ROUGHNESS);
					SqlDataReader reader = command.ExecuteReader();
					PL_CONFIG_PIPELINE_MATERIAL item = new PL_CONFIG_PIPELINE_MATERIAL();
					while(reader.Read())
					{
						item = new PL_CONFIG_PIPELINE_MATERIAL();
						if (reader[0] != DBNull.Value) { item.MATERIAL_ID = Convert.ToInt32(reader[0]); }
						if (reader[1] != DBNull.Value) { item.MATERIAL_CODE = Convert.ToString(reader[1]); }
						if (reader[2] != DBNull.Value) { item.MATERIAL_NAME = Convert.ToString(reader[2]); }
						if (reader[3] != DBNull.Value) { item.ROUGHNESS = Convert.ToDouble(reader[3]); }
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

		public void RemoveByMATERIAL_ID(int id)
		{
			using (var conn = new SqlConnection(connString))
			{
				try
				{
					Message = "";
					conn.Open();
					SqlCommand command = new SqlCommand("DELETE PL_CONFIG_PIPELINE_MATERIAL WHERE MATERIAL_ID = @MATERIAL_ID", conn);
					command.CommandType = System.Data.CommandType.Text;
					if (id != null) { command.Parameters.AddWithValue("@MATERIAL_ID", id); } else { command.Parameters.AddWithValue("@MATERIAL_ID", DBNull.Value); } 
					command.ExecuteNonQuery();
				}
				catch (Exception ex)
				{
					Message = ex.Message;
				}
			}
		}

		public void RemoveByROUGHNESS(double id)
		{
			using (var conn = new SqlConnection(connString))
			{
				try
				{
					Message = "";
					conn.Open();
					SqlCommand command = new SqlCommand("DELETE PL_CONFIG_PIPELINE_MATERIAL WHERE ROUGHNESS = @ROUGHNESS", conn);
					command.CommandType = System.Data.CommandType.Text;
					if (id != null) { command.Parameters.AddWithValue("@ROUGHNESS", id); } else { command.Parameters.AddWithValue("@ROUGHNESS", DBNull.Value); } 
					command.ExecuteNonQuery();
				}
				catch (Exception ex)
				{
					Message = ex.Message;
				}
			}
		}

		public DataTable GetDataTable(List<PL_CONFIG_PIPELINE_MATERIAL> pl_config_pipeline_material)
		{
			DataTable dt = new DataTable("PL_CONFIG_PIPELINE_MATERIAL");

			DataColumn c1 = new DataColumn("MATERIAL_ID", typeof(int)); 
			dt.Columns.Add(c1);
			DataColumn c2 = new DataColumn("MATERIAL_CODE", typeof(string)); c2.AllowDBNull = true;
			dt.Columns.Add(c2);
			DataColumn c3 = new DataColumn("MATERIAL_NAME", typeof(string)); c3.AllowDBNull = true;
			dt.Columns.Add(c3);
			DataColumn c4 = new DataColumn("ROUGHNESS", typeof(double)); 
			dt.Columns.Add(c4);

			foreach (PL_CONFIG_PIPELINE_MATERIAL v in pl_config_pipeline_material)
			{
				DataRow dr = dt.NewRow();
				if (v.MATERIAL_ID != null) { dr[0] = v.MATERIAL_ID; } else { dr[0] = DBNull.Value; }
				if (v.MATERIAL_CODE != null) { dr[1] = v.MATERIAL_CODE; } else { dr[1] = DBNull.Value; }
				if (v.MATERIAL_NAME != null) { dr[2] = v.MATERIAL_NAME; } else { dr[2] = DBNull.Value; }
				if (v.ROUGHNESS != null) { dr[3] = v.ROUGHNESS; } else { dr[3] = DBNull.Value; }
				dt.Rows.Add(dr);
			}
			dt.AcceptChanges();

			return dt;
		}

		public void AddManyBulk(List<PL_CONFIG_PIPELINE_MATERIAL> pl_config_pipeline_material)
		{
			using (var conn = new SqlConnection(connString))
			{
				try
				{
					Message = "";
					conn.Open();

					DataTable dt = GetDataTable(pl_config_pipeline_material);
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