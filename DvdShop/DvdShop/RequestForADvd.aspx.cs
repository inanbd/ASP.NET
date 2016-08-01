using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DvdShop
{
    public partial class RequestForADvd : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["username"] == null)
            {
                //Response.Write("null");
                Response.Redirect("Index.aspx");
            }
            if (Session["type"].Equals("1"))
            {
                //
                Response.Redirect("Index.aspx");
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            String title = TextBox1.Text;
            String desc = TextBox2.Text;
            String username = Session["username"].ToString();

            
            String sql = "Insert into Requests (Title,Description,RequestedBy) values('" + title + "','" + desc + "','" + username + "')";

            //Response.Write(sql);

            String connStr = ConfigurationManager.ConnectionStrings["DvdShop"].ConnectionString;
            using (SqlConnection con = new SqlConnection(connStr))
            {

                con.Open();

                SqlCommand cmd = con.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = sql;
                cmd.ExecuteNonQuery();

                con.Close();

            }
            //Response.Write("Movie Added To Database Successfully");

            Response.Redirect("User.aspx");


        }
    }
}