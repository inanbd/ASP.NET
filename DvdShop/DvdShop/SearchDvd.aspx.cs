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
    public partial class SearchDvd : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack) {
                LoadDataFromDatabase();
                LoadGridViewData();
            }
        }

        private void LoadDataFromDatabase()
        {
            string sql = "SELECT *  FROM Movies WHERE MovieTitle LIKE '%" + TextBoxSearch.Text + "%' OR Actors LIKE '%" + TextBoxSearch.Text + "%' OR Category LIKE '%" + TextBoxSearch.Text + "%'  ";
            string connStr = ConfigurationManager.ConnectionStrings["DvdShop"].ConnectionString;
            SqlConnection conn = new SqlConnection(connStr);

            SqlDataAdapter adapter = new SqlDataAdapter(sql, conn);
            SqlCommandBuilder builder = new SqlCommandBuilder(adapter);

            DataSet ds = new DataSet();
            adapter.Fill(ds, "Users");
            ds.Tables["Users"].PrimaryKey = new DataColumn[] { ds.Tables["Users"].Columns["Id"] };

            Cache["DATASET"] = ds;
            Cache["ADAPTER"] = adapter;
        }

        private void LoadGridViewData()
        {
            if (Cache["DATASET"] == null)
            {
                this.LoadDataFromDatabase();
            }

            GridView1.DataSource = ((DataSet)Cache["DATASET"]).Tables["Users"];
            GridView1.DataBind();
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            LoadDataFromDatabase();
            LoadGridViewData();
        }
    }
}