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
        /* navbar styling */
        .navbar.sticky {
            padding: 15px 0;
        }

        .navbar.sticky .menu {
            margin-right: -15%;
            display: inline-flex
        }

        /* Buttons styling */
        .actions {
            display: grid;
        }

            .actions .btn {
                font-family: 'Poppins', sans-serif;
                font-weight: 500;
                width: 550px;
            }

                .actions .btn span {
                    font-size: 34px;
                    font-weight: 500;
                    margin-right: 12px;
                    color: #333;
                    transition: all 0.3s ease;
                }

                .actions .btn:hover span {
                    color: #fff;
                }

        /* other styling */
        .text-1, .text {
            color: #111;
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
                <ul class="menu" style="margin-right: -15%; display: inline-flex">
                    <li>
                        <asp:DropDownList ID="DropDownListAccountType" CssClass="dropDownList" runat="server" Style="font-size: 18px; width: 75%; height: 40px; border: #fff; border-style: dashed; border-width: 2px; padding: 0 4px;" OnSelectedIndexChanged="DropDownListAccountType_SelectedIndexChanged" AutoPostBack="true">
                            <asp:ListItem Text="Current Account" id="li1" Enabled="false"/>
                            <asp:ListItem Text="Saving Account" id="li2" Enabled="false"/>
                            <asp:ListItem Text="Salary Account" id="li3" Enabled="false"/>
                        </asp:DropDownList>
                    </li>
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

