using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using WebThemeforest2.Models;

namespace WebThemeforest2.Repositories
{
	public partial class PL_CONFIG_CALC_AREARepository
	{
		private string connString;
		public string Message { get; set; }

		public PL_CONFIG_CALC_AREARepository(string connectionString)
		{
			connString = connectionString;
		}

		public void Add(PL_CONFIG_CALC_AREA pl_config_calc_area)
		{
			using (var conn = new SqlConnection(connString))
			{
				try
				{
					Message = "";
					conn.Open();
					SqlCommand command = new SqlCommand("INSERT INTO PL_CONFIG_CALC_AREA ([AREA], [REGIME], [FILE_NAME], [ENABLED]) VALUES(@AREA, @REGIME, @FILE_NAME, @ENABLED)", conn);
					command.CommandType = System.Data.CommandType.Text;
                    //if (pl_config_calc_area.ID != null) { command.Parameters.AddWithValue("@ID", pl_config_calc_area.ID); } else { command.Parameters.AddWithValue("@ID", DBNull.Value); } 
					if (pl_config_calc_area.AREA != null) { command.Parameters.AddWithValue("@AREA", pl_config_calc_area.AREA); } else { command.Parameters.AddWithValue("@AREA", DBNull.Value); } 
					if (pl_config_calc_area.REGIME != null) { command.Parameters.AddWithValue("@REGIME", pl_config_calc_area.REGIME); } else { command.Parameters.AddWithValue("@REGIME", DBNull.Value); } 
					if (pl_config_calc_area.FILE_NAME != null) { command.Parameters.AddWithValue("@FILE_NAME", pl_config_calc_area.FILE_NAME); } else { command.Parameters.AddWithValue("@FILE_NAME", DBNull.Value); } 
					if (pl_config_calc_area.ENABLED != null) { command.Parameters.AddWithValue("@ENABLED", pl_config_calc_area.ENABLED); } else { command.Parameters.AddWithValue("@ENABLED", DBNull.Value); } 
					command.ExecuteNonQuery();
				}
				catch (Exception ex)
				{
					Message = ex.Message;
				}
			}
		}

