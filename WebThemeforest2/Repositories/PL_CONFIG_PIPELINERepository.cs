using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using WebThemeforest2.Models;

namespace WebThemeforest2.Repositories
{
    public partial class PL_CONFIG_PIPELINERepository
    {
        private string connString;
        public string Message { get; set; }

        public PL_CONFIG_PIPELINERepository(string connectionString)
        {
            connString = connectionString;
        }

        public void Add(PL_CONFIG_PIPELINE PL_CONFIG_PIPELINE)
        {
            using (var conn = new SqlConnection(connString))
            {
                try
                {
                    Message = "";
                    conn.Open();
                    SqlCommand command = new SqlCommand("INSERT INTO PL_CONFIG_PIPELINE_SCHEDULE ( [MATERIAL_ID], [SCHEDULE], [NPS], [OUTSIDE_DIAMETER], [WALL_THICKNESS], [INSIDE_DIAMETER]) VALUES( @MATERIAL_ID, @SCHEDULE, @NPS, @OUTSIDE_DIAMETER, @WALL_THICKNESS, @INSIDE_DIAMETER)", conn);
                    command.CommandType = System.Data.CommandType.Text;
                    
                    if (PL_CONFIG_PIPELINE.MATERIAL_ID != null) { command.Parameters.AddWithValue("@MATERIAL_ID", PL_CONFIG_PIPELINE.MATERIAL_ID); } else { command.Parameters.AddWithValue("@MATERIAL_ID", DBNull.Value); }
                    if (PL_CONFIG_PIPELINE.SCHEDULE != null) { command.Parameters.AddWithValue("@SCHEDULE", PL_CONFIG_PIPELINE.SCHEDULE); } else { command.Parameters.AddWithValue("@SCHEDULE", DBNull.Value); }
                    if (PL_CONFIG_PIPELINE.NPS != null) { command.Parameters.AddWithValue("@NPS", PL_CONFIG_PIPELINE.NPS); } else { command.Parameters.AddWithValue("@NPS", DBNull.Value); }
                    if (PL_CONFIG_PIPELINE.OUTSIDE_DIAMETER != null) { command.Parameters.AddWithValue("@OUTSIDE_DIAMETER", PL_CONFIG_PIPELINE.OUTSIDE_DIAMETER); } else { command.Parameters.AddWithValue("@OUTSIDE_DIAMETER", DBNull.Value); }
                    if (PL_CONFIG_PIPELINE.WALL_THICKNESS != null) { command.Parameters.AddWithValue("@WALL_THICKNESS", PL_CONFIG_PIPELINE.WALL_THICKNESS); } else { command.Parameters.AddWithValue("@WALL_THICKNESS", DBNull.Value); }
                    if (PL_CONFIG_PIPELINE.INSIDE_DIAMETER != null) { command.Parameters.AddWithValue("@INSIDE_DIAMETER", PL_CONFIG_PIPELINE.INSIDE_DIAMETER); } else { command.Parameters.AddWithValue("@INSIDE_DIAMETER", DBNull.Value); }
                    command.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    Message = ex.Message;
                }
            }
        }

