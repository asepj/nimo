using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using WebThemeforest2.Models;

namespace WebThemeforest2.Repositories
{
	public partial class HistoryCalculatorRepository
	{
		private string connString;
		public string Message { get; set; }

		public HistoryCalculatorRepository(string connectionString)
		{
			connString = connectionString;
		}

		public void Add(HistoryCalculator historycalculator)
		{
			using (var conn = new SqlConnection(connString))
			{
				try
				{
					Message = "";
					conn.Open();
                    SqlCommand command = new SqlCommand("INSERT INTO PL_HISTORY_CALCULATOR ( [SOURCE_DIAMETER], [SOURCE_PRESSURE], [PRESSURE_INPUT], [FLOWRATE_INPUT], [ESTIMATED_DIAMETER], [ESTIMATED_LENGTH], [ESTIMATED_COST], [ESTIMATED_FLOWRATE], [REMAINING_CAPACITY], [CATEGORY], [CUSTOMER], [LAT], [LNG], [CREATED_DATE], [CREATED_BY]) VALUES( @SOURCE_DIAMETER, @SOURCE_PRESSURE, @PRESSURE_INPUT, @FLOWRATE_INPUT, @ESTIMATED_DIAMETER, @ESTIMATED_LENGTH, @ESTIMATED_COST, @ESTIMATED_FLOWRATE, @REMAINING_CAPACITY, @CATEGORY, @CUSTOMER, @LAT, @LNG, @CREATED_DATE, @CREATED_BY)", conn);
					command.CommandType = System.Data.CommandType.Text;
					
					if (historycalculator.SOURCE_DIAMETER != null) { command.Parameters.AddWithValue("@SOURCE_DIAMETER", historycalculator.SOURCE_DIAMETER); } else { command.Parameters.AddWithValue("@SOURCE_DIAMETER", DBNull.Value); } 
					if (historycalculator.SOURCE_PRESSURE != null) { command.Parameters.AddWithValue("@SOURCE_PRESSURE", historycalculator.SOURCE_PRESSURE); } else { command.Parameters.AddWithValue("@SOURCE_PRESSURE", DBNull.Value); } 
					if (historycalculator.PRESSURE_INPUT != null) { command.Parameters.AddWithValue("@PRESSURE_INPUT", historycalculator.PRESSURE_INPUT); } else { command.Parameters.AddWithValue("@PRESSURE_INPUT", DBNull.Value); } 
					if (historycalculator.FLOWRATE_INPUT != null) { command.Parameters.AddWithValue("@FLOWRATE_INPUT", historycalculator.FLOWRATE_INPUT); } else { command.Parameters.AddWithValue("@FLOWRATE_INPUT", DBNull.Value); } 
					if (historycalculator.ESTIMATED_DIAMETER != null) { command.Parameters.AddWithValue("@ESTIMATED_DIAMETER", historycalculator.ESTIMATED_DIAMETER); } else { command.Parameters.AddWithValue("@ESTIMATED_DIAMETER", DBNull.Value); } 
					if (historycalculator.ESTIMATED_LENGTH != null) { command.Parameters.AddWithValue("@ESTIMATED_LENGTH", historycalculator.ESTIMATED_LENGTH); } else { command.Parameters.AddWithValue("@ESTIMATED_LENGTH", DBNull.Value); } 
					if (historycalculator.ESTIMATED_COST != null) { command.Parameters.AddWithValue("@ESTIMATED_COST", historycalculator.ESTIMATED_COST); } else { command.Parameters.AddWithValue("@ESTIMATED_COST", DBNull.Value); } 
					if (historycalculator.ESTIMATED_FLOWRATE != null) { command.Parameters.AddWithValue("@ESTIMATED_FLOWRATE", historycalculator.ESTIMATED_FLOWRATE); } else { command.Parameters.AddWithValue("@ESTIMATED_FLOWRATE", DBNull.Value); } 
					if (historycalculator.REMAINING_CAPACITY != null) { command.Parameters.AddWithValue("@REMAINING_CAPACITY", historycalculator.REMAINING_CAPACITY); } else { command.Parameters.AddWithValue("@REMAINING_CAPACITY", DBNull.Value); } 
					if (historycalculator.CATEGORY != null) { command.Parameters.AddWithValue("@CATEGORY", historycalculator.CATEGORY); } else { command.Parameters.AddWithValue("@CATEGORY", DBNull.Value); } 
					if (historycalculator.CUSTOMER != null) { command.Parameters.AddWithValue("@CUSTOMER", historycalculator.CUSTOMER); } else { command.Parameters.AddWithValue("@CUSTOMER", DBNull.Value); } 
					if (historycalculator.LAT != null) { command.Parameters.AddWithValue("@LAT", historycalculator.LAT); } else { command.Parameters.AddWithValue("@LAT", DBNull.Value); } 
					if (historycalculator.LNG != null) { command.Parameters.AddWithValue("@LNG", historycalculator.LNG); } else { command.Parameters.AddWithValue("@LNG", DBNull.Value); } 
					if (historycalculator.CREATED_DATE != null) { command.Parameters.AddWithValue("@CREATED_DATE", DateTime.Now); } else { command.Parameters.AddWithValue("@CREATED_DATE", DBNull.Value); } 
					if (historycalculator.CREATED_BY != null) { command.Parameters.AddWithValue("@CREATED_BY", historycalculator.CREATED_BY); } else { command.Parameters.AddWithValue("@CREATED_BY", DBNull.Value); } 
					command.ExecuteNonQuery();
				}
				catch (Exception ex)
				{
					Message = ex.Message;
				}
			}
		}

