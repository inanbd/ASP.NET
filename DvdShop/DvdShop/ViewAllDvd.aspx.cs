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
    public partial class ViewAllDvd : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            if (Session["username"] == null)
            {
                //Response.Write("null");
                Response.Redirect("Index.aspx");
            }
            if (Session["type"].Equals("2"))
            {
                //
                Response.Redirect("Index.aspx");
            }

            if (!IsPostBack)
            {
                this.LoadDataFromDatabase();
                this.LoadGridViewData();
            }
        }

        private void LoadDataFromDatabase()
        {
           // string sql = "SELECT * FROM Movies";
            string sql = "SELECT *  FROM Movies WHERE MovieTitle LIKE '%" + TextBoxSearch.Text + "%' OR Actors LIKE '%" + TextBoxSearch.Text + "%' OR Category LIKE '%" + TextBoxSearch.Text + "%'  ";

            string connStr = ConfigurationManager.ConnectionStrings["DvdShop"].ConnectionString;
            SqlConnection conn = new SqlConnection(connStr);

            SqlDataAdapter adapter = new SqlDataAdapter(sql, conn);
            SqlCommandBuilder builder = new SqlCommandBuilder(adapter);

            DataSet ds = new DataSet();
            adapter.Fill(ds, "Movies");
            ds.Tables["Movies"].PrimaryKey = new DataColumn[] { ds.Tables["Movies"].Columns["Id"] };

            Cache["DATASET"] = ds;
            Cache["ADAPTER"] = adapter;
        }

        private void LoadGridViewData()
        {
            if (Cache["DATASET"] == null)
            {
                this.LoadDataFromDatabase();
            }

            GridView1.DataSource = ((DataSet)Cache["DATASET"]).Tables["Movies"];
            GridView1.DataBind();
        }

        protected void GridView1_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            DataSet ds = (DataSet)Cache["DATASET"];
            DataRow dr = ds.Tables["Movies"].Rows.Find(e.Keys["Id"]);
            dr["MovieTitle"] = e.NewValues["MovieTitle"];
            dr["Description"] = e.NewValues["Description"];
            dr["Category"] = e.NewValues["Category"];
            dr["AudioQuality"] = e.NewValues["AudioQuality"];
            dr["VideoQuality"] = e.NewValues["VideoQuality"];
            dr["Language"] = e.NewValues["Language"];
            dr["Actors"] = e.NewValues["Actors"];

            Cache["DATASET"] = ds;

            GridView1.EditIndex = -1;
            this.LoadGridViewData();
        }

        protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            DataSet ds = (DataSet)Cache["DATASET"];
            DataRow dr = ds.Tables["Movies"].Rows.Find(e.Keys["Id"]);
            dr.Delete();

            Cache["DATASET"] = ds;

            GridView1.EditIndex = -1;
            this.LoadGridViewData();
        }
        protected void GridView1_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            GridView1.EditIndex = -1;
            this.LoadGridViewData();
        }
        protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
        {
            GridView1.EditIndex = e.NewEditIndex;
            this.LoadGridViewData();
        }
        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType != DataControlRowType.Header)
            {
                if (e.Row.Cells[0].Text == "P102")
                {
                    e.Row.BackColor = System.Drawing.Color.Red;
                }
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            DataSet ds = (DataSet)Cache["DATASET"];
            if (ds.HasChanges())
            {
                ds.RejectChanges();
            }
            Cache["DATASET"] = ds;
            this.LoadGridViewData();
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            this.LoadDataFromDatabase();
            this.LoadGridViewData();
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            DataSet ds = (DataSet)Cache["DATASET"];
            SqlDataAdapter adapter = (SqlDataAdapter)Cache["ADAPTER"];
            adapter.Update(ds.Tables["Movies"]);
            //Response.Write("Database Updated");
        }

        protected void Button4_Click(object sender, EventArgs e)
        {
            LoadDataFromDatabase();
            LoadGridViewData();
        }
    }
}