using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using WebThemeforest2.Models;

namespace WebThemeforest2.Repositories
{
    public partial class PL_CONFIG_TEMPERATURERepository
    {
        private string connString;
        public string Message { get; set; }

        public PL_CONFIG_TEMPERATURERepository(string connectionString)
        {
            connString = connectionString;
        }

        public void Add(PL_CONFIG_TEMPERATURE pl_config_calculator_temperature)
        {
            using (var conn = new SqlConnection(connString))
            {
                try
                {
                    Message = "";
                    conn.Open();
                    SqlCommand command = new SqlCommand("INSERT INTO PL_CONFIG_CALCULATOR_TEMPERATURE ( [TEMPERATURE]) VALUES( @TEMPERATURE)", conn);
                    command.CommandType = System.Data.CommandType.Text;

                    if (pl_config_calculator_temperature.TEMPERATURE != null) { command.Parameters.AddWithValue("@TEMPERATURE", pl_config_calculator_temperature.TEMPERATURE); } else { command.Parameters.AddWithValue("@TEMPERATURE", DBNull.Value); }
                    command.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    Message = ex.Message;
                }
            }
        }

        public void AddMany(List<PL_CONFIG_TEMPERATURE> pl_config_calculator_temperature)
        {
            using (var conn = new SqlConnection(connString))
            {
                try
                {
                    Message = "";
                    conn.Open();
                    int pos = 0;
                    foreach (PL_CONFIG_TEMPERATURE item in pl_config_calculator_temperature)
                    {
                        SqlCommand command = new SqlCommand("INSERT INTO PL_CONFIG_CALCULATOR_TEMPERATURE ([ID], [TEMPERATURE]) VALUES(@ID, @TEMPERATURE)", conn);
                        command.CommandType = System.Data.CommandType.Text;
                        if (pl_config_calculator_temperature[pos].ID != null) { command.Parameters.AddWithValue("@ID", pl_config_calculator_temperature[pos].ID); } else { command.Parameters.AddWithValue("@ID", DBNull.Value); }
                        if (pl_config_calculator_temperature[pos].TEMPERATURE != null) { command.Parameters.AddWithValue("@TEMPERATURE", pl_config_calculator_temperature[pos].TEMPERATURE); } else { command.Parameters.AddWithValue("@TEMPERATURE", DBNull.Value); }
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

        public void Update(PL_CONFIG_TEMPERATURE pl_config_calculator_temperature)
        {
            using (var conn = new SqlConnection(connString))
            {
                try
                {
                    Message = "";
                    conn.Open();
                    SqlCommand command = new SqlCommand("UPDATE PL_CONFIG_CALCULATOR_TEMPERATURE SET TEMPERATURE = @TEMPERATURE WHERE ID = @ID", conn);
                    command.CommandType = System.Data.CommandType.Text;
                    if (pl_config_calculator_temperature.ID != null) { command.Parameters.AddWithValue("@ID", pl_config_calculator_temperature.ID); } else { command.Parameters.AddWithValue("@ID", DBNull.Value); }
                    if (pl_config_calculator_temperature.TEMPERATURE != null) { command.Parameters.AddWithValue("@TEMPERATURE", pl_config_calculator_temperature.TEMPERATURE); } else { command.Parameters.AddWithValue("@TEMPERATURE", DBNull.Value); }
                    command.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    Message = ex.Message;
                }
            }
        }

        public void UpdateMany(List<PL_CONFIG_TEMPERATURE> pl_config_calculator_temperatures)
        {
            using (var conn = new SqlConnection(connString))
            {
                try
                {
                    Message = "";
                    conn.Open();
                    foreach (PL_CONFIG_TEMPERATURE item in pl_config_calculator_temperatures)
                    {
                        SqlCommand command = new SqlCommand("UPDATE PL_CONFIG_CALCULATOR_TEMPERATURE SET TEMPERATURE = @TEMPERATURE WHERE ID = @ID", conn);
                        command.CommandType = System.Data.CommandType.Text;
                        if (item.ID != null) { command.Parameters.AddWithValue("@ID", item.ID); } else { command.Parameters.AddWithValue("@ID", DBNull.Value); }
                        if (item.TEMPERATURE != null) { command.Parameters.AddWithValue("@TEMPERATURE", item.TEMPERATURE); } else { command.Parameters.AddWithValue("@TEMPERATURE", DBNull.Value); }
                        command.ExecuteNonQuery();
                    }
                }
                catch (Exception ex)
                {
                    Message = ex.Message;
                }
            }
        }

        public void Remove(PL_CONFIG_TEMPERATURE id)
        {
            using (var conn = new SqlConnection(connString))
            {
                try
                {
                    Message = "";
                    conn.Open();
                    SqlCommand command = new SqlCommand("DELETE PL_CONFIG_CALCULATOR_TEMPERATURE WHERE ID = @ID", conn);
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

        public List<PL_CONFIG_TEMPERATURE> GetData()
        {
            List<PL_CONFIG_TEMPERATURE> items = new List<PL_CONFIG_TEMPERATURE>();
            using (var conn = new SqlConnection(connString))
            {
                Message = "";
                try
                {
                    conn.Open();
                    SqlCommand command = new SqlCommand("SELECT [ID], [TEMPERATURE] FROM PL_CONFIG_CALCULATOR_TEMPERATURE", conn);
                    SqlDataReader reader = command.ExecuteReader();
                    PL_CONFIG_TEMPERATURE item = new PL_CONFIG_TEMPERATURE();
                    while (reader.Read())
                    {
                        item = new PL_CONFIG_TEMPERATURE();
                        if (reader[0] != DBNull.Value) { item.ID = Convert.ToInt32(reader[0]); }
                        if (reader[1] != DBNull.Value) { item.TEMPERATURE = Convert.ToInt32(reader[1]); }
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

        public List<PL_CONFIG_TEMPERATURE> GetDataTemperature()
        {
            List<PL_CONFIG_TEMPERATURE> items = new List<PL_CONFIG_TEMPERATURE>();
            using (var conn = new SqlConnection(connString))
            {
                Message = "";
                try
                {
                    conn.Open();
                    SqlCommand command = new SqlCommand(" SELECT  [TEMPERATURE] FROM PL_CONFIG_CALCULATOR_TEMPERATURE", conn);
                    SqlDataReader reader = command.ExecuteReader();
                    PL_CONFIG_TEMPERATURE item = new PL_CONFIG_TEMPERATURE();
                    while (reader.Read())
                    {
                        item = new PL_CONFIG_TEMPERATURE();
                        
                        if (reader[0] != DBNull.Value) { item.TEMPERATURE = Convert.ToInt32(reader[0]); }
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

        public List<PL_CONFIG_TEMPERATURE> GetDataByID(int ID)
        {
            List<PL_CONFIG_TEMPERATURE> items = new List<PL_CONFIG_TEMPERATURE>();
            using (var conn = new SqlConnection(connString))
            {
                Message = "";
                try
                {
                    conn.Open();
                    SqlCommand command = new SqlCommand("SELECT [ID], [TEMPERATURE] FROM PL_CONFIG_CALCULATOR_TEMPERATURE WHERE ID = @ID", conn);
                    command.Parameters.AddWithValue("@ID", ID);
                    SqlDataReader reader = command.ExecuteReader();
                    PL_CONFIG_TEMPERATURE item = new PL_CONFIG_TEMPERATURE();
                    while (reader.Read())
                    {
                        item = new PL_CONFIG_TEMPERATURE();
                        if (reader[0] != DBNull.Value) { item.ID = Convert.ToInt32(reader[0]); }
                        if (reader[1] != DBNull.Value) { item.TEMPERATURE = Convert.ToInt32(reader[1]); }
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
                    SqlCommand command = new SqlCommand("DELETE PL_CONFIG_CALCULATOR_TEMPERATURE WHERE ID = @ID", conn);
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

        public DataTable GetDataTable(List<PL_CONFIG_TEMPERATURE> pl_config_calculator_temperature)
        {
            DataTable dt = new DataTable("PL_CONFIG_CALCULATOR_TEMPERATURE");

            DataColumn c1 = new DataColumn("ID", typeof(int));
            dt.Columns.Add(c1);
            DataColumn c2 = new DataColumn("TEMPERATURE", typeof(int)); c2.AllowDBNull = true;
            dt.Columns.Add(c2);

            foreach (PL_CONFIG_TEMPERATURE v in pl_config_calculator_temperature)
            {
                DataRow dr = dt.NewRow();
                if (v.ID != null) { dr[0] = v.ID; } else { dr[0] = DBNull.Value; }
                if (v.TEMPERATURE != null) { dr[1] = v.TEMPERATURE; } else { dr[1] = DBNull.Value; }
                dt.Rows.Add(dr);
            }
            dt.AcceptChanges();

            return dt;
        }

        public void AddManyBulk(List<PL_CONFIG_TEMPERATURE> pl_config_calculator_temperature)
        {
            using (var conn = new SqlConnection(connString))
            {
                try
                {
                    Message = "";
                    conn.Open();

                    DataTable dt = GetDataTable(pl_config_calculator_temperature);
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


        public List<PL_CONFIG_TEMPERATURE> GetDimeter()
        {
            List<PL_CONFIG_TEMPERATURE> items = new List<PL_CONFIG_TEMPERATURE>();
            using (var conn = new SqlConnection(connString))
            {
                Message = "";
                try
                {
                    conn.Open();
                    SqlCommand command = new SqlCommand("SELECT [TEMPERATURE] FROM PL_CONFIG_CALCULATOR_TEMPERATURE order by TEMPERATURE asc ", conn);
                    SqlDataReader reader = command.ExecuteReader();
                    //command.Parameters.AddWithValue("@AREA_NAME", pl_config_overview.AREA_NAME);
                    PL_CONFIG_TEMPERATURE item = new PL_CONFIG_TEMPERATURE();
                    while (reader.Read())
                    {
                        item = new PL_CONFIG_TEMPERATURE();
                        if (reader[0] != DBNull.Value) { item.TEMPERATURE = Convert.ToInt32(reader[0]); }

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