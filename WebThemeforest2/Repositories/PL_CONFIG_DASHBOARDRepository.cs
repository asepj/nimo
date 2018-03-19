using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using WebThemeforest2.Models;

namespace WebThemeforest2.Repositories
{
    public partial class PL_CONFIG_DASHBOARDRepository
    {
        private string connString;
        public string Message { get; set; }

        public PL_CONFIG_DASHBOARDRepository(string connectionString)
        {
            connString = connectionString;
        }

        public string GetMaxCap(PL_CONFIG_DASHBOARD PL_CONFIG_DASHBOARD)
        {
            string Capmax = "";
            using (var conn = new SqlConnection(connString))
            {
                string command = "SELECT [CAPACITY_MAX] FROM PL_CONFIG_DASHBOARD WHERE AREA ='" + PL_CONFIG_DASHBOARD.AREA + "'";
                SqlCommand cmd = new SqlCommand(command, conn);

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                conn.Open();
                try
                {
                    Capmax = dt.Rows[0]["CAPACITY_MAX"].ToString();
                }
                catch { Capmax = ""; }
                da.Dispose();
                conn.Close();
            }
            return Capmax;
        }

        public void Add(PL_CONFIG_DASHBOARD PL_CONFIG_DASHBOARD)
        {
            using (var conn = new SqlConnection(connString))
            {
                try
                {
                    Message = "";
                    conn.Open();
                    SqlCommand command = new SqlCommand("INSERT INTO PL_CONFIG_DASHBOARD ( [AREA], [NAME], [CAPACITY_MAX]) VALUES( @AREA, @NAME, @CAPACITY_MAX)", conn);
                    command.CommandType = System.Data.CommandType.Text;

                    if (PL_CONFIG_DASHBOARD.AREA != null) { command.Parameters.AddWithValue("@AREA", PL_CONFIG_DASHBOARD.AREA); } else { command.Parameters.AddWithValue("@AREA", DBNull.Value); }
                    if (PL_CONFIG_DASHBOARD.NAME != null) { command.Parameters.AddWithValue("@NAME", PL_CONFIG_DASHBOARD.NAME); } else { command.Parameters.AddWithValue("@NAME", DBNull.Value); }
                    if (PL_CONFIG_DASHBOARD.CAPACITY_MAX != null) { command.Parameters.AddWithValue("@CAPACITY_MAX", PL_CONFIG_DASHBOARD.CAPACITY_MAX); } else { command.Parameters.AddWithValue("@CAPACITY_MAX", DBNull.Value); }
                    command.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    Message = ex.Message;
                }
            }
        }

