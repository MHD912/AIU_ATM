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
            }
            else { Response.Redirect("Login.aspx"); }
        }

        protected bool notEmpty()
        {
            bool res = true;
            if (TextBoxTransferValue.Text != "")
            {
                bool r = true;
                TextBoxTransferValue.Text = TextBoxTransferValue.Text.ToString().Trim();
                try
                {
                    float number = float.Parse(TextBoxTransferValue.Text);
                }
                catch 
                {
                    r = false;
                }
                TextBoxTransferValue.CssClass = "form-control";
                if (!r)
                {
                    LabelTransferValueFeedback.Text = "Value can contain numbers only";
                    TextBoxTransferValue.CssClass = "form-control is-invalid";
                }
                res = res && r;
            }
            else
            {
                res = false;
                LabelTransferValueFeedback.Text = "Required";
                TextBoxTransferValue.CssClass = "form-control is-invalid";
            }

            if (TextBoxRecipient.Text != "")
            {
                bool r = true;
                TextBoxRecipient.Text = TextBoxRecipient.Text.ToString().Trim();
                try
                {
                    float number = float.Parse(TextBoxRecipient.Text);
                }
                catch 
                {
                    r = false;
                }
                TextBoxRecipient.CssClass = "form-control";
                if (!r)
                {
                    LabelRecipientFeedback.Text = "Recipient ID can contain numbers only";
                    TextBoxRecipient.CssClass = "form-control is-invalid";
                }
                res = res && r;
            }
            else
            {
                res = false;
                LabelRecipientFeedback.Text = "Required";
                TextBoxRecipient.CssClass = "form-control is-invalid";
            }

            if (TextBoxPinCode.Text != "")
            {
                bool r = true;
                TextBoxPinCode.Text = TextBoxPinCode.Text.ToString().Trim();
                try
                {
                    float number = float.Parse(TextBoxPinCode.Text);
                }
                catch 
                {
                    r = false;
                }
                TextBoxPinCode.CssClass = "form-control";
                if (!r)
                {
                    LabelPinCodeFeedback.Text = "PIN code only contain numbers";
                    TextBoxPinCode.CssClass = "form-control is-invalid";
                }
                res = res && r;
            }
            else
            {
                res = false;
                LabelPinCodeFeedback.Text = "Required";
                TextBoxPinCode.CssClass = "form-control is-invalid";
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
                            TextBoxTransferValue.Text = "";
                            TextBoxTransferValue.CssClass = "form-control";
                            LabelTransferValueFeedback.Text = "Your balance is not sufficient";
                            TextBoxPinCode.Text = "";
                            TextBoxPinCode.CssClass = "form-control";
                        }
                    }
                    else { TextBoxTransferValue.Text = ""; }
                }
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