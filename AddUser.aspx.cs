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
                if (!r) { LabelFirstNameFeedback.Text = "Name must only contain letters"; TextBoxFirstName.CssClass = "form-control is-invalid"; }
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
                if (!r) { LabelMidNameFeedback.Text = "Name must only contain letters"; TextBoxMidName.CssClass = "form-control is-invalid"; }
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
                if (!r) { LabelLastNameFeedback.Text = "Name must only contain letters"; TextBoxLastName.CssClass = "form-control is-invalid"; }
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
                if (!r) { LabelUserNameFeedback.Text = "Username can only contain letters and (_,-) with length of 3-16"; TextBoxUserName.CssClass = "form-control is-invalid"; }
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
            if (TextBoxConfirmPassword.Text == "")
            {
                res = false;
                LabelConfirmPasswordFeedback.Text = "Required";
                TextBoxConfirmPassword.CssClass = "form-control is-invalid";
            }
            else if (TextBoxPassword.Text != TextBoxConfirmPassword.Text)
            {
                res = false;
                TextBoxConfirmPassword.CssClass = "form-control is-invalid";
                LabelConfirmPasswordFeedback.Text = "Passwords doesn't match";
            }
            if (TextBoxEmail.Text != "")
            {
                //Regex reg = new Regex("/^([a-zA-Z0-9._%-]+@[a-zA-Z0-9.-]+\\.[a-zA-Z]{2,6})*$/");
                //TextBoxEmail.Text = TextBoxEmail.Text.ToString().Trim();
                //bool r = reg.IsMatch(TextBoxEmail.Text);
                //TextBoxEmail.CssClass = "form-control";
                //if (!r) { LabelEmailFeedback.Text = "Invalid email"; TextBoxEmail.CssClass = "form-control is-invalid"; }
                //res = res && r;
            }
            else
            {
                res = false;
                LabelEmailFeedback.Text = "Required";
                TextBoxEmail.CssClass = "form-control is-invalid";
            }
            if (TextBoxBirthDate.Text == "")
            {
                res = false;
                LabelBirthDateFeedback.Text = "Required";
                TextBoxBirthDate.CssClass = "form-control is-invalid";
            }
            if (TextBoxContact.Text != "")
            {
                bool r = true;
                TextBoxContact.Text = TextBoxContact.Text.ToString().Trim();
                try
                {
                    string s = TextBoxContact.Text;
                    float number = float.Parse(TextBoxContact.Text);
                    if(s.Length != 9) { r = false; }
                }
                catch (Exception ex)
                {
                    r = false;
                }
                TextBoxContact.CssClass = "form-control";
                if (!r) { LabelContactFeedback.Text = "Invalid phone number"; TextBoxContact.CssClass = "form-control is-invalid"; }
                res = res && r;
            }
            else
            {
                res = false;
                LabelContactFeedback.Text = "Required";
                TextBoxContact.CssClass = "form-control is-invalid";
            }
            if (TextBoxAddress.Text == "")
            {
                res = false;
                LabelAddressFeedback.Text = "Required";
                TextBoxAddress.CssClass = "form-control is-invalid";
            }
            if (!CheckBoxUserType.Checked)
            {
                if (TextBoxPin.Text != "")
                {
                    bool r = true;
                    TextBoxPin.Text = TextBoxPin.Text.ToString().Trim();
                    try
                    {
                        string s = TextBoxPin.Text;
                        float number = float.Parse(TextBoxPin.Text);
                        if(s.Length < 4) { r = false; }
                    }
                    catch (Exception ex)
                    {
                        r = false;
                    }
                    TextBoxPin.CssClass = "form-control";
                    if (!r) { LabelPinFeedback.Text = "PIN code must contain numbers only with at least 4-Digits"; TextBoxPin.CssClass = "form-control is-invalid"; }
                    res = res && r;
                }
                else
                {
                    res = false;
                    LabelPinFeedback.Text = "Required";
                    TextBoxPin.CssClass = "form-control is-invalid";
                }
                if (TextBoxConfirmPin.Text == "")
                {
                    res = false;
                    LabelConfirmPinFeedback.Text = "Required";
                    TextBoxConfirmPin.CssClass = "form-control is-invalid";
                }
                else if (TextBoxPin.Text != TextBoxConfirmPin.Text)
                {
                    res = false;
                    TextBoxConfirmPin.CssClass = "form-control is-invalid";
                    LabelConfirmPinFeedback.Text = "PIN code doesn't match";
                }
                if (TextBoxBalance.Text != "")
                {
                    bool r = true;
                    TextBoxBalance.Text = TextBoxBalance.Text.ToString().Trim();
                    try
                    {                        
                        float number = float.Parse(TextBoxBalance.Text);                        
                    }
                    catch (Exception ex)
                    {
                        r = false;
                    }
                    TextBoxBalance.CssClass = "form-control";
                    if (!r) { LabelBalanceFeedback.Text = "Balance must contain numbers only"; TextBoxBalance.CssClass = "form-control is-invalid"; }
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
                            cmd.Parameters.AddWithValue("@uID", userID);
                            cmd.Parameters.AddWithValue("@FN", TextBoxFirstName.Text);
                            cmd.Parameters.AddWithValue("@MN", TextBoxMidName.Text);
                            cmd.Parameters.AddWithValue("@LN", TextBoxLastName.Text);
                            cmd.Parameters.AddWithValue("@BD", TextBoxBirthDate.Text);
                            cmd.Parameters.AddWithValue("@EM", TextBoxEmail.Text);
                            cmd.Parameters.AddWithValue("@P", p);
                            cmd.Parameters.AddWithValue("@Add", TextBoxAddress.Text);
                            cmd.Parameters.AddWithValue("@G", g);
                            cmd.ExecuteNonQuery();
                            cmd.Parameters.Clear();

                            cmd.CommandText = "insert into Accounts(Balance,PIN,AccountType,UserID) values(@Balance,@PIN,@AT, @uID)";
                            cmd.Parameters.AddWithValue("@Balance", TextBoxBalance.Text);
                            cmd.Parameters.AddWithValue("@PIN", TextBoxPin.Text);
                            cmd.Parameters.AddWithValue("@AT", Acctype);
                            cmd.Parameters.AddWithValue("@uID", userID);
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
                else
                {
                    LabelUserNameFeedback.Text = "Username is used";
                    TextBoxUserName.CssClass = "form-control is-invalid";
                }
            }
        }

        protected void ButtonReset_Click(object sender, EventArgs e)
        {
            TextBoxFirstName.Text = "";
            TextBoxFirstName.CssClass = "form-control";

            TextBoxLastName.Text = "";
            TextBoxLastName.CssClass = "form-control";
            
            TextBoxMidName.Text = "";
            TextBoxMidName.CssClass = "form-control";
            
            TextBoxUserName.Text = "";
            TextBoxUserName.CssClass = "form-control";
            
            TextBoxPassword.Text = "";
            TextBoxPassword.CssClass = "form-control";
            
            TextBoxConfirmPassword.Text = "";
            TextBoxConfirmPassword.CssClass = "form-control";
            
            TextBoxEmail.Text = "";
            TextBoxEmail.CssClass = "form-control";
            
            TextBoxContact.Text = "";
            TextBoxContact.CssClass = "form-control";
            
            TextBoxAddress.Text = "";
            TextBoxAddress.CssClass = "form-control";
            
            TextBoxBalance.Text = "";
            TextBoxBalance.CssClass = "form-control";
            
            TextBoxPin.Text = "";
            TextBoxPin.CssClass = "form-control";   
            
            TextBoxConfirmPin.Text = "";
            TextBoxConfirmPin.CssClass = "form-control";

            RadioButtonFemale.Checked = false;
            RadioButtonMale.Checked = false;

            TextBoxBirthDate.Text = "";
            TextBoxBirthDate.CssClass = "form-control";

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