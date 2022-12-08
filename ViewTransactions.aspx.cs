using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Test
{
	public partial class ViewTransactions : System.Web.UI.Page
    {
        string userID;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["User"] != null)
            {
                userID = Session["User"].ToString();
            }
            else { Response.Redirect("AdminLogin.aspx"); }
        }

        protected void LinkButtonDashboard_Click(object sender, EventArgs e)
        {
            Session["User"] = userID;
            Response.Redirect("AdminDashboard.aspx");
        }

        protected void LinkButtonCreate_Click(object sender, EventArgs e)
        {
            Session["User"] = userID;
            Response.Redirect("CreateCustomer.aspx");
        }

        protected void customersGridView_DataBound(object sender, EventArgs e)
        {
            
        }
        
    }
}
