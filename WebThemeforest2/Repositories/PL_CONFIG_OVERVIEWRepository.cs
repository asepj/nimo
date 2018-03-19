using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using WebThemeforest2.Models;

namespace WebThemeforest2.Repositories
{
    public partial class PL_CONFIG_OVERVIEWRepository
    {
        private string connString;
        public string Message { get; set; }

        public PL_CONFIG_OVERVIEWRepository(string connectionString)
        {
            connString = connectionString;
        }

        public void Add(PL_CONFIG_OVERVIEW pl_config_overview)
        {
            using (var conn = new SqlConnection(connString))
            {
                try
                {
                    Message = "";
                    conn.Open();
                    SqlCommand command = new SqlCommand("INSERT INTO PL_CONFIG_OVERVIEW ( [MIN], [MAX], [COLOUR],[ID_UNIT_USAHA], [AREA_NAME],[MAP_TYPE]) VALUES( @MIN, @MAX, @COLOUR, @ID_UNIT_USAHA, @AREA_NAME,@MAP_TYPE)", conn);
                    command.CommandType = System.Data.CommandType.Text;

                    if (pl_config_overview.MIN != null) { command.Parameters.AddWithValue("@MIN", pl_config_overview.MIN); } else { command.Parameters.AddWithValue("@MIN", DBNull.Value); }
                    if (pl_config_overview.MAX != null) { command.Parameters.AddWithValue("@MAX", pl_config_overview.MAX); } else { command.Parameters.AddWithValue("@MAX", DBNull.Value); }
                    if (pl_config_overview.COLOUR != null) { command.Parameters.AddWithValue("@COLOUR", pl_config_overview.COLOUR); } else { command.Parameters.AddWithValue("@COLOUR", DBNull.Value); }
                    if (pl_config_overview.ID_UNIT_USAHA != null) { command.Parameters.AddWithValue("@ID_UNIT_USAHA", pl_config_overview.ID_UNIT_USAHA); } else { command.Parameters.AddWithValue("@ID_UNIT_USAHA", DBNull.Value); }
                    if (pl_config_overview.AREA_NAME != null) { command.Parameters.AddWithValue("@AREA_NAME", pl_config_overview.AREA_NAME); } else { command.Parameters.AddWithValue("@AREA_NAME", DBNull.Value); }
                    if (pl_config_overview.MAP_TYPE != null) { command.Parameters.AddWithValue("@MAP_TYPE", pl_config_overview.MAP_TYPE); } else { command.Parameters.AddWithValue("@MAP_TYPE", DBNull.Value); }
                    command.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    Message = ex.Message;
                }
            }
        }

