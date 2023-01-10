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
            if (Session["User"] != null) { LinkButtonLogout.Enabled = true; LinkButtonLogin.Text = "Dashboard"; }
        }

        protected void LinkButtonLogin_Click(object sender, EventArgs e)
        {
            if (Session["User"] == null)
                Response.Redirect("Login.aspx");
            else
            {
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandType = CommandType.Text;
                DataTable dt = new DataTable();
                SqlDataAdapter da = new SqlDataAdapter(cmd);

                cmd.CommandText = "select * from Users where UserName=@UN";
                cmd.Parameters.AddWithValue("@UN", Session["User"].ToString());

                da.Fill(dt);
                if(dt.Rows.Count > 0)
                {
                    string pre = dt.Rows[0]["Privilege"].ToString();
                    if (pre == "1") Response.Redirect("AdminDashboard.aspx");
                    else if (pre == "2") Response.Redirect("CustomerDashboard.aspx");
                    else Response.Redirect("Login.aspx");
                }
                else { Response.Redirect("Login.aspx"); }
            }
        }

        protected void LinkButtonLogout_Click(object sender, EventArgs e)
        {
            Session["User"] = null;
            Session["ST"] = null;
            Session["EditUser"] = null;
            Session["ViewUser"] = null;
            Response.Redirect("Default.aspx");
        }
    }
}