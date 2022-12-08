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
    public partial class depositeMoney : System.Web.UI.Page
    {
        String userID;
        SqlConnection con = new SqlConnection(@"Data Source=LAPTOP-ORMHDR25;Initial Catalog=ATM-Bank;Integrated Security=True");
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
                cmd.CommandText = "select * from Users as u join Accounts as a on u.ID = a.UserID where u.id='" + userID + "'";
                da.Fill(dt);
                string userName = dt.Rows[0]["username"].ToString();
                string balance = dt.Rows[0]["Balance"].ToString();

                welS.Text = "Hi there " + userName;
                cusBal.Text = balance + "$";
            }
            else { Response.Redirect("AdminLogin.aspx"); }
        }

        protected void deposite_Click(object sender, EventArgs e)
        {
            if (Text1.Text != "")
            {
                double amount = double.Parse(Text1.Text);
                if (amount > 0)
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    DataTable dt = new DataTable();
                    SqlDataAdapter da = new SqlDataAdapter(cmd);

                    double Balance = 0;
                    cmd.CommandText = "select * from Users as u join Accounts as a on u.ID = a.UserID where u.id='" + userID + "'";
                    da.Fill(dt);

                    if (dt.Rows.Count > 0)
                    {
                        Balance = double.Parse(dt.Rows[0]["Balance"].ToString());
                        cmd.CommandText = "EXEC deposit '" + dt.Rows[0]["AccountNo"] + "','" + Text1.Text + "'";
                        cmd.ExecuteNonQuery();
                    }
                    Text1.Text = "";
                    cusBal.Text = (amount + Balance) + "$";
                }
            }
        }
    }
}