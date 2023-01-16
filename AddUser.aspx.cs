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
using System.Text.RegularExpressions;

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
            Boolean res = true;
            if (TextBoxFirstName.Text != "")
            {
                Regex reg = new Regex("^[A-Za-z ]{3,20}$");
                TextBoxFirstName.Text = TextBoxFirstName.Text.Trim();
                bool r = reg.IsMatch(TextBoxFirstName.Text);
                TextBoxFirstName.CssClass = "form-control";
                if (!r) { LabelFirstNameFeedback.Text = "Names should have only characteres"; TextBoxFirstName.CssClass = "form-control is-invalid"; }
                res = res && r;
            }
            else
            { 
                res = false;
                LabelFirstNameFeedback.Text = "Required";
                TextBoxFirstName.CssClass = "form-control is-invalid";
            }
            if (TextBoxMidName.Text != "")
            {
                Regex reg = new Regex("^[A-Za-z ]{3,20}$");
                TextBoxMidName.Text = TextBoxMidName.Text.ToString().Trim();
                bool r = reg.IsMatch(TextBoxMidName.Text);
                TextBoxMidName.CssClass = "form-control";
                if (!r) { LabelMidNameFeedback.Text = "Names should have only characteres"; TextBoxMidName.CssClass = "form-control is-invalid"; }
                res = res && r;
            }
            else
            {
                res = false;
                LabelMidNameFeedback.Text = "Required";
                TextBoxMidName.CssClass = "form-control is-invalid";
            }
            if (TextBoxLastName.Text != "")
            {
                Regex reg = new Regex("^[A-Za-z ]{3,20}$");
                TextBoxLastName.Text = TextBoxLastName.Text.ToString().Trim();
                bool r = reg.IsMatch(TextBoxLastName.Text);
                TextBoxLastName.CssClass = "form-control";
                if (!r) { LabelLastNameFeedback.Text = "Names should have only characteres"; TextBoxLastName.CssClass = "form-control is-invalid"; }
                res = res && r;
            }
            else
            {
                res = false;
                LabelLastNameFeedback.Text = "Required";
                TextBoxLastName.CssClass = "form-control is-invalid";
            }
            if (TextBoxUserName.Text != "")
            {
                Regex reg = new Regex("/^[a-z0-9_-]{3,16}$/");
                TextBoxUserName.Text = TextBoxUserName.Text.ToString().Trim();
                bool r = reg.IsMatch(TextBoxUserName.Text);
                TextBoxUserName.CssClass = "form-control";
                if (!r) { LabelUserNameFeedback.Text = "UserName should have only characteres and (_,-) length of 3-16"; TextBoxUserName.CssClass = "form-control is-invalid"; }
                res = res && r;
            }
            else
            {
                res = false;
                LabelUserNameFeedback.Text = "Required";
                TextBoxUserName.CssClass = "form-control is-invalid";
            }
            if (TextBoxPassword.Text != "")
            {
                Regex reg = new Regex("/(?=(.*[0-9]))(?=.*[\\!@#$%^&*()\\\\[\\]{}\\-_+=~`|:;\"'<>,./?])(?=.*[a-z])(?=(.*[A-Z]))(?=(.*)).{8,}/");
                TextBoxPassword.Text = TextBoxPassword.Text.ToString().Trim();
                bool r = reg.IsMatch(TextBoxPassword.Text);
                TextBoxPassword.CssClass = "form-control";
                if (!r) { LabelPasswordFeedback.Text = "Password Should have 1 lowercase letter, 1 uppercase letter, 1 number, 1 special character and be at least 8 characters long"; TextBoxPassword.CssClass = "form-control is-invalid"; }
                res = res && r;
            }
            else
            {
                res = false;
                LabelPasswordFeedback.Text = "Required";
                TextBoxPassword.CssClass = "form-control is-invalid";
            }
            if (TextBoxConfirmPassword.Text != "")
            {
                Regex reg = new Regex("/(?=(.*[0-9]))(?=.*[\\!@#$%^&*()\\\\[\\]{}\\-_+=~`|:;\"'<>,./?])(?=.*[a-z])(?=(.*[A-Z]))(?=(.*)).{8,}/");
                TextBoxConfirmPassword.Text = TextBoxConfirmPassword.Text.ToString().Trim();
                bool r = reg.IsMatch(TextBoxConfirmPassword.Text);
                TextBoxConfirmPassword.CssClass = "form-control";
                if (!r) { LabelConfirmPasswordFeedback.Text = "Password Should have 1 lowercase letter, 1 uppercase letter, 1 number, 1 special character and be at least 8 characters long"; TextBoxConfirmPassword.CssClass = "form-control is-invalid"; }
                res = res && r;
            }
            else
            {
                res = false;
                LabelConfirmPasswordFeedback.Text = "Required";
                TextBoxConfirmPassword.CssClass = "form-control is-invalid";
            }
            if (TextBoxEmail.Text != "")
            {
                Regex reg = new Regex("/^([a-zA-Z0-9._%-]+@[a-zA-Z0-9.-]+\\.[a-zA-Z]{2,6})*$/");
                TextBoxEmail.Text = TextBoxEmail.Text.ToString().Trim();
                bool r = reg.IsMatch(TextBoxEmail.Text);
                TextBoxEmail.CssClass = "form-control";
                if (!r) { LabelEmailFeedback.Text = "Wrong email syntax"; TextBoxEmail.CssClass = "form-control is-invalid"; }
                res = res && r;
            }
            else
            {
                res = false;
                LabelEmailFeedback.Text = "Required";
                TextBoxEmail.CssClass = "form-control is-invalid";
            }
            if (TextBoxContact.Text != "")
            {
                Regex reg = new Regex("/^[1-9][0-9]{8}$/");
                TextBoxContact.Text = TextBoxContact.Text.ToString().Trim();
                bool r = reg.IsMatch(TextBoxContact.Text);
                TextBoxContact.CssClass = "form-control";
                if (!r) { LabelContactFeedback.Text = "Wrong phone syntax"; TextBoxContact.CssClass = "form-control is-invalid"; }
                res = res && r;
            }
            else
            {
                res = false;
                LabelContactFeedback.Text = "Required";
                TextBoxContact.CssClass = "form-control is-invalid";
            }

            if (!CheckBoxUserType.Checked)
            {
                if (TextBoxPin.Text != "")
                {
                    Regex reg = new Regex("/^[0-9]{4}$/");
                    TextBoxPin.Text = TextBoxPin.Text.ToString().Trim();
                    bool r = reg.IsMatch(TextBoxPin.Text);
                    TextBoxPin.CssClass = "form-control";
                    if (!r) { LabelPinFeedback.Text = "Please enter 4-Digit PIN code"; TextBoxPin.CssClass = "form-control is-invalid"; }
                    res = res && r;
                }
                else
                {
                    res = false;
                    LabelPinFeedback.Text = "Required";
                    TextBoxPin.CssClass = "form-control is-invalid";
                }
                if (TextBoxConfirmPin.Text != "")
                {
                    Regex reg = new Regex("/^[0-9]{4}$/");
                    TextBoxConfirmPin.Text = TextBoxConfirmPin.Text.ToString().Trim();
                    bool r = reg.IsMatch(TextBoxConfirmPin.Text);
                    TextBoxConfirmPin.CssClass = "form-control";
                    if (!r) { LabelConfirmPinFeedback.Text = "Please enter 4-Digit PIN code"; TextBoxConfirmPin.CssClass = "form-control is-invalid"; }
                    res = res && r;
                }
                else
                {
                    res = false;
                    LabelConfirmPinFeedback.Text = "Required";
                    TextBoxConfirmPin.CssClass = "form-control is-invalid";
                }
                if (TextBoxBalance.Text != "")
                {
                    Regex reg = new Regex("/^[0-9]+$/");
                    TextBoxBalance.Text = TextBoxBalance.Text.ToString().Trim();
                    bool r = reg.IsMatch(TextBoxBalance.Text);
                    TextBoxBalance.CssClass = "form-control";
                    if (!r) { LabelBalanceFeedback.Text = "Balace should be in numbers"; TextBoxBalance.CssClass = "form-control is-invalid"; }
                    res = res && r;
                }
                else
                {
                    res = false;
                    LabelBalanceFeedback.Text = "Required";
                    TextBoxBalance.CssClass = "form-control is-invalid";
                }
            }
            

            return res;
        }

        protected void ButtonCreate_Click(object sender, EventArgs e)
        {
            if (notEmpty())
            {
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandType = CommandType.Text;
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();

                TextBoxPin.CssClass = "form-control";
                TextBoxConfirmPin.CssClass = "form-control";
                if (TextBoxPin.Text == TextBoxConfirmPin.Text)
                {
                    TextBoxPassword.CssClass = "form-control";
                    TextBoxConfirmPassword.CssClass = "form-control";
                    if (TextBoxPassword.Text == TextBoxConfirmPassword.Text)
                    {
                        TextBoxUserName.CssClass = "form-control";
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
                        else { LabelUserNameFeedback.Text = "UserName is used";
                            TextBoxUserName.CssClass = "form-control is-invalid"; }
                    }
                    else {
                        TextBoxPassword.CssClass = "form-control is-invalid";
                        TextBoxConfirmPassword.CssClass = "form-control is-invalid";
                        LabelConfirmPasswordFeedback.Text = "Comfirm Passwords, Passwords doesn't match";
                    }
                }
                else {
                    TextBoxPin.CssClass = "form-control is-invalid";
                    TextBoxConfirmPin.CssClass = "form-control is-invalid";
                    LabelConfirmPinFeedback.Text = "Comfirm PINs, PINs doesn't match";
                }
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