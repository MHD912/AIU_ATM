using System;
using System.Drawing;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using System.Security.AccessControl;
using System.Text.RegularExpressions;

namespace AIU_ATM
{
    public partial class EditUserDetails : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection(@"Data Source=LOCALHOST;Initial Catalog=ATM-Bank;Integrated Security=True");
        string userID;
        string[] accountTypeCurrent = { "", "", "" };
        string[] accountTypeSaving = { "", "", "" };
        string[] accountTypeSalary = { "", "", "" };

        protected void Page_Load(object sender, EventArgs e)
        {
            if (con.State == ConnectionState.Open)
            {
                con.Close();
            }
            con.Open();

            if (Session["EditUser"] != null)
            {
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandType = CommandType.Text;
                DataTable dt = new DataTable();
                SqlDataAdapter da = new SqlDataAdapter(cmd);

                userID = Session["EditUser"].ToString();

                if (Session["view"].ToString() == "2")
                {
                    cmd.CommandText = "select ui.FirstName as FN, ui.MiddleName as MN, ui.LastName as LN, u.UserName as UN, u.PassWord as PW, ui.Email as EM, ui.BirthDate as BD,ui.Gender as G,ui.Phone as P,ui.Address as Addr,a.AccountType as Type,a.Balance as Bal,a.PIN as PIN from Users as u join usersInfo as ui on (u.id = ui.id) join Accounts as a on (a.userID = ui.id) where u.id= @uID";
                    cmd.Parameters.AddWithValue("@uID", userID);

                    da.Fill(dt);

                    if (!IsPostBack)
                    {
                        ButtonDiscard_Click(sender, e);
                    }
                    else
                    {
                        DropDownListAccountType_SelectedIndexChanged(sender, e);

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


                        if (int.Parse(Session["sel"].ToString()) == 0)
                        {
                            TextBoxBalance.Text = accountTypeCurrent[1];
                            TextBoxPin.Text = accountTypeCurrent[2];
                            TextBoxConfirmPin.Text = accountTypeCurrent[2];
                        }
                        else if (int.Parse(Session["sel"].ToString()) == 1)
                        {
                            TextBoxBalance.Text = accountTypeSaving[1];
                            TextBoxPin.Text = accountTypeSaving[2];
                            TextBoxConfirmPin.Text = accountTypeSaving[2];
                        }
                        else if (int.Parse(Session["sel"].ToString()) == 2)
                        {
                            TextBoxBalance.Text = accountTypeSalary[1];
                            TextBoxPin.Text = accountTypeSalary[2];
                            TextBoxConfirmPin.Text = accountTypeSalary[2];
                        }
                    }
                }
                else if (Session["view"].ToString() == "1")
                {
                    CheckBoxUserType.Checked = true;
                    TextBoxBalance.Enabled = false;
                    TextBoxPin.Enabled = false;
                    TextBoxConfirmPin.Enabled = false;
                    ButtonDiscard_Click(sender, e);
                }

            }
            else { Response.Redirect("Login.aspx"); }
        }


