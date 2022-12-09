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
            if(con.State == ConnectionState.Open)
            {
                con.Close();
            }
            con.Open();

            if (Session["User"] != null)
            {
                userID = Session["User"].ToString();
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
            string AccountNo = usersGridView.Rows[rowIndex].Cells[2].Text;

            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);

            cmd.CommandText = "select u.ID as UID from Users as u join Accounts as a on u.ID = a.UserID where a.AccountNo='" + AccountNo + "'";
            da.Fill(dt);
            string cusID = dt.Rows[0]["UID"].ToString();

            Session["ViewUser"] = cusID;
            Session["User"] = userID;
            Response.Redirect("ViewUserDetails.aspx");
        }

    }
}