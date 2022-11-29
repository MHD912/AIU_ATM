<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AdminDashboard.aspx.cs" Inherits="Test.AdminDashboard" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Admin Dashboard</title>
    <meta charset="UTF-8" />
    <meta name="viewport" content="width = device-width, initial-scale=1.0" />
    <link rel="stylesheet" href="style.css" />
    <link rel="stylesheet" href="source/css/all.min.css" />
    <link rel="stylesheet" href="source/css/fontawesome.min.css" />
    <script src="https://code.jquery.com/jquery-3.6.0.min.js"></script>
    <script src="https://cdnjs.cloudflare.com/ajax/libs/typed.js/2.0.12/typed.min.js"></script>
    <style>
        .home {
            background: url(source/wallpaper.png) no-repeat center;
            color: #111;
        }

        .btn {
            font-family: 'Ubuntu', sans-serif;
            border: none;
            background: none;
            color: rgb(52, 205, 133);
            font-size: 22px;
            font-weight: 400;
            border-radius: 6px;
            cursor: pointer;
            transition: all 0.3s ease;
            margin-inline-end: 60px;
            text-decoration-line: underline;
            text-decoration-style: dashed;
            text-decoration-color: #111;
        }

            .btn:hover {
                /*text-decoration-style: solid;*/
                text-decoration-color: rgb(52, 205, 133);
            }

        .navbar.sticky {
            background-color: rgb(52, 205, 133);
        }

            .navbar.sticky .logo a {
                color: #333;
            }

                .navbar.sticky .logo a:hover {
                    color: #fff;
                }

                .navbar.sticky .logo a span {
                    color: #fff;
                }

                .navbar.sticky .logo a:hover span {
                    color: #333;
                }


        .typing {
            color: rgb(52, 205, 133);
        }

        .actions-list {
            margin-bottom: 1em;
        }

        footer {
            width: 100%;
            height: 100%;
            position: fixed;
        }
    </style>
    <script>
        $('document').ready(function () {
            var typed = new Typed(".typing", {
                strings: ["Bank", "Dashboard"],
                typeSpeed: 100,
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
                <ul class="menu">
                    <li>
                        <asp:HyperLink Style="color: #fff;" ID="HyperLinkLogout" runat="server">Logout</asp:HyperLink>
                    </li>
                </ul>
            </div>
        </nav>

        <!-- Home section start -->

        <section class="home" id="home" style="margin-bottom: -3em;">
            <!-- Max-width class helps in responsiveness of the website -->
            <div class="max-width">
                <div class="home-content">
                    <div class="text-2" style="color: #333;">Hi there Admin <span style="color: rgb(52, 205, 133);">; )</span></div>
                    <div class="text-1" style="margin: 5em 0 2em;">-Choose from the actions below :</div>
                    <div class="actions-list">
                        <span class="fas fa-arrow-right" style="font-size: 20px;" />
                        <asp:Button ID="ButtonViewCustomers" CssClass="btn" runat="server" Text="View Customers" OnClick="ButtonViewCustomers_Click" />
                    </div>
                    <br />
                    <div class="actions-list">
                        <span class="fas fa-arrow-right" style="font-size: 20px;" />
                        <asp:Button ID="ButtonViewTransactions" CssClass="btn" runat="server" Text="View Transactions" OnClick="ButtonViewTransactions_Click" />
                    </div>
                    <br />
                    <div class="actions-list">
                        <span class="fas fa-arrow-right" style="font-size: 20px;" />
                        <asp:Button ID="ButtonCreateCustomer" CssClass="btn" runat="server" Text="Create Customer" OnClick="ButtonCreateCustomer_Click" /><br />
                    </div>
                </div>
            </div>
        </section>
        <footer>
            <span>Designed By <a href="#">Hussein912</a> | <span class="fas fa-copyright"></span>
                2022 All rights reserved.
            </span>
        </footer>
    </form>
</body>
</html>
