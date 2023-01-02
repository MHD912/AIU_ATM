<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CustomerDashboard.aspx.cs" Inherits="AIU_ATM.CustomerDashboard" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Customer Dashboard</title>
    <meta charset="UTF-8" />
    <meta name="viewport" content="width = device-width, initial-scale=1.0" />
    <link rel="stylesheet" href="Content/Site.css" />
    <link rel="stylesheet" href="Content/font-face.css" />
    <link rel="stylesheet" href="Content/font-awesome-5.15.4.min.css" />
    <link rel="stylesheet" href="Content/google-material-symbols-rounded.css" />
    <script src="Scripts/jquery-3.6.1.min.js"></script>
    <script src="Scripts/typed.min.js"></script>
    <style>
        .actions {
            display: grid;
        }

            .actions .btn span {
                font-size: 34px;
                font-weight: 500;
                margin-right: 12px;
                color: #333;
                transition: all 0.3s ease;
            }

        .btn {
            font-family: 'Poppins', sans-serif;
            font-weight: 500;
            cursor: pointer;
            width: 550px;
        }

            .btn:hover span {
                color: #fff;
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
                            <asp:HyperLink ID="HyperLinkLogout" CssClass="logout-button" runat="server" NavigateUrl="~/Default.aspx">
                            <i id="logout-icon1" class="material-symbols-rounded" style="font-weight:600;  font-size: 32px;">logout</i>
                            <i id="logout-icon2" class="material-symbols-rounded" style="font-weight:600; font-size: 32px;">door_open</i>
                            </asp:HyperLink>
                            <span class="tool-tiptext" style="width: 60px; margin-left: -35px;">Logout</span>
                        </div>
                    </li>
                </ul>
            </div>
        </nav>

        <!-- Home section start -->

        <section class="home" id="home" style="height: 94vh;">
            <!-- Max-width class helps in responsiveness of the website -->
            <div class="max-width">
                <div class="home-content">
                    <div class="text-2" style="color: #333;">
                        <asp:Label ID="welS" runat="server"></asp:Label>
                        <span style="color: rgb(52, 205, 133);">; )</span>
                    </div>
                    <div class="text-1" style="margin: 3em 0 2em;">
                        - Your balance is<span style="color: rgb(52, 205, 133);">:</span>
                        <asp:Label runat="server" Text="0$" ID="cusBal"></asp:Label>
                    </div>
                    <div class="actions">
                        <asp:LinkButton ID="LinkButtonDeposit" CssClass="btn" runat="server" OnClick="LinkButtonDeposit_Click">
                            <span class="material-symbols-rounded" style="margin-left: -27px">credit_score</span> Deposit Money
                        </asp:LinkButton>
                        <asp:LinkButton ID="LinkButtonWithdraw" CssClass="btn" runat="server" OnClick="LinkButtonWithdraw_Click">
                            <span class="material-symbols-rounded" style="margin-left: -2px">credit_card_off</span> Withdraw Money
                        </asp:LinkButton>
                        <asp:LinkButton ID="LinkButtonTransfer" CssClass="btn" runat="server" OnClick="LinkButtonTransfer_Click">
                            <span class="material-symbols-rounded" style="margin-left: -20px">repeat</span> Transfer Money
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

