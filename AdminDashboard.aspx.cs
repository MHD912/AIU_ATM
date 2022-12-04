using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Microsoft.Ajax.Utilities;

namespace Test
{
    public partial class AdminDashboard : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection(@"Data Source=LAPTOP-ORMHDR25;Initial Catalog=ATM-Bank;Integrated Security=True");
        string userID = null;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (con.State == ConnectionState.Open)
            {
                con.Close();
            }
            con.Open();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);

            if (Session["User"] != null)
            {
                userID = Session["User"].ToString();
                cmd.CommandText = "select * from Users where id='" + userID + "'";
                da.Fill(dt);
                string userName = dt.Rows[0]["username"].ToString();

                welS.Text = "Hi there " + userName;
            }
            else { welS.Text = "Not Logged In"; }
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
            //Response.Redirect("ViewTransactions.aspx");
        }
    }
}