using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DvdShop
{
    public partial class User : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(Session["username"] == null)
            {
                //Response.Write("null");
                Response.Redirect("Index.aspx");
            }
            if (Session["type"].Equals("1")) {
                //
                Response.Redirect("Index.aspx");
            }

        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            Response.Redirect("RequestForADvd.aspx");
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Response.Redirect("ViwAllDvdCust.aspx");
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            Response.Redirect("SearchDvd.aspx");
        }

        protected void Button4_Click(object sender, EventArgs e)
        {
            Response.Redirect("Logout.aspx");
        }
    }
}