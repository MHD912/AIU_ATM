using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Test
{
    public partial class withdrawMoney : System.Web.UI.Page
    {
        string userID;
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

            userID = Session["User"].ToString();
            //userID = "35";

            cmd.CommandText = "select * from Users as u join Accounts as a on u.ID = a.UserID where u.id='" + userID + "'";
            da.Fill(dt);
            string userName = dt.Rows[0]["username"].ToString();
            string balance = dt.Rows[0]["Balance"].ToString();

            welS.Text = "Hi there " + userName;
            cusBal.Text = balance + "$";
        }

        protected void withdraw_Click(object sender, EventArgs e)
        {
            if(Text1.Text != "")
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
                cmd.CommandText = "select * from Users as u join Accounts as a on u.ID = a.UserID where u.id='" + userID + "'";
                da.Fill(dt);
                double balance = double.Parse( dt.Rows[0]["Balance"].ToString() );
                if(double.Parse(Text1.Text) < balance)
                {
                    cmd.CommandText = "EXEC withdraw '" + dt.Rows[0]["AccountNo"] + "','" + Text1.Text + "'";
                    cmd.ExecuteNonQuery();
                    Text1.Text = "";
                    Page_Load(sender, e);
                }
            }
        }
    }
}