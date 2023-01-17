using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AIU_ATM
{
    public partial class ViewTransactions : System.Web.UI.Page
    {
        string userID;
        string accID;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Admin"] != null)
            {
                userID = Session["Admin"].ToString();
                SqlDataSource1.SelectCommand = "SELECT t.ID, tt.Type, t.FromAcc, t.ToAcc, t.Amount, t.Time FROM Transactions AS t INNER JOIN TransactionsTypes AS tt ON t.Type = tt.ID";
            }
            else if (Session["Customer"] != null)
            {
                userID = Session["Customer"].ToString();
                accID = Session["AccountTransactions"].ToString();
                LinkButtonCreate.Enabled = false;
                LinkButtonCreate.Visible = false;

                SqlDataSource1.SelectParameters.Add("accID", accID);
                SqlDataSource1.SelectCommand = "SELECT t.ID, tt.Type, t.FromAcc, t.ToAcc, t.Amount, t.Time FROM Transactions AS t INNER JOIN TransactionsTypes AS tt ON t.Type = tt.ID WHERE t.FromAcc = @accID OR t.ToAcc = @accID";
                //SqlDataSource1.SelectParameters.Clear();
            }
            else { Response.Redirect("Login.aspx"); }
        }

        protected void LinkButtonCreate_Click(object sender, EventArgs e)
        {
            Session["Admin"] = userID;
            Response.Redirect("AddTransaction.aspx");
        }

        protected void LinkButtonDashboard_Click(object sender, EventArgs e)
        {
            if (Session["Admin"] != null)
            {
                Session["Admin"] = userID;
                Response.Redirect("AdminDashboard.aspx");
            }
            else if (Session["Customer"] != null)
            {
                Session["Customer"] = userID;
                Response.Redirect("CustomerDashboard.aspx");
            }
        }

        protected void LinkButtonLogout_Click(object sender, EventArgs e)
        {
            Session["Admin"] = null;
            Session["Customer"] = null;
            Session["ST"] = null;
            Session["EditUser"] = null;
            Session["ViewUser"] = null;
            Session["AccountTransactions"] = null;
            Response.Redirect("Login.aspx");
        }

        protected void transactionsGridView_SelectedIndexChanged(object sender, EventArgs e)
        {
            int rowIndex = transactionsGridView.SelectedIndex;
            string tID = transactionsGridView.Rows[rowIndex].Cells[0].Text;
            Session["tID"] = tID;
            Page.ClientScript.RegisterStartupScript(this.GetType(), "OpenWindow", "window.open('Receipt.aspx','_blank');", true);
        }
    }

}