using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DataLoadWithPagination.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            String connStr = ConfigurationManager.ConnectionStrings["SAMPLE"].ConnectionString;
            using (SqlConnection con = new SqlConnection(connStr))
            {
                String sql = "Select count(*)/10 as totalrows  from student";
                SqlDataAdapter sda = new SqlDataAdapter(sql, con);

                DataTable dt = new DataTable();
                sda.Fill(dt);

                foreach (System.Data.DataRow dr in dt.Rows)
                {
                    ViewBag.rowCount = dr["totalrows"].ToString();
                }

                return View();
            }
        }
        public ActionResult Select(int offset,String orderby,String ascDesc)
        {
            String connStr = ConfigurationManager.ConnectionStrings["SAMPLE"].ConnectionString;
            using (SqlConnection con = new SqlConnection(connStr))
            {
                String sql = "Select * from Student ORDER BY "+orderby+" "+ ascDesc + " OFFSET "+offset+" ROWS FETCH NEXT 10 ROWS ONLY;";
                SqlDataAdapter sda = new SqlDataAdapter(sql, con);

                DataTable dt = new DataTable();
                sda.Fill(dt);

                return View(dt);
            }
        }
        public ActionResult JQueryDataTable()
        {
            return View();
        }
        public ActionResult JQueryDataTableResult()
        {

            String connStr = ConfigurationManager.ConnectionStrings["SAMPLE"].ConnectionString;
            using (SqlConnection con = new SqlConnection(connStr))
            {
                String sql = "Select top 40000 * from Student";
                SqlDataAdapter sda = new SqlDataAdapter(sql, con);

                DataTable dt = new DataTable();
                sda.Fill(dt);
                dt.Columns.Add(new DataColumn("Picture"));
                foreach(DataRow dr in dt.Rows)
                {
                    dr["Picture"] = "  <input type='checkbox' name='vehicle' value='Bike'>";
                }
                string data = JsonConvert.SerializeObject(dt, Formatting.None);

                //return Json(new { data=data}, JsonRequestBehavior.AllowGet);

                JsonResult jsonResult = Json(dt, JsonRequestBehavior.AllowGet);
                jsonResult.MaxJsonLength = int.MaxValue;

                return Content("{\"data\": " + data  + "}");
            }

            
        }
    }
}















//Data input code

//for(int i = 1; i < 30000; i++)
//{

//    String sql = "Insert into Student (Name) values('asdzxc"+i.ToString()+ "')";

//    //Response.Write(sql);

//    String connStr = ConfigurationManager.ConnectionStrings["SAMPLE"].ConnectionString;
//    using (SqlConnection con = new SqlConnection(connStr))
//    {

//        con.Open();

//        SqlCommand cmd = con.CreateCommand();
//        cmd.CommandType = CommandType.Text;
//        cmd.CommandText = sql;
//        cmd.ExecuteNonQuery();

//        con.Close();

//    }


//}


//return View();