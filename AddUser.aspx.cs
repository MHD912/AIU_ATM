﻿using System;
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

            if (Session["User"] != null)
            {
                userID = Session["User"].ToString();
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

                                    cmd.CommandText = "insert into Users(UserName,PassWord,Privilege)" +
                                        " values('" + TextBoxUserName.Text + "','" + TextBoxPassword.Text + "',2)";
                                    cmd.ExecuteNonQuery();

                                    cmd.CommandText = "select max(ID) as id from Users";
                                    da.Fill(dt);
                                    string userID = dt.Rows[0]["id"].ToString();

                                    cmd.CommandText = "insert into UsersInfo(ID,FirstName,MiddleName,LastName,BirthDate,Email,Phone,Address,Gender)" +
                                        " values('" + userID + "' ,'" + TextBoxFirstName.Text + "','" + TextBoxMidName.Text + "','" + TextBoxLastName.Text + "','" + TextBoxBirthDate.Text + "','" + TextBoxEmail.Text + "','" + p + "','" + TextBoxAddress.Text + "','" + g + "')";
                                    cmd.ExecuteNonQuery();

                                    cmd.CommandText = "insert into Accounts(Balance,PIN,AccountType,UserID)" +
                                        " values('" + TextBoxBalance.Text + "','" + TextBoxPin.Text + "','" + Acctype + "', '" + userID + "')";
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
    }
}