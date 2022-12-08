using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AIU_ATM
{
    public partial class AdminDashboard : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void ButtonViewCustomers_Click(object sender, EventArgs e)
        {
            Response.Redirect("ViewCustomers.aspx");
        }

        protected void ButtonCreateCustomer_Click(object sender, EventArgs e)
        {
            Response.Redirect("CreateCustomer.aspx");
        }

        protected void ButtonViewTransactions_Click(object sender, EventArgs e)
        {
            Response.Redirect("ViewTransactions.aspx");
        }
    }
}