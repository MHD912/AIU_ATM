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
                if (Session["Transaction"] != null && Session["transUser"] != null)
                {
                    LinkButtonPrint.Visible = true;
                    DropDownListTransactionType.SelectedIndex = int.Parse(Session["Transaction"].ToString()) - 1;
                }
            }
            else
            {
                Response.Redirect("Login.aspx");
            }
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
            double amount = double.Parse(TextBoxAmount.Text);
            if (amount > 0)
            {
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandType = CommandType.Text;
                DataTable dt = new DataTable();
                SqlDataAdapter da = new SqlDataAdapter(cmd);

                if (selTT == 2)
                {
                    bool res = true;
                    if (TextBoxSenderNo.Text != "")
                    {
                        bool r = true;
                        TextBoxSenderNo.Text = TextBoxSenderNo.Text.ToString().Trim();
                        try
                        {
                            float number = float.Parse(TextBoxSenderNo.Text);
                        }
                        catch (Exception ex)
                        {
                            r = false;
                        }
                        TextBoxSenderNo.CssClass = "form-control";
                        if (!r)
                        {
                            LabelSenderNoFeedback.Text = "Accounts is only numbers";
                            TextBoxSenderNo.CssClass = "form-control is-invalid";
                        }
                        res = res && r;
                    }
                    else{
                        res = false;
                        LabelSenderNoFeedback.Text = "Required";
                        TextBoxSenderNo.CssClass = "form-control is-invalid";
                    }
                    if (TextBoxRecipientNo.Text != "")
                    {
                        bool r = true;
                        TextBoxRecipientNo.Text = TextBoxRecipientNo.Text.ToString().Trim();
                        try
                        {
                            float number = float.Parse(TextBoxRecipientNo.Text);
                        }
                        catch (Exception ex)
                        {
                            r = false;
                        }
                        TextBoxRecipientNo.CssClass = "form-control";
                        if (!r)
                        {
                            LabelRecipientNoFeedback.Text = "Accounts is only numbers";
                            TextBoxRecipientNo.CssClass = "form-control is-invalid";
                        }
                        res = res && r;
                    }
                    else
                    {
                        res = false;
                        LabelRecipientNoFeedback.Text = "Required";
                        TextBoxRecipientNo.CssClass = "form-control is-invalid";
                    }
                    if (TextBoxAmount.Text != "")
                    {
                        bool r = true;
                        TextBoxAmount.Text = TextBoxAmount.Text.ToString().Trim();
                        try
                        {
                            float number = float.Parse(TextBoxAmount.Text);
                        }
                        catch (Exception ex)
                        {
                            r = false;
                        }
                        TextBoxAmount.CssClass = "form-control";
                        if (!r)
                        {
                            LabelAmountFeedback.Text = "Amount can contain numbers only";
                            TextBoxAmount.CssClass = "form-control is-invalid";
                        }
                        res = res && r;
                    }
                    else
                    {
                        res = false;
                        LabelRecipientNoFeedback.Text = "Required";
                        TextBoxRecipientNo.CssClass = "form-control is-invalid";
                    }
                    if (res)
                    {
                        cmd.CommandText = "select * from Accounts where AccountNo=@aNo2";
                        cmd.Parameters.AddWithValue("@aNo2", TextBoxRecipientNo.Text);
                        da.Fill(dt);
                        int ex = dt.Rows.Count;
                        dt.Clear();

                        double balance = 0;
                        cmd.CommandText = "select * from Accounts where AccountNo=@AN";
                        cmd.Parameters.AddWithValue("@AN", TextBoxSenderNo.Text);

                        da.Fill(dt);

                        if (ex <= 0) 
                        {                            
                            LabelRecipientNoFeedback.Text = "Recipient AccountNo doesn't exist";
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
                        }
                        else
                        {
                            LabelSenderNoFeedback.Text = "Recipient AccountNo doesn't exist";
                            TextBoxSenderNo.CssClass = "form-control is-invalid";
                        }
                    }
                    
                }
                else if (selTT == 0 || selTT == 1)
                {
                    bool res = true;
                    if (TextBoxAccountNo.Text != "")
                    {
                        bool r = true;
                        TextBoxAccountNo.Text = TextBoxAccountNo.Text.ToString().Trim();
                        try
                        {
                            float number = float.Parse(TextBoxAccountNo.Text);
                        }
                        catch (Exception ex)
                        {
                            r = false;
                        }
                        TextBoxAccountNo.CssClass = "form-control";
                        if (!r)
                        {
                            LabelAccountNoFeedback.Text = "Accounts is only numbers";
                            TextBoxAccountNo.CssClass = "form-control is-invalid";
                        }
                        res = res && r;
                    }
                    else
                    {
                        res = false;
                        LabelRecipientNoFeedback.Text = "Required";
                        TextBoxRecipientNo.CssClass = "form-control is-invalid";
                    }
                    if (TextBoxAmount.Text != "")
                    {
                        bool r = true;
                        TextBoxAmount.Text = TextBoxAmount.Text.ToString().Trim();
                        try
                        {
                            float number = float.Parse(TextBoxAmount.Text);
                        }
                        catch (Exception ex)
                        {
                            r = false;
                        }
                        TextBoxAmount.CssClass = "form-control";
                        if (!r)
                        {
                            LabelAmountFeedback.Text = "Amount can contain numbers only";
                            TextBoxAmount.CssClass = "form-control is-invalid";
                        }
                        res = res && r;
                    }
                    else
                    {
                        res = false;
                        LabelAccountNoFeedback.Text = "Required";
                        TextBoxAmount.CssClass = "form-control is-invalid";
                    }

                    double balance = 0;
                    cmd.CommandText = "select * from Accounts where AccountNo=@AN";
                    cmd.Parameters.AddWithValue("@AN", TextBoxAccountNo.Text);

                    da.Fill(dt);
                    if (!res) { return; }
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
                            else {
                                LabelAmountFeedback.Text = "Amount is higher than balace";
                                TextBoxAmount.CssClass = "form-control is-invalid";
                            }
                        }
                        else if (selTT == 0)
                        {
                            if (double.Parse(TextBoxAmount.Text) > 0)
                            {
                                cmd.CommandText = "EXEC deposit @aNo, @Amount";
                                cmd.Parameters.AddWithValue("@aNo", TextBoxAccountNo.Text);
                                cmd.Parameters.AddWithValue("@Amount", TextBoxAmount.Text);

                                cmd.ExecuteNonQuery();
                                Session["Transaction"] = 1;
                                Session["transUser"] = dt.Rows[0]["AccountNo"].ToString();
                                Response.Redirect("AddTransaction.aspx");
                                TextBoxAmount.Text = "";
                            }
                            else
                            {
                                LabelAmountFeedback.Text = "Amount is negative";
                                TextBoxAmount.CssClass = "form-control is-invalid";
                            }
                        }
                        TextBoxAccountNo.Text = ""; TextBoxAmount.Text = "";
                    }
                    else {
                        LabelAccountNoFeedback.Text = "AccountNo doesn't exist";
                        TextBoxAmount.CssClass = "form-control is-invalid";
                    }
                }
            }
            else
            {
                LabelAmountFeedback.Text = "Amount is negative";
                TextBoxAmount.CssClass = "form-control is-invalid";
            }
        }

        protected void LinkButtonPrint_Click(object sender, EventArgs e)
        {
            if (Session["Transaction"] != null && Session["transUser"] != null)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "OpenWindow", "window.open('Receipt.aspx','_blank');", true);
            }
        }
    }
}