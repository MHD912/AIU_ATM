﻿using System;
using System.Drawing;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Test
{
    public partial class ViewCustomers : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void LinkButtonDashboard_Click(object sender, EventArgs e)
        {

            Response.Redirect("AdminDashboard.aspx");
        }

        protected void LinkButtonCreate_Click(object sender, EventArgs e)
        {

            Response.Redirect("CreateCustomer.aspx");
        }

        protected void LinkButton1_Click(object sender, EventArgs e)
        {

            Response.Redirect("ViewCustomerDetail.aspx");
        }

        protected void customersGridView_DataBound(object sender, EventArgs e)
        {
            //GridViewRow row = customersGridView.HeaderRow;
            //row.Cells[0].ColumnSpan = 3;
            //row.Cells[1].Visible = false;
            //row.Cells[2].Visible = false;
        }


    }
}