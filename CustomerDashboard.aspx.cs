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
    public partial class customerDashboard : System.Web.UI.Page
    {
        string userID = null;
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
        
        protected void withdraw_Click(object sender, EventArgs e)
        {
            Session["User"] = userID;            
            Response.Redirect("WithdrawMoney.aspx");
        }

        protected void deposit_Click(object sender, EventArgs e)
        {
            Session["User"] = userID;
            Response.Redirect("DepositMoney.aspx");
        }

        protected void transfer_Click(object sender, EventArgs e)
        {
            Session["User"] = userID;
            Response.Redirect("TransferMoney.aspx");
        }
    }
}