using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AIU_ATM
{
    public partial class ViewCustomerDetails : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void ButtonEdit_Click(object sender, EventArgs e)
        {
            Response.Redirect("EditCustomerDeatials.aspx");
        }
    }
}