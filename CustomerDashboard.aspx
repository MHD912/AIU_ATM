<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CustomerDashboard.aspx.cs" Inherits="AIU_ATM.CustomerDashboard" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Customer Dashboard</title>
    <meta charset="UTF-8" />
    <meta name="viewport" content="width = device-width, initial-scale=1.0" />
    <link rel="stylesheet" href="Content/Site.css" />
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
            </div>
        </nav>

        <!-- Home section start -->

        <section class="home" id="home">
            <!-- Max-width class helps in responsiveness of the website -->
            <div class="max-width">
                <div class="home-content">
                    <div class="text-2" style="color: #333;">Hi there customer <span style="color: rgb(52, 205, 133);">; )</span></div>
                    <div class="text-1" style="margin: 125px 0 40px;">
                        -your balance is<span style="color: rgb(52, 205, 133);">:</span> 0.0 S.P
                    </div>
                    <asp:Button Style="display: block; margin-bottom: 30px; width: 550px" class="btn" ID="ButtonWithdraw" runat="server" Text="Withdraw money" />
                    <asp:Button Style="display: block; margin-bottom: 30px; width: 550px" class="btn" ID="ButtomDeposit" runat="server" Text="Deposit money" />
                    <asp:Button Style="display: block; margin-bottom: 30px; width: 550px" class="btn" ID="ButtonTransfer" runat="server" Text="Transfer money" />
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

