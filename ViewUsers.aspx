<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ViewUsers.aspx.cs" Inherits="AIU_ATM.ViewUsers" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>View Users</title>
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
        /* navbar styling */
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

        .contact .right form .email {
            margin-left: 0px;
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
                strings: ["Bank", "View Users"],
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
                            <asp:LinkButton ID="LinkButtonLogout" CssClass="logout-button" runat="server" OnClick="LinkButtonLogout_Click">
                            <i id="logout-icon1" class="material-symbols-rounded" style="font-weight:600;  font-size: 32px;">logout</i>
                            <i id="logout-icon2" class="material-symbols-rounded" style="font-weight:600; font-size: 32px;">door_open</i>
                            </asp:LinkButton>
                            <span class="tool-tiptext" style="width: 60px; margin-left: -35px;">Logout</span>
                        </div>
                    </li>
                </ul>
            </div>
        </nav>

        <div class="wrapper">
            <div class="container-fluid">
                <div class="row">
                    <div class="col-md-12">
                        <div class="mt-5 mb-3 clearfix">
                            <h2 class="pull-left" id="table_title"><asp:Label runat="server" ID="tableText" Text="Customers Details"></asp:Label></h2>
                            <label class="switch pull-left" style="margin: 10px 0 auto 20px;">
                                <asp:CheckBox ID="CheckBoxPrivilgeToggle" runat="server" AutoPostBack="true"/>
                                <span class="slider round"></span>
                            </label>
                            <asp:LinkButton CssClass="btn btn-success pull-right" ID="LinkButtonCreate" runat="server" OnClick="LinkButtonCreate_Click"><i class="fa fa-plus"></i> Add New User</asp:LinkButton>
                            <asp:LinkButton CssClass="btn btn-success pull-right" ID="LinkButtonDashboard" runat="server" OnClick="LinkButtonDashboard_Click"><i class="fa fa-home"></i> Dashboard</asp:LinkButton>
                        </div>
                    </div>
                    <div style="margin: auto; text-align-last: center; width: fit-content;">
                        <asp:GridView CssClass="table table-bordered table-condensed table-responsive table-hover"
                            ID="usersGridView" runat="server" Width="100%" AutoGenerateColumns="false" OnSelectedIndexChanged="usersGridView_SelectedIndexChanged" DataKeyNames="UserName" OnRowDeleting="usersGridView_RowDeleting">
                            <Columns>
                                <asp:CommandField ShowHeader="false"
                                    CancelText="&lt;span class=&quot;fa fa-close&quot;&gt;&lt;/span&gt;"
                                    DeleteText="&lt;span class=&quot;fa fa-trash&quot;&gt;&lt;/span&gt;"
                                    EditText="&lt;span class=&quot;fa fa-pencil&quot;&gt;&lt;/span&gt;"
                                    UpdateText="&lt;span class=&quot;fa fa-check&quot;&gt;&lt;/span&gt;"
                                    SelectText="&lt;span class=&quot;fa fa-eye&quot;&gt;&lt;/span&gt;"
                                    ShowEditButton="True"
                                    ShowDeleteButton="True"
                                    ShowSelectButton="True"
                                    HeaderText="Action">
                                    <ItemStyle HorizontalAlign="Justify" Wrap="False" />
                                </asp:CommandField>
                                <asp:BoundField DataField="UserName" HeaderText="UserName" SortExpression="UserName" />
                                <asp:BoundField DataField="Email" HeaderText="Email" SortExpression="Email" />
                                <asp:BoundField DataField="BirthDate" HeaderText="BirthDate" SortExpression="BirthDate" />
                                <asp:BoundField DataField="Gender" HeaderText="Gender" SortExpression="Gender" ItemStyle-Width="2em" />
                            </Columns>
                        </asp:GridView>

                        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:ATM-BankConnectionString %>"
                            
                            DeleteCommand="delete from UsersInfo
                                where ID = (select ID from Users where UserName = @UserName)">
                            
                        </asp:SqlDataSource>
                    </div>
                </div>
            </div>
        </div>
       
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
