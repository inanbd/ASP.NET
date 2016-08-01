using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;

namespace DvdShop
{
    public partial class Index : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Label1.Text = "";
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            DataBase();
        }


        protected void DataBase()
        {
            String connStr = ConfigurationManager.ConnectionStrings["DvdShop"].ConnectionString;
            using (SqlConnection con = new SqlConnection(connStr)) {

                String username = TextBox1.Text;
                String password = TextBox2.Text;

               // String sql = "Select type from users where username = '"+username+"' and Password = '"+password+"'";



                String sql = " SELECT COALESCE( (SELECT type FROM users WHERE username = '" + username + "' and Password = '" + password + "' ), 0)";

                //SqlCommand cmd = new SqlCommand(sql,con);

                SqlDataAdapter sda = new SqlDataAdapter(sql,con);
        
                DataTable dt = new DataTable();
                sda.Fill(dt);

                if (dt.Rows[0][0].ToString().Equals("0")) {
                    Label1.Text = "Invalid Username/Password";
                } else if (dt.Rows[0][0].ToString().Equals("1")) {
                    //admin
                    Session["username"] = username;
                    Session["type"] = "1";

                    Response.Redirect("Admin.aspx");


                } else if (dt.Rows[0][0].ToString().Equals("2")) {
                    //user
                    Session["username"] = username;
                    Session["type"] = "2";
                    Response.Redirect("User.aspx");

                }

                //Response.Write(dt.Rows[0][0].ToString());

                //con.Open();
                //cmd.ExecuteReader();


            }
        }

    }
}