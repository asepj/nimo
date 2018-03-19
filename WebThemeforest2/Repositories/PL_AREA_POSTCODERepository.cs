using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using WebThemeforest2.Models;

namespace WebThemeforest2.Repositories
{
	public partial class PL_AREA_POSTCODERepository
	{
		private string connString;
		public string Message { get; set; }

		public PL_AREA_POSTCODERepository(string connectionString)
		{
			connString = connectionString;
		}

		public void Add(PL_AREA_POSTCODE pl_area_postcode)
		{
			using (var conn = new SqlConnection(connString))
			{
				try
				{
					Message = "";
					conn.Open();
					SqlCommand command = new SqlCommand("INSERT INTO PL_AREA_POSTCODE ([KODE_POS], [KELURAHAN], [KECAMATAN], [JENIS], [KABUPATEN], [PROPINSI], [NAMA_AREA]) VALUES(@KODE_POS, @KELURAHAN, @KECAMATAN, @JENIS, @KABUPATEN, @PROPINSI, @NAMA_AREA)", conn);
					command.CommandType = System.Data.CommandType.Text;
					if (pl_area_postcode.KODE_POS != null) { command.Parameters.AddWithValue("@KODE_POS", pl_area_postcode.KODE_POS); } else { command.Parameters.AddWithValue("@KODE_POS", DBNull.Value); } 
					if (pl_area_postcode.KELURAHAN != null) { command.Parameters.AddWithValue("@KELURAHAN", pl_area_postcode.KELURAHAN); } else { command.Parameters.AddWithValue("@KELURAHAN", DBNull.Value); } 
					if (pl_area_postcode.KECAMATAN != null) { command.Parameters.AddWithValue("@KECAMATAN", pl_area_postcode.KECAMATAN); } else { command.Parameters.AddWithValue("@KECAMATAN", DBNull.Value); } 
					if (pl_area_postcode.JENIS != null) { command.Parameters.AddWithValue("@JENIS", pl_area_postcode.JENIS); } else { command.Parameters.AddWithValue("@JENIS", DBNull.Value); } 
					if (pl_area_postcode.KABUPATEN != null) { command.Parameters.AddWithValue("@KABUPATEN", pl_area_postcode.KABUPATEN); } else { command.Parameters.AddWithValue("@KABUPATEN", DBNull.Value); } 
					if (pl_area_postcode.PROPINSI != null) { command.Parameters.AddWithValue("@PROPINSI", pl_area_postcode.PROPINSI); } else { command.Parameters.AddWithValue("@PROPINSI", DBNull.Value); } 
					if (pl_area_postcode.NAMA_AREA != null) { command.Parameters.AddWithValue("@NAMA_AREA", pl_area_postcode.NAMA_AREA); } else { command.Parameters.AddWithValue("@NAMA_AREA", DBNull.Value); } 
					command.ExecuteNonQuery();
				}
				catch (Exception ex)
				{
					Message = ex.Message;
				}
			}
		}

