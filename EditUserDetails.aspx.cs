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
                cmd.CommandText = "select ui.FirstName as FN, ui.MiddleName as MN, ui.LastName as LN, u.UserName as UN, u.PassWord as PW, ui.Email as EM, ui.BirthDate as BD,ui.Gender as G,ui.Phone as P,ui.Address as Addr,a.AccountType as Type,a.Balance as Bal,a.PIN as PIN from Users as u join usersInfo as ui on (u.id = ui.id) join Accounts as a on (a.userID = ui.id) where u.id= @uID";
                cmd.Parameters.AddWithValue("@uID", userID);

                da.Fill(dt);

                if (!IsPostBack){
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
            else { Response.Redirect("Login.aspx"); }
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
                            cmd.Parameters.AddWithValue("@uID",userID);
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

            if (notEmpty()) {
                if(TextBoxPassword.Text == TextBoxConfirmPassword.Text)
                {
                    DropDownListAccountType_SelectedIndexChanged(sender, e);
                    cmd.CommandText = "select * from users where username = @UN";
                    cmd.Parameters.AddWithValue("@UN",TextBoxUserName.Text);
                    da.Fill(dt);
                    cmd.Parameters.Clear();
                    bool updateUN = true;
                    if (dt.Rows.Count > 0 && !(dt.Rows[0]["ID"].ToString().Equals(userID)) ) { updateUN = false; }
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

                        Page_Load(sender, e);
                    }
                    else { TextBoxUserName.Text = ""; }
                }
                else { TextBoxConfirmPassword.Text = TextBoxPassword.Text = ""; }
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
                
                
                && RadioButtonFemale.Checked == false
                && RadioButtonMale.Checked == false
                && TextBoxBirthDate.Text == ""
                ));
        }

        protected void ButtonDiscard_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);


            userID = Session["EditUser"].ToString();
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
    }
}