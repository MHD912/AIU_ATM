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
    public partial class ViewUserDetails : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection(@"Data Source=LOCALHOST;Initial Catalog=ATM-Bank;Integrated Security=True");
        string userID;
        string[] accountTypeCurrent = {"","",""};
        string[] accountTypeSaving = {"","",""};
        string[] accountTypeSalary = {"","",""};
        int sel = -1;
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
            if (Session["ViewUser"] != null)
            {
                userID = Session["ViewUser"].ToString();

                if (Session["view"].ToString() == "2")
                {
                    cmd.CommandText = "select ui.FirstName as FN, ui.MiddleName as MN, ui.LastName as LN, u.UserName as UN, u.PassWord as PW, ui.Email as EM, ui.BirthDate as BD,ui.Gender as G,ui.Phone as P,ui.Address as Addr,a.AccountType as Type,a.Balance as Bal,a.PIN as PIN from Users as u join usersInfo as ui on (u.id = ui.id) join Accounts as a on (a.userID = ui.id) where u.id= @uID";
                    cmd.Parameters.AddWithValue("@uID", userID);

                    da.Fill(dt);

                    TextBoxFirstName.Text = dt.Rows[0]["FN"].ToString();
                    TextBoxMidName.Text = dt.Rows[0]["MN"].ToString();
                    TextBoxLastName.Text = dt.Rows[0]["LN"].ToString();
                    TextBoxUserName.Text = dt.Rows[0]["UN"].ToString();
                    TextBoxPassword.Text = dt.Rows[0]["PW"].ToString();
                    TextBoxEmail.Text = dt.Rows[0]["EM"].ToString();
                    TextBoxBirthDate.Text = dt.Rows[0]["BD"].ToString();
                    TextBoxGender.Text = dt.Rows[0]["G"].ToString();
                    TextBoxContact.Text = dt.Rows[0]["P"].ToString();
                    TextBoxAddress.Text = dt.Rows[0]["Addr"].ToString();

                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        if (dt.Rows[i]["Type"].ToString().Equals("1"))
                        {
                            accountTypeCurrent[0] = "1";
                            accountTypeCurrent[1] = dt.Rows[i]["Bal"].ToString();
                            accountTypeCurrent[2] = dt.Rows[i]["PIN"].ToString();
                        }
                        else if (dt.Rows[i]["Type"].ToString().Equals("2"))
                        {
                            accountTypeSaving[0] = "2";
                            accountTypeSaving[1] = dt.Rows[i]["Bal"].ToString();
                            accountTypeSaving[2] = dt.Rows[i]["PIN"].ToString();
                        }
                        else if (dt.Rows[i]["Type"].ToString().Equals("3"))
                        {
                            accountTypeSalary[0] = "3";
                            accountTypeSalary[1] = dt.Rows[i]["Bal"].ToString();
                            accountTypeSalary[2] = dt.Rows[i]["PIN"].ToString();
                        }
                    }
                    if (!IsPostBack)
                    {
                        if (accountTypeCurrent[0] != "")
                        {
                            DropDownListAccountType.SelectedIndex = 0;
                            TextBoxBalance.Text = accountTypeCurrent[1];
                            TextBoxPin.Text = accountTypeCurrent[2];
                        }
                        else if (accountTypeSaving[0] != "")
                        {
                            DropDownListAccountType.SelectedIndex = 1;
                            TextBoxBalance.Text = accountTypeSaving[1];
                            TextBoxPin.Text = accountTypeSaving[2];
                        }
                        else if (accountTypeSalary[0] != "")
                        {
                            DropDownListAccountType.SelectedIndex = 2;
                            TextBoxBalance.Text = accountTypeSalary[1];
                            TextBoxPin.Text = accountTypeSalary[2];
                        }
                    }
                }
                else if (Session["view"].ToString() == "1")
                {
                    cmd.CommandText = "select ui.FirstName as FN, ui.MiddleName as MN, ui.LastName as LN, u.UserName as UN, u.PassWord as PW, ui.Email as EM, ui.BirthDate as BD,ui.Gender as G,ui.Phone as P,ui.Address as Addr from Users as u join usersInfo as ui on (u.id = ui.id) where u.id= @uID";
                    cmd.Parameters.AddWithValue("@uID", userID);

                    da.Fill(dt);

                    TextBoxFirstName.Text = dt.Rows[0]["FN"].ToString();
                    TextBoxMidName.Text = dt.Rows[0]["MN"].ToString();
                    TextBoxLastName.Text = dt.Rows[0]["LN"].ToString();
                    TextBoxUserName.Text = dt.Rows[0]["UN"].ToString();
                    TextBoxPassword.Text = dt.Rows[0]["PW"].ToString();
                    TextBoxEmail.Text = dt.Rows[0]["EM"].ToString();
                    TextBoxBirthDate.Text = dt.Rows[0]["BD"].ToString();
                    TextBoxGender.Text = dt.Rows[0]["G"].ToString();
                    TextBoxContact.Text = dt.Rows[0]["P"].ToString();
                    TextBoxAddress.Text = dt.Rows[0]["Addr"].ToString();

                    
                }   

            }
            else { Response.Redirect("ViewUsers.aspx"); }
        }

        protected void ButtonEdit_Click(object sender, EventArgs e)
        {
            Session["EditUser"] = userID;
            Response.Redirect("EditUserDetails.aspx");
        }

        protected void LinkButtonBack_Click(object sender, EventArgs e)
        {
            Session["ViewUser"] = null;
            Response.Redirect("ViewUsers.aspx");
        }

        protected void DropDownListAccountType_SelectedIndexChanged(object sender, EventArgs e)
        {
            sel = DropDownListAccountType.SelectedIndex;
            if (sel == 0)
            {
                TextBoxBalance.Text = accountTypeCurrent[1];
                TextBoxPin.Text = accountTypeCurrent[2];
            }
            else if(sel == 1)
            {
                TextBoxBalance.Text = accountTypeSaving[1];
                TextBoxPin.Text = accountTypeSaving[2];
            }
            else if (sel == 2)
            {
                TextBoxBalance.Text = accountTypeSalary[1];
                TextBoxPin.Text = accountTypeSalary[2];
            }
        }

    }
}