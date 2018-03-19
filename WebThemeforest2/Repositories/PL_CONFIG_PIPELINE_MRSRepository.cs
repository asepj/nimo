using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using WebThemeforest2.Models;

namespace WebThemeforest2.Repositories
{
    public partial class PL_CONFIG_PIPELINE_MRSRepository
    {
        private string connString;
        public string Message { get; set; }

        public PL_CONFIG_PIPELINE_MRSRepository(string connectionString)
        {
            connString = connectionString;
        }

        public void Add(PL_CONFIG_PIPELINE_MRS pl_config_pipeline_mrs)
        {
            using (var conn = new SqlConnection(connString))
            {
                try
                {
                    Message = "";
                    conn.Open();
                    SqlCommand command = new SqlCommand("INSERT INTO PL_CONFIG_PIPELINE_MRS ( [MRS_TYPE], [MATERIAL_COST], [CONSTRUCTION_COST], [MAX_FLOW]) VALUES( @MRS_TYPE, @MATERIAL_COST, @CONSTRUCTION_COST, @MAX_FLOW)", conn);
                    command.CommandType = System.Data.CommandType.Text;
                    //if (pl_config_pipeline_mrs.ID_MRS != null) { command.Parameters.AddWithValue("@ID_MRS", pl_config_pipeline_mrs.ID_MRS); } else { command.Parameters.AddWithValue("@ID_MRS", DBNull.Value); }
                    if (pl_config_pipeline_mrs.MRS_TYPE != null) { command.Parameters.AddWithValue("@MRS_TYPE", pl_config_pipeline_mrs.MRS_TYPE); } else { command.Parameters.AddWithValue("@MRS_TYPE", DBNull.Value); }
                    if (pl_config_pipeline_mrs.MATERIAL_COST != null) { command.Parameters.AddWithValue("@MATERIAL_COST", pl_config_pipeline_mrs.MATERIAL_COST); } else { command.Parameters.AddWithValue("@MATERIAL_COST", DBNull.Value); }
                    if (pl_config_pipeline_mrs.CONSTRUCTION_COST != null) { command.Parameters.AddWithValue("@CONSTRUCTION_COST", pl_config_pipeline_mrs.CONSTRUCTION_COST); } else { command.Parameters.AddWithValue("@CONSTRUCTION_COST", DBNull.Value); }
                    if (pl_config_pipeline_mrs.MAX_FLOW != null) { command.Parameters.AddWithValue("@MAX_FLOW", pl_config_pipeline_mrs.MAX_FLOW); } else { command.Parameters.AddWithValue("@MAX_FLOW", DBNull.Value); }
                    command.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    Message = ex.Message;
                }
            }
        }

