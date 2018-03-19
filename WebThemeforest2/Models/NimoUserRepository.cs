using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace WebThemeforest2.Models
{
    public partial class NimoUserRepository
    {

        private string connString;
        public string Message { get; set; }


        public NimoUserRepository(string connectionString)
        {
            connString = connectionString;
        }

        public NimoUser GetLogin(NimoUser user)
        {
            NimoUser usr = null;
            List<NimoUser> items = new List<NimoUser>();
            if (user != null)
            {
                using (var conn = new SqlConnection(connString))
                {
                    Message = "";
                    try
                    {
                        conn.Open();
                        SqlCommand command = new SqlCommand("SELECT [USER_ID], [USER_NAME], [USER_PASSWORD] FROM PL_USER WHERE USER_ID = '" + user.USER_ID.ToUpper() + "' AND USER_PASSWORD = '" + user.USER_PASSWORD + "'", conn);
                        SqlDataReader reader = command.ExecuteReader();
                        NimoUser item = new NimoUser();
                        while (reader.Read())
                        {
                            item = new NimoUser();
                            if (reader[0] != DBNull.Value) { item.USER_ID = Convert.ToString(reader[0]); }
                            if (reader[1] != DBNull.Value) { item.USER_NAME = Convert.ToString(reader[1]); }
                            if (reader[2] != DBNull.Value) { item.USER_PASSWORD = Convert.ToString(reader[2]); }
                            items.Add(item);
                        }
                    }
                    catch (Exception ex)
                    {
                        Message = ex.Message;
                    }
                }
                if (items.Count > 0)
                { 
                     

                    usr = items[0];
                }

            }
            return usr;
        }


    }
}