        public void AddMany(List<PL_CONFIG_DASHBOARD> PL_CONFIG_DASHBOARD)
        {
            using (var conn = new SqlConnection(connString))
            {
                try
                {
                    Message = "";
                    conn.Open();
                    int pos = 0;
                    foreach (PL_CONFIG_DASHBOARD item in PL_CONFIG_DASHBOARD)
                    {
                        SqlCommand command = new SqlCommand("INSERT INTO PL_CONFIG_DASHBOARD ([ID], [AREA], [NAME], [CAPACITY_MAX]) VALUES(@ID, @AREA, @NAME, @CAPACITY_MAX)", conn);
                        command.CommandType = System.Data.CommandType.Text;
                        if (PL_CONFIG_DASHBOARD[pos].ID != null) { command.Parameters.AddWithValue("@ID", PL_CONFIG_DASHBOARD[pos].ID); } else { command.Parameters.AddWithValue("@ID", DBNull.Value); }
                        if (PL_CONFIG_DASHBOARD[pos].AREA != null) { command.Parameters.AddWithValue("@AREA", PL_CONFIG_DASHBOARD[pos].AREA); } else { command.Parameters.AddWithValue("@AREA", DBNull.Value); }
                        if (PL_CONFIG_DASHBOARD[pos].NAME != null) { command.Parameters.AddWithValue("@NAME", PL_CONFIG_DASHBOARD[pos].NAME); } else { command.Parameters.AddWithValue("@NAME", DBNull.Value); }
                        if (PL_CONFIG_DASHBOARD[pos].CAPACITY_MAX != null) { command.Parameters.AddWithValue("@CAPACITY_MAX", PL_CONFIG_DASHBOARD[pos].CAPACITY_MAX); } else { command.Parameters.AddWithValue("@CAPACITY_MAX", DBNull.Value); }
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

        public void Update(PL_CONFIG_DASHBOARD PL_CONFIG_DASHBOARD)
        {
            using (var conn = new SqlConnection(connString))
            {
                try
                {
                    Message = "";
                    conn.Open();
                    SqlCommand command = new SqlCommand("UPDATE PL_CONFIG_DASHBOARD SET  AREA = @AREA, NAME = @NAME, CAPACITY_MAX = @CAPACITY_MAX WHERE ID = @ID ", conn);

                    command.CommandType = System.Data.CommandType.Text;

                    if (PL_CONFIG_DASHBOARD.ID != null) { command.Parameters.AddWithValue("@ID", PL_CONFIG_DASHBOARD.ID); } else { command.Parameters.AddWithValue("@ID", DBNull.Value); }
                    if (PL_CONFIG_DASHBOARD.AREA != null) { command.Parameters.AddWithValue("@AREA", PL_CONFIG_DASHBOARD.AREA); } else { command.Parameters.AddWithValue("@AREA", DBNull.Value); }
                    if (PL_CONFIG_DASHBOARD.NAME != null) { command.Parameters.AddWithValue("@NAME", PL_CONFIG_DASHBOARD.NAME); } else { command.Parameters.AddWithValue("@NAME", DBNull.Value); }
                    if (PL_CONFIG_DASHBOARD.CAPACITY_MAX != null) { command.Parameters.AddWithValue("@CAPACITY_MAX", PL_CONFIG_DASHBOARD.CAPACITY_MAX); } else { command.Parameters.AddWithValue("@CAPACITY_MAX", DBNull.Value); }
                    command.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    Message = ex.Message;
                }
            }
        }

        public void UpdateMany(List<PL_CONFIG_DASHBOARD> PL_CONFIG_DASHBOARDs)
        {
            using (var conn = new SqlConnection(connString))
            {
                try
                {
                    Message = "";
                    conn.Open();
                    foreach (PL_CONFIG_DASHBOARD item in PL_CONFIG_DASHBOARDs)
                    {
                        SqlCommand command = new SqlCommand("UPDATE PL_CONFIG_DASHBOARD SET ID = @ID, AREA = @AREA, NAME = @NAME, CAPACITY_MAX = @CAPACITY_MAX WHERE ", conn);
                        command.CommandType = System.Data.CommandType.Text;
                        if (item.ID != null) { command.Parameters.AddWithValue("@ID", item.ID); } else { command.Parameters.AddWithValue("@ID", DBNull.Value); }
                        if (item.AREA != null) { command.Parameters.AddWithValue("@AREA", item.AREA); } else { command.Parameters.AddWithValue("@AREA", DBNull.Value); }
                        if (item.NAME != null) { command.Parameters.AddWithValue("@NAME", item.NAME); } else { command.Parameters.AddWithValue("@NAME", DBNull.Value); }
                        if (item.CAPACITY_MAX != null) { command.Parameters.AddWithValue("@CAPACITY_MAX", item.CAPACITY_MAX); } else { command.Parameters.AddWithValue("@CAPACITY_MAX", DBNull.Value); }
                        command.ExecuteNonQuery();
                    }
                }
                catch (Exception ex)
                {
                    Message = ex.Message;
                }
            }
        }

        public void Remove(PL_CONFIG_DASHBOARD id)
        {
            using (var conn = new SqlConnection(connString))
            {
                try
                {
                    Message = "";
                    conn.Open();
                    SqlCommand command = new SqlCommand("DELETE PL_CONFIG_DASHBOARD WHERE ID = @ID ", conn);
                    command.Parameters.AddWithValue("@ID", id.ID);
                    command.CommandType = System.Data.CommandType.Text;
                    command.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    Message = ex.Message;
                }
            }
        }

        public List<PL_CONFIG_DASHBOARD> GetData()
        {
            List<PL_CONFIG_DASHBOARD> items = new List<PL_CONFIG_DASHBOARD>();
            using (var conn = new SqlConnection(connString))
            {
                Message = "";
                try
                {
                    conn.Open();
                    SqlCommand command = new SqlCommand("SELECT [ID], [AREA], [NAME], [CAPACITY_MAX] FROM PL_CONFIG_DASHBOARD order by AREA asc", conn);
                    SqlDataReader reader = command.ExecuteReader();
                    PL_CONFIG_DASHBOARD item = new PL_CONFIG_DASHBOARD();
                    while (reader.Read())
                    {
                        item = new PL_CONFIG_DASHBOARD();
                        if (reader[0] != DBNull.Value) { item.ID = Convert.ToInt32(reader[0]); }
                        if (reader[1] != DBNull.Value) { item.AREA = Convert.ToString(reader[1]); }
                        if (reader[2] != DBNull.Value) { item.NAME = Convert.ToString(reader[2]); }
                        if (reader[3] != DBNull.Value) { item.CAPACITY_MAX = Convert.ToInt32(reader[3]); }
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


        public List<PL_CONFIG_DASHBOARD> GetDataArea()
        {
            List<PL_CONFIG_DASHBOARD> items = new List<PL_CONFIG_DASHBOARD>();
            using (var conn = new SqlConnection(connString))
            {
                Message = "";
                try
                {
                    conn.Open();
                    SqlCommand command = new SqlCommand("SELECT [AREA], [NAME] FROM PL_CONFIG_DASHBOARD", conn);
                    SqlDataReader reader = command.ExecuteReader();
                    PL_CONFIG_DASHBOARD item = new PL_CONFIG_DASHBOARD();
                    while (reader.Read())
                    {
                        item = new PL_CONFIG_DASHBOARD();
                        
                        if (reader[0] != DBNull.Value) { item.AREA = Convert.ToString(reader[0]); }
                        if (reader[1] != DBNull.Value) { item.NAME = Convert.ToString(reader[1]); }
                       
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

        public DataTable GetDataTable(List<PL_CONFIG_DASHBOARD> PL_CONFIG_DASHBOARD)
        {
            DataTable dt = new DataTable("PL_CONFIG_DASHBOARD");

            DataColumn c1 = new DataColumn("ID", typeof(int)); c1.AllowDBNull = true;
            dt.Columns.Add(c1);
            DataColumn c2 = new DataColumn("AREA", typeof(string)); c2.AllowDBNull = true;
            dt.Columns.Add(c2);
            DataColumn c3 = new DataColumn("NAME", typeof(string)); c3.AllowDBNull = true;
            dt.Columns.Add(c3);
            DataColumn c4 = new DataColumn("CAPACITY_MAX", typeof(int)); c4.AllowDBNull = true;
            dt.Columns.Add(c4);

            foreach (PL_CONFIG_DASHBOARD v in PL_CONFIG_DASHBOARD)
            {
                DataRow dr = dt.NewRow();
                if (v.ID != null) { dr[0] = v.ID; } else { dr[0] = DBNull.Value; }
                if (v.AREA != null) { dr[1] = v.AREA; } else { dr[1] = DBNull.Value; }
                if (v.NAME != null) { dr[2] = v.NAME; } else { dr[2] = DBNull.Value; }
                if (v.CAPACITY_MAX != null) { dr[3] = v.CAPACITY_MAX; } else { dr[3] = DBNull.Value; }
                dt.Rows.Add(dr);
            }
            dt.AcceptChanges();

            return dt;
        }

        public void AddManyBulk(List<PL_CONFIG_DASHBOARD> PL_CONFIG_DASHBOARD)
        {
            using (var conn = new SqlConnection(connString))
            {
                try
                {
                    Message = "";
                    conn.Open();

                    DataTable dt = GetDataTable(PL_CONFIG_DASHBOARD);
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