        public void AddMany(List<PL_CONFIG_PIPELINE_MRS> pl_config_pipeline_mrs)
        {
            using (var conn = new SqlConnection(connString))
            {
                try
                {
                    Message = "";
                    conn.Open();
                    int pos = 0;
                    foreach (PL_CONFIG_PIPELINE_MRS item in pl_config_pipeline_mrs)
                    {
                        SqlCommand command = new SqlCommand("INSERT INTO PL_CONFIG_PIPELINE_MRS ([ID_MRS], [MRS_TYPE], [MATERIAL_COST], [CONSTRUCTION_COST], [MAX_FLOW]) VALUES(@ID_MRS, @MRS_TYPE, @MATERIAL_COST, @CONSTRUCTION_COST, @MAX_FLOW)", conn);
                        command.CommandType = System.Data.CommandType.Text;
                        if (pl_config_pipeline_mrs[pos].ID_MRS != null) { command.Parameters.AddWithValue("@ID_MRS", pl_config_pipeline_mrs[pos].ID_MRS); } else { command.Parameters.AddWithValue("@ID_MRS", DBNull.Value); }
                        if (pl_config_pipeline_mrs[pos].MRS_TYPE != null) { command.Parameters.AddWithValue("@MRS_TYPE", pl_config_pipeline_mrs[pos].MRS_TYPE); } else { command.Parameters.AddWithValue("@MRS_TYPE", DBNull.Value); }
                        if (pl_config_pipeline_mrs[pos].MATERIAL_COST != null) { command.Parameters.AddWithValue("@MATERIAL_COST", pl_config_pipeline_mrs[pos].MATERIAL_COST); } else { command.Parameters.AddWithValue("@MATERIAL_COST", DBNull.Value); }
                        if (pl_config_pipeline_mrs[pos].CONSTRUCTION_COST != null) { command.Parameters.AddWithValue("@CONSTRUCTION_COST", pl_config_pipeline_mrs[pos].CONSTRUCTION_COST); } else { command.Parameters.AddWithValue("@CONSTRUCTION_COST", DBNull.Value); }
                        if (pl_config_pipeline_mrs[pos].MAX_FLOW != null) { command.Parameters.AddWithValue("@MAX_FLOW", pl_config_pipeline_mrs[pos].MAX_FLOW); } else { command.Parameters.AddWithValue("@MAX_FLOW", DBNull.Value); }
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

        public void Update(PL_CONFIG_PIPELINE_MRS pl_config_pipeline_mrs)
        {
            using (var conn = new SqlConnection(connString))
            {
                try
                {
                    Message = "";
                    conn.Open();
                    SqlCommand command = new SqlCommand("UPDATE PL_CONFIG_PIPELINE_MRS SET MRS_TYPE = @MRS_TYPE, MATERIAL_COST = @MATERIAL_COST, CONSTRUCTION_COST = @CONSTRUCTION_COST, MAX_FLOW = @MAX_FLOW WHERE ID_MRS = @ID_MRS", conn);
                    command.CommandType = System.Data.CommandType.Text;
                    if (pl_config_pipeline_mrs.ID_MRS != null) { command.Parameters.AddWithValue("@ID_MRS", pl_config_pipeline_mrs.ID_MRS); } else { command.Parameters.AddWithValue("@ID_MRS", DBNull.Value); }
                    if (pl_config_pipeline_mrs.MRS_TYPE != null) { command.Parameters.AddWithValue("@MRS_TYPE", pl_config_pipeline_mrs.MRS_TYPE); } else { command.Parameters.AddWithValue("@MRS_TYPE", DBNull.Value); }
                    if (pl_config_pipeline_mrs.MATERIAL_COST != null) { command.Parameters.AddWithValue("@MATERIAL_COST", pl_config_pipeline_mrs.MATERIAL_COST); } else { command.Parameters.AddWithValue("@MATERIAL_COST", DBNull.Value); }
                    if (pl_config_pipeline_mrs.CONSTRUCTION_COST != null) { command.Parameters.AddWithValue("@CONSTRUCTION_COST", pl_config_pipeline_mrs.CONSTRUCTION_COST); } else { command.Parameters.AddWithValue("@CONSTRUCTION_COST", DBNull.Value); }
                    if (pl_config_pipeline_mrs.MAX_FLOW != null) { command.Parameters.AddWithValue("@MAX_FLOW", pl_config_pipeline_mrs.MAX_FLOW); } else { command.Parameters.AddWithValue("@MAX_FLOW", DBNull.Value); }
                    command.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    Message = ex.Message;
                }
            }
        }

        public void UpdateMany(List<PL_CONFIG_PIPELINE_MRS> pl_config_pipeline_mrss)
        {
            using (var conn = new SqlConnection(connString))
            {
                try
                {
                    Message = "";
                    conn.Open();
                    foreach (PL_CONFIG_PIPELINE_MRS item in pl_config_pipeline_mrss)
                    {
                        SqlCommand command = new SqlCommand("UPDATE PL_CONFIG_PIPELINE_MRS SET MRS_TYPE = @MRS_TYPE, MATERIAL_COST = @MATERIAL_COST, CONSTRUCTION_COST = @CONSTRUCTION_COST, MAX_FLOW = @MAX_FLOW WHERE ID_MRS = @ID_MRS", conn);
                        command.CommandType = System.Data.CommandType.Text;
                        if (item.ID_MRS != null) { command.Parameters.AddWithValue("@ID_MRS", item.ID_MRS); } else { command.Parameters.AddWithValue("@ID_MRS", DBNull.Value); }
                        if (item.MRS_TYPE != null) { command.Parameters.AddWithValue("@MRS_TYPE", item.MRS_TYPE); } else { command.Parameters.AddWithValue("@MRS_TYPE", DBNull.Value); }
                        if (item.MATERIAL_COST != null) { command.Parameters.AddWithValue("@MATERIAL_COST", item.MATERIAL_COST); } else { command.Parameters.AddWithValue("@MATERIAL_COST", DBNull.Value); }
                        if (item.CONSTRUCTION_COST != null) { command.Parameters.AddWithValue("@CONSTRUCTION_COST", item.CONSTRUCTION_COST); } else { command.Parameters.AddWithValue("@CONSTRUCTION_COST", DBNull.Value); }
                        if (item.MAX_FLOW != null) { command.Parameters.AddWithValue("@MAX_FLOW", item.MAX_FLOW); } else { command.Parameters.AddWithValue("@MAX_FLOW", DBNull.Value); }
                        command.ExecuteNonQuery();
                    }
                }
                catch (Exception ex)
                {
                    Message = ex.Message;
                }
            }
        }

        public void Remove(PL_CONFIG_PIPELINE_MRS id)
        {
            using (var conn = new SqlConnection(connString))
            {
                try
                {
                    Message = "";
                    conn.Open();
                    SqlCommand command = new SqlCommand("DELETE PL_CONFIG_PIPELINE_MRS WHERE ID_MRS = @ID_MRS", conn);
                    command.CommandType = System.Data.CommandType.Text;
                    if (id.ID_MRS != null) { command.Parameters.AddWithValue("@ID_MRS", id.ID_MRS); } else { command.Parameters.AddWithValue("@ID_MRS", DBNull.Value); }
                    command.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    Message = ex.Message;
                }
            }
        }

        public List<PL_CONFIG_PIPELINE_MRS> GetData()
        {
            List<PL_CONFIG_PIPELINE_MRS> items = new List<PL_CONFIG_PIPELINE_MRS>();
            using (var conn = new SqlConnection(connString))
            {
                Message = "";
                try
                {
                    conn.Open();
                    SqlCommand command = new SqlCommand("SELECT [ID_MRS], [MRS_TYPE], [MATERIAL_COST], [CONSTRUCTION_COST], [MAX_FLOW] FROM PL_CONFIG_PIPELINE_MRS", conn);
                    SqlDataReader reader = command.ExecuteReader();
                    PL_CONFIG_PIPELINE_MRS item = new PL_CONFIG_PIPELINE_MRS();
                    while (reader.Read())
                    {
                        item = new PL_CONFIG_PIPELINE_MRS();
                        if (reader[0] != DBNull.Value) { item.ID_MRS = Convert.ToInt32(reader[0]); }
                        if (reader[1] != DBNull.Value) { item.MRS_TYPE = Convert.ToString(reader[1]); }
                        if (reader[2] != DBNull.Value) { item.MATERIAL_COST = Convert.ToDouble(reader[2]); }
                        if (reader[3] != DBNull.Value) { item.CONSTRUCTION_COST = Convert.ToDouble(reader[3]); }
                        if (reader[4] != DBNull.Value) { item.MAX_FLOW = Convert.ToDouble(reader[4]); }
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

        public List<PL_CONFIG_PIPELINE_MRS> GetDataByID_MRS(int ID_MRS)
        {
            List<PL_CONFIG_PIPELINE_MRS> items = new List<PL_CONFIG_PIPELINE_MRS>();
            using (var conn = new SqlConnection(connString))
            {
                Message = "";
                try
                {
                    conn.Open();
                    SqlCommand command = new SqlCommand("SELECT [ID_MRS], [MRS_TYPE], [MATERIAL_COST], [CONSTRUCTION_COST], [MAX_FLOW] FROM PL_CONFIG_PIPELINE_MRS WHERE ID_MRS = @ID_MRS", conn);
                    command.Parameters.AddWithValue("@ID_MRS", ID_MRS);
                    SqlDataReader reader = command.ExecuteReader();
                    PL_CONFIG_PIPELINE_MRS item = new PL_CONFIG_PIPELINE_MRS();
                    while (reader.Read())
                    {
                        item = new PL_CONFIG_PIPELINE_MRS();
                        if (reader[0] != DBNull.Value) { item.ID_MRS = Convert.ToInt32(reader[0]); }
                        if (reader[1] != DBNull.Value) { item.MRS_TYPE = Convert.ToString(reader[1]); }
                        if (reader[2] != DBNull.Value) { item.MATERIAL_COST = Convert.ToDouble(reader[2]); }
                        if (reader[3] != DBNull.Value) { item.CONSTRUCTION_COST = Convert.ToDouble(reader[3]); }
                        if (reader[4] != DBNull.Value) { item.MAX_FLOW = Convert.ToDouble(reader[4]); }
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

        public void RemoveByID_MRS(int id)
        {
            using (var conn = new SqlConnection(connString))
            {
                try
                {
                    Message = "";
                    conn.Open();
                    SqlCommand command = new SqlCommand("DELETE PL_CONFIG_PIPELINE_MRS WHERE ID_MRS = @ID_MRS", conn);
                    command.CommandType = System.Data.CommandType.Text;
                    if (id != null) { command.Parameters.AddWithValue("@ID_MRS", id); } else { command.Parameters.AddWithValue("@ID_MRS", DBNull.Value); }
                    command.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    Message = ex.Message;
                }
            }
        }

        public DataTable GetDataTable(List<PL_CONFIG_PIPELINE_MRS> pl_config_pipeline_mrs)
        {
            DataTable dt = new DataTable("PL_CONFIG_PIPELINE_MRS");

            DataColumn c1 = new DataColumn("ID_MRS", typeof(int));
            dt.Columns.Add(c1);
            DataColumn c2 = new DataColumn("MRS_TYPE", typeof(string)); c2.AllowDBNull = true;
            dt.Columns.Add(c2);
            DataColumn c3 = new DataColumn("MATERIAL_COST", typeof(double)); c3.AllowDBNull = true;
            dt.Columns.Add(c3);
            DataColumn c4 = new DataColumn("CONSTRUCTION_COST", typeof(double)); c4.AllowDBNull = true;
            dt.Columns.Add(c4);
            DataColumn c5 = new DataColumn("MAX_FLOW", typeof(double)); c5.AllowDBNull = true;
            dt.Columns.Add(c5);

            foreach (PL_CONFIG_PIPELINE_MRS v in pl_config_pipeline_mrs)
            {
                DataRow dr = dt.NewRow();
                if (v.ID_MRS != null) { dr[0] = v.ID_MRS; } else { dr[0] = DBNull.Value; }
                if (v.MRS_TYPE != null) { dr[1] = v.MRS_TYPE; } else { dr[1] = DBNull.Value; }
                if (v.MATERIAL_COST != null) { dr[2] = v.MATERIAL_COST; } else { dr[2] = DBNull.Value; }
                if (v.CONSTRUCTION_COST != null) { dr[3] = v.CONSTRUCTION_COST; } else { dr[3] = DBNull.Value; }
                if (v.MAX_FLOW != null) { dr[4] = v.MAX_FLOW; } else { dr[4] = DBNull.Value; }
                dt.Rows.Add(dr);
            }
            dt.AcceptChanges();

            return dt;
        }

        public void AddManyBulk(List<PL_CONFIG_PIPELINE_MRS> pl_config_pipeline_mrs)
        {
            using (var conn = new SqlConnection(connString))
            {
                try
                {
                    Message = "";
                    conn.Open();

                    DataTable dt = GetDataTable(pl_config_pipeline_mrs);
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