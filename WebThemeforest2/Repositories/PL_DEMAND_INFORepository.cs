using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using WebThemeforest2.Models;

namespace WebThemeforest2.Repositories
{
	public partial class PL_DEMAND_INFORepository
	{
		private string connString;
		public string Message { get; set; }

		public PL_DEMAND_INFORepository(string connectionString)
		{
			connString = connectionString;
		}

		public void Add(PL_DEMAND_INFO pl_demand_info)
		{
			using (var conn = new SqlConnection(connString))
			{
				try
				{
					Message = "";
					conn.Open();
					SqlCommand command = new SqlCommand("INSERT INTO PL_DEMAND_INFO ([IDRefPelanggan], [AreaID], [Name], [Latitude], [Longitude], [Altitude], [Geometry]) VALUES(@IDRefPelanggan, @AreaID, @Name, @Latitude, @Longitude, @Altitude, @Geometry)", conn);
					command.CommandType = System.Data.CommandType.Text;
					if (pl_demand_info.IDRefPelanggan != null) { command.Parameters.AddWithValue("@IDRefPelanggan", pl_demand_info.IDRefPelanggan); } else { command.Parameters.AddWithValue("@IDRefPelanggan", DBNull.Value); } 
					if (pl_demand_info.AreaID != null) { command.Parameters.AddWithValue("@AreaID", pl_demand_info.AreaID); } else { command.Parameters.AddWithValue("@AreaID", DBNull.Value); } 
					if (pl_demand_info.Name != null) { command.Parameters.AddWithValue("@Name", pl_demand_info.Name); } else { command.Parameters.AddWithValue("@Name", DBNull.Value); } 
					if (pl_demand_info.Latitude != null) { command.Parameters.AddWithValue("@Latitude", pl_demand_info.Latitude); } else { command.Parameters.AddWithValue("@Latitude", DBNull.Value); } 
					if (pl_demand_info.Longitude != null) { command.Parameters.AddWithValue("@Longitude", pl_demand_info.Longitude); } else { command.Parameters.AddWithValue("@Longitude", DBNull.Value); } 
					if (pl_demand_info.Altitude != null) { command.Parameters.AddWithValue("@Altitude", pl_demand_info.Altitude); } else { command.Parameters.AddWithValue("@Altitude", DBNull.Value); } 
					if (pl_demand_info.Geometry != null) { command.Parameters.AddWithValue("@Geometry", pl_demand_info.Geometry); } else { command.Parameters.AddWithValue("@Geometry", DBNull.Value); } 
					command.ExecuteNonQuery();
				}
				catch (Exception ex)
				{
					Message = ex.Message;
				}
			}
		}

