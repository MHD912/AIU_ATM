using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AIU_ATM
{
    public partial class AdminLogin : System.Web.UI.Page
    {

        SqlConnection con = new SqlConnection(@"Data Source=LOCALHOST;Initial Catalog=ATM-Bank;Integrated Security=True");

        protected void Page_Load(object sender, EventArgs e)
        {
            if (con.State == ConnectionState.Open)
            {
                con.Close();
            }
            con.Open();

            if (Session["Admin"] != null)
            {
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandType = CommandType.Text;
                DataTable dt = new DataTable();
                SqlDataAdapter da = new SqlDataAdapter(cmd);

                cmd.CommandText = "select * from users where ID=@ID";
                cmd.Parameters.AddWithValue("@ID", Session["Admin"].ToString());
                da.Fill(dt);
                Response.Redirect("AdminDashboard.aspx");
            }
            else if (Session["Customer"] != null)
            {
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandType = CommandType.Text;
                DataTable dt = new DataTable();
                SqlDataAdapter da = new SqlDataAdapter(cmd);

                cmd.CommandText = "select * from users where ID=@ID";
                cmd.Parameters.AddWithValue("@ID", Session["Customer"].ToString());
                da.Fill(dt);
                Response.Redirect("CustomerDashboard.aspx");
            }

        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);

            cmd.CommandText = "select * from Users where UserName=@UN";
            cmd.Parameters.AddWithValue("@UN", username.Text);

            da.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                string userID = dt.Rows[0]["id"].ToString();
                string privilege = dt.Rows[0]["privilege"].ToString();
                string passWord = dt.Rows[0]["password"].ToString();
                if (passWord == password.Text)
                {
                    //Session["User"] = userID;
                    if (privilege == "1")
                    {
                        Session["Admin"] = userID;
                        Response.Redirect("AdminDashboard.aspx");
                    }
                    else if (privilege == "2")
                    {
                        Session["Customer"] = userID;
                        Response.Redirect("CustomerDashboard.aspx");
                    }
                }
                else { password.Text = ""; }
            }
            else { username.Text = ""; password.Text = ""; }
        }
    }
}