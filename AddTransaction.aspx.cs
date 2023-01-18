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
    public partial class AddTransaction : System.Web.UI.Page
    {
        string userID;
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
                userID = Session["Admin"].ToString();
                LinkButtonPrint.Visible = false;
                LinkButtonPrint.Enabled = false;
                if (Session["Transaction"] != null && Session["transUser"] != null)
                {
                    LinkButtonPrint.Visible = true;
                    LinkButtonPrint.Enabled = true;
                    DropDownListTransactionType.SelectedIndex = int.Parse(Session["Transaction"].ToString()) - 1;
                }
            }
            else
            {
                Response.Redirect("Login.aspx");
            }
        }

        protected bool notEmpty(int selectedIndex)
        {
            bool res = true;
            if (TextBoxAmount.Text == "")
            {
                TextBoxAmount.CssClass = "form-control is-invalid";
                LabelAmountFeedback.Text = "Required";
                res = false;
            }
            else
            {
                TextBoxAmount.CssClass = "form-control";
                bool isNumber = true;
                try
                {
                    double amount = double.Parse(TextBoxAmount.Text);
                    if (amount < 0)
                    {
                        LabelAmountFeedback.Text = "Amount can't be negative";
                        TextBoxAmount.CssClass = "form-control is-invalid";
                        res = false;
                    }
                    else if (amount < 500)
                    {
                        LabelAmountFeedback.Text = "Amount must be at least 500 SP";
                        TextBoxAmount.CssClass = "form-control is-invalid";
                        res = false;
                    }
                }
                catch
                {
                    isNumber = false;
                    LabelAmountFeedback.Text = "Amount can't contain letters";
                    TextBoxAmount.CssClass = "form-control is-invalid";
                }
                res = res && isNumber;
            }
            if (selectedIndex == 2)
            {
                if (TextBoxSenderNo.Text == "")
                {
                    TextBoxSenderNo.CssClass = "form-control is-invalid";
                    LabelSenderNoFeedback.Text = "Required";
                    res = false;
                }
                else
                {
                    TextBoxSenderNo.CssClass = "form-control";
                    bool isNumber = true;
                    TextBoxSenderNo.Text = TextBoxSenderNo.Text.ToString().Trim();
                    try
                    {
                        double number = double.Parse(TextBoxSenderNo.Text);
                        if (number < 0)
                        {
                            LabelSenderNoFeedback.Text = "Account number can't be negative";
                            TextBoxSenderNo.CssClass = "form-control is-invalid";
                            res = false;
                        }
                    }
                    catch 
                    {
                        isNumber = false;
                        LabelSenderNoFeedback.Text = "Sender account number can't contain letters";
                        TextBoxSenderNo.CssClass = "form-control is-invalid";
                    }
                    res = res && isNumber;
                }
                if (TextBoxRecipientNo.Text == "")
                {
                    TextBoxRecipientNo.CssClass = "form-control is-invalid";
                    LabelRecipientNoFeedback.Text = "Required";
                    res = false;
                }
                else
                {
                    TextBoxRecipientNo.CssClass = "form-control";
                    bool isNumber = true;
                    TextBoxRecipientNo.Text = TextBoxRecipientNo.Text.ToString().Trim();
                    try
                    {
                        double number = double.Parse(TextBoxRecipientNo.Text);
                        if (number < 0)
                        {
                            LabelRecipientNoFeedback.Text = "Account number can't be negative";
                            TextBoxRecipientNo.CssClass = "form-control is-invalid";
                            res = false;
                        }
                    }
                    catch 
                    {
                        isNumber = false;
                        LabelRecipientNoFeedback.Text = "Recipient account number can't contain letters";
                        TextBoxRecipientNo.CssClass = "form-control is-invalid";
                    }
                    res = res && isNumber;
                }
            }
            else
            {
                if (TextBoxAccountNo.Text == "")
                {
                    TextBoxAccountNo.CssClass = "form-control is-invalid";
                    LabelAccountNoFeedback.Text = "Required";
                    res = false;
                }
                else
                {
                    TextBoxAccountNo.CssClass = "form-control";
                    bool isNumber = true;
                    TextBoxAccountNo.Text = TextBoxAccountNo.Text.ToString().Trim();
                    try
                    {
                        double number = double.Parse(TextBoxAccountNo.Text);
                        if (number < 0)
                        {
                            LabelAccountNoFeedback.Text = "Account number can't be negative";
                            TextBoxAccountNo.CssClass = "form-control is-invalid";
                            res = false;
                        }
                    }
                    catch 
                    {
                        isNumber = false;
                        LabelAccountNoFeedback.Text = "Account number can't contain letters";
                        TextBoxAccountNo.CssClass = "form-control is-invalid";
                    }
                    res = res && isNumber;
                }
            }
            return res;
        }

        protected void LinkButtonBack_Click(object sender, EventArgs e)
        {
            Session["Transaction"] = null;
            Session["transUser"] = null;
            Response.Redirect("ViewTransactions.aspx");
        }

        protected void LinkButtonLogout_Click(object sender, EventArgs e)
        {
            Session["Admin"] = null;
            Session["EditUser"] = null;
            Session["ViewUser"] = null;
            Session["AccountTransactions"] = null;
            Response.Redirect("Login.aspx");
        }

        protected void ButtonSubmit_Click(object sender, EventArgs e)
        {
            int selTT = DropDownListTransactionType.SelectedIndex;
            if (!notEmpty(selTT)) { return; }

            double amount = double.Parse(TextBoxAmount.Text);
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);

            if (selTT == 2)
            {

                cmd.CommandText = "select * from Accounts where AccountNo=@aNo2";
                cmd.Parameters.AddWithValue("@aNo2", TextBoxRecipientNo.Text);
                da.Fill(dt);
                int ex = dt.Rows.Count;
                dt.Clear();

                double balance;
                cmd.CommandText = "select * from Accounts where AccountNo=@AN";
                cmd.Parameters.AddWithValue("@AN", TextBoxSenderNo.Text);

                da.Fill(dt);

                if (ex <= 0)
                {
                    LabelRecipientNoFeedback.Text = "Recipient account doesn't exist";
                    TextBoxRecipientNo.CssClass = "form-control is-invalid";
                }
                else if (dt.Rows.Count > 0)
                {
                    balance = double.Parse(dt.Rows[0]["Balance"].ToString());
                    if (amount < balance)
                    {
                        cmd.CommandText = "EXEC transferM @aNo, @aNo2, @Amount";
                        cmd.Parameters.AddWithValue("@aNo", TextBoxSenderNo.Text);
                        cmd.Parameters.AddWithValue("@Amount", TextBoxAmount.Text);

                        cmd.ExecuteNonQuery();
                        Session["Transaction"] = 3;
                        Session["transUser"] = dt.Rows[0]["AccountNo"].ToString();
                        Response.Redirect("AddTransaction.aspx");
                        TextBoxAmount.Text = "";
                        TextBoxSenderNo.Text = "";
                        TextBoxRecipientNo.Text = "";
                    }
                    else
                    {
                        TextBoxAmount.Text = "";
                        TextBoxAmount.CssClass = "form-control is-invalid";
                        LabelAmountFeedback.Text = "Your current balance is not enough";
                    }
                }
                else
                {
                    LabelSenderNoFeedback.Text = "Recipient account doesn't exist";
                    TextBoxSenderNo.CssClass = "form-control is-invalid";
                }
            }
            else
            {
                double balance;
                cmd.CommandText = "select * from Accounts where AccountNo=@AN";
                cmd.Parameters.AddWithValue("@AN", TextBoxAccountNo.Text);

                da.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    balance = double.Parse(dt.Rows[0]["Balance"].ToString());
                    if (selTT == 1)
                    {
                        if (amount < balance)
                        {
                            cmd.CommandText = "EXEC withdraw @aNo, @Amount";
                            cmd.Parameters.AddWithValue("@aNo", TextBoxAccountNo.Text);
                            cmd.Parameters.AddWithValue("@Amount", TextBoxAmount.Text);

                            cmd.ExecuteNonQuery();
                            Session["Transaction"] = 2;
                            Session["transUser"] = dt.Rows[0]["AccountNo"].ToString();
                            Response.Redirect("AddTransaction.aspx");
                            TextBoxAmount.Text = "";
                        }
                        else
                        {
                            LabelAmountFeedback.Text = "Your current balance is not enough";
                            TextBoxAmount.CssClass = "form-control is-invalid";
                        }
                    }
                    else if (selTT == 0)
                    {
                        cmd.CommandText = "EXEC deposit @aNo, @Amount";
                        cmd.Parameters.AddWithValue("@aNo", TextBoxAccountNo.Text);
                        cmd.Parameters.AddWithValue("@Amount", TextBoxAmount.Text);

                        cmd.ExecuteNonQuery();
                        Session["Transaction"] = 1;
                        Session["transUser"] = dt.Rows[0]["AccountNo"].ToString();
                        Response.Redirect("AddTransaction.aspx");
                    }

                    TextBoxAccountNo.Text = "";
                    TextBoxAmount.Text = "";
                }
                else
                {
                    LabelAccountNoFeedback.Text = "Account doesn't exist";
                    TextBoxAccountNo.CssClass = "form-control is-invalid";
                }
            }
        }

        protected void LinkButtonPrint_Click(object sender, EventArgs e)
        {
            if (Session["Transaction"] != null && Session["transUser"] != null)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "OpenWindow", "window.open('Receipt.aspx','_blank');", true);
                LinkButtonPrint.Visible = false;
                LinkButtonPrint.Enabled = false;
            }
        }
    }
}