        protected bool notEmpty()
        {
            bool res = true;
            Regex capitalizeRegex = new Regex(@"^[a-z]|(?<=\s)[a-z]", RegexOptions.IgnoreCase);

            if (TextBoxFirstName.Text != "")
            {
                Regex reg = new Regex(@"^[A-Za-z ]{3,20}$");
                TextBoxFirstName.Text = TextBoxFirstName.Text.Trim();
                bool isValid = reg.IsMatch(TextBoxFirstName.Text);
                TextBoxFirstName.CssClass = "form-control";
                if (!isValid)
                {
                    LabelFirstNameFeedback.Text = "Name must only contain letters";
                    TextBoxFirstName.CssClass = "form-control is-invalid";
                }
                else
                {
                    TextBoxFirstName.Text = capitalizeRegex.Replace(TextBoxFirstName.Text, m => m.Value.ToUpper());
                }
                res = res && isValid;
            }
            else
            {
                res = false;
                LabelFirstNameFeedback.Text = "Required";
                TextBoxFirstName.CssClass = "form-control is-invalid";
            }
            if (TextBoxMidName.Text != "")
            {
                Regex reg = new Regex(@"^[A-Za-z ]{3,20}$");
                TextBoxMidName.Text = TextBoxMidName.Text.Trim();
                bool isValid = reg.IsMatch(TextBoxMidName.Text);
                TextBoxMidName.CssClass = "form-control";
                if (!isValid)
                {
                    LabelMidNameFeedback.Text = "Name must only contain letters";
                    TextBoxMidName.CssClass = "form-control is-invalid";
                }
                else
                {
                    TextBoxMidName.Text = capitalizeRegex.Replace(TextBoxMidName.Text, m => m.Value.ToUpper());
                }
                res = res && isValid;
            }
            else
            {
                res = false;
                LabelMidNameFeedback.Text = "Required";
                TextBoxMidName.CssClass = "form-control is-invalid";
            }
            if (TextBoxLastName.Text != "")
            {
                Regex reg = new Regex(@"^[A-Za-z ]{3,20}$");
                TextBoxLastName.Text = TextBoxLastName.Text.Trim();
                bool isValid = reg.IsMatch(TextBoxLastName.Text);
                TextBoxLastName.CssClass = "form-control";
                if (!isValid)
                {
                    LabelLastNameFeedback.Text = "Name must only contain letters";
                    TextBoxLastName.CssClass = "form-control is-invalid";
                }
                else
                {
                    TextBoxLastName.Text = capitalizeRegex.Replace(TextBoxLastName.Text, m => m.Value.ToUpper());
                }
                res = res && isValid;
            }
            else
            {
                res = false;
                LabelLastNameFeedback.Text = "Required";
                TextBoxLastName.CssClass = "form-control is-invalid";
            }
            if (TextBoxUserName.Text != "")
            {
                Regex reg = new Regex(@"^[a-z0-9]{3,16}$");
                TextBoxUserName.Text = TextBoxUserName.Text.Trim();
                bool isValid = reg.IsMatch(TextBoxUserName.Text);
                TextBoxUserName.CssClass = "form-control";
                if (!isValid) { LabelUserNameFeedback.Text = "Username can only contain lower case letters and numbers with length of 3-16"; TextBoxUserName.CssClass = "form-control is-invalid"; }
                res = res && isValid;
            }
            else
            {
                res = false;
                LabelUserNameFeedback.Text = "Required";
                TextBoxUserName.CssClass = "form-control is-invalid";
            }
            if (TextBoxPassword.Text != "")
            {
                Regex reg = new Regex(@"^(?=.*[A-Z])(?=.*\d)(?=.*[^a-zA-Z\d])[A-Z\d$@$!%*?&]{8,}$");
                TextBoxPassword.Text = TextBoxPassword.Text.Trim();
                bool isVaild = reg.IsMatch(TextBoxPassword.Text);
                TextBoxPassword.CssClass = "form-control";
                if (!isVaild) { LabelPasswordFeedback.Text = "Password must start start with an upper-case letter, contains at least one special character, and be at least 8 characters long"; TextBoxPassword.CssClass = "form-control is-invalid"; }
                res = res && isVaild;
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
                Regex reg = new Regex(@"^[a-zA-Z0-9.!#$%&'*+/=?^_`{|}~-]+@[a-zA-Z0-9](?:[a-zA-Z0-9-]{0,61}[a-zA-Z0-9])?(?:\.[a-zA-Z]{2,})+$");
                TextBoxEmail.Text = TextBoxEmail.Text.Trim();
                bool isValid = reg.IsMatch(TextBoxEmail.Text);
                TextBoxEmail.CssClass = "form-control";
                if (!isValid) { LabelEmailFeedback.Text = "Invalid email"; TextBoxEmail.CssClass = "form-control is-invalid"; }
                res = res && isValid;
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
                Regex reg = new Regex(@"^[0-9]{7,12}$");
                TextBoxContact.Text = Regex.Replace(TextBoxContact.Text.Trim(), @"^0*", "");
                bool isValid = reg.IsMatch(TextBoxContact.Text);
                TextBoxContact.CssClass = "form-control";
                if (!isValid) { LabelContactFeedback.Text = "Invalid phone number"; TextBoxContact.CssClass = "form-control is-invalid"; }
                res = res && isValid;
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
                    Regex reg = new Regex(@"^[0-9]{4,12}$");
                    TextBoxContact.Text = TextBoxContact.Text.Trim();
                    bool isValid = reg.IsMatch(TextBoxContact.Text);
                    TextBoxPin.CssClass = "form-control";
                    if (!isValid) { LabelPinFeedback.Text = "PIN code must contain numbers only with 4-12 digits"; TextBoxPin.CssClass = "form-control is-invalid"; }
                    res = res && isValid;
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

                if (TextBoxBalance.Text == "")
                {
                    TextBoxBalance.CssClass = "form-control is-invalid";
                    LabelBalanceFeedback.Text = "Required";
                    res = false;
                }
                else
                {
                    TextBoxBalance.Text = TextBoxBalance.Text.Trim();
                    TextBoxBalance.CssClass = "form-control";
                    bool isValid = true;
                    try
                    {
                        double amount = double.Parse(TextBoxBalance.Text);
                        if (amount < 0)
                        {
                            LabelBalanceFeedback.Text = "Balance can't be negative";
                            TextBoxBalance.CssClass = "form-control is-invalid";
                            res = false;
                        }
                        else if (amount < 500)
                        {
                            LabelBalanceFeedback.Text = "Balance must be at least 500 SP";
                            TextBoxBalance.CssClass = "form-control is-invalid";
                            res = false;
                        }
                    }
                    catch
                    {
                        isValid = false;
                        LabelBalanceFeedback.Text = "Balance can't contain letters";
                        TextBoxBalance.CssClass = "form-control is-invalid";
                    }
                    res = res && isValid;
                }
            }

            return res;
        }

