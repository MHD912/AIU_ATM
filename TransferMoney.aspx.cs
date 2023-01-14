using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AIU_ATM
{
    public partial class TransferMoney : System.Web.UI.Page
    {
        string userID;
        SqlConnection con = new SqlConnection(@"Data Source=LOCALHOST;Initial Catalog=ATM-Bank;Integrated Security=True");
        string PIN = "0";

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

                cmd.CommandText = "select * from Users as u join Accounts as a on u.ID = a.UserID where u.id=@uID and a.AccountType=@AT";
                cmd.Parameters.AddWithValue("@uID", userID);
                cmd.Parameters.AddWithValue("@AT", 1 + int.Parse(Session["ST"].ToString()));

                da.Fill(dt);
                string userName = dt.Rows[0]["username"].ToString();
                string balance = dt.Rows[0]["Balance"].ToString();
                PIN = dt.Rows[0]["PIN"].ToString();

                welS.Text = "Hi there " + userName;
                cusBal.Text = balance + " SP";
                LinkButtonPrint.Visible = false;
            }
            else { Response.Redirect("Login.aspx"); }
        }

        protected void ButtonTransfer_Click(object sender, EventArgs e)
        {
            if (PIN == TextBoxPinCode.Text)
            {

            }
            else { TextBoxPinCode.Text = ""; }
            if (TextBoxTransferValue.Text != "")
            {
                double amount = double.Parse(TextBoxTransferValue.Text);
                if (amount > 0)
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    DataTable dt = new DataTable();
                    SqlDataAdapter da = new SqlDataAdapter(cmd);

                    cmd.CommandText = "select * from Accounts where AccountNo=@aNo2";
                    cmd.Parameters.AddWithValue("@aNo2", TextBoxRecipient.Text);
                    da.Fill(dt);
                    int ex = dt.Rows.Count;
                    dt.Rows.Clear();

                    double balance = 0;

                    cmd.CommandText = "select * from Users as u join Accounts as a on u.ID = a.UserID where u.id=@uID and a.AccountType=@AT";
                    cmd.Parameters.AddWithValue("@uID", userID);
                    cmd.Parameters.AddWithValue("@AT", 1 + int.Parse(Session["ST"].ToString()));

                    da.Fill(dt);

                    if(ex <= 0) { TextBoxRecipient.Text = ""; }
                    if (dt.Rows.Count > 0 && TextBoxRecipient.Text != "")
                    {
                        balance = double.Parse(dt.Rows[0]["Balance"].ToString());
                        if (amount < balance)
                        {
                            cmd.CommandText = "EXEC transferM @aNo, @aNo2, @Amount";
                            cmd.Parameters.AddWithValue("@aNo", dt.Rows[0]["AccountNo"]);
                            cmd.Parameters.AddWithValue("@Amount", TextBoxTransferValue.Text);

                            cmd.ExecuteNonQuery();

                            Session["Transaction"] = 3;
                            Session["transUser"] = dt.Rows[0]["AccountNo"].ToString();
                            LinkButtonPrint.Visible = true;
                            TextBoxTransferValue.Text = "";
                            cusBal.Text = (balance - amount) + "$";
                        }
                    }
                    else { TextBoxTransferValue.Text = ""; }
                }
            }
        }
        protected void LinkButtonBack_Click(object sender, EventArgs e)
        {
            Session["User"] = userID;
            Response.Redirect("CustomerDashboard.aspx");
        }

        protected void LinkButtonLogout_Click(object sender, EventArgs e)
        {
            Session["User"] = null;
            Session["ST"] = null;
            Response.Redirect("Login.aspx");
        }

        protected void LinkButtonPrint_Click(object sender, EventArgs e)
        {
            Page.ClientScript.RegisterStartupScript(this.GetType(), "OpenWindow", "window.open('Receipt.aspx','_blank');", true);
        }
    }
}