		public void AddMany(List<PL_CONFIG_CALC_AREA> pl_config_calc_area)
		{
			using (var conn = new SqlConnection(connString))
			{
				try
				{
					Message = "";
					conn.Open();
					int pos = 0;
					foreach(PL_CONFIG_CALC_AREA item in pl_config_calc_area)
					{
						SqlCommand command = new SqlCommand("INSERT INTO PL_CONFIG_CALC_AREA ([ID], [AREA], [REGIME], [FILE_NAME], [ENABLED]) VALUES(@ID, @AREA, @REGIME, @FILE_NAME, @ENABLED)", conn);
						command.CommandType = System.Data.CommandType.Text;
						if (pl_config_calc_area[pos].ID != null) { command.Parameters.AddWithValue("@ID", pl_config_calc_area[pos].ID); } else { command.Parameters.AddWithValue("@ID", DBNull.Value); } 
						if (pl_config_calc_area[pos].AREA != null) { command.Parameters.AddWithValue("@AREA", pl_config_calc_area[pos].AREA); } else { command.Parameters.AddWithValue("@AREA", DBNull.Value); } 
						if (pl_config_calc_area[pos].REGIME != null) { command.Parameters.AddWithValue("@REGIME", pl_config_calc_area[pos].REGIME); } else { command.Parameters.AddWithValue("@REGIME", DBNull.Value); } 
						if (pl_config_calc_area[pos].FILE_NAME != null) { command.Parameters.AddWithValue("@FILE_NAME", pl_config_calc_area[pos].FILE_NAME); } else { command.Parameters.AddWithValue("@FILE_NAME", DBNull.Value); } 
						if (pl_config_calc_area[pos].ENABLED != null) { command.Parameters.AddWithValue("@ENABLED", pl_config_calc_area[pos].ENABLED); } else { command.Parameters.AddWithValue("@ENABLED", DBNull.Value); } 
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

		public void Update(PL_CONFIG_CALC_AREA pl_config_calc_area)
		{
			using (var conn = new SqlConnection(connString))
			{
				try
				{
					Message = "";
					conn.Open();
					SqlCommand command = new SqlCommand("UPDATE PL_CONFIG_CALC_AREA SET AREA = @AREA, REGIME = @REGIME, FILE_NAME = @FILE_NAME, ENABLED = @ENABLED WHERE ID = @ID", conn);
					command.CommandType = System.Data.CommandType.Text;
					if (pl_config_calc_area.ID != null) { command.Parameters.AddWithValue("@ID", pl_config_calc_area.ID); } else { command.Parameters.AddWithValue("@ID", DBNull.Value); } 
					if (pl_config_calc_area.AREA != null) { command.Parameters.AddWithValue("@AREA", pl_config_calc_area.AREA); } else { command.Parameters.AddWithValue("@AREA", DBNull.Value); } 
					if (pl_config_calc_area.REGIME != null) { command.Parameters.AddWithValue("@REGIME", pl_config_calc_area.REGIME); } else { command.Parameters.AddWithValue("@REGIME", DBNull.Value); } 
					if (pl_config_calc_area.FILE_NAME != null) { command.Parameters.AddWithValue("@FILE_NAME", pl_config_calc_area.FILE_NAME); } else { command.Parameters.AddWithValue("@FILE_NAME", DBNull.Value); } 
					if (pl_config_calc_area.ENABLED != null) { command.Parameters.AddWithValue("@ENABLED", pl_config_calc_area.ENABLED); } else { command.Parameters.AddWithValue("@ENABLED", DBNull.Value); } 
					command.ExecuteNonQuery();
				}
				catch (Exception ex)
				{
					Message = ex.Message;
				}
			}
		}

		public void UpdateMany(List<PL_CONFIG_CALC_AREA> pl_config_calc_areas)
		{
			using (var conn = new SqlConnection(connString))
			{
				try
				{
					Message = "";
					conn.Open();
					foreach(PL_CONFIG_CALC_AREA item in pl_config_calc_areas)
					{
						SqlCommand command = new SqlCommand("UPDATE PL_CONFIG_CALC_AREA SET AREA = @AREA, REGIME = @REGIME, FILE_NAME = @FILE_NAME, ENABLED = @ENABLED WHERE ID = @ID", conn);
						command.CommandType = System.Data.CommandType.Text;
						if (item.ID != null) { command.Parameters.AddWithValue("@ID", item.ID); } else { command.Parameters.AddWithValue("@ID", DBNull.Value); } 
						if (item.AREA != null) { command.Parameters.AddWithValue("@AREA", item.AREA); } else { command.Parameters.AddWithValue("@AREA", DBNull.Value); } 
						if (item.REGIME != null) { command.Parameters.AddWithValue("@REGIME", item.REGIME); } else { command.Parameters.AddWithValue("@REGIME", DBNull.Value); } 
						if (item.FILE_NAME != null) { command.Parameters.AddWithValue("@FILE_NAME", item.FILE_NAME); } else { command.Parameters.AddWithValue("@FILE_NAME", DBNull.Value); } 
						if (item.ENABLED != null) { command.Parameters.AddWithValue("@ENABLED", item.ENABLED); } else { command.Parameters.AddWithValue("@ENABLED", DBNull.Value); } 
						command.ExecuteNonQuery();
					}
				}
				catch (Exception ex)
				{
					Message = ex.Message;
				}
			}
		}

		public void Remove(PL_CONFIG_CALC_AREA id)
		{
			using (var conn = new SqlConnection(connString))
			{
				try
				{
					Message = "";
					conn.Open();
					SqlCommand command = new SqlCommand("DELETE PL_CONFIG_CALC_AREA WHERE ID = @ID", conn);
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

        public List<PL_CONFIG_CALC_AREA> GetData()
        {
            List<PL_CONFIG_CALC_AREA> items = new List<PL_CONFIG_CALC_AREA>();
            using (var conn = new SqlConnection(connString))
            {
                Message = "";
                try
                {
                    conn.Open();
                    SqlCommand command = new SqlCommand("SELECT [ID], [AREA], [REGIME], [FILE_NAME], [ENABLED] FROM PL_CONFIG_CALC_AREA", conn);
                    SqlDataReader reader = command.ExecuteReader();
                    PL_CONFIG_CALC_AREA item = new PL_CONFIG_CALC_AREA();
                    while (reader.Read())
                    {
                        item = new PL_CONFIG_CALC_AREA();
                        if (reader[0] != DBNull.Value) { item.ID = Convert.ToInt32(reader[0]); }
                        if (reader[1] != DBNull.Value) { item.AREA = Convert.ToString(reader[1]); }
                        if (reader[2] != DBNull.Value) { item.REGIME = Convert.ToString(reader[2]); }
                        if (reader[3] != DBNull.Value) { item.FILE_NAME = Convert.ToString(reader[3]); }
                        if (reader[4] != DBNull.Value) { item.ENABLED = Convert.ToInt32(reader[4]); }
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





		public List<PL_CONFIG_CALC_AREA> GetDataByID(int ID)
		{
			List<PL_CONFIG_CALC_AREA> items = new List<PL_CONFIG_CALC_AREA>();
			using (var conn = new SqlConnection(connString))
			{
				Message = "";
				try
				{
					conn.Open();
					SqlCommand command = new SqlCommand("SELECT [ID], [AREA], [REGIME], [FILE_NAME], [ENABLED] FROM PL_CONFIG_CALC_AREA WHERE ID = @ID", conn);
					command.Parameters.AddWithValue("@ID", ID);
					SqlDataReader reader = command.ExecuteReader();
					PL_CONFIG_CALC_AREA item = new PL_CONFIG_CALC_AREA();
					while(reader.Read())
					{
						item = new PL_CONFIG_CALC_AREA();
						if (reader[0] != DBNull.Value) { item.ID = Convert.ToInt32(reader[0]); }
						if (reader[1] != DBNull.Value) { item.AREA = Convert.ToString(reader[1]); }
						if (reader[2] != DBNull.Value) { item.REGIME = Convert.ToString(reader[2]); }
						if (reader[3] != DBNull.Value) { item.FILE_NAME = Convert.ToString(reader[3]); }
						if (reader[4] != DBNull.Value) { item.ENABLED = Convert.ToInt32(reader[4]); }
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


        public List<PL_CONFIG_CALC_AREA> GetDataByAREA(string AREA)
        {
            List<PL_CONFIG_CALC_AREA> items = new List<PL_CONFIG_CALC_AREA>();
            using (var conn = new SqlConnection(connString))
            {
                Message = "";
                try
                {
                    conn.Open();
                    SqlCommand command = new SqlCommand("SELECT [ID], [AREA], [REGIME], [FILE_NAME], [ENABLED], [LAT], [LNG], [ID_CONSTRUCTION], [CATEGORY], [ENABLED] FROM PL_CONFIG_CALC_AREA WHERE AREA = @AREA", conn);
                    command.Parameters.AddWithValue("@AREA", AREA);
                    SqlDataReader reader = command.ExecuteReader();
                    PL_CONFIG_CALC_AREA item = new PL_CONFIG_CALC_AREA();
                    while (reader.Read())
                    {
                        item = new PL_CONFIG_CALC_AREA();
                        if (reader[0] != DBNull.Value) { item.ID = Convert.ToInt32(reader[0]); }
                        if (reader[1] != DBNull.Value) { item.AREA = Convert.ToString(reader[1]); }
                        if (reader[2] != DBNull.Value) { item.REGIME = Convert.ToString(reader[2]); }
                        if (reader[3] != DBNull.Value) { item.FILE_NAME = Convert.ToString(reader[3]); }
                        if (reader[4] != DBNull.Value) { item.ENABLED = Convert.ToInt32(reader[4]); }
                        if (reader[5] != DBNull.Value) { item.LAT = Convert.ToDouble(reader[5]); }
                        if (reader[6] != DBNull.Value) { item.LNG = Convert.ToDouble(reader[6]); }
                        if (reader[7] != DBNull.Value) { item.ID_CONSTRUCTION = Convert.ToInt32(reader[7]); }
                        if (reader[8] != DBNull.Value) { item.CATEGORY = Convert.ToString(reader[8]); }
                        if (reader[9] != DBNull.Value) { item.ENABLED = Convert.ToInt32(reader[9]); }
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


        public List<PL_CONFIG_CALC_AREA> GetDataByID_CONSTRUCTION(int ID_CONSTRUCTION)
        {
            List<PL_CONFIG_CALC_AREA> items = new List<PL_CONFIG_CALC_AREA>();
            using (var conn = new SqlConnection(connString))
            {
                Message = "";
                try
                {
                    conn.Open();
                    SqlCommand command = new SqlCommand("SELECT [ID], [AREA], [REGIME], [FILE_NAME], [ENABLED], [LAT], [LNG], [ID_CONSTRUCTION], [CATEGORY], [ENABLED] FROM PL_CONFIG_CALC_AREA WHERE ID_CONSTRUCTION = @ID_CONSTRUCTION", conn);
                    command.Parameters.AddWithValue("@ID_CONSTRUCTION", ID_CONSTRUCTION);
                    SqlDataReader reader = command.ExecuteReader();
                    PL_CONFIG_CALC_AREA item = new PL_CONFIG_CALC_AREA();
                    while (reader.Read())
                    {
                        item = new PL_CONFIG_CALC_AREA();
                        if (reader[0] != DBNull.Value) { item.ID = Convert.ToInt32(reader[0]); }
                        if (reader[1] != DBNull.Value) { item.AREA = Convert.ToString(reader[1]); }
                        if (reader[2] != DBNull.Value) { item.REGIME = Convert.ToString(reader[2]); }
                        if (reader[3] != DBNull.Value) { item.FILE_NAME = Convert.ToString(reader[3]); }
                        if (reader[4] != DBNull.Value) { item.ENABLED = Convert.ToInt32(reader[4]); }
                        if (reader[5] != DBNull.Value) { item.LAT = Convert.ToDouble(reader[5]); }
                        if (reader[6] != DBNull.Value) { item.LNG = Convert.ToDouble(reader[6]); }
                        if (reader[7] != DBNull.Value) { item.ID_CONSTRUCTION = Convert.ToInt32(reader[7]); }
                        if (reader[8] != DBNull.Value) { item.CATEGORY = Convert.ToString(reader[8]); }
                        if (reader[9] != DBNull.Value) { item.ENABLED = Convert.ToInt32(reader[9]); }
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

        //public List<PL_CONFIG_CALC_AREA> GetDataByAREA(string AREA)
        //{
        //    List<PL_CONFIG_CALC_AREA> items = new List<PL_CONFIG_CALC_AREA>();
        //    using (var conn = new SqlConnection(connString))
        //    {
        //        Message = "";
        //        try
        //        {
        //            conn.Open();
        //            SqlCommand command = new SqlCommand("SELECT DISTINCT [ID], [AREA], [REGIME], [FILE_NAME], [LAT],[LNG], [ENABLED] FROM PL_CONFIG_CALC_AREA WHERE AREA = @AREA", conn);
        //            command.Parameters.AddWithValue("@AREA", AREA);
        //            SqlDataReader reader = command.ExecuteReader();
        //            PL_CONFIG_CALC_AREA item = new PL_CONFIG_CALC_AREA();
        //            while (reader.Read())
        //            {
        //                item = new PL_CONFIG_CALC_AREA();
        //                if (reader[0] != DBNull.Value) { item.ID = Convert.ToInt32(reader[0]); }
        //                if (reader[1] != DBNull.Value) { item.AREA = Convert.ToString(reader[1]); }
        //                if (reader[2] != DBNull.Value) { item.REGIME = Convert.ToString(reader[2]); }
                       
        //                if (reader[3] != DBNull.Value) { item.FILE_NAME = Convert.ToString(reader[3]); }
        //                if (reader[3] != DBNull.Value) { item.LAT = Convert.ToDouble(reader[4]); }
        //                if (reader[3] != DBNull.Value) { item.LNG = Convert.ToDouble(reader[5]); }
        //                if (reader[4] != DBNull.Value) { item.ENABLED = Convert.ToInt32(reader[6]); }
        //                items.Add(item);
        //            }
        //        }
        //        catch (Exception ex)
        //        {
        //            Message = ex.Message;
        //        }
        //    }
        //    return items;
        //}


        public List<PL_CONFIG_CALC_AREA> GetDataByCATEGORY(string CATEGORY)
        {
            List<PL_CONFIG_CALC_AREA> items = new List<PL_CONFIG_CALC_AREA>();
            using (var conn = new SqlConnection(connString))
            {
                Message = "";
                try
                {
                    conn.Open();
                    SqlCommand command = new SqlCommand("SELECT [ID], [AREA], [REGIME], [FILE_NAME], [ENABLED], [LAT], [LNG], [ID_CONSTRUCTION], [CATEGORY], [ENABLED] FROM PL_CONFIG_CALC_AREA WHERE CATEGORY = @CATEGORY", conn);
                    command.Parameters.AddWithValue("@CATEGORY", CATEGORY);
                    SqlDataReader reader = command.ExecuteReader();
                    PL_CONFIG_CALC_AREA item = new PL_CONFIG_CALC_AREA();
                    while (reader.Read())
                    {
                        item = new PL_CONFIG_CALC_AREA();
                        if (reader[0] != DBNull.Value) { item.ID = Convert.ToInt32(reader[0]); }
                        if (reader[1] != DBNull.Value) { item.AREA = Convert.ToString(reader[1]); }
                        if (reader[2] != DBNull.Value) { item.REGIME = Convert.ToString(reader[2]); }
                        if (reader[3] != DBNull.Value) { item.FILE_NAME = Convert.ToString(reader[3]); }
                        if (reader[4] != DBNull.Value) { item.ENABLED = Convert.ToInt32(reader[4]); }
                        if (reader[5] != DBNull.Value) { item.LAT = Convert.ToDouble(reader[5]); }
                        if (reader[6] != DBNull.Value) { item.LNG = Convert.ToDouble(reader[6]); }
                        if (reader[7] != DBNull.Value) { item.ID_CONSTRUCTION = Convert.ToInt32(reader[7]); }
                        if (reader[8] != DBNull.Value) { item.CATEGORY = Convert.ToString(reader[8]); }
                        if (reader[9] != DBNull.Value) { item.ENABLED = Convert.ToInt32(reader[9]); }
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
					SqlCommand command = new SqlCommand("DELETE PL_CONFIG_CALC_AREA WHERE ID = @ID", conn);
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

		public DataTable GetDataTable(List<PL_CONFIG_CALC_AREA> pl_config_calc_area)
		{
			DataTable dt = new DataTable("PL_CONFIG_CALC_AREA");

			DataColumn c1 = new DataColumn("ID", typeof(int)); 
			dt.Columns.Add(c1);
			DataColumn c2 = new DataColumn("AREA", typeof(string)); c2.AllowDBNull = true;
			dt.Columns.Add(c2);
			DataColumn c3 = new DataColumn("REGIME", typeof(string)); c3.AllowDBNull = true;
			dt.Columns.Add(c3);
			DataColumn c4 = new DataColumn("FILE_NAME", typeof(string)); c4.AllowDBNull = true;
			dt.Columns.Add(c4);
			DataColumn c5 = new DataColumn("ENABLED", typeof(int)); c5.AllowDBNull = true;
			dt.Columns.Add(c5);

			foreach (PL_CONFIG_CALC_AREA v in pl_config_calc_area)
			{
				DataRow dr = dt.NewRow();
				if (v.ID != null) { dr[0] = v.ID; } else { dr[0] = DBNull.Value; }
				if (v.AREA != null) { dr[1] = v.AREA; } else { dr[1] = DBNull.Value; }
				if (v.REGIME != null) { dr[2] = v.REGIME; } else { dr[2] = DBNull.Value; }
				if (v.FILE_NAME != null) { dr[3] = v.FILE_NAME; } else { dr[3] = DBNull.Value; }
				if (v.ENABLED != null) { dr[4] = v.ENABLED; } else { dr[4] = DBNull.Value; }
				dt.Rows.Add(dr);
			}
			dt.AcceptChanges();

			return dt;
		}

		public void AddManyBulk(List<PL_CONFIG_CALC_AREA> pl_config_calc_area)
		{
			using (var conn = new SqlConnection(connString))
			{
				try
				{
					Message = "";
					conn.Open();

					DataTable dt = GetDataTable(pl_config_calc_area);
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


        public List<PL_CONFIG_CALC_AREA> GetDataByRegime(PL_CONFIG_CALC_AREA ID)
        {
            List<PL_CONFIG_CALC_AREA> items = new List<PL_CONFIG_CALC_AREA>();
            using (var conn = new SqlConnection(connString))
            {
                Message = "";
                try
                {
                    conn.Open();
                    SqlCommand command = new SqlCommand("SELECT DISTINCT [ID], [AREA], [REGIME], [FILE_NAME], [ENABLED] FROM PL_CONFIG_CALC_AREA WHERE ID = @ID", conn);
                    command.Parameters.AddWithValue("@ID", ID.ID);
                    SqlDataReader reader = command.ExecuteReader();
                    PL_CONFIG_CALC_AREA item = new PL_CONFIG_CALC_AREA();
                    while (reader.Read())
                    {
                        item = new PL_CONFIG_CALC_AREA();
                        if (reader[0] != DBNull.Value) { item.ID = Convert.ToInt32(reader[0]); }
                        if (reader[1] != DBNull.Value) { item.AREA = Convert.ToString(reader[1]); }
                        if (reader[2] != DBNull.Value) { item.REGIME = Convert.ToString(reader[2]); }
                        if (reader[3] != DBNull.Value) { item.FILE_NAME = Convert.ToString(reader[3]); }
                        if (reader[4] != DBNull.Value) { item.ENABLED = Convert.ToInt32(reader[4]); }
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