		public void AddMany(List<PL_DEMAND_INFO> pl_demand_info)
		{
			using (var conn = new SqlConnection(connString))
			{
				try
				{
					Message = "";
					conn.Open();
					int pos = 0;
					foreach(PL_DEMAND_INFO item in pl_demand_info)
					{
						SqlCommand command = new SqlCommand("INSERT INTO PL_DEMAND_INFO ([IDRefPelanggan], [AreaID], [Name], [Latitude], [Longitude], [Altitude], [Geometry]) VALUES(@IDRefPelanggan, @AreaID, @Name, @Latitude, @Longitude, @Altitude, @Geometry)", conn);
						command.CommandType = System.Data.CommandType.Text;
						if (pl_demand_info[pos].IDRefPelanggan != null) { command.Parameters.AddWithValue("@IDRefPelanggan", pl_demand_info[pos].IDRefPelanggan); } else { command.Parameters.AddWithValue("@IDRefPelanggan", DBNull.Value); } 
						if (pl_demand_info[pos].AreaID != null) { command.Parameters.AddWithValue("@AreaID", pl_demand_info[pos].AreaID); } else { command.Parameters.AddWithValue("@AreaID", DBNull.Value); } 
						if (pl_demand_info[pos].Name != null) { command.Parameters.AddWithValue("@Name", pl_demand_info[pos].Name); } else { command.Parameters.AddWithValue("@Name", DBNull.Value); } 
						if (pl_demand_info[pos].Latitude != null) { command.Parameters.AddWithValue("@Latitude", pl_demand_info[pos].Latitude); } else { command.Parameters.AddWithValue("@Latitude", DBNull.Value); } 
						if (pl_demand_info[pos].Longitude != null) { command.Parameters.AddWithValue("@Longitude", pl_demand_info[pos].Longitude); } else { command.Parameters.AddWithValue("@Longitude", DBNull.Value); } 
						if (pl_demand_info[pos].Altitude != null) { command.Parameters.AddWithValue("@Altitude", pl_demand_info[pos].Altitude); } else { command.Parameters.AddWithValue("@Altitude", DBNull.Value); } 
						if (pl_demand_info[pos].Geometry != null) { command.Parameters.AddWithValue("@Geometry", pl_demand_info[pos].Geometry); } else { command.Parameters.AddWithValue("@Geometry", DBNull.Value); } 
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

		public void Update(PL_DEMAND_INFO pl_demand_info)
		{
			using (var conn = new SqlConnection(connString))
			{
				try
				{
					Message = "";
					conn.Open();
					SqlCommand command = new SqlCommand("UPDATE PL_DEMAND_INFO SET Latitude = @Latitude, Longitude = @Longitude, Altitude = @Altitude, Geometry = @Geometry WHERE IDRefPelanggan = @IDRefPelanggan AND AreaID = @AreaID AND Name = @Name", conn);
					command.CommandType = System.Data.CommandType.Text;
					if (pl_demand_info.IDRefPelanggan != null) { command.Parameters.AddWithValue("@IDRefPelanggan", pl_demand_info.IDRefPelanggan); } else { command.Parameters.AddWithValue("@IDRefPelanggan", DBNull.Value); } 
					if (pl_demand_info.AreaID != null) { command.Parameters.AddWithValue("@AreaID", pl_demand_info.AreaID); } else { command.Parameters.AddWithValue("@AreaID", DBNull.Value); } 
					if (pl_demand_info.Name != null) { command.Parameters.AddWithValue("@Name", pl_demand_info.Name); } else { command.Parameters.AddWithValue("@Name", DBNull.Value); } 
					if (pl_demand_info.Latitude != null) { command.Parameters.AddWithValue("@Latitude", pl_demand_info.Latitude); } else { command.Parameters.AddWithValue("@Latitude", DBNull.Value); } 
					if (pl_demand_info.Longitude != null) { command.Parameters.AddWithValue("@Longitude", pl_demand_info.Longitude); } else { command.Parameters.AddWithValue("@Longitude", DBNull.Value); } 
					if (pl_demand_info.Altitude != null) { command.Parameters.AddWithValue("@Altitude", pl_demand_info.Altitude); } else { command.Parameters.AddWithValue("@Altitude", DBNull.Value); } 
					if (pl_demand_info.Geometry != null) { command.Parameters.AddWithValue("@Geometry", pl_demand_info.Geometry); } else { command.Parameters.AddWithValue("@Geometry", DBNull.Value); } 
					command.ExecuteNonQuery();
				}
				catch (Exception ex)
				{
					Message = ex.Message;
				}
			}
		}

		public void UpdateMany(List<PL_DEMAND_INFO> pl_demand_infos)
		{
			using (var conn = new SqlConnection(connString))
			{
				try
				{
					Message = "";
					conn.Open();
					foreach(PL_DEMAND_INFO item in pl_demand_infos)
					{
						SqlCommand command = new SqlCommand("UPDATE PL_DEMAND_INFO SET Latitude = @Latitude, Longitude = @Longitude, Altitude = @Altitude, Geometry = @Geometry WHERE IDRefPelanggan = @IDRefPelanggan AND AreaID = @AreaID AND Name = @Name", conn);
						command.CommandType = System.Data.CommandType.Text;
						if (item.IDRefPelanggan != null) { command.Parameters.AddWithValue("@IDRefPelanggan", item.IDRefPelanggan); } else { command.Parameters.AddWithValue("@IDRefPelanggan", DBNull.Value); } 
						if (item.AreaID != null) { command.Parameters.AddWithValue("@AreaID", item.AreaID); } else { command.Parameters.AddWithValue("@AreaID", DBNull.Value); } 
						if (item.Name != null) { command.Parameters.AddWithValue("@Name", item.Name); } else { command.Parameters.AddWithValue("@Name", DBNull.Value); } 
						if (item.Latitude != null) { command.Parameters.AddWithValue("@Latitude", item.Latitude); } else { command.Parameters.AddWithValue("@Latitude", DBNull.Value); } 
						if (item.Longitude != null) { command.Parameters.AddWithValue("@Longitude", item.Longitude); } else { command.Parameters.AddWithValue("@Longitude", DBNull.Value); } 
						if (item.Altitude != null) { command.Parameters.AddWithValue("@Altitude", item.Altitude); } else { command.Parameters.AddWithValue("@Altitude", DBNull.Value); } 
						if (item.Geometry != null) { command.Parameters.AddWithValue("@Geometry", item.Geometry); } else { command.Parameters.AddWithValue("@Geometry", DBNull.Value); } 
						command.ExecuteNonQuery();
					}
				}
				catch (Exception ex)
				{
					Message = ex.Message;
				}
			}
		}

		public void Remove(PL_DEMAND_INFO id)
		{
			using (var conn = new SqlConnection(connString))
			{
				try
				{
					Message = "";
					conn.Open();
					SqlCommand command = new SqlCommand("DELETE PL_DEMAND_INFO WHERE IDRefPelanggan = @IDRefPelanggan AND AreaID = @AreaID AND Name = @Name", conn);
					command.CommandType = System.Data.CommandType.Text;
					if (id.IDRefPelanggan != null) { command.Parameters.AddWithValue("@IDRefPelanggan", id.IDRefPelanggan); } else { command.Parameters.AddWithValue("@IDRefPelanggan", DBNull.Value); } 
					if (id.AreaID != null) { command.Parameters.AddWithValue("@AreaID", id.AreaID); } else { command.Parameters.AddWithValue("@AreaID", DBNull.Value); } 
					if (id.Name != null) { command.Parameters.AddWithValue("@Name", id.Name); } else { command.Parameters.AddWithValue("@Name", DBNull.Value); } 
					command.ExecuteNonQuery();
				}
				catch (Exception ex)
				{
					Message = ex.Message;
				}
			}
		}

		public List<PL_DEMAND_INFO> GetData()
		{
			List<PL_DEMAND_INFO> items = new List<PL_DEMAND_INFO>();
			using (var conn = new SqlConnection(connString))
			{
				Message = "";
				try
				{
					conn.Open();
					SqlCommand command = new SqlCommand("SELECT [IDRefPelanggan], [AreaID], [Name], [Latitude], [Longitude], [Altitude], [Geometry] FROM PL_DEMAND_INFO", conn);
					SqlDataReader reader = command.ExecuteReader();
					PL_DEMAND_INFO item = new PL_DEMAND_INFO();
					while(reader.Read())
					{
						item = new PL_DEMAND_INFO();
						if (reader[0] != DBNull.Value) { item.IDRefPelanggan = Convert.ToString(reader[0]); }
						if (reader[1] != DBNull.Value) { item.AreaID = Convert.ToString(reader[1]); }
						if (reader[2] != DBNull.Value) { item.Name = Convert.ToString(reader[2]); }
						if (reader[3] != DBNull.Value) { item.Latitude = Convert.ToDouble(reader[3]); }
						if (reader[4] != DBNull.Value) { item.Longitude = Convert.ToDouble(reader[4]); }
						if (reader[5] != DBNull.Value) { item.Altitude = Convert.ToDouble(reader[5]); }
						if (reader[6] != DBNull.Value) { item.Geometry = Convert.ToString(reader[6]); }
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

		public List<PL_DEMAND_INFO> GetDataByIDRefPelanggan(string IDRefPelanggan)
		{
			List<PL_DEMAND_INFO> items = new List<PL_DEMAND_INFO>();
			using (var conn = new SqlConnection(connString))
			{
				Message = "";
				try
				{
					conn.Open();
					SqlCommand command = new SqlCommand("SELECT [IDRefPelanggan], [AreaID], [Name], [Latitude], [Longitude], [Altitude], [Geometry] FROM PL_DEMAND_INFO WHERE IDRefPelanggan = @IDRefPelanggan", conn);
					command.Parameters.AddWithValue("@IDRefPelanggan", IDRefPelanggan);
					SqlDataReader reader = command.ExecuteReader();
					PL_DEMAND_INFO item = new PL_DEMAND_INFO();
					while(reader.Read())
					{
						item = new PL_DEMAND_INFO();
						if (reader[0] != DBNull.Value) { item.IDRefPelanggan = Convert.ToString(reader[0]); }
						if (reader[1] != DBNull.Value) { item.AreaID = Convert.ToString(reader[1]); }
						if (reader[2] != DBNull.Value) { item.Name = Convert.ToString(reader[2]); }
						if (reader[3] != DBNull.Value) { item.Latitude = Convert.ToDouble(reader[3]); }
						if (reader[4] != DBNull.Value) { item.Longitude = Convert.ToDouble(reader[4]); }
						if (reader[5] != DBNull.Value) { item.Altitude = Convert.ToDouble(reader[5]); }
						if (reader[6] != DBNull.Value) { item.Geometry = Convert.ToString(reader[6]); }
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

		public List<PL_DEMAND_INFO> GetDataByAreaID(string AreaID)
		{
			List<PL_DEMAND_INFO> items = new List<PL_DEMAND_INFO>();
			using (var conn = new SqlConnection(connString))
			{
				Message = "";
				try
				{
					conn.Open();
					SqlCommand command = new SqlCommand("SELECT [IDRefPelanggan], [AreaID], [Name], [Latitude], [Longitude], [Altitude], [Geometry] FROM PL_DEMAND_INFO WHERE AreaID = @AreaID", conn);
					command.Parameters.AddWithValue("@AreaID", AreaID);
					SqlDataReader reader = command.ExecuteReader();
					PL_DEMAND_INFO item = new PL_DEMAND_INFO();
					while(reader.Read())
					{
						item = new PL_DEMAND_INFO();
						if (reader[0] != DBNull.Value) { item.IDRefPelanggan = Convert.ToString(reader[0]); }
						if (reader[1] != DBNull.Value) { item.AreaID = Convert.ToString(reader[1]); }
						if (reader[2] != DBNull.Value) { item.Name = Convert.ToString(reader[2]); }
						if (reader[3] != DBNull.Value) { item.Latitude = Convert.ToDouble(reader[3]); }
						if (reader[4] != DBNull.Value) { item.Longitude = Convert.ToDouble(reader[4]); }
						if (reader[5] != DBNull.Value) { item.Altitude = Convert.ToDouble(reader[5]); }
						if (reader[6] != DBNull.Value) { item.Geometry = Convert.ToString(reader[6]); }
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

		public List<PL_DEMAND_INFO> GetDataByName(string Name)
		{
			List<PL_DEMAND_INFO> items = new List<PL_DEMAND_INFO>();
			using (var conn = new SqlConnection(connString))
			{
				Message = "";
				try
				{
					conn.Open();
					SqlCommand command = new SqlCommand("SELECT [IDRefPelanggan], [AreaID], [Name], [Latitude], [Longitude], [Altitude], [Geometry] FROM PL_DEMAND_INFO WHERE Name = @Name", conn);
					command.Parameters.AddWithValue("@Name", Name);
					SqlDataReader reader = command.ExecuteReader();
					PL_DEMAND_INFO item = new PL_DEMAND_INFO();
					while(reader.Read())
					{
						item = new PL_DEMAND_INFO();
						if (reader[0] != DBNull.Value) { item.IDRefPelanggan = Convert.ToString(reader[0]); }
						if (reader[1] != DBNull.Value) { item.AreaID = Convert.ToString(reader[1]); }
						if (reader[2] != DBNull.Value) { item.Name = Convert.ToString(reader[2]); }
						if (reader[3] != DBNull.Value) { item.Latitude = Convert.ToDouble(reader[3]); }
						if (reader[4] != DBNull.Value) { item.Longitude = Convert.ToDouble(reader[4]); }
						if (reader[5] != DBNull.Value) { item.Altitude = Convert.ToDouble(reader[5]); }
						if (reader[6] != DBNull.Value) { item.Geometry = Convert.ToString(reader[6]); }
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

		public void RemoveByIDRefPelanggan(string id)
		{
			using (var conn = new SqlConnection(connString))
			{
				try
				{
					Message = "";
					conn.Open();
					SqlCommand command = new SqlCommand("DELETE PL_DEMAND_INFO WHERE IDRefPelanggan = @IDRefPelanggan", conn);
					command.CommandType = System.Data.CommandType.Text;
					if (id != null) { command.Parameters.AddWithValue("@IDRefPelanggan", id); } else { command.Parameters.AddWithValue("@IDRefPelanggan", DBNull.Value); } 
					command.ExecuteNonQuery();
				}
				catch (Exception ex)
				{
					Message = ex.Message;
				}
			}
		}

		public void RemoveByAreaID(string id)
		{
			using (var conn = new SqlConnection(connString))
			{
				try
				{
					Message = "";
					conn.Open();
					SqlCommand command = new SqlCommand("DELETE PL_DEMAND_INFO WHERE AreaID = @AreaID", conn);
					command.CommandType = System.Data.CommandType.Text;
					if (id != null) { command.Parameters.AddWithValue("@AreaID", id); } else { command.Parameters.AddWithValue("@AreaID", DBNull.Value); } 
					command.ExecuteNonQuery();
				}
				catch (Exception ex)
				{
					Message = ex.Message;
				}
			}
		}

		public void RemoveByName(string id)
		{
			using (var conn = new SqlConnection(connString))
			{
				try
				{
					Message = "";
					conn.Open();
					SqlCommand command = new SqlCommand("DELETE PL_DEMAND_INFO WHERE Name = @Name", conn);
					command.CommandType = System.Data.CommandType.Text;
					if (id != null) { command.Parameters.AddWithValue("@Name", id); } else { command.Parameters.AddWithValue("@Name", DBNull.Value); } 
					command.ExecuteNonQuery();
				}
				catch (Exception ex)
				{
					Message = ex.Message;
				}
			}
		}

		public DataTable GetDataTable(List<PL_DEMAND_INFO> pl_demand_info)
		{
			DataTable dt = new DataTable("PL_DEMAND_INFO");

			DataColumn c1 = new DataColumn("IDRefPelanggan", typeof(string)); 
			dt.Columns.Add(c1);
			DataColumn c2 = new DataColumn("AreaID", typeof(string)); 
			dt.Columns.Add(c2);
			DataColumn c3 = new DataColumn("Name", typeof(string)); 
			dt.Columns.Add(c3);
			DataColumn c4 = new DataColumn("Latitude", typeof(double)); c4.AllowDBNull = true;
			dt.Columns.Add(c4);
			DataColumn c5 = new DataColumn("Longitude", typeof(double)); c5.AllowDBNull = true;
			dt.Columns.Add(c5);
			DataColumn c6 = new DataColumn("Altitude", typeof(double)); c6.AllowDBNull = true;
			dt.Columns.Add(c6);
			DataColumn c7 = new DataColumn("Geometry", typeof(string)); c7.AllowDBNull = true;
			dt.Columns.Add(c7);

			foreach (PL_DEMAND_INFO v in pl_demand_info)
			{
				DataRow dr = dt.NewRow();
				if (v.IDRefPelanggan != null) { dr[0] = v.IDRefPelanggan; } else { dr[0] = DBNull.Value; }
				if (v.AreaID != null) { dr[1] = v.AreaID; } else { dr[1] = DBNull.Value; }
				if (v.Name != null) { dr[2] = v.Name; } else { dr[2] = DBNull.Value; }
				if (v.Latitude != null) { dr[3] = v.Latitude; } else { dr[3] = DBNull.Value; }
				if (v.Longitude != null) { dr[4] = v.Longitude; } else { dr[4] = DBNull.Value; }
				if (v.Altitude != null) { dr[5] = v.Altitude; } else { dr[5] = DBNull.Value; }
				if (v.Geometry != null) { dr[6] = v.Geometry; } else { dr[6] = DBNull.Value; }
				dt.Rows.Add(dr);
			}
			dt.AcceptChanges();

			return dt;
		}

		public void AddManyBulk(List<PL_DEMAND_INFO> pl_demand_info)
		{
			using (var conn = new SqlConnection(connString))
			{
				try
				{
					Message = "";
					conn.Open();

					DataTable dt = GetDataTable(pl_demand_info);
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