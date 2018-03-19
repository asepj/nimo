using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using WebThemeforest2.Models;

namespace WebThemeforest2.Repositories
{
    public partial class PL_CONFIG_PIPELINE_COSTRepository
    {
        private string connString;
        public string Message { get; set; }

        public PL_CONFIG_PIPELINE_COSTRepository(string connectionString)
        {
            connString = connectionString;
        }

        public void Add(PL_CONFIG_PIPELINE_COST pl_config_pipeline_cost)
        {
            using (var conn = new SqlConnection(connString))
            {
                try
                {
                    Message = "";
                    conn.Open();
                    SqlCommand command = new SqlCommand("INSERT INTO PL_CONFIG_PIPELINE_COST ([ID_CLASSIFICATION], [PIPE_GRADE], [NPS], [MATERIAL_COST_PERMETER], [BASE_MATERIAL_COST], [CONSTRUCTION_COST], [BASE_CONSTRUCTION_COST]) VALUES( @ID_CLASSIFICATION, @PIPE_GRADE, @NPS, @MATERIAL_COST_PERMETER, @BASE_MATERIAL_COST, @CONSTRUCTION_COST, @BASE_CONSTRUCTION_COST)", conn);
                    command.CommandType = System.Data.CommandType.Text;
                    
                    if (pl_config_pipeline_cost.ID_CLASSIFICATION != null) { command.Parameters.AddWithValue("@ID_CLASSIFICATION", pl_config_pipeline_cost.ID_CLASSIFICATION); } else { command.Parameters.AddWithValue("@ID_CLASSIFICATION", DBNull.Value); }
                    if (pl_config_pipeline_cost.PIPE_GRADE != null) { command.Parameters.AddWithValue("@PIPE_GRADE", pl_config_pipeline_cost.PIPE_GRADE); } else { command.Parameters.AddWithValue("@PIPE_GRADE", DBNull.Value); }
                    if (pl_config_pipeline_cost.NPS != null) { command.Parameters.AddWithValue("@NPS", pl_config_pipeline_cost.NPS); } else { command.Parameters.AddWithValue("@NPS", DBNull.Value); }
                    if (pl_config_pipeline_cost.MATERIAL_COST_PERMETER != null) { command.Parameters.AddWithValue("@MATERIAL_COST_PERMETER", pl_config_pipeline_cost.MATERIAL_COST_PERMETER); } else { command.Parameters.AddWithValue("@MATERIAL_COST_PERMETER", DBNull.Value); }
                    if (pl_config_pipeline_cost.BASE_MATERIAL_COST != null) { command.Parameters.AddWithValue("@BASE_MATERIAL_COST", pl_config_pipeline_cost.BASE_MATERIAL_COST); } else { command.Parameters.AddWithValue("@BASE_MATERIAL_COST", DBNull.Value); }
                    if (pl_config_pipeline_cost.CONSTRUCTION_COST != null) { command.Parameters.AddWithValue("@CONSTRUCTION_COST", pl_config_pipeline_cost.CONSTRUCTION_COST); } else { command.Parameters.AddWithValue("@CONSTRUCTION_COST", DBNull.Value); }
                    if (pl_config_pipeline_cost.BASE_CONSTRUCTION_COST != null) { command.Parameters.AddWithValue("@BASE_CONSTRUCTION_COST", pl_config_pipeline_cost.BASE_CONSTRUCTION_COST); } else { command.Parameters.AddWithValue("@BASE_CONSTRUCTION_COST", DBNull.Value); }
                    command.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    Message = ex.Message;
                }
            }
        }

