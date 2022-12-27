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
                cmd.CommandText = "select ui.FirstName as FN, ui.MiddleName as MN, ui.LastName as LN, u.UserName as UN, u.PassWord as PW, ui.Email as EM, ui.BirthDate as BD,ui.Gender as G,ui.Phone as P,ui.Address as Addr,a.Balance as Bal,a.PIN as PIN from Users as u join usersInfo as ui on (u.id = ui.id) join Accounts as a on (a.userID = ui.id) where u.id= @uID";
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
                TextBoxBalance.Text = dt.Rows[0]["Bal"].ToString();
                TextBoxAddress.Text = dt.Rows[0]["Addr"].ToString();
                TextBoxPin.Text = dt.Rows[0]["PIN"].ToString();

            }
            else { Response.Redirect("ViewUsers.aspx"); }
        }

        protected void ButtonEdit_Click(object sender, EventArgs e)
        {
            Session["EditUser"] = userID;
            Response.Redirect("EditUserDetails.aspx");
        }
    }
}