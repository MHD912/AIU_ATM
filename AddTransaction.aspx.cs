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

            if (Session["User"] != null)
            {
                userID = Session["User"].ToString();
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
                    if (TextBoxSenderNo.Text != "" && TextBoxRecipientNo.Text != "")
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

                        if (ex <= 0) { TextBoxRecipientNo.Text = ""; }
                        else if (dt.Rows.Count > 0 && TextBoxRecipientNo.Text != "")
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
                    }
                    else { TextBoxRecipientNo.Text = TextBoxSenderNo.Text = ""; }
                }
                else if (selTT == 0 || selTT == 1)
                {
                    double balance = 0;
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
                        }
                        TextBoxAccountNo.Text = ""; TextBoxAmount.Text = "";
                    }
                    else { TextBoxAccountNo.Text = ""; }
                }
            }
            else { TextBoxAmount.Text = ""; }
        }

        protected void LinkButtonPrint_Click(object sender, EventArgs e)
        {
            if (Session["Transaction"] != null)
            {
                if (Session["transUser"] != null)
                {
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "OpenWindow", "window.open('Receipt.aspx','_blank');", true);
                }
            }
        }
    }
}