        public void AddMany(List<PL_CONFIG_PIPELINE> PL_CONFIG_PIPELINE)
        {
            using (var conn = new SqlConnection(connString))
            {
                try
                {
                    Message = "";
                    conn.Open();
                    int pos = 0;
                    foreach (PL_CONFIG_PIPELINE item in PL_CONFIG_PIPELINE)
                    {
                        SqlCommand command = new SqlCommand("INSERT INTO PL_CONFIG_PIPELINE_SCHEDULE ([ID], [MATERIAL_ID], [SCHEDULE], [NPS], [OUTSIDE_DIAMETER], [WALL_THICKNESS], [INSIDE_DIAMETER]) VALUES(@ID, @MATERIAL_ID, @SCHEDULE, @NPS, @OUTSIDE_DIAMETER, @WALL_THICKNESS, @INSIDE_DIAMETER)", conn);
                        command.CommandType = System.Data.CommandType.Text;
                        if (PL_CONFIG_PIPELINE[pos].ID != null) { command.Parameters.AddWithValue("@ID", PL_CONFIG_PIPELINE[pos].ID); } else { command.Parameters.AddWithValue("@ID", DBNull.Value); }
                        if (PL_CONFIG_PIPELINE[pos].MATERIAL_ID != null) { command.Parameters.AddWithValue("@MATERIAL_ID", PL_CONFIG_PIPELINE[pos].MATERIAL_ID); } else { command.Parameters.AddWithValue("@MATERIAL_ID", DBNull.Value); }
                        if (PL_CONFIG_PIPELINE[pos].SCHEDULE != null) { command.Parameters.AddWithValue("@SCHEDULE", PL_CONFIG_PIPELINE[pos].SCHEDULE); } else { command.Parameters.AddWithValue("@SCHEDULE", DBNull.Value); }
                        if (PL_CONFIG_PIPELINE[pos].NPS != null) { command.Parameters.AddWithValue("@NPS", PL_CONFIG_PIPELINE[pos].NPS); } else { command.Parameters.AddWithValue("@NPS", DBNull.Value); }
                        if (PL_CONFIG_PIPELINE[pos].OUTSIDE_DIAMETER != null) { command.Parameters.AddWithValue("@OUTSIDE_DIAMETER", PL_CONFIG_PIPELINE[pos].OUTSIDE_DIAMETER); } else { command.Parameters.AddWithValue("@OUTSIDE_DIAMETER", DBNull.Value); }
                        if (PL_CONFIG_PIPELINE[pos].WALL_THICKNESS != null) { command.Parameters.AddWithValue("@WALL_THICKNESS", PL_CONFIG_PIPELINE[pos].WALL_THICKNESS); } else { command.Parameters.AddWithValue("@WALL_THICKNESS", DBNull.Value); }
                        if (PL_CONFIG_PIPELINE[pos].INSIDE_DIAMETER != null) { command.Parameters.AddWithValue("@INSIDE_DIAMETER", PL_CONFIG_PIPELINE[pos].INSIDE_DIAMETER); } else { command.Parameters.AddWithValue("@INSIDE_DIAMETER", DBNull.Value); }
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

        public void Update(PL_CONFIG_PIPELINE PL_CONFIG_PIPELINE)
        {
            using (var conn = new SqlConnection(connString))
            {
                try
                {
                    Message = "";
                    conn.Open();
                    SqlCommand command = new SqlCommand("UPDATE PL_CONFIG_PIPELINE_SCHEDULE SET MATERIAL_ID = @MATERIAL_ID, SCHEDULE = @SCHEDULE, NPS = @NPS, OUTSIDE_DIAMETER = @OUTSIDE_DIAMETER, WALL_THICKNESS = @WALL_THICKNESS, INSIDE_DIAMETER = @INSIDE_DIAMETER WHERE ID = @ID", conn);
                    command.CommandType = System.Data.CommandType.Text;
                    if (PL_CONFIG_PIPELINE.ID != null) { command.Parameters.AddWithValue("@ID", PL_CONFIG_PIPELINE.ID); } else { command.Parameters.AddWithValue("@ID", DBNull.Value); }
                    if (PL_CONFIG_PIPELINE.MATERIAL_ID != null) { command.Parameters.AddWithValue("@MATERIAL_ID", PL_CONFIG_PIPELINE.MATERIAL_ID); } else { command.Parameters.AddWithValue("@MATERIAL_ID", DBNull.Value); }
                    if (PL_CONFIG_PIPELINE.SCHEDULE != null) { command.Parameters.AddWithValue("@SCHEDULE", PL_CONFIG_PIPELINE.SCHEDULE); } else { command.Parameters.AddWithValue("@SCHEDULE", DBNull.Value); }
                    if (PL_CONFIG_PIPELINE.NPS != null) { command.Parameters.AddWithValue("@NPS", PL_CONFIG_PIPELINE.NPS); } else { command.Parameters.AddWithValue("@NPS", DBNull.Value); }
                    if (PL_CONFIG_PIPELINE.OUTSIDE_DIAMETER != null) { command.Parameters.AddWithValue("@OUTSIDE_DIAMETER", PL_CONFIG_PIPELINE.OUTSIDE_DIAMETER); } else { command.Parameters.AddWithValue("@OUTSIDE_DIAMETER", DBNull.Value); }
                    if (PL_CONFIG_PIPELINE.WALL_THICKNESS != null) { command.Parameters.AddWithValue("@WALL_THICKNESS", PL_CONFIG_PIPELINE.WALL_THICKNESS); } else { command.Parameters.AddWithValue("@WALL_THICKNESS", DBNull.Value); }
                    if (PL_CONFIG_PIPELINE.INSIDE_DIAMETER != null) { command.Parameters.AddWithValue("@INSIDE_DIAMETER", PL_CONFIG_PIPELINE.INSIDE_DIAMETER); } else { command.Parameters.AddWithValue("@INSIDE_DIAMETER", DBNull.Value); }
                    command.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    Message = ex.Message;
                }
            }
        }

        public void UpdateMany(List<PL_CONFIG_PIPELINE> PL_CONFIG_PIPELINEs)
        {
            using (var conn = new SqlConnection(connString))
            {
                try
                {
                    Message = "";
                    conn.Open();
                    foreach (PL_CONFIG_PIPELINE item in PL_CONFIG_PIPELINEs)
                    {
                        SqlCommand command = new SqlCommand("UPDATE PL_CONFIG_PIPELINE_SCHEDULE SET MATERIAL_ID = @MATERIAL_ID, SCHEDULE = @SCHEDULE, NPS = @NPS, OUTSIDE_DIAMETER = @OUTSIDE_DIAMETER, WALL_THICKNESS = @WALL_THICKNESS, INSIDE_DIAMETER = @INSIDE_DIAMETER WHERE ID = @ID", conn);
                        command.CommandType = System.Data.CommandType.Text;
                        if (item.ID != null) { command.Parameters.AddWithValue("@ID", item.ID); } else { command.Parameters.AddWithValue("@ID", DBNull.Value); }
                        if (item.MATERIAL_ID != null) { command.Parameters.AddWithValue("@MATERIAL_ID", item.MATERIAL_ID); } else { command.Parameters.AddWithValue("@MATERIAL_ID", DBNull.Value); }
                        if (item.SCHEDULE != null) { command.Parameters.AddWithValue("@SCHEDULE", item.SCHEDULE); } else { command.Parameters.AddWithValue("@SCHEDULE", DBNull.Value); }
                        if (item.NPS != null) { command.Parameters.AddWithValue("@NPS", item.NPS); } else { command.Parameters.AddWithValue("@NPS", DBNull.Value); }
                        if (item.OUTSIDE_DIAMETER != null) { command.Parameters.AddWithValue("@OUTSIDE_DIAMETER", item.OUTSIDE_DIAMETER); } else { command.Parameters.AddWithValue("@OUTSIDE_DIAMETER", DBNull.Value); }
                        if (item.WALL_THICKNESS != null) { command.Parameters.AddWithValue("@WALL_THICKNESS", item.WALL_THICKNESS); } else { command.Parameters.AddWithValue("@WALL_THICKNESS", DBNull.Value); }
                        if (item.INSIDE_DIAMETER != null) { command.Parameters.AddWithValue("@INSIDE_DIAMETER", item.INSIDE_DIAMETER); } else { command.Parameters.AddWithValue("@INSIDE_DIAMETER", DBNull.Value); }
                        command.ExecuteNonQuery();
                    }
                }
                catch (Exception ex)
                {
                    Message = ex.Message;
                }
            }
        }

        public void Remove(PL_CONFIG_PIPELINE id)
        {
            using (var conn = new SqlConnection(connString))
            {
                try
                {
                    Message = "";
                    conn.Open();
                    SqlCommand command = new SqlCommand("DELETE PL_CONFIG_PIPELINE_SCHEDULE WHERE ID = @ID", conn);
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

        public List<PL_CONFIG_PIPELINE> GetData()
        {
            List<PL_CONFIG_PIPELINE> items = new List<PL_CONFIG_PIPELINE>();
            using (var conn = new SqlConnection(connString))
            {
                Message = "";
                try
                {
                    conn.Open();
                    SqlCommand command = new SqlCommand("SELECT [ID], [MATERIAL_ID], [SCHEDULE], [NPS], [OUTSIDE_DIAMETER], [WALL_THICKNESS], [INSIDE_DIAMETER] FROM PL_CONFIG_PIPELINE_SCHEDULE", conn);
                    SqlDataReader reader = command.ExecuteReader();
                    PL_CONFIG_PIPELINE item = new PL_CONFIG_PIPELINE();
                    while (reader.Read())
                    {
                        item = new PL_CONFIG_PIPELINE();
                        if (reader[0] != DBNull.Value) { item.ID = Convert.ToInt32(reader[0]); }
                        if (reader[1] != DBNull.Value) { item.MATERIAL_ID = Convert.ToInt32(reader[1]); }
                        if (reader[2] != DBNull.Value) { item.SCHEDULE = Convert.ToString(reader[2]); }
                        if (reader[3] != DBNull.Value) { item.NPS = Convert.ToString(reader[3]); }
                        if (reader[4] != DBNull.Value) { item.OUTSIDE_DIAMETER = Convert.ToDouble(reader[4]); }
                        if (reader[5] != DBNull.Value) { item.WALL_THICKNESS = Convert.ToDouble(reader[5]); }
                        if (reader[6] != DBNull.Value) { item.INSIDE_DIAMETER = Convert.ToDouble(reader[6]); }
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

        public List<PL_CONFIG_PIPELINE> GetDataNPS(PL_CONFIG_PIPELINE pl_config_pipeline)
        {
            List<PL_CONFIG_PIPELINE> items = new List<PL_CONFIG_PIPELINE>();
            using (var conn = new SqlConnection(connString))
            {
                Message = "";
                try
                {
                    conn.Open();
                    SqlCommand command = new SqlCommand("SELECT TOP 1 [NPS], [OUTSIDE_DIAMETER] , [WALL_THICKNESS] FROM PL_CONFIG_PIPELINE_SCHEDULE WHERE INSIDE_DIAMETER > '" + pl_config_pipeline.INSIDE_DIAMETER + "' ORDER BY [INSIDE_DIAMETER]", conn);
                    SqlDataReader reader = command.ExecuteReader();
                    PL_CONFIG_PIPELINE item = new PL_CONFIG_PIPELINE();
                    while (reader.Read())
                    {
                        item = new PL_CONFIG_PIPELINE();

                        if (reader[0] != DBNull.Value) { item.NPS = Convert.ToString(reader[0]); }
                        if (reader[1] != DBNull.Value) { item.OUTSIDE_DIAMETER = Convert.ToDouble(reader[1]); }
                        if (reader[2] != DBNull.Value) { item.WALL_THICKNESS = Convert.ToDouble(reader[2]); }

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



        public List<PL_CONFIG_PIPELINE> GetDataNPSPart2(PL_CONFIG_PIPELINE pl_config_pipeline)
        {
            List<PL_CONFIG_PIPELINE> items = new List<PL_CONFIG_PIPELINE>();
            using (var conn = new SqlConnection(connString))
            {
                Message = "";
                try
                {
                    conn.Open();
                    SqlCommand command = new SqlCommand("SELECT TOP 1 [NPS] FROM PL_CONFIG_PIPELINE_SCHEDULE WHERE INSIDE_DIAMETER > '" + pl_config_pipeline.INSIDE_DIAMETER + "'", conn);
                    SqlDataReader reader = command.ExecuteReader();
                    PL_CONFIG_PIPELINE item = new PL_CONFIG_PIPELINE();
                    while (reader.Read())
                    {
                        item = new PL_CONFIG_PIPELINE();

                        if (reader[0] != DBNull.Value) { item.NPS = Convert.ToString(reader[0]); }
                      

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




        public double GetCost(PipeCost pipecost)
        {
           
            SqlConnection Connect = new SqlConnection(connString);
            //string queries  = "SELECT [dbo].[fn_GetPipeCost] ( " + pipecost.roughness  + "," + pipecost.idConstruction+  "," + pipecost.length+ "," +pipecost.pipePressure+ "," +pipecost.diameter +") as pipeCost";

            //string query = "select total_cost = a.total_pipe_cost + b.total_mrs_cost,   a.* ,  b.* from   [dbo].[fn_GetPipeCost](" + pipecost.roughness + "," + pipecost.idConstruction + "," + pipecost.length + "," + pipecost.pipePressure + "," + pipecost.diameter + ") a, [dbo].[fn_GetMRSCost](" + pipecost.pipePressureInput + "," + pipecost.pipeFlowrateInput + ","  + pipecost.diameter + ") b";

            string query = "SELECT * FROM [dbo].[fn_GetCapexCost](" + pipecost.roughness + "," + pipecost.idConstruction + "," + pipecost.length + "," + pipecost.diameter + "," + pipecost.pipePressureInput + "," + pipecost.pipePressure + "," + pipecost.pipeFlowrateInput + ") ";
            SqlCommand cmd = new SqlCommand(query, Connect);

            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            Connect.Open();
            int b = cmd.ExecuteNonQuery();
            da.Dispose();
            Connect.Close();

            if (dt.Rows.Count > 0)
            {

                pipecost.cost = Convert.ToDouble(dt.Rows[0]["total_capex_plus_ppn"]);
                pipecost.NPS  = Convert.ToDouble(dt.Rows[0]["nps"]);
                pipecost.unit = Convert.ToString(dt.Rows[0]["nps_unit"]);
               
            }

            return pipecost.cost;
        }

        public List<PL_CONFIG_PIPELINE> GetDataByID(int ID)
        {
            List<PL_CONFIG_PIPELINE> items = new List<PL_CONFIG_PIPELINE>();
            using (var conn = new SqlConnection(connString))
            {
                Message = "";
                try
                {
                    conn.Open();
                    SqlCommand command = new SqlCommand("SELECT [ID], [MATERIAL_ID], [SCHEDULE], [NPS], [OUTSIDE_DIAMETER], [WALL_THICKNESS], [INSIDE_DIAMETER] FROM PL_CONFIG_PIPELINE_SCHEDULE WHERE ID = @ID", conn);
                    command.Parameters.AddWithValue("@ID", ID);
                    SqlDataReader reader = command.ExecuteReader();
                    PL_CONFIG_PIPELINE item = new PL_CONFIG_PIPELINE();
                    while (reader.Read())
                    {
                        item = new PL_CONFIG_PIPELINE();
                        if (reader[0] != DBNull.Value) { item.ID = Convert.ToInt32(reader[0]); }
                        if (reader[1] != DBNull.Value) { item.MATERIAL_ID = Convert.ToInt32(reader[1]); }
                        if (reader[2] != DBNull.Value) { item.SCHEDULE = Convert.ToString(reader[2]); }
                        if (reader[3] != DBNull.Value) { item.NPS = Convert.ToString(reader[3]); }
                        if (reader[4] != DBNull.Value) { item.OUTSIDE_DIAMETER = Convert.ToDouble(reader[4]); }
                        if (reader[5] != DBNull.Value) { item.WALL_THICKNESS = Convert.ToDouble(reader[5]); }
                        if (reader[6] != DBNull.Value) { item.INSIDE_DIAMETER = Convert.ToDouble(reader[6]); }
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
                    SqlCommand command = new SqlCommand("DELETE PL_CONFIG_PIPELINE_SCHEDULE WHERE ID = @ID", conn);
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

        public DataTable GetDataTable(List<PL_CONFIG_PIPELINE> PL_CONFIG_PIPELINE)
        {
            DataTable dt = new DataTable("PL_CONFIG_PIPELINE_SCHEDULE");

            DataColumn c1 = new DataColumn("ID", typeof(int));
            dt.Columns.Add(c1);
            DataColumn c2 = new DataColumn("MATERIAL_ID", typeof(int)); c2.AllowDBNull = true;
            dt.Columns.Add(c2);
            DataColumn c3 = new DataColumn("SCHEDULE", typeof(string)); c3.AllowDBNull = true;
            dt.Columns.Add(c3);
            DataColumn c4 = new DataColumn("NPS", typeof(string)); c4.AllowDBNull = true;
            dt.Columns.Add(c4);
            DataColumn c5 = new DataColumn("OUTSIDE_DIAMETER", typeof(double)); c5.AllowDBNull = true;
            dt.Columns.Add(c5);
            DataColumn c6 = new DataColumn("WALL_THICKNESS", typeof(double)); c6.AllowDBNull = true;
            dt.Columns.Add(c6);
            DataColumn c7 = new DataColumn("INSIDE_DIAMETER", typeof(double)); c7.AllowDBNull = true;
            dt.Columns.Add(c7);

            foreach (PL_CONFIG_PIPELINE v in PL_CONFIG_PIPELINE)
            {
                DataRow dr = dt.NewRow();
                if (v.ID != null) { dr[0] = v.ID; } else { dr[0] = DBNull.Value; }
                if (v.MATERIAL_ID != null) { dr[1] = v.MATERIAL_ID; } else { dr[1] = DBNull.Value; }
                if (v.SCHEDULE != null) { dr[2] = v.SCHEDULE; } else { dr[2] = DBNull.Value; }
                if (v.NPS != null) { dr[3] = v.NPS; } else { dr[3] = DBNull.Value; }
                if (v.OUTSIDE_DIAMETER != null) { dr[4] = v.OUTSIDE_DIAMETER; } else { dr[4] = DBNull.Value; }
                if (v.WALL_THICKNESS != null) { dr[5] = v.WALL_THICKNESS; } else { dr[5] = DBNull.Value; }
                if (v.INSIDE_DIAMETER != null) { dr[6] = v.INSIDE_DIAMETER; } else { dr[6] = DBNull.Value; }
                dt.Rows.Add(dr);
            }
            dt.AcceptChanges();

            return dt;
        }

        public void AddManyBulk(List<PL_CONFIG_PIPELINE> PL_CONFIG_PIPELINE)
        {
            using (var conn = new SqlConnection(connString))
            {
                try
                {
                    Message = "";
                    conn.Open();

                    DataTable dt = GetDataTable(PL_CONFIG_PIPELINE);
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