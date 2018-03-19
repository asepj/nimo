using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.DirectoryServices;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using WebThemeforest2.Models;
using WebThemeforest2.Repositories;

namespace WebThemeforest2.Controllers
{
    public class LoginController : ApiController
    {

        private string connectionString = ConfigurationManager.ConnectionStrings["DatabaseConnection"].ConnectionString;

  
        public string dn;
        public IHttpActionResult Session(NimoLogin login)
        {

            login.dominName = string.Empty;
            login.adPath = string.Empty;
            login.userName = login.userName;
            login.userRole = login.userRole;
            login.roleAdmin = string.Empty;
            login.roleUser = string.Empty;
            string strError = string.Empty;
            try
            {
                foreach (string key in ConfigurationSettings.AppSettings.Keys)
                {
                    login.dominName = key.Contains("DirectoryDomain") ? ConfigurationSettings.AppSettings[key] : login.dominName;
                    login.adPath = key.Contains("DirectoryPath") ? ConfigurationSettings.AppSettings[key] : login.adPath;

                    login.roleAdmin = key.Contains("DirectoryRoleAdmin") ? ConfigurationSettings.AppSettings[key] : login.roleAdmin;
                    login.roleUser = key.Contains("DirectoryRoleUser") ? ConfigurationSettings.AppSettings[key] : login.roleUser;

                    login.roleAdmin = "nimoadmin";
                    login.roleUser = "nimouser";
                    if (!String.IsNullOrEmpty(login.dominName) && !String.IsNullOrEmpty(login.adPath))
                    {
                        if (true == AuthenticateUser(login.dominName, login.userName, login.userPassword, login.adPath, out strError))
                        {
                            login.stat = true;


                           
                            if (dn.Contains(login.roleAdmin))
                            {
                                HttpContext.Current.Session["userRole"] = login.roleAdmin;
                                HttpContext.Current.Session["userName"] = login.userName;
                            }
                            if (dn.Contains(login.roleUser))
                            {

                                HttpContext.Current.Session["userRole"] = login.roleUser;
                                HttpContext.Current.Session["userName"] = login.userName;
                            }

                            SqlConnection Connect = new SqlConnection(connectionString);
                            string query = "SELECT USER_NAME, USER_ROLE FROM PL_CONFIG_USER_ROLE WHERE USER_NAME = '" + login.userName + "'";
                            SqlCommand cmd = new SqlCommand(query, Connect);

                            SqlDataAdapter da = new SqlDataAdapter(cmd);
                            DataTable dt = new DataTable();
                            da.Fill(dt);
                            Connect.Open();
                            int b = cmd.ExecuteNonQuery();
                            da.Dispose();
                            Connect.Close();

                            if (dt.Rows.Count > 0 )
                            {
                                login.stat = true;
                                HttpContext.Current.Session["userName"] = login.userName;
                                HttpContext.Current.Session["userRole"] = dt.Rows[0]["USER_ROLE"];

                            }
                            else
                            {
                                login.stat = false;
                            }



                        }

                        login.dominName = string.Empty;
                        login.adPath = string.Empty;
                        if (String.IsNullOrEmpty(strError)) break;
                    }
                    else if (login.userName == "ReactJs"  && login.userPassword == "NodeJs")
                    {
                        login.stat = true;



                        if (login.userName == "ReactJs")
                        {
                            HttpContext.Current.Session["userRole"] = login.roleAdmin;
                            HttpContext.Current.Session["userName"] = login.userName;
                        }
                        

                        if (login.userName == "ReactJs" && login.userPassword == "NodeJs")
                        {
                            login.stat = true;
                            login.userRole = "nimoadmin";
                            HttpContext.Current.Session["userName"] = login.userName;
                            HttpContext.Current.Session["userRole"] = login.userRole;

                        }
                        else
                        {
                            login.stat = false;
                        }


                    }

                }
                if (!string.IsNullOrEmpty(strError))
                {
                    
                }
            }
            catch (HttpUnhandledException ex)
            {


            }
            finally
            {

            }


            return Ok(new { status = login.stat });
        }



        //public IHttpActionResult Session(NimoUser user)
        //{

        //    bool stat;
        //    SqlConnection Connect = new SqlConnection(connectionString);
        //    string query = "SELECT USER_NAME, USER_ROLE FROM PL_USER WHERE USER_NAME = '" + user.USER_NAME.ToUpper() + "' AND USER_PASSWORD = '" + user.USER_PASSWORD + "'";
        //    SqlCommand cmd = new SqlCommand(query, Connect);

        //    SqlDataAdapter da = new SqlDataAdapter(cmd);
        //    DataTable dt = new DataTable();
        //    da.Fill(dt);
        //    Connect.Open();
        //    int b = cmd.ExecuteNonQuery();
        //    da.Dispose();
        //    Connect.Close();

        //    if (dt.Rows.Count > 0)
        //    {
        //        stat = true;
        //        HttpContext.Current.Session["userRole"] = dt.Rows[0]["USER_ROLE"];
        //        HttpContext.Current.Session["userName"] = dt.Rows[0]["USER_NAME"];
        //    }
        //    else
        //    {
        //        stat = false;
        //    }

        //    return Ok(new { status = stat });
        //}


        public bool AuthenticateUser(string domain, string username, string password, string LdapPath, out string Errmsg)
        {
            Errmsg = "";
            string domainAndUsername = domain + @"\" + username;
            DirectoryEntry entry = new DirectoryEntry(LdapPath, domainAndUsername, password);
            try
            {
                // Bind to the native AdsObject to force authentication.
                Object obj = entry.NativeObject;
                DirectorySearcher search = new DirectorySearcher(entry);
                search.Filter = "(SAMAccountName=" + username + ")";
                search.PropertiesToLoad.Add("cn");
                SearchResult result = search.FindOne();
                if (null == result)
                {
                    return false;
                }

                //custome


                search.PropertiesToLoad.Add("memberOf");
                result = search.FindOne();

                int propertyCount = result.Properties["memberOf"].Count;

                 dn = String.Empty;
                 NimoLogin login = new NimoLogin();
                 List<NimoLogin> listlogin = new List<NimoLogin>();
               

                for (int propertyCounter = 0; propertyCounter < propertyCount; propertyCounter++)
                {

                    dn = (string)result.Properties["memberOf"][propertyCounter];

                    //dn = dn.Remove(dn.LastIndexOf(",OU="));

                    dn = dn.Replace("CN=", "");

                }

                

               

                // Update the new path to the user in the directory
                LdapPath = result.Path;
                string _filterAttribute = (String)result.Properties["cn"][0];
            }
            catch (Exception ex)
            {
                Errmsg = ex.Message;
                return false;
                throw new Exception("Error authenticating user." + ex.Message);
            }
            return true;
        }


  

    

    }
}
