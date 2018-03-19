using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebThemeforest2.Models;

namespace WebThemeforest2.Controllers
{
    public class HomeController : Controller
    {
      
      
        public ActionResult Index()
        {
            Response.Cache.SetCacheability(HttpCacheability.NoCache);  // HTTP 1.1.
            Response.Cache.AppendCacheExtension("no-store, must-revalidate");
            Response.AppendHeader("Pragma", "no-cache"); // HTTP 1.0.
            Response.AppendHeader("Expires", "0"); // Proxies.
            CheckSessionNotLogin();

            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }


        public ActionResult Calculator()
        {
            CheckSessionNotLogin();
           
            ViewBag.Message = "Calculator";

            return View();
        }

        public ActionResult Analysis()
        {
            CheckSessionNotLogin();
            ViewBag.Message = "Analysis";

            return View();
        }

        
        public ActionResult Overview()
        {
            CheckSessionNotLogin();
            ViewBag.Message = "Overview";

            return View();
        }


        public ActionResult MapSerch()
        {

            ViewBag.Message = "MapSerch";

            return View();
        }

        public ActionResult pipeDemandMap()
        {

            ViewBag.Message = "pipeDemandMap";

            return View();
        }



        public ActionResult PipelineMap ()
        {
            CheckSessionNotLogin();
           
            ViewBag.Message = "PipelineMap";
            return PartialView();

        }


        public ActionResult OverviewMap()
        {
            CheckSessionNotLogin();
            ViewBag.Message = "OverviewMap";
            return PartialView();

        }


  

        public ActionResult Login()
        {
            CheckSessionLogin();
            ViewBag.Message = "Login";
            return PartialView();

        }




        public ActionResult logout()
        {
            if (Session != null)
            {
                Session.RemoveAll();
                Response.Redirect(Url.Action("Login", "Home"));
            }
            return View();
        }


        public ActionResult Pipeline()
        {
            
            return View();
        }


        public ActionResult Setting()
        {
            CheckSessionNotLogin();
            CheckSessionSettings();
            ViewBag.Message = "Setting";


            return View();

        }


        public ActionResult Settings(HttpPostedFileBase file)
        {
            CheckSessionNotLogin();
            CheckSessionSettings();
            ViewBag.Message = "Settings";

           

            return PartialView();

        }


       //[HttpPost]
       // public ActionResult UploadFiles()
       // {
       //     if (Request.Files.Count > 0)
       //     {
       //         try
       //         {
       //             string filePath = string.Empty;
       //             HttpFileCollectionBase files = Request.Files;
       //             for (int i = 0; i < files.Count; i++)
       //             {
       //                 HttpPostedFileBase postedFile = files[i];
       //                 if (postedFile != null)
       //                 {
       //                     string path = Server.MapPath("~/Uploads/");
       //                     if (!Directory.Exists(path))
       //                     {
       //                         Directory.CreateDirectory(path);
       //                     }

       //                     filePath = path + Path.GetFileName(postedFile.FileName);
       //                     string extension = Path.GetExtension(postedFile.FileName);
       //                     postedFile.SaveAs(filePath);

       //                     string conString = string.Empty;
       //                     switch (extension)
       //                     {
       //                         case ".xls": //Excel 97-03.
       //                             conString = ConfigurationManager.ConnectionStrings["Excel03ConString"].ConnectionString;
       //                             break;
       //                         case ".xlsx": //Excel 07 and above.
       //                             conString = ConfigurationManager.ConnectionStrings["Excel07ConString"].ConnectionString;
       //                             break;
       //                         case ".csv": //Excel 07 and above.
       //                             conString = ConfigurationManager.ConnectionStrings["CSVConString"].ConnectionString;
       //                             break;
       //                     }

       //                     DataTable dt = new DataTable();
       //                     conString = string.Format(conString, filePath);

       //                     using (OleDbConnection connExcel = new OleDbConnection(conString))
       //                     {
       //                         using (OleDbCommand cmdExcel = new OleDbCommand())
       //                         {
       //                             using (OleDbDataAdapter odaExcel = new OleDbDataAdapter())
       //                             {
       //                                 cmdExcel.Connection = connExcel;

