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
    public partial class AddNewDvd : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["username"] == null)
            {
                //Response.Write("null");
                //Response.Redirect("Index.aspx");
            }
            try
            {
                if (Session["type"].Equals("2"))
                {
                    //
                    // Response.Redirect("Index.aspx");
                }
            }
            catch (Exception ex) {

            }

            LoadCatagories();

        }

        protected void LoadCatagories() {


            String connStr = ConfigurationManager.ConnectionStrings["DvdShop"].ConnectionString;
            using (SqlConnection con = new SqlConnection(connStr))
            {
                con.Open();
                String sql = "Select CategoryName as name from Category";

                //SqlCommand cmd = new SqlCommand(sql,con);

                SqlDataAdapter sda = new SqlDataAdapter(sql, con);
                SqlCommandBuilder builder = new SqlCommandBuilder(sda);

                DataSet ds = new DataSet();
                sda.Fill(ds,"Category");
                DropDownListCategory.DataSource = ds;
                DropDownListCategory.DataTextField = "name";
                DropDownListCategory.DataValueField = "name";
                DropDownListCategory.DataBind();
                con.Close();
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            String title = TextBoxTitle.Text;
            String description = TextBoxDescription.Text;
            String category = DropDownListCategory.Text;
            String audioQuality = DropDownListAudio.Text;
            String videoQualtiy = DropDownListVideo.Text;
            String Language = DropDownListLanguage.Text;

            String sql = "Insert into Movies (MovieTitle,Description,Category,AudioQuality,VideoQuality,Language) values('" + title + "','" + description + "','" + category + "','" + audioQuality + "','" + videoQualtiy + "','" + Language + "')";

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
            Response.Write("Movie Added To Database Successfully");



        }
    }
}