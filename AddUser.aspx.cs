using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Runtime.Remoting.Messaging;
using Microsoft.Ajax.Utilities;

namespace AIU_ATM
{
    public partial class AddUser : System.Web.UI.Page
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
            }
            else
            {
                Response.Redirect("Login.aspx");
            }
        }

        protected bool notEmpty()
        {
            return (!(
                TextBoxFirstName.Text == ""
                && TextBoxLastName.Text == ""
                && TextBoxMidName.Text == ""
                && TextBoxUserName.Text == ""
                && TextBoxPassword.Text == ""
                && TextBoxConfirmPassword.Text == ""
                && TextBoxEmail.Text == ""
                && TextBoxContact.Text == ""
                && TextBoxAddress.Text == ""
                && TextBoxPin.Text == ""
                && TextBoxConfirmPin.Text == ""
                && RadioButtonFemale.Checked == false
                && RadioButtonMale.Checked == false
                && TextBoxBirthDate.Text == ""
                && TextBoxBalance.Text == ""
                ));
        }

        protected void ButtonCreate_Click(object sender, EventArgs e)
        {
            if (notEmpty())
            {
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandType = CommandType.Text;
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                if (TextBoxPin.Text == TextBoxConfirmPin.Text)
                {
                    if (TextBoxPassword.Text == TextBoxConfirmPassword.Text)
                    {
                        cmd.CommandText = "Select * from users where username = '" + TextBoxUserName.Text + "'";
                        da.Fill(dt);
                        if (dt.Rows.Count == 0)
                        {
                            if (CheckBoxUserType.Checked == false)
                            {
                                if (!(TextBoxBalance.Text == "" && TextBoxPin.Text == "" && TextBoxConfirmPin.Text == ""))
                                {
                                    string g = "Male";
                                    if (RadioButtonFemale.Checked == true) { g = "FeMale"; }

                                    string p = DropDownListCountryCode.Text + "-" + TextBoxContact.Text;

                                    int Acctype = 1;
                                    if (DropDownListAccountType.SelectedIndex == 1) { Acctype = 2; }
                                    else if (DropDownListAccountType.SelectedIndex == 2) { Acctype = 3; }

                                    cmd.CommandText = "insert into Users(UserName,PassWord,Privilege) values(@UN,@PW,2)";
                                    cmd.Parameters.AddWithValue("@UN", TextBoxUserName.Text);
                                    cmd.Parameters.AddWithValue("@PW", TextBoxPassword.Text);
                                    cmd.ExecuteNonQuery();

                                    cmd.CommandText = "select max(ID) as id from Users";
                                    da.Fill(dt);
                                    string userID = dt.Rows[0]["id"].ToString();

                                    cmd.CommandText = "insert into UsersInfo(ID,FirstName,MiddleName,LastName,BirthDate,Email,Phone,Address,Gender) values(@uID ,@FN,@MN,@LN,@BD,@EM,@P,@Add,@G)";
                                    cmd.Parameters.AddWithValue("@uID",userID);
                                    cmd.Parameters.AddWithValue("@FN",TextBoxFirstName.Text);
                                    cmd.Parameters.AddWithValue("@MN", TextBoxMidName.Text);
                                    cmd.Parameters.AddWithValue("@LN", TextBoxLastName.Text);
                                    cmd.Parameters.AddWithValue("@BD", TextBoxBirthDate.Text);
                                    cmd.Parameters.AddWithValue("@EM", TextBoxEmail.Text);
                                    cmd.Parameters.AddWithValue("@P", p);
                                    cmd.Parameters.AddWithValue("@Add", TextBoxAddress.Text);
                                    cmd.Parameters.AddWithValue("@G",g);
                                    cmd.ExecuteNonQuery();
                                    cmd.Parameters.Clear();

                                    cmd.CommandText = "insert into Accounts(Balance,PIN,AccountType,UserID) values(@Balance,@PIN,@AT, @uID)";
                                    cmd.Parameters.AddWithValue("@Balance", TextBoxBalance.Text);
                                    cmd.Parameters.AddWithValue("@PIN", TextBoxPin.Text);
                                    cmd.Parameters.AddWithValue("@AT", Acctype);
                                    cmd.Parameters.AddWithValue("@uID",userID);
                                    cmd.ExecuteNonQuery();
                                    

                                    ButtonReset_Click(sender, e);
                                }

                            }
                            else
                            {
                                string g = "Male";
                                if (RadioButtonFemale.Checked == true) { g = "FeMale"; }
                                string p = DropDownListCountryCode.Text + "-" + TextBoxContact.Text;

                                cmd.CommandText = "insert into Users(UserName,PassWord,Privilege)" +
                                    " values('" + TextBoxUserName.Text + "','" + TextBoxPassword.Text + "',1)";
                                cmd.ExecuteNonQuery();

                                cmd.CommandText = "select max(ID) as id from Users";
                                da.Fill(dt);
                                string userID = dt.Rows[0]["id"].ToString();

                                cmd.CommandText = "insert into UsersInfo(ID,FirstName,MiddleName,LastName,BirthDate,Email,Phone,Address,Gender)" +
                                    " values('" + userID + "' ,'" + TextBoxFirstName.Text + "','" + TextBoxMidName.Text + "','" + TextBoxLastName.Text + "','" + TextBoxBirthDate.Text + "','" + TextBoxEmail.Text + "','" + p + "','" + TextBoxAddress.Text + "','" + g + "')";
                                cmd.ExecuteNonQuery();

                                ButtonReset_Click(sender, e);
                            }
                        }
                        else { TextBoxUserName.Text = ""; }
                    }
                    else { TextBoxConfirmPassword.Text = TextBoxPassword.Text = ""; }
                }
                else { TextBoxPin.Text = TextBoxConfirmPin.Text = ""; }
            }
        }

        protected void ButtonReset_Click(object sender, EventArgs e)
        {
            TextBoxFirstName.Text = "";
            TextBoxLastName.Text = "";
            TextBoxMidName.Text = "";
            TextBoxUserName.Text = "";
            TextBoxPassword.Text = "";
            TextBoxConfirmPassword.Text = "";
            TextBoxEmail.Text = "";
            TextBoxContact.Text = "";
            TextBoxAddress.Text = "";
            TextBoxBalance.Text = "";
            TextBoxPin.Text = "";
            TextBoxConfirmPin.Text = "";

            RadioButtonFemale.Checked = false;
            RadioButtonMale.Checked = false;

            TextBoxBirthDate.Text = "";

            CheckBoxUserType.Checked = false;
            DropDownListAccountType.SelectedIndex = 0;
        }

        protected void LinkButtonBack_Click(object sender, EventArgs e)
        {
            Session["Admin"] = userID;
            Response.Redirect("AdminDashboard.aspx");
        }

        protected void LinkButtonLogout_Click(object sender, EventArgs e)
        {
            Session["Admin"] = null;
            Session["EditUser"] = null;
            Session["ViewUser"] = null;
            Session["AccountTransactions"] = null;
            Response.Redirect("Login.aspx");
        }
    }
}