       //                                 //Get the name of First Sheet.
       //                                 connExcel.Open();
       //                                 DataTable dtExcelSchema;
       //                                 dtExcelSchema = connExcel.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, null);
       //                                 string sheetName = dtExcelSchema.Rows[0]["TABLE_NAME"].ToString();
       //                                 connExcel.Close();

       //                                 //Read Data from First Sheet.
       //                                 connExcel.Open();
       //                                 cmdExcel.CommandText = "SELECT * From [" + sheetName + "]";
       //                                 odaExcel.SelectCommand = cmdExcel;
       //                                 odaExcel.Fill(dt);
       //                                 connExcel.Close();
       //                             }
       //                         }
       //                     }

       //                     conString = ConfigurationManager.ConnectionStrings["DatabaseConnection"].ConnectionString;
       //                     using (SqlConnection con = new SqlConnection(conString))
       //                     {
       //                         using (SqlBulkCopy sqlBulkCopy = new SqlBulkCopy(con))
       //                         {
       //                             //Set the database table name.
       //                             sqlBulkCopy.DestinationTableName = "dbo.PL_CONFIG_PIPELINE_COST";

       //                             //[OPTIONAL]: Map the Excel columns with that of the database table
       //                             //sqlBulkCopy.ColumnMappings.Add("ID", "ID");
       //                             sqlBulkCopy.ColumnMappings.Add("ID_CLASSIFICATION", "ID_CLASSIFICATION");
       //                             sqlBulkCopy.ColumnMappings.Add("PIPE_GRADE", "PIPE_GRADE");
       //                             sqlBulkCopy.ColumnMappings.Add("NPS", "NPS");
       //                             sqlBulkCopy.ColumnMappings.Add("MATERIAL_COST_PERMETER", "MATERIAL_COST_PERMETER");
       //                             sqlBulkCopy.ColumnMappings.Add("BASE_MATERIAL_COST", "BASE_MATERIAL_COST");
       //                             sqlBulkCopy.ColumnMappings.Add("CONSTRUCTION_COST", "CONSTRUCTION_COST");
       //                             sqlBulkCopy.ColumnMappings.Add("BASE_CONSTRUCTION_COST", "BASE_CONSTRUCTION_COST");


       //                             con.Open();
       //                             sqlBulkCopy.WriteToServer(dt);
       //                             con.Close();
       //                         }
       //                     }





       //                     //dt.Columns.AddRange(new DataColumn[7] { new DataColumn("ID_CLASSIFICATION"),
       //                     //new DataColumn("PIPE_GRADE"),
       //                     //new DataColumn("NPS") ,
       //                     //new DataColumn("MATERIAL_COST_PERMETER") ,
       //                     //new DataColumn("BASE_MATERIAL_COST") ,
       //                     //new DataColumn("CONSTRUCTION_COST") ,
       //                     //new DataColumn("BASE_CONSTRUCTION_COST") });
                          


       //                     //string csvData = filePath;
       //                     //foreach (string row in csvData.Split('\n'))
       //                     //{
       //                     //    if (!string.IsNullOrEmpty(row))
       //                     //    {
       //                     //        dt.Rows.Add();
       //                     //        int x = 0;
       //                     //        foreach (string cell in row.Split(','))
       //                     //        {
       //                     //            dt.Rows[dt.Rows.Count - 1][i] = cell;
       //                     //            x++;
       //                     //        }
       //                     //    }
       //                     //}

       //                     //string consString = ConfigurationManager.ConnectionStrings["DatabaseConnection"].ConnectionString;
       //                     //using (SqlConnection con = new SqlConnection(consString))
       //                     //{
       //                     //    using (SqlBulkCopy sqlBulkCopy = new SqlBulkCopy(con))
       //                     //    {
       //                     //        //Set the database table name
       //                     //        sqlBulkCopy.DestinationTableName = "dbo.PL_CONFIG_PIPELINE_COST";
       //                     //        con.Open();
       //                     //        sqlBulkCopy.WriteToServer(dt);
       //                     //        con.Close();
       //                     //    }
       //                     //}


