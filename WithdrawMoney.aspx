<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WithdrawMoney.aspx.cs" Inherits="AIU_ATM.WithdrawMoney" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <title>Withdraw Money</title>
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


        /*.navbar.sticky {
            padding: 10.6px 0;
        }*/

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
                strings: ["Bank", "Withdraw"],
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
                <div class="logo">
                    <asp:HyperLink ID="logoHyperLink" runat="server" NavigateUrl="~/Default.aspx">
                        AIU|<span class="typing"></span> 
                    </asp:HyperLink>
                </div>
                <!-- Navigation bar menu -->
                <ul class="menu">
                    <li>
                        <asp:HyperLink ID="homeHyperLink" runat="server" NavigateUrl="~/CustomerDashboard.aspx" ForeColor="White">
                            <span class="fas fa-home" style="font-size: 25px;"/>
                        </asp:HyperLink>
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
                        <asp:Label ID="welS" runat="server"></asp:Label>
                        <span style="color: rgb(52, 205, 133);">; )</span>
                    </div>
                    <div class="text-1" style="margin-bottom: 40px;">
                        - Your balance is:
                        <asp:Label runat="server" Text="0$" ID="cusBal"></asp:Label>
                    </div>
                    <div class="text-1">Withdraw: </div>
                    <asp:TextBox runat="server" CssClass="input" Style="width: 220px; margin-top: 10px; margin-right: 5px; height: 50px;" ID="TextBoxWithdrawAmount" type="text"></asp:TextBox>$<br />
                    <asp:Button Style="display: block; margin-top: 30px; margin-bottom: 30px; width: 550px" class="btn" ID="ButtonWithdraw" runat="server" Text="Withdraw Money" OnClick="ButtonWithdraw_Click" />
                </div>
            </div>
        </section>
    </form>
</body>
</html>
