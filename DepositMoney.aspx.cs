using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AIU_ATM
{
    public partial class DepositMoney : System.Web.UI.Page
    {
        String userID;
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
            if (TextBoxDepositAmount.Text != "")
            {
                bool r = true;
                TextBoxDepositAmount.Text = TextBoxDepositAmount.Text.ToString().Trim();
                try
                {
                    float number = float.Parse(TextBoxDepositAmount.Text);
                }catch
                {
                    r = false;
                }
                TextBoxDepositAmount.CssClass = "form-control";
                if (!r)
                {
                    LabelDepositAmountFeedback.Text = "Amount can contain numbers only";
                    TextBoxDepositAmount.CssClass = "form-control is-invalid";
                }
                res = res && r;
            }
            else
            {
                res = false;
                LabelDepositAmountFeedback.Text = "Required";
                TextBoxDepositAmount.CssClass = "form-control is-invalid";
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

        protected void ButtonDeposite_Click(object sender, EventArgs e)
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
                double amount = double.Parse(TextBoxDepositAmount.Text);
                if (amount > 0)
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    DataTable dt = new DataTable();
                    SqlDataAdapter da = new SqlDataAdapter(cmd);

                    double Balance = 0;
                    cmd.CommandText = "select * from Users as u join Accounts as a on u.ID = a.UserID where u.id=@uID and a.AccountType=@AT";
                    cmd.Parameters.AddWithValue("@uID", userID);
                    cmd.Parameters.AddWithValue("@AT", 1 + int.Parse(Session["ST"].ToString()));

                    da.Fill(dt);

                    if (dt.Rows.Count > 0)
                    {
                        Balance = double.Parse(dt.Rows[0]["Balance"].ToString());
                        cmd.CommandText = "EXEC deposit @aNo, @Amount";
                        cmd.Parameters.AddWithValue("@aNo", dt.Rows[0]["AccountNo"]);
                        cmd.Parameters.AddWithValue("@Amount", TextBoxDepositAmount.Text);
                        cmd.ExecuteNonQuery();

                        Session["Transaction"] = 1;
                        Session["transUser"] = dt.Rows[0]["AccountNo"].ToString();
                        LinkButtonPrint.Visible = true;
                    }
                    TextBoxDepositAmount.Text = "";
                    TextBoxDepositAmount.CssClass = "form-control";
                    TextBoxPinCode.Text = "";
                    TextBoxPinCode.CssClass = "form-control";
                    cusBal.Text = (amount + Balance) + "SP";
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