		public void AddMany(List<HistoryCalculator> historycalculator)
		{
			using (var conn = new SqlConnection(connString))
			{
				try
				{
					Message = "";
					conn.Open();
					int pos = 0;
					foreach(HistoryCalculator item in historycalculator)
					{
                        SqlCommand command = new SqlCommand("INSERT INTO PL_HISTORY_CALCULATOR ([ID], [SOURCE_DIAMETER], [SOURCE_PRESSURE], [PRESSURE_INPUT], [FLOWRATE_INPUT], [ESTIMATED_DIAMETER], [ESTIMATED_LENGTH], [ESTIMATED_COST], [ESTIMATED_FLOWRATE], [REMAINING_CAPACITY], [CATEGORY], [CUSTOMER], [LAT], [LNG], [CREATED_DATE], [CREATED_BY]) VALUES(@ID, @SOURCE_DIAMETER, @SOURCE_PRESSURE, @PRESSURE_INPUT, @FLOWRATE_INPUT, @ESTIMATED_DIAMETER, @ESTIMATED_LENGTH, @ESTIMATED_COST, @ESTIMATED_FLOWRATE, @REMAINING_CAPACITY, @CATEGORY, @CUSTOMER, @LAT, @LNG, @CREATED_DATE, @CREATED_BY)", conn);
						command.CommandType = System.Data.CommandType.Text;
						if (historycalculator[pos].ID != null) { command.Parameters.AddWithValue("@ID", historycalculator[pos].ID); } else { command.Parameters.AddWithValue("@ID", DBNull.Value); } 
						if (historycalculator[pos].SOURCE_DIAMETER != null) { command.Parameters.AddWithValue("@SOURCE_DIAMETER", historycalculator[pos].SOURCE_DIAMETER); } else { command.Parameters.AddWithValue("@SOURCE_DIAMETER", DBNull.Value); } 
						if (historycalculator[pos].SOURCE_PRESSURE != null) { command.Parameters.AddWithValue("@SOURCE_PRESSURE", historycalculator[pos].SOURCE_PRESSURE); } else { command.Parameters.AddWithValue("@SOURCE_PRESSURE", DBNull.Value); } 
						if (historycalculator[pos].PRESSURE_INPUT != null) { command.Parameters.AddWithValue("@PRESSURE_INPUT", historycalculator[pos].PRESSURE_INPUT); } else { command.Parameters.AddWithValue("@PRESSURE_INPUT", DBNull.Value); } 
						if (historycalculator[pos].FLOWRATE_INPUT != null) { command.Parameters.AddWithValue("@FLOWRATE_INPUT", historycalculator[pos].FLOWRATE_INPUT); } else { command.Parameters.AddWithValue("@FLOWRATE_INPUT", DBNull.Value); } 
						if (historycalculator[pos].ESTIMATED_DIAMETER != null) { command.Parameters.AddWithValue("@ESTIMATED_DIAMETER", historycalculator[pos].ESTIMATED_DIAMETER); } else { command.Parameters.AddWithValue("@ESTIMATED_DIAMETER", DBNull.Value); } 
						if (historycalculator[pos].ESTIMATED_LENGTH != null) { command.Parameters.AddWithValue("@ESTIMATED_LENGTH", historycalculator[pos].ESTIMATED_LENGTH); } else { command.Parameters.AddWithValue("@ESTIMATED_LENGTH", DBNull.Value); } 
						if (historycalculator[pos].ESTIMATED_COST != null) { command.Parameters.AddWithValue("@ESTIMATED_COST", historycalculator[pos].ESTIMATED_COST); } else { command.Parameters.AddWithValue("@ESTIMATED_COST", DBNull.Value); } 
						if (historycalculator[pos].ESTIMATED_FLOWRATE != null) { command.Parameters.AddWithValue("@ESTIMATED_FLOWRATE", historycalculator[pos].ESTIMATED_FLOWRATE); } else { command.Parameters.AddWithValue("@ESTIMATED_FLOWRATE", DBNull.Value); } 
						if (historycalculator[pos].REMAINING_CAPACITY != null) { command.Parameters.AddWithValue("@REMAINING_CAPACITY", historycalculator[pos].REMAINING_CAPACITY); } else { command.Parameters.AddWithValue("@REMAINING_CAPACITY", DBNull.Value); } 
						if (historycalculator[pos].CATEGORY != null) { command.Parameters.AddWithValue("@CATEGORY", historycalculator[pos].CATEGORY); } else { command.Parameters.AddWithValue("@CATEGORY", DBNull.Value); } 
						if (historycalculator[pos].CUSTOMER != null) { command.Parameters.AddWithValue("@CUSTOMER", historycalculator[pos].CUSTOMER); } else { command.Parameters.AddWithValue("@CUSTOMER", DBNull.Value); } 
						if (historycalculator[pos].LAT != null) { command.Parameters.AddWithValue("@LAT", historycalculator[pos].LAT); } else { command.Parameters.AddWithValue("@LAT", DBNull.Value); } 
						if (historycalculator[pos].LNG != null) { command.Parameters.AddWithValue("@LNG", historycalculator[pos].LNG); } else { command.Parameters.AddWithValue("@LNG", DBNull.Value); } 
						if (historycalculator[pos].CREATED_DATE != null) { command.Parameters.AddWithValue("@CREATED_DATE", historycalculator[pos].CREATED_DATE); } else { command.Parameters.AddWithValue("@CREATED_DATE", DBNull.Value); } 
						if (historycalculator[pos].CREATED_BY != null) { command.Parameters.AddWithValue("@CREATED_BY", historycalculator[pos].CREATED_BY); } else { command.Parameters.AddWithValue("@CREATED_BY", DBNull.Value); } 
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

		public void Update(HistoryCalculator historycalculator)
		{
			using (var conn = new SqlConnection(connString))
			{
				try
				{
					Message = "";
					conn.Open();
                    SqlCommand command = new SqlCommand("UPDATE PL_HISTORY_CALCULATOR SET SOURCE_DIAMETER = @SOURCE_DIAMETER, SOURCE_PRESSURE = @SOURCE_PRESSURE, PRESSURE_INPUT = @PRESSURE_INPUT, FLOWRATE_INPUT = @FLOWRATE_INPUT, ESTIMATED_DIAMETER = @ESTIMATED_DIAMETER, ESTIMATED_LENGTH = @ESTIMATED_LENGTH, ESTIMATED_COST = @ESTIMATED_COST, ESTIMATED_FLOWRATE = @ESTIMATED_FLOWRATE, REMAINING_CAPACITY = @REMAINING_CAPACITY, CATEGORY = @CATEGORY, CUSTOMER = @CUSTOMER, LAT = @LAT, LNG = @LNG, CREATED_DATE = @CREATED_DATE, CREATED_BY = @CREATED_BY WHERE ID = @ID", conn);
					command.CommandType = System.Data.CommandType.Text;
					if (historycalculator.ID != null) { command.Parameters.AddWithValue("@ID", historycalculator.ID); } else { command.Parameters.AddWithValue("@ID", DBNull.Value); } 
					if (historycalculator.SOURCE_DIAMETER != null) { command.Parameters.AddWithValue("@SOURCE_DIAMETER", historycalculator.SOURCE_DIAMETER); } else { command.Parameters.AddWithValue("@SOURCE_DIAMETER", DBNull.Value); } 
					if (historycalculator.SOURCE_PRESSURE != null) { command.Parameters.AddWithValue("@SOURCE_PRESSURE", historycalculator.SOURCE_PRESSURE); } else { command.Parameters.AddWithValue("@SOURCE_PRESSURE", DBNull.Value); } 
					if (historycalculator.PRESSURE_INPUT != null) { command.Parameters.AddWithValue("@PRESSURE_INPUT", historycalculator.PRESSURE_INPUT); } else { command.Parameters.AddWithValue("@PRESSURE_INPUT", DBNull.Value); } 
					if (historycalculator.FLOWRATE_INPUT != null) { command.Parameters.AddWithValue("@FLOWRATE_INPUT", historycalculator.FLOWRATE_INPUT); } else { command.Parameters.AddWithValue("@FLOWRATE_INPUT", DBNull.Value); } 
					if (historycalculator.ESTIMATED_DIAMETER != null) { command.Parameters.AddWithValue("@ESTIMATED_DIAMETER", historycalculator.ESTIMATED_DIAMETER); } else { command.Parameters.AddWithValue("@ESTIMATED_DIAMETER", DBNull.Value); } 
					if (historycalculator.ESTIMATED_LENGTH != null) { command.Parameters.AddWithValue("@ESTIMATED_LENGTH", historycalculator.ESTIMATED_LENGTH); } else { command.Parameters.AddWithValue("@ESTIMATED_LENGTH", DBNull.Value); } 
					if (historycalculator.ESTIMATED_COST != null) { command.Parameters.AddWithValue("@ESTIMATED_COST", historycalculator.ESTIMATED_COST); } else { command.Parameters.AddWithValue("@ESTIMATED_COST", DBNull.Value); } 
					if (historycalculator.ESTIMATED_FLOWRATE != null) { command.Parameters.AddWithValue("@ESTIMATED_FLOWRATE", historycalculator.ESTIMATED_FLOWRATE); } else { command.Parameters.AddWithValue("@ESTIMATED_FLOWRATE", DBNull.Value); } 
					if (historycalculator.REMAINING_CAPACITY != null) { command.Parameters.AddWithValue("@REMAINING_CAPACITY", historycalculator.REMAINING_CAPACITY); } else { command.Parameters.AddWithValue("@REMAINING_CAPACITY", DBNull.Value); } 
					if (historycalculator.CATEGORY != null) { command.Parameters.AddWithValue("@CATEGORY", historycalculator.CATEGORY); } else { command.Parameters.AddWithValue("@CATEGORY", DBNull.Value); } 
					if (historycalculator.CUSTOMER != null) { command.Parameters.AddWithValue("@CUSTOMER", historycalculator.CUSTOMER); } else { command.Parameters.AddWithValue("@CUSTOMER", DBNull.Value); } 
					if (historycalculator.LAT != null) { command.Parameters.AddWithValue("@LAT", historycalculator.LAT); } else { command.Parameters.AddWithValue("@LAT", DBNull.Value); } 
					if (historycalculator.LNG != null) { command.Parameters.AddWithValue("@LNG", historycalculator.LNG); } else { command.Parameters.AddWithValue("@LNG", DBNull.Value); } 
					if (historycalculator.CREATED_DATE != null) { command.Parameters.AddWithValue("@CREATED_DATE", historycalculator.CREATED_DATE); } else { command.Parameters.AddWithValue("@CREATED_DATE", DBNull.Value); } 
					if (historycalculator.CREATED_BY != null) { command.Parameters.AddWithValue("@CREATED_BY", historycalculator.CREATED_BY); } else { command.Parameters.AddWithValue("@CREATED_BY", DBNull.Value); } 
					command.ExecuteNonQuery();
				}
				catch (Exception ex)
				{
					Message = ex.Message;
				}
			}
		}

		public void UpdateMany(List<HistoryCalculator> historycalculators)
		{
			using (var conn = new SqlConnection(connString))
			{
				try
				{
					Message = "";
					conn.Open();
					foreach(HistoryCalculator item in historycalculators)
					{
                        SqlCommand command = new SqlCommand("UPDATE PL_HISTORY_CALCULATOR SET SOURCE_DIAMETER = @SOURCE_DIAMETER, SOURCE_PRESSURE = @SOURCE_PRESSURE, PRESSURE_INPUT = @PRESSURE_INPUT, FLOWRATE_INPUT = @FLOWRATE_INPUT, ESTIMATED_DIAMETER = @ESTIMATED_DIAMETER, ESTIMATED_LENGTH = @ESTIMATED_LENGTH, ESTIMATED_COST = @ESTIMATED_COST, ESTIMATED_FLOWRATE = @ESTIMATED_FLOWRATE, REMAINING_CAPACITY = @REMAINING_CAPACITY, CATEGORY = @CATEGORY, CUSTOMER = @CUSTOMER, LAT = @LAT, LNG = @LNG, CREATED_DATE = @CREATED_DATE, CREATED_BY = @CREATED_BY WHERE ID = @ID", conn);
						command.CommandType = System.Data.CommandType.Text;
						if (item.ID != null) { command.Parameters.AddWithValue("@ID", item.ID); } else { command.Parameters.AddWithValue("@ID", DBNull.Value); } 
						if (item.SOURCE_DIAMETER != null) { command.Parameters.AddWithValue("@SOURCE_DIAMETER", item.SOURCE_DIAMETER); } else { command.Parameters.AddWithValue("@SOURCE_DIAMETER", DBNull.Value); } 
						if (item.SOURCE_PRESSURE != null) { command.Parameters.AddWithValue("@SOURCE_PRESSURE", item.SOURCE_PRESSURE); } else { command.Parameters.AddWithValue("@SOURCE_PRESSURE", DBNull.Value); } 
						if (item.PRESSURE_INPUT != null) { command.Parameters.AddWithValue("@PRESSURE_INPUT", item.PRESSURE_INPUT); } else { command.Parameters.AddWithValue("@PRESSURE_INPUT", DBNull.Value); } 
						if (item.FLOWRATE_INPUT != null) { command.Parameters.AddWithValue("@FLOWRATE_INPUT", item.FLOWRATE_INPUT); } else { command.Parameters.AddWithValue("@FLOWRATE_INPUT", DBNull.Value); } 
						if (item.ESTIMATED_DIAMETER != null) { command.Parameters.AddWithValue("@ESTIMATED_DIAMETER", item.ESTIMATED_DIAMETER); } else { command.Parameters.AddWithValue("@ESTIMATED_DIAMETER", DBNull.Value); } 
						if (item.ESTIMATED_LENGTH != null) { command.Parameters.AddWithValue("@ESTIMATED_LENGTH", item.ESTIMATED_LENGTH); } else { command.Parameters.AddWithValue("@ESTIMATED_LENGTH", DBNull.Value); } 
						if (item.ESTIMATED_COST != null) { command.Parameters.AddWithValue("@ESTIMATED_COST", item.ESTIMATED_COST); } else { command.Parameters.AddWithValue("@ESTIMATED_COST", DBNull.Value); } 
						if (item.ESTIMATED_FLOWRATE != null) { command.Parameters.AddWithValue("@ESTIMATED_FLOWRATE", item.ESTIMATED_FLOWRATE); } else { command.Parameters.AddWithValue("@ESTIMATED_FLOWRATE", DBNull.Value); } 
						if (item.REMAINING_CAPACITY != null) { command.Parameters.AddWithValue("@REMAINING_CAPACITY", item.REMAINING_CAPACITY); } else { command.Parameters.AddWithValue("@REMAINING_CAPACITY", DBNull.Value); } 
						if (item.CATEGORY != null) { command.Parameters.AddWithValue("@CATEGORY", item.CATEGORY); } else { command.Parameters.AddWithValue("@CATEGORY", DBNull.Value); } 
						if (item.CUSTOMER != null) { command.Parameters.AddWithValue("@CUSTOMER", item.CUSTOMER); } else { command.Parameters.AddWithValue("@CUSTOMER", DBNull.Value); } 
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

		public void Remove(HistoryCalculator id)
		{
			using (var conn = new SqlConnection(connString))
			{
				try
				{
					Message = "";
					conn.Open();
                    SqlCommand command = new SqlCommand("DELETE PL_HISTORY_CALCULATOR WHERE ID = @ID", conn);
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

		public List<HistoryCalculator> GetData()
		{
			List<HistoryCalculator> items = new List<HistoryCalculator>();
			using (var conn = new SqlConnection(connString))
			{
				Message = "";
				try
				{
					conn.Open();
                    SqlCommand command = new SqlCommand("SELECT [ID], [SOURCE_DIAMETER], [SOURCE_PRESSURE], [PRESSURE_INPUT], [FLOWRATE_INPUT], [ESTIMATED_DIAMETER], [ESTIMATED_LENGTH], [ESTIMATED_COST], [ESTIMATED_FLOWRATE], [REMAINING_CAPACITY], [CATEGORY], [CUSTOMER], [LAT], [LNG], [CREATED_DATE], [CREATED_BY] FROM PL_HISTORY_CALCULATOR  order by CREATED_DATE desc", conn);
					SqlDataReader reader = command.ExecuteReader();
					HistoryCalculator item = new HistoryCalculator();
					while(reader.Read())
					{
						item = new HistoryCalculator();
						if (reader[0] != DBNull.Value) { item.ID = Convert.ToInt32(reader[0]); }
						if (reader[1] != DBNull.Value) { item.SOURCE_DIAMETER = Convert.ToDouble(reader[1]); }
						if (reader[2] != DBNull.Value) { item.SOURCE_PRESSURE = Convert.ToDouble(reader[2]); }
						if (reader[3] != DBNull.Value) { item.PRESSURE_INPUT = Convert.ToDouble(reader[3]); }
						if (reader[4] != DBNull.Value) { item.FLOWRATE_INPUT = Convert.ToDouble(reader[4]); }
						if (reader[5] != DBNull.Value) { item.ESTIMATED_DIAMETER = Convert.ToDouble(reader[5]); }
						if (reader[6] != DBNull.Value) { item.ESTIMATED_LENGTH = Convert.ToDouble(reader[6]); }
						if (reader[7] != DBNull.Value) { item.ESTIMATED_COST = Convert.ToDouble(reader[7]); }
						if (reader[8] != DBNull.Value) { item.ESTIMATED_FLOWRATE = Convert.ToDouble(reader[8]); }
						if (reader[9] != DBNull.Value) { item.REMAINING_CAPACITY = Convert.ToDouble(reader[9]); }
						if (reader[10] != DBNull.Value) { item.CATEGORY = Convert.ToString(reader[10]); }
						if (reader[11] != DBNull.Value) { item.CUSTOMER = Convert.ToString(reader[11]); }
						if (reader[12] != DBNull.Value) { item.LAT = Convert.ToDouble(reader[12]); }
						if (reader[13] != DBNull.Value) { item.LNG = Convert.ToDouble(reader[13]); }
						if (reader[14] != DBNull.Value) { item.CREATED_DATE = Convert.ToDateTime(reader[14]); }
						if (reader[15] != DBNull.Value) { item.CREATED_BY = Convert.ToString(reader[15]); }
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

		public List<HistoryCalculator> GetDataByID(int ID)
		{
			List<HistoryCalculator> items = new List<HistoryCalculator>();
			using (var conn = new SqlConnection(connString))
			{
				Message = "";
				try
				{
					conn.Open();
                    SqlCommand command = new SqlCommand("SELECT [ID], [SOURCE_DIAMETER], [SOURCE_PRESSURE], [PRESSURE_INPUT], [FLOWRATE_INPUT], [ESTIMATED_DIAMETER], [ESTIMATED_LENGTH], [ESTIMATED_COST], [ESTIMATED_FLOWRATE], [REMAINING_CAPACITY], [CATEGORY], [CUSTOMER], [LAT], [LNG], [CREATED_DATE], [CREATED_BY] FROM PL_HISTORY_CALCULATOR WHERE ID = @ID", conn);
					command.Parameters.AddWithValue("@ID", ID);
					SqlDataReader reader = command.ExecuteReader();
					HistoryCalculator item = new HistoryCalculator();
					while(reader.Read())
					{
						item = new HistoryCalculator();
						if (reader[0] != DBNull.Value) { item.ID = Convert.ToInt32(reader[0]); }
						if (reader[1] != DBNull.Value) { item.SOURCE_DIAMETER = Convert.ToDouble(reader[1]); }
						if (reader[2] != DBNull.Value) { item.SOURCE_PRESSURE = Convert.ToDouble(reader[2]); }
						if (reader[3] != DBNull.Value) { item.PRESSURE_INPUT = Convert.ToDouble(reader[3]); }
						if (reader[4] != DBNull.Value) { item.FLOWRATE_INPUT = Convert.ToDouble(reader[4]); }
						if (reader[5] != DBNull.Value) { item.ESTIMATED_DIAMETER = Convert.ToDouble(reader[5]); }
						if (reader[6] != DBNull.Value) { item.ESTIMATED_LENGTH = Convert.ToDouble(reader[6]); }
						if (reader[7] != DBNull.Value) { item.ESTIMATED_COST = Convert.ToDouble(reader[7]); }
						if (reader[8] != DBNull.Value) { item.ESTIMATED_FLOWRATE = Convert.ToDouble(reader[8]); }
						if (reader[9] != DBNull.Value) { item.REMAINING_CAPACITY = Convert.ToDouble(reader[9]); }
						if (reader[10] != DBNull.Value) { item.CATEGORY = Convert.ToString(reader[10]); }
						if (reader[11] != DBNull.Value) { item.CUSTOMER = Convert.ToString(reader[11]); }
						if (reader[12] != DBNull.Value) { item.LAT = Convert.ToDouble(reader[12]); }
                        if (reader[13] != DBNull.Value) { item.LNG = Convert.ToDouble(reader[13]); }
						if (reader[14] != DBNull.Value) { item.CREATED_DATE = Convert.ToDateTime(reader[14]); }
						if (reader[15] != DBNull.Value) { item.CREATED_BY = Convert.ToString(reader[15]); }
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
                    SqlCommand command = new SqlCommand("DELETE PL_HISTORY_CALCULATOR WHERE ID = @ID", conn);
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

		public DataTable GetDataTable(List<HistoryCalculator> historycalculator)
		{
            DataTable dt = new DataTable("PL_HISTORY_CALCULATOR");

			DataColumn c1 = new DataColumn("ID", typeof(int)); 
			dt.Columns.Add(c1);
			DataColumn c2 = new DataColumn("SOURCE_DIAMETER", typeof(double)); c2.AllowDBNull = true;
			dt.Columns.Add(c2);
			DataColumn c3 = new DataColumn("SOURCE_PRESSURE", typeof(double)); c3.AllowDBNull = true;
			dt.Columns.Add(c3);
			DataColumn c4 = new DataColumn("PRESSURE_INPUT", typeof(double)); c4.AllowDBNull = true;
			dt.Columns.Add(c4);
			DataColumn c5 = new DataColumn("FLOWRATE_INPUT", typeof(double)); c5.AllowDBNull = true;
			dt.Columns.Add(c5);
			DataColumn c6 = new DataColumn("ESTIMATED_DIAMETER", typeof(double)); c6.AllowDBNull = true;
			dt.Columns.Add(c6);
			DataColumn c7 = new DataColumn("ESTIMATED_LENGTH", typeof(double)); c7.AllowDBNull = true;
			dt.Columns.Add(c7);
			DataColumn c8 = new DataColumn("ESTIMATED_COST", typeof(double)); c8.AllowDBNull = true;
			dt.Columns.Add(c8);
			DataColumn c9 = new DataColumn("ESTIMATED_FLOWRATE", typeof(double)); c9.AllowDBNull = true;
			dt.Columns.Add(c9);
			DataColumn c10 = new DataColumn("REMAINING_CAPACITY", typeof(double)); c10.AllowDBNull = true;
			dt.Columns.Add(c10);
			DataColumn c11 = new DataColumn("CATEGORY", typeof(string)); c11.AllowDBNull = true;
			dt.Columns.Add(c11);
			DataColumn c12 = new DataColumn("CUSTOMER", typeof(string)); c12.AllowDBNull = true;
			dt.Columns.Add(c12);
			DataColumn c13 = new DataColumn("LAT", typeof(double)); c13.AllowDBNull = true;
			dt.Columns.Add(c13);
			DataColumn c14 = new DataColumn("LNG", typeof(double)); c14.AllowDBNull = true;
			dt.Columns.Add(c14);
			DataColumn c15 = new DataColumn("CREATED_DATE", typeof(DateTime)); c15.AllowDBNull = true;
			dt.Columns.Add(c15);
			DataColumn c16 = new DataColumn("CREATED_BY", typeof(string)); c16.AllowDBNull = true;
			dt.Columns.Add(c16);

			foreach (HistoryCalculator v in historycalculator)
			{
				DataRow dr = dt.NewRow();
				if (v.ID != null) { dr[0] = v.ID; } else { dr[0] = DBNull.Value; }
				if (v.SOURCE_DIAMETER != null) { dr[1] = v.SOURCE_DIAMETER; } else { dr[1] = DBNull.Value; }
				if (v.SOURCE_PRESSURE != null) { dr[2] = v.SOURCE_PRESSURE; } else { dr[2] = DBNull.Value; }
				if (v.PRESSURE_INPUT != null) { dr[3] = v.PRESSURE_INPUT; } else { dr[3] = DBNull.Value; }
				if (v.FLOWRATE_INPUT != null) { dr[4] = v.FLOWRATE_INPUT; } else { dr[4] = DBNull.Value; }
				if (v.ESTIMATED_DIAMETER != null) { dr[5] = v.ESTIMATED_DIAMETER; } else { dr[5] = DBNull.Value; }
				if (v.ESTIMATED_LENGTH != null) { dr[6] = v.ESTIMATED_LENGTH; } else { dr[6] = DBNull.Value; }
				if (v.ESTIMATED_COST != null) { dr[7] = v.ESTIMATED_COST; } else { dr[7] = DBNull.Value; }
				if (v.ESTIMATED_FLOWRATE != null) { dr[8] = v.ESTIMATED_FLOWRATE; } else { dr[8] = DBNull.Value; }
				if (v.REMAINING_CAPACITY != null) { dr[9] = v.REMAINING_CAPACITY; } else { dr[9] = DBNull.Value; }
				if (v.CATEGORY != null) { dr[10] = v.CATEGORY; } else { dr[10] = DBNull.Value; }
				if (v.CUSTOMER != null) { dr[11] = v.CUSTOMER; } else { dr[11] = DBNull.Value; }
				if (v.LAT != null) { dr[12] = v.LAT; } else { dr[12] = DBNull.Value; }
				if (v.LNG != null) { dr[13] = v.LNG; } else { dr[13] = DBNull.Value; }
				if (v.CREATED_DATE != null) { dr[14] = v.CREATED_DATE; } else { dr[14] = DBNull.Value; }
				if (v.CREATED_BY != null) { dr[15] = v.CREATED_BY; } else { dr[15] = DBNull.Value; }
				dt.Rows.Add(dr);
			}
			dt.AcceptChanges();

			return dt;
		}

		public void AddManyBulk(List<HistoryCalculator> historycalculator)
		{
			using (var conn = new SqlConnection(connString))
			{
				try
				{
					Message = "";
					conn.Open();

					DataTable dt = GetDataTable(historycalculator);
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