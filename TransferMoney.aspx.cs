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

            if (Session["Customer"] != null)
            {
                userID = Session["Customer"].ToString();

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
                LinkButtonPrint.Enabled = false;
            }
            else { Response.Redirect("Login.aspx"); }
        }

        protected bool notEmpty()
        {
            bool res = true;
            if (TextBoxTransferValue.Text == "")
            {
                TextBoxTransferValue.CssClass = "form-control is-invalid";
                LabelTransferValueFeedback.Text = "Required";
                res = false;
            }
            else
            {
                TextBoxTransferValue.Text = TextBoxTransferValue.Text.Trim();
                TextBoxTransferValue.CssClass = "form-control";
                bool isNumber = true;
                try
                {
                    double amount = double.Parse(TextBoxTransferValue.Text);
                    if (amount < 0)
                    {
                        LabelTransferValueFeedback.Text = "Amount can't be negative";
                        TextBoxTransferValue.CssClass = "form-control is-invalid";
                        res = false;
                    }
                    else if (amount < 500)
                    {
                        LabelTransferValueFeedback.Text = "Amount must be at least 500 SP";
                        TextBoxTransferValue.CssClass = "form-control is-invalid";
                        res = false;
                    }
                }
                catch
                {
                    isNumber = false;
                    LabelTransferValueFeedback.Text = "Amount can't contain letters";
                    TextBoxTransferValue.CssClass = "form-control is-invalid";
                }
                res = res && isNumber;
            }

            if (TextBoxRecipient.Text == "")
            {
                TextBoxRecipient.CssClass = "form-control is-invalid";
                LabelRecipientFeedback.Text = "Required";
                res = false;
            }
            else
            {
                TextBoxRecipient.CssClass = "form-control";
                bool isNumber = true;
                TextBoxRecipient.Text = TextBoxRecipient.Text.Trim();
                try
                {
                    double number = double.Parse(TextBoxRecipient.Text);
                    if (number < 0)
                    {
                        LabelRecipientFeedback.Text = "Account number can't be negative";
                        TextBoxRecipient.CssClass = "form-control is-invalid";
                        res = false;
                    }
                }
                catch
                {
                    isNumber = false;
                    LabelRecipientFeedback.Text = "Recipient account number can't contain letters";
                    TextBoxRecipient.CssClass = "form-control is-invalid";
                }
                res = res && isNumber;
            }

            if (TextBoxPinCode.Text != "")
            {
                bool isNumber = true;
                TextBoxPinCode.CssClass = "form-control";
                TextBoxPinCode.Text = TextBoxPinCode.Text.Trim();
                try
                {
                    int number = int.Parse(TextBoxPinCode.Text);
                    if (number < 0)
                    {
                        LabelPinCodeFeedback.Text = "PIN code can't be negative";
                        TextBoxPinCode.CssClass = "form-control is-invalid";
                        res = false;
                    }
                }
                catch
                {
                    isNumber = false;
                    LabelPinCodeFeedback.Text = "PIN code can't contain letters";
                    TextBoxPinCode.CssClass = "form-control is-invalid";
                }
                res = res && isNumber;
            }
            else
            {
                LabelPinCodeFeedback.Text = "Required";
                TextBoxPinCode.CssClass = "form-control is-invalid";
                res = false;
            }
            return res;
        }

        protected void ButtonTransfer_Click(object sender, EventArgs e)
        {

            if (!notEmpty()) { return; }
            if (PIN != TextBoxPinCode.Text)
            {
                TextBoxPinCode.Text = "";
                TextBoxPinCode.CssClass = "form-control is-invalid";
                LabelPinCodeFeedback.Text = "PIN code is incorrect";
            }
            else
            {
                double amount = double.Parse(TextBoxTransferValue.Text);

                SqlCommand cmd = con.CreateCommand();
                cmd.CommandType = CommandType.Text;
                DataTable dt = new DataTable();
                SqlDataAdapter da = new SqlDataAdapter(cmd);

                cmd.CommandText = "select * from Accounts where AccountNo=@aNo2";
                cmd.Parameters.AddWithValue("@aNo2", TextBoxRecipient.Text);
                da.Fill(dt);
                int ex = dt.Rows.Count;
                dt.Rows.Clear();

                double balance;

                cmd.CommandText = "select * from Users as u join Accounts as a on u.ID = a.UserID where u.id=@uID and a.AccountType=@AT";
                cmd.Parameters.AddWithValue("@uID", userID);
                cmd.Parameters.AddWithValue("@AT", 1 + int.Parse(Session["ST"].ToString()));

                da.Fill(dt);

                if (ex <= 0)
                {
                    TextBoxRecipient.Text = "";
                    TextBoxRecipient.CssClass = "form-control is-invalid";
                    LabelRecipientFeedback.Text = "Recipient account not found";
                    return;
                }
                if (dt.Rows.Count > 0)
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
                        LinkButtonPrint.Enabled = true;

                        TextBoxTransferValue.Text = "";
                        TextBoxTransferValue.CssClass = "form-control";
                        TextBoxRecipient.Text = "";
                        TextBoxRecipient.CssClass = "form-control";
                        TextBoxPinCode.Text = "";
                        TextBoxPinCode.CssClass = "form-control";
                        cusBal.Text = (balance - amount) + "SP";
                    }
                    else
                    {
                        TextBoxTransferValue.CssClass = "form-control";
                        LabelTransferValueFeedback.Text = "Your balance is not sufficient";
                        TextBoxRecipient.CssClass = "form-control";
                        TextBoxPinCode.Text = "";
                        TextBoxPinCode.CssClass = "form-control";
                    }
                }
                else { Response.Redirect("Login.aspx"); }
            }
        }
        protected void LinkButtonBack_Click(object sender, EventArgs e)
        {
            Session["Customer"] = userID;
            Response.Redirect("CustomerDashboard.aspx");
        }

        protected void LinkButtonLogout_Click(object sender, EventArgs e)
        {
            Session["Customer"] = null;
            Session["ST"] = null;
            Session["AccountTransactions"] = null;
            Response.Redirect("Login.aspx");
        }

        protected void LinkButtonPrint_Click(object sender, EventArgs e)
        {
            Page.ClientScript.RegisterStartupScript(this.GetType(), "OpenWindow", "window.open('Receipt.aspx','_blank');", true);
        }
    }
}