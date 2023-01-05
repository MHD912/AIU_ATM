using System;
using System.Drawing;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;

namespace AIU_ATM
{
    public partial class EditUserDetails : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection(@"Data Source=LOCALHOST;Initial Catalog=ATM-Bank;Integrated Security=True");
        string userID;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (con.State == ConnectionState.Open)
            {
                con.Close();
            }
            con.Open();

            if (Session["EditUser"] != null)
            {
                userID = Session["EditUser"].ToString();
            }
            else { Response.Redirect("Login.aspx"); }
        }

        protected void LinkButtonBack_Click(object sender, EventArgs e)
        {
            Response.Redirect("ViewUserDetails.aspx");
        }

        protected void ButtonDiscard_Click(object sender, EventArgs e)
        {
            Response.Redirect("ViewUserDetails.aspx");
        }
    }
}