<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AdminDashboard.aspx.cs" Inherits="AIU_ATM.AdminDashboard" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Admin Dashboard</title>
    <meta charset="UTF-8" />
    <meta name="viewport" content="width = device-width, initial-scale=1.0" />
    <link rel="stylesheet" href="Content/Site.css" />
    <link rel="stylesheet" href="Content/font-face.css" />
    <link rel="stylesheet" href="Content/font-awesome-5.15.4.min.css" />
    <link rel="stylesheet" href="Content/google-material-symbols-rounded.css" />
    <script src="Scripts/jquery-3.6.1.min.js"></script>
    <script src="Scripts/typed.min.js"></script>
    <style>
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

        .btn {
            font-family: 'Poppins', sans-serif;
            border: none;
            background: none;
            color: #fff;
            font-size: 22px;
            font-weight: 500;
            cursor: pointer;
        }

        .home .home-content a {
            font-family: 'Poppins', sans-serif;
            font-size: 22px;
            font-weight: 500;
            border: none;
            border-radius: 6px;
            margin-top: 0;
            margin-bottom: 10px;
            padding: 10px 0;
            display: inline-flex;
            cursor: pointer;
            justify-content: center;
            transition: all 0.3s ease;
        }

        .home .home-content .actions-box span {
            padding: 0 10px 0 0;
            font-size: 35px;
            font-weight: 400;
            color: #333;
            transition: all 0.3s ease;
        }

        .home .home-content .actions-box a:hover span {
            color: #fff;
            transition: all 0.3s ease;
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
                <ul class="menu" style="margin-right: -15%;">
                    <li>
                        <div class="tool-tip">
                            <asp:LinkButton ID="LinkButtonLogout" CssClass="logout-button" runat="server" OnClick="LinkButtonLogout_Click">
                            <i id="logout-icon1" class="material-symbols-rounded" style="font-weight:600; font-size: 32px;" >logout</i>
                            <i id="logout-icon2" class="material-symbols-rounded" style="font-weight:600; font-size: 32px;" >door_open</i>
                            </asp:LinkButton>
                            <span class="tool-tiptext" style="width:60px; margin-left: -35px;">Logout</span>                            
                        </div>
                    </li>
                </ul>
            </div>
        </nav>

        <!-- Home section start -->

        <section class="home" id="home" style="margin-bottom: -3em;">
            <!-- Max-width class helps in responsiveness of the website -->
            <div class="max-width">
                <div class="home-content">
                    <div class="text-2" style="color: #333;">
                        <asp:Label ID="welS" runat="server"></asp:Label><span style="color: rgb(52, 205, 133);"> ; )</span>
                    </div>
                    <div class="text-1" style="margin: 5em 0 2em; color: #111;">-Choose from the actions below :</div>
                    <div class="actions-box" style="width: 75%;">
                        <asp:LinkButton ID="LinkButtonViewTransactions" runat="server" Style="width: 99.5%;" OnClick="LinkButtonViewTransactions_Click">
                            <span class="material-symbols-rounded">receipt_long</span>View Transactions
                        </asp:LinkButton>
                        <asp:LinkButton ID="LinkButtonAddUser" runat="server" Style="width: 49%; margin-right: 7px;" OnClick="LinkButtonAddUser_Click">
                            <span class="material-symbols-rounded">person_add</span>Add New User
                        </asp:LinkButton>
                        <asp:LinkButton ID="LinkButtonViewUsers" runat="server" Style="width: 48%;" OnClick="LinkButtonViewUsers_Click">
                            <span class="material-symbols-rounded">groups</span>View Users
                        </asp:LinkButton>
                    </div>
                </div>
            </div>
        </section>
        <footer>
            <span>Designed By <a href="#">HYA - Software</a> | <span class="fas fa-copyright"></span>
                2022 All rights reserved.
            </span>
        </footer>
    </form>
</body>
</html>
