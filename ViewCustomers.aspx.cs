using System;
using System.Drawing;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AIU_ATM
{
    public partial class ViewCustomers : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void LinkButtonDashboard_Click(object sender, EventArgs e)
        {

            Response.Redirect("AdminDashboard.aspx");
        }

        protected void LinkButtonCreate_Click(object sender, EventArgs e)
        {

            Response.Redirect("CreateCustomer.aspx");
        }

    }
}