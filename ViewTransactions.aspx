<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ViewTransactions.aspx.cs" Inherits="AIU_ATM.ViewTransactions" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>View Transactions</title>
    <meta charset="UTF-8" />
    <meta http-equiv="X-UA-Compatible" content="IE=edge" />
    <meta name="viewport" content="width=device-width, initial-scale=1.0" />
    <link rel="stylesheet" href="Content/Site.css" />
    <link rel="stylesheet" href="Content/font-face.css" />
    <link rel="stylesheet" href="Content/font-awesome-5.15.4.min.css" />
    <link rel="stylesheet" href="Content/bootstrap.min.css" />
    <link rel="stylesheet" href="Content/font-awesome-4.7.0.min.css" />
    <link rel="stylesheet" href="Content/google-material-symbols-rounded.css" />
    <script src="Scripts/jquery-3.6.1.min.js"></script>
    <script src="Scripts/typed.min.js"></script>
    <script src="Scripts/popper.min.js"></script>
    <script src="Scripts/bootstrap.min.js"></script>
    <style>
        /* navbar styking */
        .navbar.sticky {
            padding: 7.5px 0;
            display: block
        }

            .navbar.sticky a:hover {
                text-decoration: none;
            }

        .max-width {
            margin: auto 50px
        }

        /* table styling */
        .mt-5 {
            margin: auto -50px;
        }

        .wrapper {
            width: 680px;
            margin: 0 auto;
            padding: 20px 0 36%;
        }

        table tr td:last-child {
            width: 120px;
        }

        .table-responsive {
            display: contents;
            white-space: nowrap;
        }

        .btn-success {
            border: 2px solid rgb(52, 205, 133);
            background: rgb(52, 205, 133);
            margin: auto 10px;
        }

        table table-bordered table-condensed table-responsive table-hover .span {
            color: yellow;
        }

        .contact .right form .field,
        .contact .right form .fields .field {
            height: 45px;
            width: 100%;
            margin-bottom: 36px;
        }

        .contact .contact-content {
            justify-content: center;
        }

        .contact .title::after {
            content: "";
        }

        .contact .right form .email {
            margin-left: 0px;
        }

        /* Delete Column Styling */
        .delete-column {
            width: 10%;
        }

        /* footer styling */

        footer span .footer-anchor {
            color: rgb(52, 205, 133);
            text-decoration: none;
        }

            footer span .footer-anchor:hover {
                text-decoration: underline;
            }
    </style>
    <script>
        $('document').ready(function () {
            var typed = new Typed(".typing", {
                strings: ["Bank", "View Transactions"],
                typeSpeed: 80,
                backSpeed: 60,
                backDelay: 3600,
                cursorChar: '_',
                fadeOut: true,
                loop: true
            });
        });
    </script>
</head>
<body>
    <form id="form1" runat="server">

        <!-- Navigation bar -->

        <nav class="navbar sticky">
            <!-- Max-width class helps in responsiveness of the website -->
            <div class="max-width">
                <!-- Logo class returns the client to home page once clicked -->
                <div class="logo">
                    <asp:HyperLink ID="logoHyperLink" runat="server" NavigateUrl="~/Default.aspx">
                    AIU|<span class="typing"></span> 
                    </asp:HyperLink>
                </div>
                <!-- Navigation bar menu -->
                <ul class="menu" style="margin-right: -15%; margin-bottom: 0;">
                    <li>
                        <div class="tool-tip">
                            <asp:LinkButton ID="LinkButtonLogout" CssClass="logout-button" runat="server">
                            <i id="logout-icon1" class="material-symbols-rounded" style="font-weight:600;  font-size: 32px;">logout</i>
                            <i id="logout-icon2" class="material-symbols-rounded" style="font-weight:600; font-size: 32px;">door_open</i>
                            </asp:LinkButton>
                            <span class="tool-tiptext" style="width: 60px; margin-left: -35px;">Logout</span>
                        </div>
                    </li>
                </ul>
            </div>
        </nav>
        <section class="wrapper">
            <div class="container-fluid">
                <div class="row">
                    <div class="col-md-12">
                        <div class="mt-5 mb-3 clearfix">
                            <h2 class="pull-left">Transactions Details</h2>
                            <asp:LinkButton CssClass="btn btn-success pull-right" ID="LinkButtonCreate" runat="server" OnClick="LinkButtonCreate_Click"><i class="fa fa-plus"></i> New Transaction</asp:LinkButton>
                            <asp:LinkButton CssClass="btn btn-success pull-right" ID="LinkButtonDashboard" runat="server" OnClick="LinkButtonDashboard_Click"><i class="fa fa-home"></i> Dashboard</asp:LinkButton>
                        </div>
                        <div style="margin: auto; text-align-last: center; width: fit-content">
                            <asp:GridView CssClass="table table-bordered table-condensed table-responsive table-hover" ID="transactionsGridView" runat="server" DataSourceID="SqlDataSource1" DataKeyNames="ID" AutoGenerateColumns="False">
                                <Columns>
                                    <asp:BoundField DataField="ID" HeaderText="ID" InsertVisible="False" ReadOnly="True" SortExpression="ID" />
                                    <asp:BoundField DataField="Type" HeaderText="Type" SortExpression="Type" />
                                    <asp:BoundField DataField="FromAcc" HeaderText="FromAcc" SortExpression="FromAcc" />
                                    <asp:BoundField DataField="ToAcc" HeaderText="ToAcc" SortExpression="ToAcc" />
                                    <asp:BoundField DataField="Amount" HeaderText="Amount" SortExpression="Amount" />
                                    <asp:BoundField DataField="Time" HeaderText="Time" SortExpression="Time" />
                                    <asp:CommandField DeleteText="&lt;span class=&quot;fa fa-trash&quot;&gt;&lt;/span&gt;" HeaderText="Delete" HeaderStyle-CssClass="delete-column" ShowDeleteButton="True" />
                                </Columns>
                            </asp:GridView>
                            <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:ATM-BankConnectionString %>"
                                SelectCommand="SELECT t.ID, tt.Type, t.FromAcc, t.ToAcc, t.Amount, t.Time FROM Transactions AS t INNER JOIN TransactionsTypes AS tt ON t.Type = tt.ID"
                                DeleteCommand="DELETE FROM Transactions WHERE (ID = @ID)">
                                <DeleteParameters>
                                    <asp:Parameter Name="ID" Type="Int32" />
                                </DeleteParameters>
                            </asp:SqlDataSource>
                        </div>
                    </div>
                </div>
            </div>
        </section>
        <footer>
            <span>Designed By
                <asp:HyperLink ID="HyperLinkHYASoftware" CssClass="footer-anchor" runat="server">HYA - Software</asp:HyperLink>
                | <span class="fas fa-copyright"></span>
                2022 All rights reserved.
            </span>
        </footer>
    </form>
</body>
</html>
