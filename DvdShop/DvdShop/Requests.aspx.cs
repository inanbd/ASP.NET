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
    public partial class Requests : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            this.LoadDataFromDatabase();
            this.LoadGridViewData();
        }


        private void LoadDataFromDatabase()
        {
            string sql = "SELECT * From Requests";
            string connStr = ConfigurationManager.ConnectionStrings["DvdShop"].ConnectionString;
            SqlConnection conn = new SqlConnection(connStr);

            SqlDataAdapter adapter = new SqlDataAdapter(sql, conn);
            SqlCommandBuilder builder = new SqlCommandBuilder(adapter);

            DataSet ds = new DataSet();
            adapter.Fill(ds, "Requests");
            ds.Tables["Requests"].PrimaryKey = new DataColumn[] { ds.Tables["Requests"].Columns["Id"] };

            Cache["DATASET"] = ds;
            Cache["ADAPTER"] = adapter;
        }

        private void LoadGridViewData()
        {
            if (Cache["DATASET"] == null)
            {
                this.LoadDataFromDatabase();
            }

            GridView1.DataSource = ((DataSet)Cache["DATASET"]).Tables["Requests"];
            GridView1.DataBind();
        }


    }
}