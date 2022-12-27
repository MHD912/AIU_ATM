using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AIU_ATM
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
            else { Response.Redirect("Login.aspx"); }
        }

        protected void LinkButtonCreate_Click(object sender, EventArgs e)
        {
            Session["User"] = userID;
            Response.Redirect("CreateTransaction.aspx");
        }

        protected void LinkButtonDashboard_Click(object sender, EventArgs e)
        {
            Session["User"] = userID;
            Response.Redirect("AdminDashboard.aspx");
        }

    }
}