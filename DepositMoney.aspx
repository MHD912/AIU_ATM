<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="DepositMoney.aspx.cs" Inherits="AIU_ATM.DepositMoney" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Deposit Money</title>
    <meta charset="UTF-8" />
    <meta name="viewport" content="width = device-width, initial-scale=1.0" />
    <link rel="stylesheet" href="Content/Site.css" />
    <link rel="stylesheet" href="Content/font-face.css" />
    <link rel="stylesheet" href="Content/font-awesome-5.15.4.min.css" />
    <link rel="stylesheet" href="Content/google-material-symbols-rounded.css" />
    <script src="Scripts/jquery-3.6.1.min.js"></script>
    <script src="Scripts/typed.min.js"></script>
    <style>

        .btn {
            font-family: 'Ubuntu', sans-serif;
            width: 8em;
            height: 3em;
            border: 2px solid rgb(52, 205, 133);
            background: rgb(52, 205, 133);
            color: #fff;
            font-size: 22px;
            font-weight: 400;
            border-radius: 6px;
            cursor: pointer;
            transition: all 0.3s ease;
            margin-inline-end: 60px
        }

            .btn:hover {
                color: rgb(52, 205, 133);
                background: none;
            }

        .dropDownList {
            font-family: 'Poppins', sans-serif;
            font-size: 18px;
            width: 8em;
            height: 3em;
            border: 2px solid rgb(52, 205, 133);
            background: rgb(52, 205, 133);
            color: #fff;
            font-size: 22px;
            font-weight: 400;
            border-radius: 6px;
            cursor: pointer;
            transition: all 0.3s ease;
            margin-inline-end: 60px;
            outline: none;
        }

            .dropDownList .listItem {
                color: #222;
                background: #fff;
            }

                .dropDownList .listItem:hover {
                    color: rgb(52, 205, 133);
                    background: none;
                }

        .navbar.sticky {
            padding: 10.6px 0;
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
            <div class="max-width" style="margin: 0 50px; padding: 0;">
                <!-- Logo class returns the client to home page once clicked -->
                <div class="logo">
                    <asp:LinkButton ID="LinkButtonBack" runat="server" style="margin-right: 60px;" OnClick="LinkButtonBack_Click">
                        <span class="material-symbols-rounded" style="font-size: 42px; font-weight: 300; transform: translate(-10px, 7px);" >arrow_circle_left</span>
                    </asp:LinkButton>
                    <asp:HyperLink ID="logoHyperLink" runat="server" NavigateUrl="~/Default.aspx">
                        AIU|<span class="typing"></span> 
                    </asp:HyperLink>
                </div>
                <!-- Navigation bar menu -->
                <ul class="menu" style="margin-right: -13%;">
                    <li style="transform: translateY(-3px);">
                        <div class="tooltip">
                            <asp:HyperLink ID="homeHyperLink" runat="server" NavigateUrl="~/AdminDashboard.aspx" ForeColor="White">
                                <i class="fas fa-home" style="font-size: 26px;"></i>
                            </asp:HyperLink>
                            <span class="tooltiptext" style="width: 80px; margin-left: -27px; top: 141%;">Dashboard</span>
                        </div>
                    </li>
                    <li>
                        <div class="tooltip">
                            <asp:HyperLink ID="HyperLinkLogout" CssClass="logout-button" runat="server" NavigateUrl="~/Default.aspx">
                            <i id="logout-icon1" class="material-symbols-rounded" style="font-weight:600;  font-size: 32px;">logout</i>
                            <i id="logout-icon2" class="material-symbols-rounded" style="font-weight:600; font-size: 32px;">door_open</i>
                            </asp:HyperLink>
                            <span class="tooltiptext" style="width: 60px; margin-left: -35px;">Logout</span>
                        </div>
                    </li>
                </ul>
            </div>
        </nav>

        <!-- Home section start -->

        <section class="home" id="home">
            <!-- Max-width class helps in responsiveness of the website -->
            <div class="max-width">
                <div class="home-content">
                    <div class="text-2" style="color: #333; margin-bottom: 3em;">
                        <asp:Label ID="welS" runat="server"></asp:Label> <span style="color: rgb(52, 205, 133);">; )</span>
                    </div>
                    <div class="text-1" style="margin-bottom: 40px;">
                        - Your balance is: <asp:Label runat="server" Text="0$" ID="cusBal"></asp:Label>
                    </div>
                    <div class="text-1">Deposit: </div>
                    <asp:TextBox runat="server" Style="width: 220px; margin-top: 10px; margin-right: 5px; height: 50px;" class="input" ID="TextBoxDepositAmount" type="text"></asp:TextBox>$<br />
                    <asp:Button Style="display: block; margin-top: 30px; margin-bottom: 30px; width: 550px" class="btn" ID="ButtonDeposite" runat="server" Text="Deposite money" OnClick="ButtonDeposite_Click" />
                </div>
            </div>
        </section>
    </form>
</body>
</html>