        protected void LinkButtonBack_Click(object sender, EventArgs e)
        {
            Session["EditUser"] = userID;
            Response.Redirect("ViewUserDetails.aspx");
        }

        protected void DropDownListAccountType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (TextBoxBalance.Text != "" && (TextBoxPin.Text != "" || TextBoxConfirmPin.Text != ""))
            {
                if (double.Parse(TextBoxBalance.Text) >= 0)
                {
                    if (TextBoxPin.Text == TextBoxConfirmPin.Text && TextBoxPin.Text.Length == 4)
                    {
                        SqlCommand cmd = con.CreateCommand();
                        cmd.CommandType = CommandType.Text;
                        DataTable dt = new DataTable();
                        SqlDataAdapter da = new SqlDataAdapter(cmd);

                        int type = int.Parse(Session["sel"].ToString());
                        cmd.CommandText = "select * from accounts where UserID = @userID and AccountType = @AT";
                        cmd.Parameters.AddWithValue("@userID", userID);
                        cmd.Parameters.AddWithValue("@AT", type + 1);
                        da.Fill(dt);
                        cmd.Parameters.Clear();

                        if (dt.Rows.Count == 0)
                        {
                            cmd.CommandText = "insert into Accounts(Balance,PIN,AccountType,UserID) values(@Balance,@PIN,@AT, @uID)";
                            cmd.Parameters.AddWithValue("@Balance", TextBoxBalance.Text);
                            cmd.Parameters.AddWithValue("@PIN", TextBoxPin.Text);
                            cmd.Parameters.AddWithValue("@AT", type + 1);
                            cmd.Parameters.AddWithValue("@uID", userID);
                            cmd.ExecuteNonQuery();
                            cmd.Parameters.Clear();
                        }
                        else
                        {
                            cmd.CommandText = "update Accounts set balance = @Balance, PIN=@PIN where UserID = @uID and AccountType = @AT";
                            cmd.Parameters.AddWithValue("@Balance", TextBoxBalance.Text);
                            cmd.Parameters.AddWithValue("@PIN", TextBoxPin.Text);
                            cmd.Parameters.AddWithValue("@AT", type + 1);
                            cmd.Parameters.AddWithValue("@uID", userID);
                            cmd.ExecuteNonQuery();
                            cmd.Parameters.Clear();
                        }

                    }
                    else
                    {
                        DropDownListAccountType.SelectedIndex = int.Parse(Session["sel"].ToString());
                        TextBoxConfirmPin.Text = "";
                        TextBoxPin.Text = "";
                    }
                }
                else
                {
                    DropDownListAccountType.SelectedIndex = int.Parse(Session["sel"].ToString());
                    TextBoxBalance.Text = "";
                }
            }