        public void AddMany(List<PL_CONFIG_OVERVIEW> pl_config_overview)
        {
            using (var conn = new SqlConnection(connString))
            {
                try
                {
                    Message = "";
                    conn.Open();
                    int pos = 0;
                    foreach (PL_CONFIG_OVERVIEW item in pl_config_overview)
                    {
                        SqlCommand command = new SqlCommand("INSERT INTO PL_CONFIG_OVERVIEW ([ID], [MIN], [MAX], [COLOUR], [AREA_NAME]) VALUES(@ID, @MIN, @MAX, @COLOUR, @AREA_NAME)", conn);
                        command.CommandType = System.Data.CommandType.Text;
                        if (pl_config_overview[pos].ID != null) { command.Parameters.AddWithValue("@ID", pl_config_overview[pos].ID); } else { command.Parameters.AddWithValue("@ID", DBNull.Value); }
                        if (pl_config_overview[pos].MIN != null) { command.Parameters.AddWithValue("@MIN", pl_config_overview[pos].MIN); } else { command.Parameters.AddWithValue("@MIN", DBNull.Value); }
                        if (pl_config_overview[pos].MAX != null) { command.Parameters.AddWithValue("@MAX", pl_config_overview[pos].MAX); } else { command.Parameters.AddWithValue("@MAX", DBNull.Value); }
                        if (pl_config_overview[pos].COLOUR != null) { command.Parameters.AddWithValue("@COLOUR", pl_config_overview[pos].COLOUR); } else { command.Parameters.AddWithValue("@COLOUR", DBNull.Value); }
                        if (pl_config_overview[pos].AREA_NAME != null) { command.Parameters.AddWithValue("@AREA_NAME", pl_config_overview[pos].AREA_NAME); } else { command.Parameters.AddWithValue("@AREA_NAME", DBNull.Value); }
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

        public void Update(PL_CONFIG_OVERVIEW pl_config_overview)
        {
            using (var conn = new SqlConnection(connString))
            {
                try
                {
                    Message = "";
                    conn.Open();
                    SqlCommand command = new SqlCommand("UPDATE PL_CONFIG_OVERVIEW SET MIN = @MIN, MAX = @MAX, COLOUR = @COLOUR, AREA_NAME = @AREA_NAME, MAP_TYPE = @MAP_TYPE WHERE ID = @ID", conn);
                    command.CommandType = System.Data.CommandType.Text;
                    if (pl_config_overview.ID != null) { command.Parameters.AddWithValue("@ID", pl_config_overview.ID); } else { command.Parameters.AddWithValue("@ID", DBNull.Value); }
                    if (pl_config_overview.MIN != null) { command.Parameters.AddWithValue("@MIN", pl_config_overview.MIN); } else { command.Parameters.AddWithValue("@MIN", DBNull.Value); }
                    if (pl_config_overview.MAX != null) { command.Parameters.AddWithValue("@MAX", pl_config_overview.MAX); } else { command.Parameters.AddWithValue("@MAX", DBNull.Value); }
                    if (pl_config_overview.COLOUR != null) { command.Parameters.AddWithValue("@COLOUR", pl_config_overview.COLOUR); } else { command.Parameters.AddWithValue("@COLOUR", DBNull.Value); }
                    if (pl_config_overview.AREA_NAME != null) { command.Parameters.AddWithValue("@AREA_NAME", pl_config_overview.AREA_NAME); } else { command.Parameters.AddWithValue("@AREA_NAME", DBNull.Value); }
                    if (pl_config_overview.MAP_TYPE != null) { command.Parameters.AddWithValue("@MAP_TYPE", pl_config_overview.MAP_TYPE); } else { command.Parameters.AddWithValue("@MAP_TYPE", DBNull.Value); }
                    command.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    Message = ex.Message;
                }
            }
        }

        public void UpdateMany(List<PL_CONFIG_OVERVIEW> pl_config_overviews)
        {
            using (var conn = new SqlConnection(connString))
            {
                try
                {
                    Message = "";
                    conn.Open();
                    foreach (PL_CONFIG_OVERVIEW item in pl_config_overviews)
                    {
                        SqlCommand command = new SqlCommand("UPDATE PL_CONFIG_OVERVIEW SET MIN = @MIN, MAX = @MAX, COLOUR = @COLOUR, AREA_NAME = @AREA_NAME WHERE ID = @ID", conn);
                        command.CommandType = System.Data.CommandType.Text;
                        if (item.ID != null) { command.Parameters.AddWithValue("@ID", item.ID); } else { command.Parameters.AddWithValue("@ID", DBNull.Value); }
                        if (item.MIN != null) { command.Parameters.AddWithValue("@MIN", item.MIN); } else { command.Parameters.AddWithValue("@MIN", DBNull.Value); }
                        if (item.MAX != null) { command.Parameters.AddWithValue("@MAX", item.MAX); } else { command.Parameters.AddWithValue("@MAX", DBNull.Value); }
                        if (item.COLOUR != null) { command.Parameters.AddWithValue("@COLOUR", item.COLOUR); } else { command.Parameters.AddWithValue("@COLOUR", DBNull.Value); }
                        if (item.AREA_NAME != null) { command.Parameters.AddWithValue("@AREA_NAME", item.AREA_NAME); } else { command.Parameters.AddWithValue("@AREA_NAME", DBNull.Value); }
                        command.ExecuteNonQuery();
                    }
                }
                catch (Exception ex)
                {
                    Message = ex.Message;
                }
            }
        }

        public void Remove(PL_CONFIG_OVERVIEW id)
        {
            using (var conn = new SqlConnection(connString))
            {
                try
                {
                    Message = "";
                    conn.Open();
                    SqlCommand command = new SqlCommand("DELETE PL_CONFIG_OVERVIEW WHERE ID = @ID", conn);
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

        public List<PL_CONFIG_OVERVIEW> GetData()
        {
            List<PL_CONFIG_OVERVIEW> items = new List<PL_CONFIG_OVERVIEW>();
            using (var conn = new SqlConnection(connString))
            {
                Message = "";
                try
                {
                    conn.Open();
                    SqlCommand command = new SqlCommand("SELECT [ID], [MIN], [MAX], [COLOUR], [AREA_NAME], [MAP_TYPE] FROM PL_CONFIG_OVERVIEW where AREA_NAME = 'Kerawang' and MAP_TYPE='Saturation'  order by [MIN] asc", conn);
                    SqlDataReader reader = command.ExecuteReader();

                    PL_CONFIG_OVERVIEW item = new PL_CONFIG_OVERVIEW();
                    while (reader.Read())
                    {
                        item = new PL_CONFIG_OVERVIEW();
                        if (reader[0] != DBNull.Value) { item.ID = Convert.ToInt32(reader[0]); }
                        if (reader[1] != DBNull.Value) { item.MIN = Convert.ToDouble(reader[1]); }
                        if (reader[2] != DBNull.Value) { item.MAX = Convert.ToDouble(reader[2]); }
                        if (reader[3] != DBNull.Value) { item.COLOUR = Convert.ToString(reader[3]); }
                        if (reader[4] != DBNull.Value) { item.AREA_NAME = Convert.ToString(reader[4]); }
                        if (reader[5] != DBNull.Value) { item.MAP_TYPE = Convert.ToString(reader[5]); }
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

        public List<PL_CONFIG_OVERVIEW> GetDataByID(string AREA_NAME)
        {
            List<PL_CONFIG_OVERVIEW> items = new List<PL_CONFIG_OVERVIEW>();
            using (var conn = new SqlConnection(connString))
            {
                Message = "";
                try
                {
                    conn.Open();
                    SqlCommand command = new SqlCommand("SELECT [ID], [MIN], [MAX], [COLOUR], [AREA_NAME] , [MAP_TYPE] FROM PL_CONFIG_OVERVIEW WHERE ID = @ID", conn);
                    command.Parameters.AddWithValue("@AREA_NAME", AREA_NAME);
                    SqlDataReader reader = command.ExecuteReader();
                    PL_CONFIG_OVERVIEW item = new PL_CONFIG_OVERVIEW();
                    while (reader.Read())
                    {
                        item = new PL_CONFIG_OVERVIEW();
                        if (reader[0] != DBNull.Value) { item.ID = Convert.ToInt32(reader[0]); }
                        if (reader[1] != DBNull.Value) { item.MIN = Convert.ToDouble(reader[1]); }
                        if (reader[2] != DBNull.Value) { item.MAX = Convert.ToDouble(reader[2]); }
                        if (reader[3] != DBNull.Value) { item.COLOUR = Convert.ToString(reader[3]); }
                        if (reader[4] != DBNull.Value) { item.AREA_NAME = Convert.ToString(reader[4]); }
                        if (reader[5] != DBNull.Value) { item.MAP_TYPE = Convert.ToString(reader[5]); }
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
                    SqlCommand command = new SqlCommand("DELETE PL_CONFIG_OVERVIEW WHERE ID = @ID", conn);
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

        public DataTable GetDataTable(List<PL_CONFIG_OVERVIEW> pl_config_overview)
        {
            DataTable dt = new DataTable("PL_CONFIG_OVERVIEW");

            DataColumn c1 = new DataColumn("ID", typeof(int));
            dt.Columns.Add(c1);
            DataColumn c2 = new DataColumn("MIN", typeof(double)); c2.AllowDBNull = true;
            dt.Columns.Add(c2);
            DataColumn c3 = new DataColumn("MAX", typeof(double)); c3.AllowDBNull = true;
            dt.Columns.Add(c3);
            DataColumn c4 = new DataColumn("COLOUR", typeof(string)); c4.AllowDBNull = true;
            dt.Columns.Add(c4);
            DataColumn c5 = new DataColumn("AREA_NAME", typeof(int)); c5.AllowDBNull = true;
            dt.Columns.Add(c5);

            foreach (PL_CONFIG_OVERVIEW v in pl_config_overview)
            {
                DataRow dr = dt.NewRow();
                if (v.ID != null) { dr[0] = v.ID; } else { dr[0] = DBNull.Value; }
                if (v.MIN != null) { dr[1] = v.MIN; } else { dr[1] = DBNull.Value; }
                if (v.MAX != null) { dr[2] = v.MAX; } else { dr[2] = DBNull.Value; }
                if (v.COLOUR != null) { dr[3] = v.COLOUR; } else { dr[3] = DBNull.Value; }
                if (v.AREA_NAME != null) { dr[4] = v.AREA_NAME; } else { dr[4] = DBNull.Value; }
                dt.Rows.Add(dr);
            }
            dt.AcceptChanges();

            return dt;
        }

        public void AddManyBulk(List<PL_CONFIG_OVERVIEW> pl_config_overview)
        {
            using (var conn = new SqlConnection(connString))
            {
                try
                {
                    Message = "";
                    conn.Open();

                    DataTable dt = GetDataTable(pl_config_overview);
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


        public List<PL_CONFIG_OVERVIEW> GetAreaSelect(PL_CONFIG_OVERVIEW pl_config_overview)
        {
            List<PL_CONFIG_OVERVIEW> items = new List<PL_CONFIG_OVERVIEW>();
            using (var conn = new SqlConnection(connString))
            {
                Message = "";
                try
                {
                    conn.Open();
                    SqlCommand command = new SqlCommand("SELECT [ID], [MIN], [MAX], [COLOUR], [AREA_NAME] , [MAP_TYPE] FROM PL_CONFIG_OVERVIEW where AREA_NAME = '" + pl_config_overview.AREA_NAME + "'", conn);
                    SqlDataReader reader = command.ExecuteReader();
                    //command.Parameters.AddWithValue("@AREA_NAME", pl_config_overview.AREA_NAME);
                    PL_CONFIG_OVERVIEW item = new PL_CONFIG_OVERVIEW();
                    while (reader.Read())
                    {
                        item = new PL_CONFIG_OVERVIEW();
                        if (reader[0] != DBNull.Value) { item.ID = Convert.ToInt32(reader[0]); }
                        if (reader[1] != DBNull.Value) { item.MIN = Convert.ToDouble(reader[1]); }
                        if (reader[2] != DBNull.Value) { item.MAX = Convert.ToDouble(reader[2]); }
                        if (reader[3] != DBNull.Value) { item.COLOUR = Convert.ToString(reader[3]); }
                        if (reader[4] != DBNull.Value) { item.AREA_NAME = Convert.ToString(reader[4]); }
                        if (reader[5] != DBNull.Value) { item.MAP_TYPE = Convert.ToString(reader[5]); }
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

        public List<PL_CONFIG_OVERVIEW> GetMapSelect(PL_CONFIG_OVERVIEW pl_config_overview)
        {
            List<PL_CONFIG_OVERVIEW> items = new List<PL_CONFIG_OVERVIEW>();
            using (var conn = new SqlConnection(connString))
            {
                Message = "";
                try
                {
                    conn.Open();

                    SqlCommand command = new SqlCommand("SELECT [ID], [MIN], [MAX], [COLOUR], [AREA_NAME] , [MAP_TYPE] FROM PL_CONFIG_OVERVIEW where AREA_NAME = '" + pl_config_overview.AREA_NAME + "' and MAP_TYPE='" + pl_config_overview.MAP_TYPE + "'", conn);
                    SqlDataReader reader = command.ExecuteReader();
                    //command.Parameters.AddWithValue("@AREA_NAME", pl_config_overview.AREA_NAME);
                    PL_CONFIG_OVERVIEW item = new PL_CONFIG_OVERVIEW();
                    while (reader.Read())
                    {
                        item = new PL_CONFIG_OVERVIEW();
                        if (reader[0] != DBNull.Value) { item.ID = Convert.ToInt32(reader[0]); }
                        if (reader[1] != DBNull.Value) { item.MIN = Convert.ToDouble(reader[1]); }
                        if (reader[2] != DBNull.Value) { item.MAX = Convert.ToDouble(reader[2]); }
                        if (reader[3] != DBNull.Value) { item.COLOUR = Convert.ToString(reader[3]); }
                        if (reader[4] != DBNull.Value) { item.AREA_NAME = Convert.ToString(reader[4]); }
                        if (reader[5] != DBNull.Value) { item.MAP_TYPE = Convert.ToString(reader[5]); }
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


        ///////get data karawang/////////
        public List<PL_CONFIG_OVERVIEW> GetDataKarawangSaturation()
        {
            List<PL_CONFIG_OVERVIEW> items = new List<PL_CONFIG_OVERVIEW>();
            using (var conn = new SqlConnection(connString))
            {
                Message = "";
                try
                {
                    conn.Open();
                    SqlCommand command = new SqlCommand("SELECT [ID], [MIN], [MAX], [COLOUR], [AREA_NAME], [MAP_TYPE] FROM PL_CONFIG_OVERVIEW where AREA_NAME = 'Kerawang' and MAP_TYPE='Saturation'  order by [MIN] asc", conn);
                    SqlDataReader reader = command.ExecuteReader();

                    PL_CONFIG_OVERVIEW item = new PL_CONFIG_OVERVIEW();
                    while (reader.Read())
                    {
                        item = new PL_CONFIG_OVERVIEW();
                        if (reader[0] != DBNull.Value) { item.ID = Convert.ToInt32(reader[0]); }
                        if (reader[1] != DBNull.Value) { item.MIN = Convert.ToDouble(reader[1]); }
                        if (reader[2] != DBNull.Value) { item.MAX = Convert.ToDouble(reader[2]); }
                        if (reader[3] != DBNull.Value) { item.COLOUR = Convert.ToString(reader[3]); }
                        if (reader[4] != DBNull.Value) { item.AREA_NAME = Convert.ToString(reader[4]); }
                        if (reader[5] != DBNull.Value) { item.MAP_TYPE = Convert.ToString(reader[5]); }
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

        public List<PL_CONFIG_OVERVIEW> GetDataKarawangNode()
        {
            List<PL_CONFIG_OVERVIEW> items = new List<PL_CONFIG_OVERVIEW>();
            using (var conn = new SqlConnection(connString))
            {
                Message = "";
                try
                {
                    conn.Open();
                    SqlCommand command = new SqlCommand("SELECT [ID], [MIN], [MAX], [COLOUR], [AREA_NAME], [MAP_TYPE] FROM PL_CONFIG_OVERVIEW where AREA_NAME = 'Kerawang' and MAP_TYPE='Node'  order by [MIN] asc", conn);
                    SqlDataReader reader = command.ExecuteReader();

                    PL_CONFIG_OVERVIEW item = new PL_CONFIG_OVERVIEW();
                    while (reader.Read())
                    {
                        item = new PL_CONFIG_OVERVIEW();
                        if (reader[0] != DBNull.Value) { item.ID = Convert.ToInt32(reader[0]); }
                        if (reader[1] != DBNull.Value) { item.MIN = Convert.ToDouble(reader[1]); }
                        if (reader[2] != DBNull.Value) { item.MAX = Convert.ToDouble(reader[2]); }
                        if (reader[3] != DBNull.Value) { item.COLOUR = Convert.ToString(reader[3]); }
                        if (reader[4] != DBNull.Value) { item.AREA_NAME = Convert.ToString(reader[4]); }
                        if (reader[5] != DBNull.Value) { item.MAP_TYPE = Convert.ToString(reader[5]); }
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




        public List<PL_CONFIG_OVERVIEW> GetDataByName(string AREA_NAME)
        {
            List<PL_CONFIG_OVERVIEW> items = new List<PL_CONFIG_OVERVIEW>();
            using (var conn = new SqlConnection(connString))
            {
                Message = "";
                try
                {
                    conn.Open();
                    SqlCommand command = new SqlCommand("SELECT [ID], [MIN], [MAX], [COLOUR], [AREA_NAME] , [MAP_TYPE] FROM PL_CONFIG_OVERVIEW WHERE AREA_NAME = @AREA_NAME", conn);
                    command.Parameters.AddWithValue("@AREA_NAME", AREA_NAME);
                    SqlDataReader reader = command.ExecuteReader();
                    PL_CONFIG_OVERVIEW item = new PL_CONFIG_OVERVIEW();
                    while (reader.Read())
                    {
                        item = new PL_CONFIG_OVERVIEW();
                        if (reader[0] != DBNull.Value) { item.ID = Convert.ToInt32(reader[0]); }
                        if (reader[1] != DBNull.Value) { item.MIN = Convert.ToDouble(reader[1]); }
                        if (reader[2] != DBNull.Value) { item.MAX = Convert.ToDouble(reader[2]); }
                        if (reader[3] != DBNull.Value) { item.COLOUR = Convert.ToString(reader[3]); }
                        if (reader[4] != DBNull.Value) { item.AREA_NAME = Convert.ToString(reader[4]); }
                        if (reader[5] != DBNull.Value) { item.MAP_TYPE = Convert.ToString(reader[5]); }
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