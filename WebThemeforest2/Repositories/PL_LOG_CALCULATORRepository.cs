using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using WebThemeforest2.Models;

namespace WebThemeforest2.Repositories
{
	public partial class PL_LOG_CALCULATORRepository
	{
		private string connString;
		public string Message { get; set; }

		public PL_LOG_CALCULATORRepository(string connectionString)
		{
			connString = connectionString;
		}

		public void Add(PL_LOG_CALCULATOR pl_log_calculator)
		{
			using (var conn = new SqlConnection(connString))
			{
				try
				{
					Message = "";
					conn.Open();
					SqlCommand command = new SqlCommand("INSERT INTO PL_LOG_CALCULATOR ( [SOURCE_DIAMETER], [SOURCE_PRESSURE], [ESTIMATED_DIAMETER], [ESTIMATED_PRESSURE], [ESTIMATED_LENGTH], [ESTIMATED_COST], [ESTIMATED_FLOWRATE], [REMAINING_CAPACITY], [LAT], [LNG], [CREATED_DATE], [CREATED_BY]) VALUES( @SOURCE_DIAMETER, @SOURCE_PRESSURE, @ESTIMATED_DIAMETER, @ESTIMATED_PRESSURE, @ESTIMATED_LENGTH, @ESTIMATED_COST, @ESTIMATED_FLOWRATE, @REMAINING_CAPACITY, @LAT, @LNG, @CREATED_DATE, @CREATED_BY)", conn);
					command.CommandType = System.Data.CommandType.Text;
					
					if (pl_log_calculator.SOURCE_DIAMETER != null) { command.Parameters.AddWithValue("@SOURCE_DIAMETER", pl_log_calculator.SOURCE_DIAMETER); } else { command.Parameters.AddWithValue("@SOURCE_DIAMETER", DBNull.Value); } 
					if (pl_log_calculator.SOURCE_PRESSURE != null) { command.Parameters.AddWithValue("@SOURCE_PRESSURE", pl_log_calculator.SOURCE_PRESSURE); } else { command.Parameters.AddWithValue("@SOURCE_PRESSURE", DBNull.Value); } 
					if (pl_log_calculator.ESTIMATED_DIAMETER != null) { command.Parameters.AddWithValue("@ESTIMATED_DIAMETER", pl_log_calculator.ESTIMATED_DIAMETER); } else { command.Parameters.AddWithValue("@ESTIMATED_DIAMETER", DBNull.Value); } 
					if (pl_log_calculator.ESTIMATED_PRESSURE != null) { command.Parameters.AddWithValue("@ESTIMATED_PRESSURE", pl_log_calculator.ESTIMATED_PRESSURE); } else { command.Parameters.AddWithValue("@ESTIMATED_PRESSURE", DBNull.Value); } 
					if (pl_log_calculator.ESTIMATED_LENGTH != null) { command.Parameters.AddWithValue("@ESTIMATED_LENGTH", pl_log_calculator.ESTIMATED_LENGTH); } else { command.Parameters.AddWithValue("@ESTIMATED_LENGTH", DBNull.Value); } 
					if (pl_log_calculator.ESTIMATED_COST != null) { command.Parameters.AddWithValue("@ESTIMATED_COST", pl_log_calculator.ESTIMATED_COST); } else { command.Parameters.AddWithValue("@ESTIMATED_COST", DBNull.Value); } 
					if (pl_log_calculator.ESTIMATED_FLOWRATE != null) { command.Parameters.AddWithValue("@ESTIMATED_FLOWRATE", pl_log_calculator.ESTIMATED_FLOWRATE); } else { command.Parameters.AddWithValue("@ESTIMATED_FLOWRATE", DBNull.Value); } 
					if (pl_log_calculator.REMAINING_CAPACITY != null) { command.Parameters.AddWithValue("@REMAINING_CAPACITY", pl_log_calculator.REMAINING_CAPACITY); } else { command.Parameters.AddWithValue("@REMAINING_CAPACITY", DBNull.Value); } 
					if (pl_log_calculator.LAT != null) { command.Parameters.AddWithValue("@LAT", pl_log_calculator.LAT); } else { command.Parameters.AddWithValue("@LAT", DBNull.Value); } 
					if (pl_log_calculator.LNG != null) { command.Parameters.AddWithValue("@LNG", pl_log_calculator.LNG); } else { command.Parameters.AddWithValue("@LNG", DBNull.Value); } 
					if (pl_log_calculator.CREATED_DATE != null) { command.Parameters.AddWithValue("@CREATED_DATE", DateTime.Now); } else { command.Parameters.AddWithValue("@CREATED_DATE", DBNull.Value); } 
					if (pl_log_calculator.CREATED_BY != null) { command.Parameters.AddWithValue("@CREATED_BY", pl_log_calculator.CREATED_BY); } else { command.Parameters.AddWithValue("@CREATED_BY", DBNull.Value); } 
					command.ExecuteNonQuery();
				}
				catch (Exception ex)
				{
					Message = ex.Message;
				}
			}
		}

