using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace AIU_ATM
{
    public partial class Default : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection(@"Data Source=LOCALHOST;Initial Catalog=ATM-Bank;Integrated Security=True");
        protected void Page_Load(object sender, EventArgs e)
        {
            LinkButtonLogout.Enabled = false;
            LinkButtonLogout.Visible = false;
            if (Session["Admin"] != null)
            {
                LinkButtonLogout.Visible = true;
                LinkButtonLogout.Enabled = true;
                LinkButtonLogin.Text = "Dashboard";
            }
            else if (Session["Customer"] != null)
            {
                LinkButtonLogout.Visible = true;
                LinkButtonLogout.Enabled = true;
                LinkButtonLogin.Text = "Dashboard";
            }
        }

        protected void LinkButtonLogin_Click(object sender, EventArgs e)
        {
            if (Session["Admin"] == null && Session["Customer"] == null)
                Response.Redirect("Login.aspx");
            else
            {
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandType = CommandType.Text;
                DataTable dt = new DataTable();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                if (Session["Admin"] != null)
                {
                    cmd.CommandText = "select * from Users where UserName=@UN";
                    cmd.Parameters.AddWithValue("@UN", Session["Admin"].ToString());

                    da.Fill(dt);
                    if (dt.Rows.Count > 0)
                        Response.Redirect("AdminDashboard.aspx");
                    else
                        Response.Redirect("Login.aspx");
                }
                else if (Session["Customer"] != null)
                {
                    cmd.CommandText = "select * from Users where UserName=@UN";
                    cmd.Parameters.AddWithValue("@UN", Session["Customer"].ToString());

                    da.Fill(dt);
                    if (dt.Rows.Count > 0)
                        Response.Redirect("CustomerDashboard.aspx");
                    else
                        Response.Redirect("Login.aspx");
                }
            }
        }

        protected void LinkButtonLogout_Click(object sender, EventArgs e)
        {
            Session["Admin"] = null;
            Session["Customer"] = null;
            Session["ST"] = null;
            Session["EditUser"] = null;
            Session["ViewUser"] = null;
            Session["AccountTransactions"] = null;
            Response.Redirect("Default.aspx");
        }
    }
}