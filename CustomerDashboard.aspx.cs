using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AIU_ATM
{
    public partial class CustomerDashboard : System.Web.UI.Page
    {
        string userID = null;
        SqlConnection con = new SqlConnection(@"Data Source=LOCALHOST;Initial Catalog=ATM-Bank;Integrated Security=True");
        string[] accountTypeCurrent = {"","",""};
        string[] accountTypeSaving = {"","",""};
        string[] accountTypeSalary = {"","",""};

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
                cmd.CommandText = "select * from Users as u join Accounts as a on u.ID = a.UserID where u.id=@uID";
                cmd.Parameters.AddWithValue("@uID", userID);

                da.Fill(dt);
                if(dt.Rows.Count == 0) { Response.Redirect("Login.aspx"); }
                string userName = dt.Rows[0]["username"].ToString();
                string balance = "0" ;

                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    if (dt.Rows[i]["AccountType"].ToString().Equals("1"))
                    {
                        li1.Enabled = true;
                        accountTypeCurrent[0] = "1";
                        accountTypeCurrent[1] = dt.Rows[i]["Balance"].ToString();
                        accountTypeCurrent[2] = dt.Rows[i]["PIN"].ToString();
                    }
                    else if (dt.Rows[i]["AccountType"].ToString().Equals("2"))
                    {
                        li2.Enabled = true;
                        accountTypeSaving[0] = "2";
                        accountTypeSaving[1] = dt.Rows[i]["Balance"].ToString();
                        accountTypeSaving[2] = dt.Rows[i]["PIN"].ToString();
                    }
                    else if (dt.Rows[i]["AccountType"].ToString().Equals("3"))
                    {
                        li3.Enabled = true;
                        accountTypeSalary[0] = "3";
                        accountTypeSalary[1] = dt.Rows[i]["Balance"].ToString();
                        accountTypeSalary[2] = dt.Rows[i]["PIN"].ToString();
                    }
                }
                if (!IsPostBack)
                {
                    if (accountTypeCurrent[0] != "")
                    {
                        DropDownListAccountType.SelectedIndex = 0;
                        balance = accountTypeCurrent[1];
                        Session["ST"] = 0;
                    }
                    else if (accountTypeSaving[0] != "")
                    {
                        DropDownListAccountType.SelectedIndex = 1;
                        balance = accountTypeSaving[1];
                        Session["ST"] = 1;
                    }
                    else if (accountTypeSalary[0] != "")
                    {
                        DropDownListAccountType.SelectedIndex = 2;
                        balance = accountTypeSalary[1];
                        Session["ST"] = 2;
                    }
                    cusBal.Text = balance + "$";
                }
                

                welS.Text = "Hi there " + userName;
                
            }
            else { Response.Redirect("Login.aspx"); }
        }

        protected void LinkButtonDeposit_Click(object sender, EventArgs e)
        {
            Session["User"] = userID;
            Response.Redirect("DepositMoney.aspx");
        }

        protected void LinkButtonWithdraw_Click(object sender, EventArgs e)
        {
            Session["User"] = userID;
            Response.Redirect("WithdrawMoney.aspx");
        }

        protected void LinkButtonTransfer_Click(object sender, EventArgs e)
        {
            Session["User"] = userID;
            Response.Redirect("TransferMoney.aspx");
        }

        protected void DropDownListAccountType_SelectedIndexChanged(object sender, EventArgs e)
        {
            string balance = "0";
            Session["ST"] = DropDownListAccountType.SelectedIndex;
            if (Session["ST"].ToString() == "0")
            {
                DropDownListAccountType.SelectedIndex = 0;
                balance = accountTypeCurrent[1];
                Session["ST"] = 0;
            }
            else if (Session["ST"].ToString() == "1")
            {
                DropDownListAccountType.SelectedIndex = 1;
                balance = accountTypeSaving[1];
                Session["ST"] = 1;
            }
            else if (Session["ST"].ToString() == "2")
            {
                DropDownListAccountType.SelectedIndex = 2;
                balance = accountTypeSalary[1];
                Session["ST"] = 2;
            }
            cusBal.Text = balance + "$";
        }
    }
}