		public void AddMany(List<PL_LOG_CALCULATOR> pl_log_calculator)
		{
			using (var conn = new SqlConnection(connString))
			{
				try
				{
					Message = "";
					conn.Open();
					int pos = 0;
					foreach(PL_LOG_CALCULATOR item in pl_log_calculator)
					{
						SqlCommand command = new SqlCommand("INSERT INTO PL_LOG_CALCULATOR ([ID], [SOURCE_DIAMETER], [SOURCE_PRESSURE], [ESTIMATED_DIAMETER], [ESTIMATED_PRESSURE], [ESTIMATED_LENGTH], [ESTIMATED_COST], [ESTIMATED_FLOWRATE], [REMAINING_CAPACITY], [LAT], [LNG], [CREATED_DATE], [CREATED_BY]) VALUES(@ID, @SOURCE_DIAMETER, @SOURCE_PRESSURE, @ESTIMATED_DIAMETER, @ESTIMATED_PRESSURE, @ESTIMATED_LENGTH, @ESTIMATED_COST, @ESTIMATED_FLOWRATE, @REMAINING_CAPACITY, @LAT, @LNG, @CREATED_DATE, @CREATED_BY)", conn);
						command.CommandType = System.Data.CommandType.Text;
						if (pl_log_calculator[pos].ID != null) { command.Parameters.AddWithValue("@ID", pl_log_calculator[pos].ID); } else { command.Parameters.AddWithValue("@ID", DBNull.Value); } 
						if (pl_log_calculator[pos].SOURCE_DIAMETER != null) { command.Parameters.AddWithValue("@SOURCE_DIAMETER", pl_log_calculator[pos].SOURCE_DIAMETER); } else { command.Parameters.AddWithValue("@SOURCE_DIAMETER", DBNull.Value); } 
						if (pl_log_calculator[pos].SOURCE_PRESSURE != null) { command.Parameters.AddWithValue("@SOURCE_PRESSURE", pl_log_calculator[pos].SOURCE_PRESSURE); } else { command.Parameters.AddWithValue("@SOURCE_PRESSURE", DBNull.Value); } 
						if (pl_log_calculator[pos].ESTIMATED_DIAMETER != null) { command.Parameters.AddWithValue("@ESTIMATED_DIAMETER", pl_log_calculator[pos].ESTIMATED_DIAMETER); } else { command.Parameters.AddWithValue("@ESTIMATED_DIAMETER", DBNull.Value); } 
						if (pl_log_calculator[pos].ESTIMATED_PRESSURE != null) { command.Parameters.AddWithValue("@ESTIMATED_PRESSURE", pl_log_calculator[pos].ESTIMATED_PRESSURE); } else { command.Parameters.AddWithValue("@ESTIMATED_PRESSURE", DBNull.Value); } 
						if (pl_log_calculator[pos].ESTIMATED_LENGTH != null) { command.Parameters.AddWithValue("@ESTIMATED_LENGTH", pl_log_calculator[pos].ESTIMATED_LENGTH); } else { command.Parameters.AddWithValue("@ESTIMATED_LENGTH", DBNull.Value); } 
						if (pl_log_calculator[pos].ESTIMATED_COST != null) { command.Parameters.AddWithValue("@ESTIMATED_COST", pl_log_calculator[pos].ESTIMATED_COST); } else { command.Parameters.AddWithValue("@ESTIMATED_COST", DBNull.Value); } 
						if (pl_log_calculator[pos].ESTIMATED_FLOWRATE != null) { command.Parameters.AddWithValue("@ESTIMATED_FLOWRATE", pl_log_calculator[pos].ESTIMATED_FLOWRATE); } else { command.Parameters.AddWithValue("@ESTIMATED_FLOWRATE", DBNull.Value); } 
						if (pl_log_calculator[pos].REMAINING_CAPACITY != null) { command.Parameters.AddWithValue("@REMAINING_CAPACITY", pl_log_calculator[pos].REMAINING_CAPACITY); } else { command.Parameters.AddWithValue("@REMAINING_CAPACITY", DBNull.Value); } 
						if (pl_log_calculator[pos].LAT != null) { command.Parameters.AddWithValue("@LAT", pl_log_calculator[pos].LAT); } else { command.Parameters.AddWithValue("@LAT", DBNull.Value); } 
						if (pl_log_calculator[pos].LNG != null) { command.Parameters.AddWithValue("@LNG", pl_log_calculator[pos].LNG); } else { command.Parameters.AddWithValue("@LNG", DBNull.Value); } 
						if (pl_log_calculator[pos].CREATED_DATE != null) { command.Parameters.AddWithValue("@CREATED_DATE", pl_log_calculator[pos].CREATED_DATE); } else { command.Parameters.AddWithValue("@CREATED_DATE", DBNull.Value); } 
						if (pl_log_calculator[pos].CREATED_BY != null) { command.Parameters.AddWithValue("@CREATED_BY", pl_log_calculator[pos].CREATED_BY); } else { command.Parameters.AddWithValue("@CREATED_BY", DBNull.Value); } 
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

		public void Update(PL_LOG_CALCULATOR pl_log_calculator)
		{
			using (var conn = new SqlConnection(connString))
			{
				try
				{
					Message = "";
					conn.Open();
					SqlCommand command = new SqlCommand("UPDATE PL_LOG_CALCULATOR SET SOURCE_DIAMETER = @SOURCE_DIAMETER, SOURCE_PRESSURE = @SOURCE_PRESSURE, ESTIMATED_DIAMETER = @ESTIMATED_DIAMETER, ESTIMATED_PRESSURE = @ESTIMATED_PRESSURE, ESTIMATED_LENGTH = @ESTIMATED_LENGTH, ESTIMATED_COST = @ESTIMATED_COST, ESTIMATED_FLOWRATE = @ESTIMATED_FLOWRATE, REMAINING_CAPACITY = @REMAINING_CAPACITY, LAT = @LAT, LNG = @LNG, CREATED_DATE = @CREATED_DATE, CREATED_BY = @CREATED_BY WHERE ID = @ID", conn);
					command.CommandType = System.Data.CommandType.Text;
					if (pl_log_calculator.ID != null) { command.Parameters.AddWithValue("@ID", pl_log_calculator.ID); } else { command.Parameters.AddWithValue("@ID", DBNull.Value); } 
					if (pl_log_calculator.SOURCE_DIAMETER != null) { command.Parameters.AddWithValue("@SOURCE_DIAMETER", pl_log_calculator.SOURCE_DIAMETER); } else { command.Parameters.AddWithValue("@SOURCE_DIAMETER", DBNull.Value); } 
					if (pl_log_calculator.SOURCE_PRESSURE != null) { command.Parameters.AddWithValue("@SOURCE_PRESSURE", pl_log_calculator.SOURCE_PRESSURE); } else { command.Parameters.AddWithValue("@SOURCE_PRESSURE", DBNull.Value); } 
					if (pl_log_calculator.ESTIMATED_DIAMETER != null) { command.Parameters.AddWithValue("@ESTIMATED_DIAMETER", pl_log_calculator.ESTIMATED_DIAMETER); } else { command.Parameters.AddWithValue("@ESTIMATED_DIAMETER", DBNull.Value); } 
					if (pl_log_calculator.ESTIMATED_PRESSURE != null) { command.Parameters.AddWithValue("@ESTIMATED_PRESSURE", pl_log_calculator.ESTIMATED_PRESSURE); } else { command.Parameters.AddWithValue("@ESTIMATED_PRESSURE", DBNull.Value); } 
					if (pl_log_calculator.ESTIMATED_LENGTH != null) { command.Parameters.AddWithValue("@ESTIMATED_LENGTH", pl_log_calculator.ESTIMATED_LENGTH); } else { command.Parameters.AddWithValue("@ESTIMATED_LENGTH", DBNull.Value); } 
					if (pl_log_calculator.ESTIMATED_COST != null) { command.Parameters.AddWithValue("@ESTIMATED_COST", pl_log_calculator.ESTIMATED_COST); } else { command.Parameters.AddWithValue("@ESTIMATED_COST", DBNull.Value); } 
					if (pl_log_calculator.ESTIMATED_FLOWRATE != null) { command.Parameters.AddWithValue("@ESTIMATED_FLOWRATE", pl_log_calculator.ESTIMATED_FLOWRATE); } else { command.Parameters.AddWithValue("@ESTIMATED_FLOWRATE", DBNull.Value); } 
					if (pl_log_calculator.REMAINING_CAPACITY != null) { command.Parameters.AddWithValue("@REMAINING_CAPACITY", pl_log_calculator.REMAINING_CAPACITY); } else { command.Parameters.AddWithValue("@REMAINING_CAPACITY", DBNull.Value); } 
					if (pl_log_calculator.LAT != null) { command.Parameters.AddWithValue("@LAT", pl_log_calculator.LAT); } else { command.Parameters.AddWithValue("@LAT", DBNull.Value); } 
					if (pl_log_calculator.LNG != null) { command.Parameters.AddWithValue("@LNG", pl_log_calculator.LNG); } else { command.Parameters.AddWithValue("@LNG", DBNull.Value); } 
					if (pl_log_calculator.CREATED_DATE != null) { command.Parameters.AddWithValue("@CREATED_DATE", pl_log_calculator.CREATED_DATE); } else { command.Parameters.AddWithValue("@CREATED_DATE", DBNull.Value); } 
					if (pl_log_calculator.CREATED_BY != null) { command.Parameters.AddWithValue("@CREATED_BY", pl_log_calculator.CREATED_BY); } else { command.Parameters.AddWithValue("@CREATED_BY", DBNull.Value); } 
					command.ExecuteNonQuery();
				}
				catch (Exception ex)
				{
					Message = ex.Message;
				}
			}
		}

		public void UpdateMany(List<PL_LOG_CALCULATOR> pl_log_calculators)
		{
			using (var conn = new SqlConnection(connString))
			{
				try
				{
					Message = "";
					conn.Open();
					foreach(PL_LOG_CALCULATOR item in pl_log_calculators)
					{
						SqlCommand command = new SqlCommand("UPDATE PL_LOG_CALCULATOR SET SOURCE_DIAMETER = @SOURCE_DIAMETER, SOURCE_PRESSURE = @SOURCE_PRESSURE, ESTIMATED_DIAMETER = @ESTIMATED_DIAMETER, ESTIMATED_PRESSURE = @ESTIMATED_PRESSURE, ESTIMATED_LENGTH = @ESTIMATED_LENGTH, ESTIMATED_COST = @ESTIMATED_COST, ESTIMATED_FLOWRATE = @ESTIMATED_FLOWRATE, REMAINING_CAPACITY = @REMAINING_CAPACITY, LAT = @LAT, LNG = @LNG, CREATED_DATE = @CREATED_DATE, CREATED_BY = @CREATED_BY WHERE ID = @ID", conn);
						command.CommandType = System.Data.CommandType.Text;
						if (item.ID != null) { command.Parameters.AddWithValue("@ID", item.ID); } else { command.Parameters.AddWithValue("@ID", DBNull.Value); } 
						if (item.SOURCE_DIAMETER != null) { command.Parameters.AddWithValue("@SOURCE_DIAMETER", item.SOURCE_DIAMETER); } else { command.Parameters.AddWithValue("@SOURCE_DIAMETER", DBNull.Value); } 
						if (item.SOURCE_PRESSURE != null) { command.Parameters.AddWithValue("@SOURCE_PRESSURE", item.SOURCE_PRESSURE); } else { command.Parameters.AddWithValue("@SOURCE_PRESSURE", DBNull.Value); } 
						if (item.ESTIMATED_DIAMETER != null) { command.Parameters.AddWithValue("@ESTIMATED_DIAMETER", item.ESTIMATED_DIAMETER); } else { command.Parameters.AddWithValue("@ESTIMATED_DIAMETER", DBNull.Value); } 
						if (item.ESTIMATED_PRESSURE != null) { command.Parameters.AddWithValue("@ESTIMATED_PRESSURE", item.ESTIMATED_PRESSURE); } else { command.Parameters.AddWithValue("@ESTIMATED_PRESSURE", DBNull.Value); } 
						if (item.ESTIMATED_LENGTH != null) { command.Parameters.AddWithValue("@ESTIMATED_LENGTH", item.ESTIMATED_LENGTH); } else { command.Parameters.AddWithValue("@ESTIMATED_LENGTH", DBNull.Value); } 
						if (item.ESTIMATED_COST != null) { command.Parameters.AddWithValue("@ESTIMATED_COST", item.ESTIMATED_COST); } else { command.Parameters.AddWithValue("@ESTIMATED_COST", DBNull.Value); } 
						if (item.ESTIMATED_FLOWRATE != null) { command.Parameters.AddWithValue("@ESTIMATED_FLOWRATE", item.ESTIMATED_FLOWRATE); } else { command.Parameters.AddWithValue("@ESTIMATED_FLOWRATE", DBNull.Value); } 
						if (item.REMAINING_CAPACITY != null) { command.Parameters.AddWithValue("@REMAINING_CAPACITY", item.REMAINING_CAPACITY); } else { command.Parameters.AddWithValue("@REMAINING_CAPACITY", DBNull.Value); } 
						if (item.LAT != null) { command.Parameters.AddWithValue("@LAT", item.LAT); } else { command.Parameters.AddWithValue("@LAT", DBNull.Value); } 
						if (item.LNG != null) { command.Parameters.AddWithValue("@LNG", item.LNG); } else { command.Parameters.AddWithValue("@LNG", DBNull.Value); } 
						if (item.CREATED_DATE != null) { command.Parameters.AddWithValue("@CREATED_DATE", item.CREATED_DATE); } else { command.Parameters.AddWithValue("@CREATED_DATE", DBNull.Value); } 
						if (item.CREATED_BY != null) { command.Parameters.AddWithValue("@CREATED_BY", item.CREATED_BY); } else { command.Parameters.AddWithValue("@CREATED_BY", DBNull.Value); } 
						command.ExecuteNonQuery();
					}
				}
				catch (Exception ex)
				{
					Message = ex.Message;
				}
			}
		}

		public void Remove(PL_LOG_CALCULATOR id)
		{
			using (var conn = new SqlConnection(connString))
			{
				try
				{
					Message = "";
					conn.Open();
					SqlCommand command = new SqlCommand("DELETE PL_LOG_CALCULATOR WHERE ID = @ID", conn);
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

		public List<PL_LOG_CALCULATOR> GetData()
		{
			List<PL_LOG_CALCULATOR> items = new List<PL_LOG_CALCULATOR>();
			using (var conn = new SqlConnection(connString))
			{
				Message = "";
				try
				{
					conn.Open();
                    SqlCommand command = new SqlCommand("SELECT [ID], [SOURCE_DIAMETER], [SOURCE_PRESSURE], [ESTIMATED_DIAMETER], [ESTIMATED_PRESSURE], [ESTIMATED_LENGTH], [ESTIMATED_COST], [ESTIMATED_FLOWRATE], [REMAINING_CAPACITY], [LAT], [LNG], [CREATED_DATE], [CREATED_BY] FROM PL_LOG_CALCULATOR order by CREATED_DATE desc ", conn);
					SqlDataReader reader = command.ExecuteReader();
					PL_LOG_CALCULATOR item = new PL_LOG_CALCULATOR();
					while(reader.Read())
					{
						item = new PL_LOG_CALCULATOR();
						if (reader[0] != DBNull.Value) { item.ID = Convert.ToInt32(reader[0]); }
						if (reader[1] != DBNull.Value) { item.SOURCE_DIAMETER = Convert.ToInt32(reader[1]); }
						if (reader[2] != DBNull.Value) { item.SOURCE_PRESSURE = Convert.ToInt32(reader[2]); }
						if (reader[3] != DBNull.Value) { item.ESTIMATED_DIAMETER = Convert.ToDouble(reader[3]); }
						if (reader[4] != DBNull.Value) { item.ESTIMATED_PRESSURE = Convert.ToDouble(reader[4]); }
						if (reader[5] != DBNull.Value) { item.ESTIMATED_LENGTH = Convert.ToDouble(reader[5]); }
						if (reader[6] != DBNull.Value) { item.ESTIMATED_COST = Convert.ToDouble(reader[6]); }
						if (reader[7] != DBNull.Value) { item.ESTIMATED_FLOWRATE = Convert.ToDouble(reader[7]); }
						if (reader[8] != DBNull.Value) { item.REMAINING_CAPACITY = Convert.ToDouble(reader[8]); }
						if (reader[9] != DBNull.Value) { item.LAT = Convert.ToDouble(reader[9]); }
						if (reader[10] != DBNull.Value) { item.LNG = Convert.ToDouble(reader[10]); }
						if (reader[11] != DBNull.Value) { item.CREATED_DATE = Convert.ToDateTime(reader[11]); }
						if (reader[12] != DBNull.Value) { item.CREATED_BY = Convert.ToString(reader[12]); }
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

		public List<PL_LOG_CALCULATOR> GetDataByID(int ID)
		{
			List<PL_LOG_CALCULATOR> items = new List<PL_LOG_CALCULATOR>();
			using (var conn = new SqlConnection(connString))
			{
				Message = "";
				try
				{
					conn.Open();
					SqlCommand command = new SqlCommand("SELECT [ID], [SOURCE_DIAMETER], [SOURCE_PRESSURE], [ESTIMATED_DIAMETER], [ESTIMATED_PRESSURE], [ESTIMATED_LENGTH], [ESTIMATED_COST], [ESTIMATED_FLOWRATE], [REMAINING_CAPACITY], [LAT], [LNG], [CREATED_DATE], [CREATED_BY] FROM PL_LOG_CALCULATOR WHERE ID = @ID", conn);
					command.Parameters.AddWithValue("@ID", ID);
					SqlDataReader reader = command.ExecuteReader();
					PL_LOG_CALCULATOR item = new PL_LOG_CALCULATOR();
					while(reader.Read())
					{
						item = new PL_LOG_CALCULATOR();
						if (reader[0] != DBNull.Value) { item.ID = Convert.ToInt32(reader[0]); }
						if (reader[1] != DBNull.Value) { item.SOURCE_DIAMETER = Convert.ToInt32(reader[1]); }
						if (reader[2] != DBNull.Value) { item.SOURCE_PRESSURE = Convert.ToInt32(reader[2]); }
						if (reader[3] != DBNull.Value) { item.ESTIMATED_DIAMETER = Convert.ToDouble(reader[3]); }
						if (reader[4] != DBNull.Value) { item.ESTIMATED_PRESSURE = Convert.ToDouble(reader[4]); }
						if (reader[5] != DBNull.Value) { item.ESTIMATED_LENGTH = Convert.ToDouble(reader[5]); }
						if (reader[6] != DBNull.Value) { item.ESTIMATED_COST = Convert.ToDouble(reader[6]); }
						if (reader[7] != DBNull.Value) { item.ESTIMATED_FLOWRATE = Convert.ToDouble(reader[7]); }
						if (reader[8] != DBNull.Value) { item.REMAINING_CAPACITY = Convert.ToDouble(reader[8]); }
						if (reader[9] != DBNull.Value) { item.LAT = Convert.ToDouble(reader[9]); }
						if (reader[10] != DBNull.Value) { item.LNG = Convert.ToDouble(reader[10]); }
						if (reader[11] != DBNull.Value) { item.CREATED_DATE = Convert.ToDateTime(reader[11]); }
                        if (reader[12] != DBNull.Value) { item.CREATED_BY = Convert.ToString(reader[12]); }
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
					SqlCommand command = new SqlCommand("DELETE PL_LOG_CALCULATOR WHERE ID = @ID", conn);
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

		public DataTable GetDataTable(List<PL_LOG_CALCULATOR> pl_log_calculator)
		{
			DataTable dt = new DataTable("PL_LOG_CALCULATOR");

			DataColumn c1 = new DataColumn("ID", typeof(int)); 
			dt.Columns.Add(c1);
			DataColumn c2 = new DataColumn("SOURCE_DIAMETER", typeof(double)); c2.AllowDBNull = true;
			dt.Columns.Add(c2);
			DataColumn c3 = new DataColumn("SOURCE_PRESSURE", typeof(double)); c3.AllowDBNull = true;
			dt.Columns.Add(c3);
			DataColumn c4 = new DataColumn("ESTIMATED_DIAMETER", typeof(double)); c4.AllowDBNull = true;
			dt.Columns.Add(c4);
			DataColumn c5 = new DataColumn("ESTIMATED_PRESSURE", typeof(double)); c5.AllowDBNull = true;
			dt.Columns.Add(c5);
			DataColumn c6 = new DataColumn("ESTIMATED_LENGTH", typeof(int)); c6.AllowDBNull = true;
			dt.Columns.Add(c6);
			DataColumn c7 = new DataColumn("ESTIMATED_COST", typeof(double)); c7.AllowDBNull = true;
			dt.Columns.Add(c7);
			DataColumn c8 = new DataColumn("ESTIMATED_FLOWRATE", typeof(double)); c8.AllowDBNull = true;
			dt.Columns.Add(c8);
			DataColumn c9 = new DataColumn("REMAINING_CAPACITY", typeof(double)); c9.AllowDBNull = true;
			dt.Columns.Add(c9);
			DataColumn c10 = new DataColumn("LAT", typeof(double)); c10.AllowDBNull = true;
			dt.Columns.Add(c10);
			DataColumn c11 = new DataColumn("LNG", typeof(double)); c11.AllowDBNull = true;
			dt.Columns.Add(c11);
			DataColumn c12 = new DataColumn("CREATED_DATE", typeof(DateTime)); c12.AllowDBNull = true;
			dt.Columns.Add(c12);
			DataColumn c13 = new DataColumn("CREATED_BY", typeof(string)); c13.AllowDBNull = true;
			dt.Columns.Add(c13);

			foreach (PL_LOG_CALCULATOR v in pl_log_calculator)
			{
				DataRow dr = dt.NewRow();
				if (v.ID != null) { dr[0] = v.ID; } else { dr[0] = DBNull.Value; }
				if (v.SOURCE_DIAMETER != null) { dr[1] = v.SOURCE_DIAMETER; } else { dr[1] = DBNull.Value; }
				if (v.SOURCE_PRESSURE != null) { dr[2] = v.SOURCE_PRESSURE; } else { dr[2] = DBNull.Value; }
				if (v.ESTIMATED_DIAMETER != null) { dr[3] = v.ESTIMATED_DIAMETER; } else { dr[3] = DBNull.Value; }
				if (v.ESTIMATED_PRESSURE != null) { dr[4] = v.ESTIMATED_PRESSURE; } else { dr[4] = DBNull.Value; }
				if (v.ESTIMATED_LENGTH != null) { dr[5] = v.ESTIMATED_LENGTH; } else { dr[5] = DBNull.Value; }
				if (v.ESTIMATED_COST != null) { dr[6] = v.ESTIMATED_COST; } else { dr[6] = DBNull.Value; }
				if (v.ESTIMATED_FLOWRATE != null) { dr[7] = v.ESTIMATED_FLOWRATE; } else { dr[7] = DBNull.Value; }
				if (v.REMAINING_CAPACITY != null) { dr[8] = v.REMAINING_CAPACITY; } else { dr[8] = DBNull.Value; }
				if (v.LAT != null) { dr[9] = v.LAT; } else { dr[9] = DBNull.Value; }
				if (v.LNG != null) { dr[10] = v.LNG; } else { dr[10] = DBNull.Value; }
				if (v.CREATED_DATE != null) { dr[11] = v.CREATED_DATE; } else { dr[11] = DBNull.Value; }
				if (v.CREATED_BY != null) { dr[12] = v.CREATED_BY; } else { dr[12] = DBNull.Value; }
				dt.Rows.Add(dr);
			}
			dt.AcceptChanges();

			return dt;
		}

		public void AddManyBulk(List<PL_LOG_CALCULATOR> pl_log_calculator)
		{
			using (var conn = new SqlConnection(connString))
			{
				try
				{
					Message = "";
					conn.Open();

					DataTable dt = GetDataTable(pl_log_calculator);
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