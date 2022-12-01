﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ViewCustomers.aspx.cs" Inherits="Test.ViewCustomers" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>View Customers</title>
    <meta charset="UTF-8" />
    <meta http-equiv="X-UA-Compatible" content="IE=edge" />
    <meta name="viewport" content="width=device-width, initial-scale=1.0" />
    <link rel="stylesheet" href="style.css" />
    <link rel="stylesheet" href="source/css/all.min.css" />
    <link rel="stylesheet" href="https://stackpath.bootstrapcdn.com/bootstrap/4.5.2/css/bootstrap.min.css" />
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/font-awesome/4.7.0/css/font-awesome.min.css" />
    <script src="https://code.jquery.com/jquery-3.6.0.min.js"></script>
    <script src="https://cdnjs.cloudflare.com/ajax/libs/typed.js/2.0.12/typed.min.js"></script>
    <script src="https://cdn.jsdelivr.net/npm/popper.js@1.16.1/dist/umd/popper.min.js"></script>
    <script src="https://stackpath.bootstrapcdn.com/bootstrap/4.5.2/js/bootstrap.min.js"></script>
    <style>
        .mt-5 {
            margin: auto -50px;
        }

        .max-width {
            margin: auto 50px
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

        .errors-block {
            color: crimson;
            font-size: 14px;
        }

        .contact .title::after {
            content: "";
        }

        .contact .right form .email {
            margin-left: 0px;
        }


        footer {
            width: 100%;
            height: 100%;
            position: fixed;
        }

        .wrapper {
            width: 600px;
            margin: 0 auto;
        }

        table tr td:last-child {
            width: 120px;
        }

        .table-responsive {
            display: contents;
        }

        .btn-success {
            border: 2px solid rgb(52, 205, 133);
            background: rgb(52, 205, 133);
            margin: auto 10px;
        }

        table table-bordered table-condensed table-responsive table-hover .span {
            color: yellow;
        }

        /*////////////////////////////////////*/
        .navbar.sticky {
            background-color: rgb(52, 205, 133);
        }

            .navbar.sticky .logo a {
                color: #333;
                text-decoration: none;
            }

                .navbar.sticky .logo a:hover {
                    color: #fff;
                    text-decoration: none;
                }

                .navbar.sticky .logo a span {
                    color: #fff;
                    text-decoration: none;
                }

                .navbar.sticky .logo a:hover span {
                    color: #333;
                    text-decoration: none;
                }
    </style>
    <script>
        $('document').ready(function () {
            var typed = new Typed(".typing", {
                strings: ["Bank", "View Info."],
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
        </div>
    </nav>

    <div class="wrapper">
        <div class="container-fluid">
            <div class="row">
                <div class="col-md-12">
                    <form id="form1" runat="server">
                        <div class="mt-5 mb-3 clearfix">
                            <h2 class="pull-left">Users Details</h2>
                            <asp:LinkButton CssClass="btn btn-success pull-right" ID="LinkButtonCreate" runat="server" OnClick="LinkButtonCreate_Click"><i class="fa fa-plus"></i> Add New Customer</asp:LinkButton>
                            <asp:LinkButton CssClass="btn btn-success pull-right" ID="LinkButtonDashboard" runat="server" OnClick="LinkButtonDashboard_Click"><i class="fa fa-home"></i> Dashboard</asp:LinkButton>
                        </div>
                        <div style="margin: auto -100px 0 -60px;">
                            <asp:GridView CssClass="table table-bordered table-condensed table-responsive table-hover" ID="customersGridView" runat="server" DataSourceID="SqlDataSource1" Width="100%" AutoGenerateColumns="False">
                                <Columns>
                                    <asp:CommandField ShowHeader="false" CancelText="&lt;span class=&quot;fa fa-close&quot;&gt;&lt;/span&gt;" DeleteText="&lt;span class=&quot;fa fa-trash&quot;&gt;&lt;/span&gt;" EditText="&lt;span class=&quot;fa fa-pencil&quot;&gt;&lt;/span&gt;" ShowEditButton="True" UpdateText="&lt;span class=&quot;fa fa-check&quot;&gt;&lt;/span&gt;" SelectText="&lt;a href=&quot;ViewCustomerDetail.aspx&quot;&gt;&lt;span class=&quot;fa fa-eye&quot;&gt;&lt;/span&gt;&lt;/a&gt;" ShowDeleteButton="True" ShowSelectButton="True" HeaderText="Action">
                                        <ItemStyle HorizontalAlign="Justify" Wrap="False" />
                                    </asp:CommandField>
                                    <asp:BoundField DataField="Name" HeaderText="Name" SortExpression="Name" />
                                    <asp:BoundField DataField="Email" HeaderText="Email" SortExpression="Email" />
                                    <asp:BoundField DataField="Balance" HeaderText="Balance" InsertVisible="False" ReadOnly="True" SortExpression="Balance" />
                                </Columns>
                            </asp:GridView>
                            <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:ATM-BankConnectionString %>" SelectCommand="SELECT [ID], [MiddleName], [FirstName], [LastName], [Phone], [Gender] FROM [UsersInfo]"></asp:SqlDataSource>
                        </div>

                    </form>
                </div>
            </div>
        </div>
    </div>
</body>
</html>