        public void AddMany(List<PL_CONFIG_PIPELINE_COST> pl_config_pipeline_cost)
        {
            using (var conn = new SqlConnection(connString))
            {
                try
                {
                    Message = "";
                    conn.Open();
                    int pos = 0;
                    foreach (PL_CONFIG_PIPELINE_COST item in pl_config_pipeline_cost)
                    {
                        SqlCommand command = new SqlCommand("INSERT INTO PL_CONFIG_PIPELINE_COST ([ID], [ID_CLASSIFICATION], [PIPE_GRADE], [NPS], [MATERIAL_COST_PERMETER], [BASE_MATERIAL_COST], [CONSTRUCTION_COST], [BASE_CONSTRUCTION_COST]) VALUES(@ID, @ID_CLASSIFICATION, @PIPE_GRADE, @NPS, @MATERIAL_COST_PERMETER, @BASE_MATERIAL_COST, @CONSTRUCTION_COST, @BASE_CONSTRUCTION_COST)", conn);
                        command.CommandType = System.Data.CommandType.Text;
                        if (pl_config_pipeline_cost[pos].ID != null) { command.Parameters.AddWithValue("@ID", pl_config_pipeline_cost[pos].ID); } else { command.Parameters.AddWithValue("@ID", DBNull.Value); }
                        if (pl_config_pipeline_cost[pos].ID_CLASSIFICATION != null) { command.Parameters.AddWithValue("@ID_CLASSIFICATION", pl_config_pipeline_cost[pos].ID_CLASSIFICATION); } else { command.Parameters.AddWithValue("@ID_CLASSIFICATION", DBNull.Value); }
                        if (pl_config_pipeline_cost[pos].PIPE_GRADE != null) { command.Parameters.AddWithValue("@PIPE_GRADE", pl_config_pipeline_cost[pos].PIPE_GRADE); } else { command.Parameters.AddWithValue("@PIPE_GRADE", DBNull.Value); }
                        if (pl_config_pipeline_cost[pos].NPS != null) { command.Parameters.AddWithValue("@NPS", pl_config_pipeline_cost[pos].NPS); } else { command.Parameters.AddWithValue("@NPS", DBNull.Value); }
                        if (pl_config_pipeline_cost[pos].MATERIAL_COST_PERMETER != null) { command.Parameters.AddWithValue("@MATERIAL_COST_PERMETER", pl_config_pipeline_cost[pos].MATERIAL_COST_PERMETER); } else { command.Parameters.AddWithValue("@MATERIAL_COST_PERMETER", DBNull.Value); }
                        if (pl_config_pipeline_cost[pos].BASE_MATERIAL_COST != null) { command.Parameters.AddWithValue("@BASE_MATERIAL_COST", pl_config_pipeline_cost[pos].BASE_MATERIAL_COST); } else { command.Parameters.AddWithValue("@BASE_MATERIAL_COST", DBNull.Value); }
                        if (pl_config_pipeline_cost[pos].CONSTRUCTION_COST != null) { command.Parameters.AddWithValue("@CONSTRUCTION_COST", pl_config_pipeline_cost[pos].CONSTRUCTION_COST); } else { command.Parameters.AddWithValue("@CONSTRUCTION_COST", DBNull.Value); }
                        if (pl_config_pipeline_cost[pos].BASE_CONSTRUCTION_COST != null) { command.Parameters.AddWithValue("@BASE_CONSTRUCTION_COST", pl_config_pipeline_cost[pos].BASE_CONSTRUCTION_COST); } else { command.Parameters.AddWithValue("@BASE_CONSTRUCTION_COST", DBNull.Value); }
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

        public void Update(PL_CONFIG_PIPELINE_COST pl_config_pipeline_cost)
        {
            using (var conn = new SqlConnection(connString))
            {
                try
                {
                    Message = "";
                    conn.Open();
                    SqlCommand command = new SqlCommand("UPDATE PL_CONFIG_PIPELINE_COST SET ID_CLASSIFICATION = @ID_CLASSIFICATION, PIPE_GRADE = @PIPE_GRADE, NPS = @NPS, MATERIAL_COST_PERMETER = @MATERIAL_COST_PERMETER, BASE_MATERIAL_COST = @BASE_MATERIAL_COST, CONSTRUCTION_COST = @CONSTRUCTION_COST, BASE_CONSTRUCTION_COST = @BASE_CONSTRUCTION_COST WHERE ID = @ID", conn);
                    command.CommandType = System.Data.CommandType.Text;
                    if (pl_config_pipeline_cost.ID != null) { command.Parameters.AddWithValue("@ID", pl_config_pipeline_cost.ID); } else { command.Parameters.AddWithValue("@ID", DBNull.Value); }
                    if (pl_config_pipeline_cost.ID_CLASSIFICATION != null) { command.Parameters.AddWithValue("@ID_CLASSIFICATION", pl_config_pipeline_cost.ID_CLASSIFICATION); } else { command.Parameters.AddWithValue("@ID_CLASSIFICATION", DBNull.Value); }
                    if (pl_config_pipeline_cost.PIPE_GRADE != null) { command.Parameters.AddWithValue("@PIPE_GRADE", pl_config_pipeline_cost.PIPE_GRADE); } else { command.Parameters.AddWithValue("@PIPE_GRADE", DBNull.Value); }
                    if (pl_config_pipeline_cost.NPS != null) { command.Parameters.AddWithValue("@NPS", pl_config_pipeline_cost.NPS); } else { command.Parameters.AddWithValue("@NPS", DBNull.Value); }
                    if (pl_config_pipeline_cost.MATERIAL_COST_PERMETER != null) { command.Parameters.AddWithValue("@MATERIAL_COST_PERMETER", pl_config_pipeline_cost.MATERIAL_COST_PERMETER); } else { command.Parameters.AddWithValue("@MATERIAL_COST_PERMETER", DBNull.Value); }
                    if (pl_config_pipeline_cost.BASE_MATERIAL_COST != null) { command.Parameters.AddWithValue("@BASE_MATERIAL_COST", pl_config_pipeline_cost.BASE_MATERIAL_COST); } else { command.Parameters.AddWithValue("@BASE_MATERIAL_COST", DBNull.Value); }
                    if (pl_config_pipeline_cost.CONSTRUCTION_COST != null) { command.Parameters.AddWithValue("@CONSTRUCTION_COST", pl_config_pipeline_cost.CONSTRUCTION_COST); } else { command.Parameters.AddWithValue("@CONSTRUCTION_COST", DBNull.Value); }
                    if (pl_config_pipeline_cost.BASE_CONSTRUCTION_COST != null) { command.Parameters.AddWithValue("@BASE_CONSTRUCTION_COST", pl_config_pipeline_cost.BASE_CONSTRUCTION_COST); } else { command.Parameters.AddWithValue("@BASE_CONSTRUCTION_COST", DBNull.Value); }
                    command.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    Message = ex.Message;
                }
            }
        }

        public void UpdateMany(List<PL_CONFIG_PIPELINE_COST> pl_config_pipeline_costs)
        {
            using (var conn = new SqlConnection(connString))
            {
                try
                {
                    Message = "";
                    conn.Open();
                    foreach (PL_CONFIG_PIPELINE_COST item in pl_config_pipeline_costs)
                    {
                        SqlCommand command = new SqlCommand("UPDATE PL_CONFIG_PIPELINE_COST SET ID_CLASSIFICATION = @ID_CLASSIFICATION, PIPE_GRADE = @PIPE_GRADE, NPS = @NPS, MATERIAL_COST_PERMETER = @MATERIAL_COST_PERMETER, BASE_MATERIAL_COST = @BASE_MATERIAL_COST, CONSTRUCTION_COST = @CONSTRUCTION_COST, BASE_CONSTRUCTION_COST = @BASE_CONSTRUCTION_COST WHERE ID = @ID", conn);
                        command.CommandType = System.Data.CommandType.Text;
                        if (item.ID != null) { command.Parameters.AddWithValue("@ID", item.ID); } else { command.Parameters.AddWithValue("@ID", DBNull.Value); }
                        if (item.ID_CLASSIFICATION != null) { command.Parameters.AddWithValue("@ID_CLASSIFICATION", item.ID_CLASSIFICATION); } else { command.Parameters.AddWithValue("@ID_CLASSIFICATION", DBNull.Value); }
                        if (item.PIPE_GRADE != null) { command.Parameters.AddWithValue("@PIPE_GRADE", item.PIPE_GRADE); } else { command.Parameters.AddWithValue("@PIPE_GRADE", DBNull.Value); }
                        if (item.NPS != null) { command.Parameters.AddWithValue("@NPS", item.NPS); } else { command.Parameters.AddWithValue("@NPS", DBNull.Value); }
                        if (item.MATERIAL_COST_PERMETER != null) { command.Parameters.AddWithValue("@MATERIAL_COST_PERMETER", item.MATERIAL_COST_PERMETER); } else { command.Parameters.AddWithValue("@MATERIAL_COST_PERMETER", DBNull.Value); }
                        if (item.BASE_MATERIAL_COST != null) { command.Parameters.AddWithValue("@BASE_MATERIAL_COST", item.BASE_MATERIAL_COST); } else { command.Parameters.AddWithValue("@BASE_MATERIAL_COST", DBNull.Value); }
                        if (item.CONSTRUCTION_COST != null) { command.Parameters.AddWithValue("@CONSTRUCTION_COST", item.CONSTRUCTION_COST); } else { command.Parameters.AddWithValue("@CONSTRUCTION_COST", DBNull.Value); }
                        if (item.BASE_CONSTRUCTION_COST != null) { command.Parameters.AddWithValue("@BASE_CONSTRUCTION_COST", item.BASE_CONSTRUCTION_COST); } else { command.Parameters.AddWithValue("@BASE_CONSTRUCTION_COST", DBNull.Value); }
                        command.ExecuteNonQuery();
                    }
                }
                catch (Exception ex)
                {
                    Message = ex.Message;
                }
            }
        }

        public void Remove(PL_CONFIG_PIPELINE_COST id)
        {
            using (var conn = new SqlConnection(connString))
            {
                try
                {
                    Message = "";
                    conn.Open();
                    SqlCommand command = new SqlCommand("DELETE PL_CONFIG_PIPELINE_COST WHERE ID = @ID", conn);
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

        public List<PL_CONFIG_PIPELINE_COST> GetData()
        {
            List<PL_CONFIG_PIPELINE_COST> items = new List<PL_CONFIG_PIPELINE_COST>();
            using (var conn = new SqlConnection(connString))
            {
                Message = "";
                try
                {
                    conn.Open();
                    SqlCommand command = new SqlCommand("SELECT [ID], [ID_CLASSIFICATION], [PIPE_GRADE], [NPS], [MATERIAL_COST_PERMETER], [BASE_MATERIAL_COST], [CONSTRUCTION_COST], [BASE_CONSTRUCTION_COST] FROM PL_CONFIG_PIPELINE_COST", conn);
                    SqlDataReader reader = command.ExecuteReader();
                    PL_CONFIG_PIPELINE_COST item = new PL_CONFIG_PIPELINE_COST();
                    while (reader.Read())
                    {
                        item = new PL_CONFIG_PIPELINE_COST();
                        if (reader[0] != DBNull.Value) { item.ID = Convert.ToInt32(reader[0]); }
                        if (reader[1] != DBNull.Value) { item.ID_CLASSIFICATION = Convert.ToInt32(reader[1]); }
                        if (reader[2] != DBNull.Value) { item.PIPE_GRADE = Convert.ToInt32(reader[2]); }
                        if (reader[3] != DBNull.Value) { item.NPS = Convert.ToDouble(reader[3]); }
                        if (reader[4] != DBNull.Value) { item.MATERIAL_COST_PERMETER = Convert.ToDecimal(reader[4]); }
                        if (reader[5] != DBNull.Value) { item.BASE_MATERIAL_COST = Convert.ToDecimal(reader[5]); }
                        if (reader[6] != DBNull.Value) { item.CONSTRUCTION_COST = Convert.ToDecimal(reader[6]); }
                        if (reader[7] != DBNull.Value) { item.BASE_CONSTRUCTION_COST = Convert.ToDecimal(reader[7]); }
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

        public List<PL_CONFIG_PIPELINE_COST> GetDataByID(int ID)
        {
            List<PL_CONFIG_PIPELINE_COST> items = new List<PL_CONFIG_PIPELINE_COST>();
            using (var conn = new SqlConnection(connString))
            {
                Message = "";
                try
                {
                    conn.Open();
                    SqlCommand command = new SqlCommand("SELECT [ID], [ID_CLASSIFICATION], [PIPE_GRADE], [NPS], [MATERIAL_COST_PERMETER], [BASE_MATERIAL_COST], [CONSTRUCTION_COST], [BASE_CONSTRUCTION_COST] FROM PL_CONFIG_PIPELINE_COST WHERE ID = @ID", conn);
                    command.Parameters.AddWithValue("@ID", ID);
                    SqlDataReader reader = command.ExecuteReader();
                    PL_CONFIG_PIPELINE_COST item = new PL_CONFIG_PIPELINE_COST();
                    while (reader.Read())
                    {
                        item = new PL_CONFIG_PIPELINE_COST();
                        if (reader[0] != DBNull.Value) { item.ID = Convert.ToInt32(reader[0]); }
                        if (reader[1] != DBNull.Value) { item.ID_CLASSIFICATION = Convert.ToInt32(reader[1]); }
                        if (reader[2] != DBNull.Value) { item.PIPE_GRADE = Convert.ToInt32(reader[2]); }
                        if (reader[3] != DBNull.Value) { item.NPS = Convert.ToDouble(reader[3]); }
                        if (reader[4] != DBNull.Value) { item.MATERIAL_COST_PERMETER = Convert.ToDecimal(reader[4]); }
                        if (reader[5] != DBNull.Value) { item.BASE_MATERIAL_COST = Convert.ToDecimal(reader[5]); }
                        if (reader[6] != DBNull.Value) { item.CONSTRUCTION_COST = Convert.ToDecimal(reader[6]); }
                        if (reader[7] != DBNull.Value) { item.BASE_CONSTRUCTION_COST = Convert.ToDecimal(reader[7]); }
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
                    SqlCommand command = new SqlCommand("DELETE PL_CONFIG_PIPELINE_COST WHERE ID = @ID", conn);
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

        public DataTable GetDataTable(List<PL_CONFIG_PIPELINE_COST> pl_config_pipeline_cost)
        {
            DataTable dt = new DataTable("PL_CONFIG_PIPELINE_COST");

            DataColumn c1 = new DataColumn("ID", typeof(int));
            dt.Columns.Add(c1);
            DataColumn c2 = new DataColumn("ID_CLASSIFICATION", typeof(int)); c2.AllowDBNull = true;
            dt.Columns.Add(c2);
            DataColumn c3 = new DataColumn("PIPE_GRADE", typeof(int)); c3.AllowDBNull = true;
            dt.Columns.Add(c3);
            DataColumn c4 = new DataColumn("NPS", typeof(double)); c4.AllowDBNull = true;
            dt.Columns.Add(c4);
            DataColumn c5 = new DataColumn("MATERIAL_COST_PERMETER", typeof(double)); c5.AllowDBNull = true;
            dt.Columns.Add(c5);
            DataColumn c6 = new DataColumn("BASE_MATERIAL_COST", typeof(double)); c6.AllowDBNull = true;
            dt.Columns.Add(c6);
            DataColumn c7 = new DataColumn("CONSTRUCTION_COST", typeof(double)); c7.AllowDBNull = true;
            dt.Columns.Add(c7);
            DataColumn c8 = new DataColumn("BASE_CONSTRUCTION_COST", typeof(double)); c8.AllowDBNull = true;
            dt.Columns.Add(c8);

            foreach (PL_CONFIG_PIPELINE_COST v in pl_config_pipeline_cost)
            {
                DataRow dr = dt.NewRow();
                if (v.ID != null) { dr[0] = v.ID; } else { dr[0] = DBNull.Value; }
                if (v.ID_CLASSIFICATION != null) { dr[1] = v.ID_CLASSIFICATION; } else { dr[1] = DBNull.Value; }
                if (v.PIPE_GRADE != null) { dr[2] = v.PIPE_GRADE; } else { dr[2] = DBNull.Value; }
                if (v.NPS != null) { dr[3] = v.NPS; } else { dr[3] = DBNull.Value; }
                if (v.MATERIAL_COST_PERMETER != null) { dr[4] = v.MATERIAL_COST_PERMETER; } else { dr[4] = DBNull.Value; }
                if (v.BASE_MATERIAL_COST != null) { dr[5] = v.BASE_MATERIAL_COST; } else { dr[5] = DBNull.Value; }
                if (v.CONSTRUCTION_COST != null) { dr[6] = v.CONSTRUCTION_COST; } else { dr[6] = DBNull.Value; }
                if (v.BASE_CONSTRUCTION_COST != null) { dr[7] = v.BASE_CONSTRUCTION_COST; } else { dr[7] = DBNull.Value; }
                dt.Rows.Add(dr);
            }
            dt.AcceptChanges();

            return dt;
        }

        public void AddManyBulk(List<PL_CONFIG_PIPELINE_COST> pl_config_pipeline_cost)
        {
            using (var conn = new SqlConnection(connString))
            {
                try
                {
                    Message = "";
                    conn.Open();

                    DataTable dt = GetDataTable(pl_config_pipeline_cost);
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