       //                 }
       //             }
       //             return Json("File Uploaded Successfully!");
       //         }
       //         catch (Exception ex)
       //         {
       //             return Json("Error occurred. Error details: " + ex.Message);
       //         }
       //     }
       //     else
       //     {
       //         return Json("No files selected.");
       //     }
       // }






        [HttpPost]
        public ActionResult UploadFiles()
        {
            if (Request.Files.Count > 0)
            {
                try
                {
                    string filePath = string.Empty;
                    HttpFileCollectionBase files = Request.Files;
                    for (int i = 0; i < files.Count; i++)
                    {
                        HttpPostedFileBase postedFile = files[i];
                        if (postedFile != null)
                        {
                            string path = Server.MapPath("~/Uploads/");
                            if (!Directory.Exists(path))
                            {
                                Directory.CreateDirectory(path);
                            }

                            filePath = path + Path.GetFileName(postedFile.FileName);
                            string extension = Path.GetExtension(postedFile.FileName);
                            postedFile.SaveAs(filePath);

                           

                          
                            DataTable dataTable = new DataTable();
                            string pathOnly = path + Path.GetDirectoryName(postedFile.FileName);
                            string fileName = Path.GetFileName(postedFile.FileName);

                            string sql = @"SELECT * FROM [" + fileName + "]";

                            using (OleDbConnection connection = new OleDbConnection(
                                      @"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + pathOnly +
                                      ";Extended Properties=\"Text;\""))
                            using (OleDbCommand command = new OleDbCommand(sql, connection))
                            using (OleDbDataAdapter adapter = new OleDbDataAdapter(command))
                            {
                                
                                dataTable.Locale = CultureInfo.CurrentCulture;
                                adapter.Fill(dataTable);
                               
                            }


                            string conString = string.Empty;
                            

                            

                            conString = ConfigurationManager.ConnectionStrings["DatabaseConnection"].ConnectionString;
                            using (SqlConnection con = new SqlConnection(conString))
                            {
                                con.Open();

                                using (SqlTransaction sqlTran = con.BeginTransaction())
                                {
                                    string deleteQuery = "delete from PL_CONFIG_PIPELINE_COST"; // just delete them all
                                    SqlCommand sqlComm = new SqlCommand(deleteQuery,con, sqlTran);
                                    sqlComm.ExecuteNonQuery();

                                    using (SqlBulkCopy sqlBulkCopy = new SqlBulkCopy(con,SqlBulkCopyOptions.Default, sqlTran))
                                    {
                                        //Set the database table name.
                                        sqlBulkCopy.DestinationTableName = "dbo.PL_CONFIG_PIPELINE_COST";

                                        //[OPTIONAL]: Map the Excel columns with that of the database table
                                        //sqlBulkCopy.ColumnMappings.Add("ID", "ID");
                                        sqlBulkCopy.ColumnMappings.Add("ID_CLASSIFICATION", "ID_CLASSIFICATION");
                                        sqlBulkCopy.ColumnMappings.Add("PIPE_GRADE", "PIPE_GRADE");
                                        sqlBulkCopy.ColumnMappings.Add("NPS", "NPS");
                                        sqlBulkCopy.ColumnMappings.Add("MATERIAL_COST_PERMETER", "MATERIAL_COST_PERMETER");
                                        sqlBulkCopy.ColumnMappings.Add("BASE_MATERIAL_COST", "BASE_MATERIAL_COST");
                                        sqlBulkCopy.ColumnMappings.Add("CONSTRUCTION_COST", "CONSTRUCTION_COST");
                                        sqlBulkCopy.ColumnMappings.Add("BASE_CONSTRUCTION_COST", "BASE_CONSTRUCTION_COST");


                                        try
                                        {
                                            sqlBulkCopy.WriteToServer(dataTable);
                                            sqlTran.Commit();
                                        }
                                        catch (Exception ex)
                                        {
                                            sqlTran.Rollback();
                                        }
                                       
                                        
                                    }
                                }
                                con.Close();
                            }
                        }
                    }
                    return Json("File Uploaded Successfully!");
                }
                catch (Exception ex)
                {
                    return Json("Error occurred. Error details: " + ex.Message);
                }
            }
            else
            {
                return Json("No files selected.");
            }
        }

