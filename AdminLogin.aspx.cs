using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Test
{
    public partial class AdminLogin : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection(@"Data Source=LAPTOP-ORMHDR25;Initial Catalog=ATM-Bank;Integrated Security=True");
        protected void Page_Load(object sender, EventArgs e)
        {

            if (con.State == ConnectionState.Open)
            {
                con.Close();
            }
            con.Open();
        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {

            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;

            cmd.CommandText = "select * from Users where UserName='"+username.Text+"' and PassWord='"+password.Text+"'";
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            string userID = dt.Rows[0]["id"].ToString();
            string privilege = dt.Rows[0]["privilege"].ToString();

            Session["User"] = userID;

            if(privilege == "1")
            {
                Response.Redirect("AdminDashboard.aspx");
            }else if (privilege == "2")
            {
                Response.Redirect("customerDashboard");
            }
        }
    }
}