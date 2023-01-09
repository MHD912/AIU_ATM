using System;
using System.Drawing;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;

namespace AIU_ATM
{
    public partial class ViewUsers : System.Web.UI.Page
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
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandType = CommandType.Text;
                DataTable dt = new DataTable();
                SqlDataAdapter da = new SqlDataAdapter(cmd);

                if (CheckBoxPrivilgeToggle.Checked == false) { Session["view"] = "2"; tableText.Text = "Customers Details"; }
                else if (CheckBoxPrivilgeToggle.Checked == true) { Session["view"] = "1"; tableText.Text = "Admins Details"; }
                
                
                cmd.CommandText = "select u.UserName,ui.Email,ui.BirthDate,ui.Gender from Users as u join UsersInfo as ui on u.ID=ui.ID where u.Privilege='"+ Session["view"].ToString() + "'";
                da.Fill(dt);
                usersGridView.DataSource = dt;
                usersGridView.DataBind();
                
            }
            else { Response.Redirect("Login.aspx"); }
        }

        protected void LinkButtonDashboard_Click(object sender, EventArgs e)
        {
            Session["User"] = userID;
            Response.Redirect("AdminDashboard.aspx");
        }

        protected void LinkButtonCreate_Click(object sender, EventArgs e)
        {
            Session["User"] = userID;
            Response.Redirect("AddUser.aspx");
        }

        protected void usersGridView_SelectedIndexChanged(object sender, EventArgs e)
        {
            int rowIndex = usersGridView.SelectedIndex;
            string UN = usersGridView.Rows[rowIndex].Cells[1].Text;

            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);

            cmd.CommandText = "select ID from Users where UserName=@UN";
            cmd.Parameters.AddWithValue("@UN", UN);

            da.Fill(dt);
            string cusID = dt.Rows[0][0].ToString();

            Session["ViewUser"] = cusID;
            Session["User"] = userID;
            Response.Redirect("ViewUserDetails.aspx");
        }

        protected void usersGridView_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            string un=e.Keys["UserName"].ToString();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;

            cmd.CommandText = "delete from UsersInfo where ID = (select ID from Users where UserName = @UserName)";
            cmd.Parameters.AddWithValue("@UserName", un);
            cmd.ExecuteNonQuery();

            Response.Redirect("ViewUsers.aspx");
        }

        protected void LinkButtonLogout_Click(object sender, EventArgs e)
        {
            Session["User"] = null;
            Session["EditUser"] = null;
            Session["ViewUser"] = null;
            Response.Redirect("Login.aspx");
        }
    }
}