            Session["sel"] = DropDownListAccountType.SelectedIndex;

        }

        protected void ButtonConfirm_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);

            if (notEmpty())
            {
                DropDownListAccountType_SelectedIndexChanged(sender, e);
                cmd.CommandText = "select * from users where username = @UN";
                cmd.Parameters.AddWithValue("@UN", TextBoxUserName.Text);
                da.Fill(dt);
                cmd.Parameters.Clear();
                bool updateUN = true;
                if (dt.Rows.Count > 0 && !(dt.Rows[0]["ID"].ToString().Equals(userID))) { updateUN = false; }
                if (updateUN)
                {
                    cmd.CommandText = "update Users set UserName = @UN,PassWord=@PW where id = @uID";
                    cmd.Parameters.AddWithValue("@UN", TextBoxUserName.Text);
                    cmd.Parameters.AddWithValue("@PW", TextBoxPassword.Text);
                    cmd.Parameters.AddWithValue("@uID", userID);
                    cmd.ExecuteNonQuery();
                    cmd.Parameters.Clear();

                    string g = "Male";
                    if (RadioButtonFemale.Checked == true) { g = "FeMale"; }

                    cmd.CommandText = "update UsersInfo set FirstName = @FN, LastName = @LN, MiddleName=@MN, Email=@EM, BirthDate=@BD,Gender=@G,Phone=@P,Address=@Add where id = @uID";
                    cmd.Parameters.AddWithValue("@FN", TextBoxFirstName.Text);
                    cmd.Parameters.AddWithValue("@MN", TextBoxMidName.Text);
                    cmd.Parameters.AddWithValue("@LN", TextBoxLastName.Text);
                    cmd.Parameters.AddWithValue("@BD", TextBoxBirthDate.Text);
                    cmd.Parameters.AddWithValue("@EM", TextBoxEmail.Text);
                    cmd.Parameters.AddWithValue("@P", TextBoxContact.Text);
                    cmd.Parameters.AddWithValue("@Add", TextBoxAddress.Text);
                    cmd.Parameters.AddWithValue("@G", g);
                    cmd.Parameters.AddWithValue("@uID", userID);
                    cmd.ExecuteNonQuery();
                    cmd.Parameters.Clear();

                    Response.Redirect("ViewUserDetails.aspx");
                }
                else { TextBoxUserName.Text = ""; }
            }

        }


        protected void ButtonDiscard_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);

            userID = Session["EditUser"].ToString();

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
                TextBoxConfirmPassword.Text = dt.Rows[0]["PW"].ToString();
                TextBoxEmail.Text = dt.Rows[0]["EM"].ToString();
                TextBoxBirthDate.Text = dt.Rows[0]["BD"].ToString();
                RadioButtonFemale.Checked = true;
                string g = dt.Rows[0]["G"].ToString();
                if (g.Equals("Male")) { RadioButtonFemale.Checked = false; RadioButtonMale.Checked = true; }
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

                if (accountTypeCurrent[0] != "")
                {
                    Session["sel"] = 0;
                    DropDownListAccountType.SelectedIndex = 0;
                    TextBoxBalance.Text = accountTypeCurrent[1];
                    TextBoxPin.Text = accountTypeCurrent[2];
                    TextBoxConfirmPin.Text = accountTypeCurrent[2];
                }
                else if (accountTypeSaving[0] != "")
                {
                    Session["sel"] = 1;
                    DropDownListAccountType.SelectedIndex = 1;
                    TextBoxBalance.Text = accountTypeSaving[1];
                    TextBoxPin.Text = accountTypeSaving[2];
                    TextBoxConfirmPin.Text = accountTypeSaving[2];
                }
                else if (accountTypeSalary[0] != "")
                {
                    Session["sel"] = 2;
                    DropDownListAccountType.SelectedIndex = 2;
                    TextBoxBalance.Text = accountTypeSalary[1];
                    TextBoxPin.Text = accountTypeSalary[2];
                    TextBoxConfirmPin.Text = accountTypeSalary[2];
                }

            }
            else if (Session["view"].ToString() == "1")
            {
                CheckBoxUserType.Checked = true;
                cmd.CommandText = "select ui.FirstName as FN, ui.MiddleName as MN, ui.LastName as LN, u.UserName as UN, u.PassWord as PW, ui.Email as EM, ui.BirthDate as BD,ui.Gender as G,ui.Phone as P,ui.Address as Addr from Users as u join usersInfo as ui on (u.id = ui.id) where u.id= @uID";
                cmd.Parameters.AddWithValue("@uID", userID);

                da.Fill(dt);

                TextBoxFirstName.Text = dt.Rows[0]["FN"].ToString();
                TextBoxMidName.Text = dt.Rows[0]["MN"].ToString();
                TextBoxLastName.Text = dt.Rows[0]["LN"].ToString();
                TextBoxUserName.Text = dt.Rows[0]["UN"].ToString();
                TextBoxPassword.Text = dt.Rows[0]["PW"].ToString();
                TextBoxConfirmPassword.Text = dt.Rows[0]["PW"].ToString();
                TextBoxEmail.Text = dt.Rows[0]["EM"].ToString();
                TextBoxBirthDate.Text = dt.Rows[0]["BD"].ToString();
                RadioButtonFemale.Checked = true;
                string g = dt.Rows[0]["G"].ToString();
                if (g.Equals("Male")) { RadioButtonFemale.Checked = false; RadioButtonMale.Checked = true; }
                TextBoxContact.Text = dt.Rows[0]["P"].ToString();
                TextBoxAddress.Text = dt.Rows[0]["Addr"].ToString();
            }
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