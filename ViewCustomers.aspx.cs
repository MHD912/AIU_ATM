using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Test
{
    public partial class ViewCustomers : System.Web.UI.Page
    {
        string userID;
        SqlConnection con = new SqlConnection(@"Data Source=LAPTOP-ORMHDR25;Initial Catalog=ATM-Bank;Integrated Security=True");
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
            else { Response.Redirect("AdminLogin.aspx"); }
        }

        protected void LinkButtonDashboard_Click(object sender, EventArgs e)
        {
            Session["User"] = userID;
            Response.Redirect("AdminDashboard.aspx");
        }

        protected void LinkButtonCreate_Click(object sender, EventArgs e)
        {
            Session["User"] = userID;
            Response.Redirect("CreateCustomer.aspx");
        }        

        protected void customersGridView_DataBound(object sender, EventArgs e)
        {
            
        }

        protected void customersGridView_SelectedIndexChanged(object sender, EventArgs e)
        {
            int rowIndex = customersGridView.SelectedIndex;
            string AccountNo = customersGridView.Rows[rowIndex].Cells[2].Text;

            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);

            cmd.CommandText = "select u.ID as UID from Users as u join Accounts as a on u.ID = a.UserID where a.AccountNo='" + AccountNo + "'";
            da.Fill(dt);
            string cusID = dt.Rows[0]["UID"].ToString();

            Session["ViewUser"] = cusID;
            Session["User"] = userID;
            Response.Redirect("ViewCustomerDetails.aspx");
        }
    }
}