		public void AddMany(List<PL_AREA_POSTCODE> pl_area_postcode)
		{
			using (var conn = new SqlConnection(connString))
			{
				try
				{
					Message = "";
					conn.Open();
					int pos = 0;
					foreach(PL_AREA_POSTCODE item in pl_area_postcode)
					{
						SqlCommand command = new SqlCommand("INSERT INTO PL_AREA_POSTCODE ([KODE_POS], [KELURAHAN], [KECAMATAN], [JENIS], [KABUPATEN], [PROPINSI], [NAMA_AREA]) VALUES(@KODE_POS, @KELURAHAN, @KECAMATAN, @JENIS, @KABUPATEN, @PROPINSI, @NAMA_AREA)", conn);
						command.CommandType = System.Data.CommandType.Text;
						if (pl_area_postcode[pos].KODE_POS != null) { command.Parameters.AddWithValue("@KODE_POS", pl_area_postcode[pos].KODE_POS); } else { command.Parameters.AddWithValue("@KODE_POS", DBNull.Value); } 
						if (pl_area_postcode[pos].KELURAHAN != null) { command.Parameters.AddWithValue("@KELURAHAN", pl_area_postcode[pos].KELURAHAN); } else { command.Parameters.AddWithValue("@KELURAHAN", DBNull.Value); } 
						if (pl_area_postcode[pos].KECAMATAN != null) { command.Parameters.AddWithValue("@KECAMATAN", pl_area_postcode[pos].KECAMATAN); } else { command.Parameters.AddWithValue("@KECAMATAN", DBNull.Value); } 
						if (pl_area_postcode[pos].JENIS != null) { command.Parameters.AddWithValue("@JENIS", pl_area_postcode[pos].JENIS); } else { command.Parameters.AddWithValue("@JENIS", DBNull.Value); } 
						if (pl_area_postcode[pos].KABUPATEN != null) { command.Parameters.AddWithValue("@KABUPATEN", pl_area_postcode[pos].KABUPATEN); } else { command.Parameters.AddWithValue("@KABUPATEN", DBNull.Value); } 
						if (pl_area_postcode[pos].PROPINSI != null) { command.Parameters.AddWithValue("@PROPINSI", pl_area_postcode[pos].PROPINSI); } else { command.Parameters.AddWithValue("@PROPINSI", DBNull.Value); } 
						if (pl_area_postcode[pos].NAMA_AREA != null) { command.Parameters.AddWithValue("@NAMA_AREA", pl_area_postcode[pos].NAMA_AREA); } else { command.Parameters.AddWithValue("@NAMA_AREA", DBNull.Value); } 
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

		public void Update(PL_AREA_POSTCODE pl_area_postcode)
		{
			using (var conn = new SqlConnection(connString))
			{
				try
				{
					Message = "";
					conn.Open();
					SqlCommand command = new SqlCommand("UPDATE PL_AREA_POSTCODE SET KELURAHAN = @KELURAHAN, KECAMATAN = @KECAMATAN, JENIS = @JENIS, KABUPATEN = @KABUPATEN, PROPINSI = @PROPINSI, NAMA_AREA = @NAMA_AREA WHERE KODE_POS = @KODE_POS", conn);
					command.CommandType = System.Data.CommandType.Text;
					if (pl_area_postcode.KODE_POS != null) { command.Parameters.AddWithValue("@KODE_POS", pl_area_postcode.KODE_POS); } else { command.Parameters.AddWithValue("@KODE_POS", DBNull.Value); } 
					if (pl_area_postcode.KELURAHAN != null) { command.Parameters.AddWithValue("@KELURAHAN", pl_area_postcode.KELURAHAN); } else { command.Parameters.AddWithValue("@KELURAHAN", DBNull.Value); } 
					if (pl_area_postcode.KECAMATAN != null) { command.Parameters.AddWithValue("@KECAMATAN", pl_area_postcode.KECAMATAN); } else { command.Parameters.AddWithValue("@KECAMATAN", DBNull.Value); } 
					if (pl_area_postcode.JENIS != null) { command.Parameters.AddWithValue("@JENIS", pl_area_postcode.JENIS); } else { command.Parameters.AddWithValue("@JENIS", DBNull.Value); } 
					if (pl_area_postcode.KABUPATEN != null) { command.Parameters.AddWithValue("@KABUPATEN", pl_area_postcode.KABUPATEN); } else { command.Parameters.AddWithValue("@KABUPATEN", DBNull.Value); } 
					if (pl_area_postcode.PROPINSI != null) { command.Parameters.AddWithValue("@PROPINSI", pl_area_postcode.PROPINSI); } else { command.Parameters.AddWithValue("@PROPINSI", DBNull.Value); } 
					if (pl_area_postcode.NAMA_AREA != null) { command.Parameters.AddWithValue("@NAMA_AREA", pl_area_postcode.NAMA_AREA); } else { command.Parameters.AddWithValue("@NAMA_AREA", DBNull.Value); } 
					command.ExecuteNonQuery();
				}
				catch (Exception ex)
				{
					Message = ex.Message;
				}
			}
		}

		public void UpdateMany(List<PL_AREA_POSTCODE> pl_area_postcodes)
		{
			using (var conn = new SqlConnection(connString))
			{
				try
				{
					Message = "";
					conn.Open();
					foreach(PL_AREA_POSTCODE item in pl_area_postcodes)
					{
						SqlCommand command = new SqlCommand("UPDATE PL_AREA_POSTCODE SET KELURAHAN = @KELURAHAN, KECAMATAN = @KECAMATAN, JENIS = @JENIS, KABUPATEN = @KABUPATEN, PROPINSI = @PROPINSI, NAMA_AREA = @NAMA_AREA WHERE KODE_POS = @KODE_POS", conn);
						command.CommandType = System.Data.CommandType.Text;
						if (item.KODE_POS != null) { command.Parameters.AddWithValue("@KODE_POS", item.KODE_POS); } else { command.Parameters.AddWithValue("@KODE_POS", DBNull.Value); } 
						if (item.KELURAHAN != null) { command.Parameters.AddWithValue("@KELURAHAN", item.KELURAHAN); } else { command.Parameters.AddWithValue("@KELURAHAN", DBNull.Value); } 
						if (item.KECAMATAN != null) { command.Parameters.AddWithValue("@KECAMATAN", item.KECAMATAN); } else { command.Parameters.AddWithValue("@KECAMATAN", DBNull.Value); } 
						if (item.JENIS != null) { command.Parameters.AddWithValue("@JENIS", item.JENIS); } else { command.Parameters.AddWithValue("@JENIS", DBNull.Value); } 
						if (item.KABUPATEN != null) { command.Parameters.AddWithValue("@KABUPATEN", item.KABUPATEN); } else { command.Parameters.AddWithValue("@KABUPATEN", DBNull.Value); } 
						if (item.PROPINSI != null) { command.Parameters.AddWithValue("@PROPINSI", item.PROPINSI); } else { command.Parameters.AddWithValue("@PROPINSI", DBNull.Value); } 
						if (item.NAMA_AREA != null) { command.Parameters.AddWithValue("@NAMA_AREA", item.NAMA_AREA); } else { command.Parameters.AddWithValue("@NAMA_AREA", DBNull.Value); } 
						command.ExecuteNonQuery();
					}
				}
				catch (Exception ex)
				{
					Message = ex.Message;
				}
			}
		}

		public void Remove(PL_AREA_POSTCODE id)
		{
			using (var conn = new SqlConnection(connString))
			{
				try
				{
					Message = "";
					conn.Open();
					SqlCommand command = new SqlCommand("DELETE PL_AREA_POSTCODE WHERE KODE_POS = @KODE_POS", conn);
					command.CommandType = System.Data.CommandType.Text;
					if (id.KODE_POS != null) { command.Parameters.AddWithValue("@KODE_POS", id.KODE_POS); } else { command.Parameters.AddWithValue("@KODE_POS", DBNull.Value); } 
					command.ExecuteNonQuery();
				}
				catch (Exception ex)
				{
					Message = ex.Message;
				}
			}
		}

		public List<PL_AREA_POSTCODE> GetData()
		{
			List<PL_AREA_POSTCODE> items = new List<PL_AREA_POSTCODE>();
			using (var conn = new SqlConnection(connString))
			{
				Message = "";
				try
				{
					conn.Open();
					SqlCommand command = new SqlCommand("SELECT [KODE_POS], [KELURAHAN], [KECAMATAN], [JENIS], [KABUPATEN], [PROPINSI], [NAMA_AREA] FROM PL_AREA_POSTCODE", conn);
					SqlDataReader reader = command.ExecuteReader();
					PL_AREA_POSTCODE item = new PL_AREA_POSTCODE();
					while(reader.Read())
					{
						item = new PL_AREA_POSTCODE();
						if (reader[0] != DBNull.Value) { item.KODE_POS = Convert.ToString(reader[0]); }
						if (reader[1] != DBNull.Value) { item.KELURAHAN = Convert.ToString(reader[1]); }
						if (reader[2] != DBNull.Value) { item.KECAMATAN = Convert.ToString(reader[2]); }
						if (reader[3] != DBNull.Value) { item.JENIS = Convert.ToString(reader[3]); }
						if (reader[4] != DBNull.Value) { item.KABUPATEN = Convert.ToString(reader[4]); }
						if (reader[5] != DBNull.Value) { item.PROPINSI = Convert.ToString(reader[5]); }
						if (reader[6] != DBNull.Value) { item.NAMA_AREA = Convert.ToString(reader[6]); }
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

		public List<PL_AREA_POSTCODE> GetDataByKODE_POS(string KODE_POS)
		{
			List<PL_AREA_POSTCODE> items = new List<PL_AREA_POSTCODE>();
			using (var conn = new SqlConnection(connString))
			{
				Message = "";
				try
				{
					conn.Open();
					SqlCommand command = new SqlCommand("SELECT [KODE_POS], [KELURAHAN], [KECAMATAN], [JENIS], [KABUPATEN], [PROPINSI], [NAMA_AREA] FROM PL_AREA_POSTCODE WHERE KODE_POS = @KODE_POS", conn);
					command.Parameters.AddWithValue("@KODE_POS", KODE_POS);
					SqlDataReader reader = command.ExecuteReader();
					PL_AREA_POSTCODE item = new PL_AREA_POSTCODE();
					while(reader.Read())
					{
						item = new PL_AREA_POSTCODE();
						if (reader[0] != DBNull.Value) { item.KODE_POS = Convert.ToString(reader[0]); }
						if (reader[1] != DBNull.Value) { item.KELURAHAN = Convert.ToString(reader[1]); }
						if (reader[2] != DBNull.Value) { item.KECAMATAN = Convert.ToString(reader[2]); }
						if (reader[3] != DBNull.Value) { item.JENIS = Convert.ToString(reader[3]); }
						if (reader[4] != DBNull.Value) { item.KABUPATEN = Convert.ToString(reader[4]); }
						if (reader[5] != DBNull.Value) { item.PROPINSI = Convert.ToString(reader[5]); }
						if (reader[6] != DBNull.Value) { item.NAMA_AREA = Convert.ToString(reader[6]); }
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

		public void RemoveByKODE_POS(string id)
		{
			using (var conn = new SqlConnection(connString))
			{
				try
				{
					Message = "";
					conn.Open();
					SqlCommand command = new SqlCommand("DELETE PL_AREA_POSTCODE WHERE KODE_POS = @KODE_POS", conn);
					command.CommandType = System.Data.CommandType.Text;
					if (id != null) { command.Parameters.AddWithValue("@KODE_POS", id); } else { command.Parameters.AddWithValue("@KODE_POS", DBNull.Value); } 
					command.ExecuteNonQuery();
				}
				catch (Exception ex)
				{
					Message = ex.Message;
				}
			}
		}

		public DataTable GetDataTable(List<PL_AREA_POSTCODE> pl_area_postcode)
		{
			DataTable dt = new DataTable("PL_AREA_POSTCODE");

			DataColumn c1 = new DataColumn("KODE_POS", typeof(string)); 
			dt.Columns.Add(c1);
			DataColumn c2 = new DataColumn("KELURAHAN", typeof(string)); c2.AllowDBNull = true;
			dt.Columns.Add(c2);
			DataColumn c3 = new DataColumn("KECAMATAN", typeof(string)); c3.AllowDBNull = true;
			dt.Columns.Add(c3);
			DataColumn c4 = new DataColumn("JENIS", typeof(string)); c4.AllowDBNull = true;
			dt.Columns.Add(c4);
			DataColumn c5 = new DataColumn("KABUPATEN", typeof(string)); c5.AllowDBNull = true;
			dt.Columns.Add(c5);
			DataColumn c6 = new DataColumn("PROPINSI", typeof(string)); c6.AllowDBNull = true;
			dt.Columns.Add(c6);
			DataColumn c7 = new DataColumn("NAMA_AREA", typeof(string)); c7.AllowDBNull = true;
			dt.Columns.Add(c7);

			foreach (PL_AREA_POSTCODE v in pl_area_postcode)
			{
				DataRow dr = dt.NewRow();
				if (v.KODE_POS != null) { dr[0] = v.KODE_POS; } else { dr[0] = DBNull.Value; }
				if (v.KELURAHAN != null) { dr[1] = v.KELURAHAN; } else { dr[1] = DBNull.Value; }
				if (v.KECAMATAN != null) { dr[2] = v.KECAMATAN; } else { dr[2] = DBNull.Value; }
				if (v.JENIS != null) { dr[3] = v.JENIS; } else { dr[3] = DBNull.Value; }
				if (v.KABUPATEN != null) { dr[4] = v.KABUPATEN; } else { dr[4] = DBNull.Value; }
				if (v.PROPINSI != null) { dr[5] = v.PROPINSI; } else { dr[5] = DBNull.Value; }
				if (v.NAMA_AREA != null) { dr[6] = v.NAMA_AREA; } else { dr[6] = DBNull.Value; }
				dt.Rows.Add(dr);
			}
			dt.AcceptChanges();

			return dt;
		}

		public void AddManyBulk(List<PL_AREA_POSTCODE> pl_area_postcode)
		{
			using (var conn = new SqlConnection(connString))
			{
				try
				{
					Message = "";
					conn.Open();

					DataTable dt = GetDataTable(pl_area_postcode);
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

		public List<PL_AREA_POSTCODE> GetDataFromFile()
		{
			string path = Directory.GetCurrentDirectory();
			string fileName = path + "\\FileData\\" + "PL_AREA_POSTCODE.txt";
			List<PL_AREA_POSTCODE> items = new List<PL_AREA_POSTCODE>();
			using (var reader = new StreamReader(fileName))
			{
				Message = "";
				try
				{
					int pos = 0;
					while(!reader.EndOfStream)
					{
						PL_AREA_POSTCODE item = new PL_AREA_POSTCODE();
						var line = reader.ReadLine();
						var values = line.Split('\t');
						if (pos == 0)
						{
							pos = pos + 1;
							continue;
						}
						if (values[0] != "") { item.KODE_POS = Convert.ToString(values[0]); }
						if (values[1] != "") { item.KELURAHAN = Convert.ToString(values[1]); }
						if (values[2] != "") { item.KECAMATAN = Convert.ToString(values[2]); }
						if (values[3] != "") { item.JENIS = Convert.ToString(values[3]); }
						if (values[4] != "") { item.KABUPATEN = Convert.ToString(values[4]); }
						if (values[5] != "") { item.PROPINSI = Convert.ToString(values[5]); }
						if (values[6] != "") { item.NAMA_AREA = Convert.ToString(values[6]); }
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