        [HttpPost]
        public ActionResult UploadFiles2()
        {
            if (Request.Files.Count > 0)
            {
                try
                {
                    string filePath = string.Empty;
                    HttpFileCollectionBase files = Request.Files;
                    for (int i = 0; i < files.Count; i++)
                    {
                        HttpPostedFileBase postedFile = files[i];
                        if (postedFile != null)
                        {
                            string path = Server.MapPath("~/Uploads/");
                            if (!Directory.Exists(path))
                            {
                                Directory.CreateDirectory(path);
                            }

                            filePath = path + Path.GetFileName(postedFile.FileName);
                            string extension = Path.GetExtension(postedFile.FileName);
                            postedFile.SaveAs(filePath);




                            DataTable dataTable = new DataTable();
                            string pathOnly = path + Path.GetDirectoryName(postedFile.FileName);
                            string fileName = Path.GetFileName(postedFile.FileName);

                            string sql = @"SELECT * FROM [" + fileName + "]";

                            using (OleDbConnection connection = new OleDbConnection(
                                      @"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + pathOnly +
                                      ";Extended Properties=\"Text;\""))
                            using (OleDbCommand command = new OleDbCommand(sql, connection))
                            using (OleDbDataAdapter adapter = new OleDbDataAdapter(command))
                            {

                                dataTable.Locale = CultureInfo.CurrentCulture;
                                adapter.Fill(dataTable);

                            }


                            string conString = string.Empty;


                            conString = ConfigurationManager.ConnectionStrings["DatabaseConnection"].ConnectionString;
                            using (SqlConnection con = new SqlConnection(conString))
                            {
                                con.Open();

                                using (SqlTransaction sqlTran = con.BeginTransaction())
                                {
                                    string deleteQuery = "delete from PL_CONFIG_PIPELINE_MRS"; // just delete them all
                                    SqlCommand sqlComm = new SqlCommand(deleteQuery, con, sqlTran);
                                    sqlComm.ExecuteNonQuery();

                                    using (SqlBulkCopy sqlBulkCopy = new SqlBulkCopy(con, SqlBulkCopyOptions.Default, sqlTran))
                                    {
                                        //Set the database table name.
                                        sqlBulkCopy.DestinationTableName = "dbo.PL_CONFIG_PIPELINE_MRS";

                                        //[OPTIONAL]: Map the Excel columns with that of the database table
                                        //sqlBulkCopy.ColumnMappings.Add("ID", "ID");
                                        sqlBulkCopy.ColumnMappings.Add("MRS_TYPE", "MRS_TYPE");
                                        sqlBulkCopy.ColumnMappings.Add("MATERIAL_COST", "MATERIAL_COST");

                                        sqlBulkCopy.ColumnMappings.Add("CONSTRUCTION_COST", "CONSTRUCTION_COST");
                                        sqlBulkCopy.ColumnMappings.Add("MAX_FLOW", "MAX_FLOW");



                                        try
                                        {
                                            sqlBulkCopy.WriteToServer(dataTable);
                                            sqlTran.Commit();
                                        }
                                        catch (Exception ex)
                                        {
                                            sqlTran.Rollback();
                                        }
                                    }
                                }
                            }
                        }
                    }
                    return Json("File Uploaded Successfully!");
                }
                catch (Exception ex)
                {
                    return Json("Error occurred. Error details: " + ex.Message);
                }
            }
            else
            {
                return Json("No files selected.");
            }
        }


       
        private void CheckSessionLogin()
        {
            if (Session["userRole"] != null)
            {
                // RedirectToAction("Index", "Crew");
                Response.Redirect(Url.Action("Index", "Home"));
            }

        }

        private void CheckSessionNotLogin()
        {
            if (Session["userRole"] == null)
            {
                // RedirectToAction("Index", "Crew");
                Response.Redirect(Url.Action("Login", "Home"));
            }

        }

        private void CheckSessionSettings()
        {
            if (Session["userRole"].ToString() == "nimouser")
            {
             
                Response.Redirect(Url.Action("Index", "Home"));
            }

        }


     

        public ActionResult History()
        {
            CheckSessionNotLogin();
            return View();

        }


    


    }
}