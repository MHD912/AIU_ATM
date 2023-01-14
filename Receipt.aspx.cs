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
    public partial class Receipt : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection(@"Data Source=LOCALHOST;Initial Catalog=ATM-Bank;Integrated Security=True");
        protected void Page_Load(object sender, EventArgs e)
        {
            if (con.State == ConnectionState.Open)
            {
                con.Close();
            }
            con.Open();

            if (Session["Transaction"] != null)
            {
                if (Session["transUser"] != null)
                {
                    int transType=int.Parse( Session["Transaction"].ToString());
                    string aNo = Session["transUser"].ToString();

                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    DataTable dt = new DataTable();
                    SqlDataAdapter da = new SqlDataAdapter(cmd);


                    cmd.CommandText = "select max(ID) as ID from Transactions where Type = @TT and FromAcc = @aNo";
                    if(transType == 1) { cmd.CommandText = "select max(ID) as ID from Transactions where Type = @TT and ToAcc = @aNo"; }
                    cmd.Parameters.AddWithValue("@TT", transType);
                    cmd.Parameters.AddWithValue("@aNo", aNo);
                    da.Fill(dt);
                    cmd.Parameters.Clear();

                    string tID = dt.Rows[0][0].ToString();
                    dt.Clear();

                    cmd.CommandText = "select * from Transactions where ID=@tID";
                    cmd.Parameters.AddWithValue("@tID", tID);
                    da.Fill(dt);

                    LabelDate.Text = dt.Rows[0]["Time"].ToString();
                    LabelTransactionID.Text = tID;
                    LabelTransactionValue.Text = dt.Rows[0]["Amount"].ToString();

                    if (transType == 1)
                    {
                        LabelCustomerAccountID.Text = dt.Rows[0]["ToAcc"].ToString();
                        LabelAccountType.Text = "Deposit";
                        RadioButtonDeposit.Checked = true;
                    }
                    else if(transType == 2)
                    {
                        LabelCustomerAccountID.Text = dt.Rows[0]["FromAcc"].ToString();
                        LabelAccountType.Text = "Withdraw";
                        RadioButtonWithdraw.Checked = true;
                    }
                    else if (transType == 3)
                    {
                        LabelCustomerAccountID.Text = "";
                        LabelAccountType.Text = "Transfer";
                        RadioButtonTransfer.Checked = true;

                        LabelSenderAccountID.Text = dt.Rows[0]["FromAcc"].ToString();
                        LabelReceipientAccountID.Text = dt.Rows[0]["ToAcc"].ToString();
                        
                    }
                    dt.Clear();

                    cmd.CommandText = "select * from Accounts where AccountNo=@aNo";
                    cmd.Parameters.AddWithValue("@aNo", aNo);
                    da.Fill(dt);
                    string cusID = dt.Rows[0]["userID"].ToString();
                    dt.Clear();

                    cmd.CommandText = "select * from UsersInfo where ID=@uID";
                    cmd.Parameters.AddWithValue("@uID", cusID);
                    da.Fill(dt);

                    LabelCustomerName.Text = dt.Rows[0]["FirstName"].ToString() + " " + dt.Rows[0]["LastName"].ToString();
                    LabelEmail.Text = dt.Rows[0]["Email"].ToString();
                }
                else { Response.Redirect("Default.aspx"); }
            }
            else { Response.Redirect("Default.aspx"); }
        }
    }
}