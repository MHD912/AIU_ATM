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
    <link rel="stylesheet" href="content/bootstrap.min.css" />
    <link rel="stylesheet" href="Content/google-material-symbols-rounded.css" />
    <script src="Scripts/jquery-3.6.1.min.js"></script>
    <script src="Scripts/typed.min.js"></script>
    <style>
        /* navbar styling */
        .navbar.sticky {
            padding: 7.5px 0;
            display: block;
            position: fixed;
        }

            .navbar.sticky a:hover {
                text-decoration: none;
            }

        /* input table styling */
        .form-control {
            width: 205px;
            margin-top: 10px;
            margin-right: 5px;
            height: 50px
        }

        table {
            border-collapse: separate;
        }

            table tr {
                vertical-align: -webkit-baseline-middle;
            }

        /* other styling */
        .home {
            color: #111;
            margin-bottom: -3em
        }

        #TableActions .text-1 {
            font-size: 20px;
        }

        /* other content styling */
        .form-group {
            margin-bottom: 10px;
        }

        .invalid-feedback {
            margin: -9.6px 0;
            transform: translateY(9.6px);
        }

        .btn {
            padding: 8px 15px;
            font-size: 20px;
            font-family: 'Poppins', sans-serif;
            background: rgb(52, 205, 133);
            color: #fff;
            border-radius: 6px;
        }

            .btn:hover {
                color: #fff;
            }

        .note {
            font-size: 14px;
            font-style: italic;
            text-decoration: underline;
        }

        footer span a:hover {
            color: rgb(52, 205, 133);
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
                    <asp:LinkButton ID="LinkButtonBack" runat="server" Style="margin-right: 60px;" OnClick="LinkButtonBack_Click">
                        <span class="material-symbols-rounded" style="font-size: 42px; font-weight: 300; transform: translate(-10px, 7px);" >arrow_circle_left</span>
                    </asp:LinkButton>
                    <asp:HyperLink ID="logoHyperLink" runat="server" NavigateUrl="~/Default.aspx">
                        AIU|<span class="typing"></span> 
                    </asp:HyperLink>
                </div>
                <!-- Navigation bar menu -->
                <ul class="menu" style="margin-right: -13%; margin-bottom: 0;">
                    <li style="transform: translateY(-3px);">
                        <div class="tool-tip">
                            <asp:HyperLink ID="homeHyperLink" runat="server" NavigateUrl="~/CuDashboard.aspx" ForeColor="White">
                                <i class="fas fa-home" style="font-size: 26px;"></i>
                            </asp:HyperLink>
                            <span class="tool-tiptext" style="width: 80px; margin-left: -27px; top: 141%;">Dashboard</span>
                        </div>
                    </li>
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
                        - Your balance is<span style="color: rgb(52, 205, 133);">:</span>
                        <asp:Label runat="server" Text="0$" ID="cusBal"></asp:Label>
                    </div>
                    <div>
                        <asp:Table ID="TableActions" runat="server" CellSpacing="5">
                            <asp:TableRow>
                                <asp:TableCell>
                                    <asp:Label ID="LabelDepositAmount" CssClass="text-1" runat="server" Text="Deposit "></asp:Label>
                                </asp:TableCell>
                                <asp:TableCell>
                                    <div class="form-group">
                                        <asp:TextBox ID="TextBoxDepositAmount" CssClass="form-control" placeholder="Amount" runat="server" required="true"></asp:TextBox>
                                        <asp:Label ID="LabelDepositAmountFeedback" CssClass="invalid-feedback" runat="server" Text="Label"></asp:Label>
                                    </div>
                                </asp:TableCell>
                            </asp:TableRow>
                            <asp:TableRow>
                                <asp:TableCell>
                                    <asp:Label ID="LabelPinCode" CssClass="text-1" runat="server" Text="Pin code"></asp:Label>
                                </asp:TableCell>
                                <asp:TableCell>
                                    <div class="form-group">
                                        <asp:TextBox ID="TextBoxPinCode" CssClass="form-control" runat="server" TextMode="Password" placeholder="####" required="true"></asp:TextBox>
                                        <asp:Label ID="LabelPinCodeFeedback" CssClass="invalid-feedback" runat="server" Text="Label"></asp:Label>
                                    </div>
                                </asp:TableCell>
                            </asp:TableRow>
                            <asp:TableRow>
                                <asp:TableCell ColumnSpan="2">
                                    <asp:Button ID="ButtonDeposite" CssClass="btn" runat="server" Text="Deposite Money" OnClick="ButtonDeposite_Click" />
                                    <div class="tool-tip">
                                        <asp:LinkButton ID="LinkButtonPrint" runat="server" CssClass="btn" Style="transform: translateX(10px); padding: 12px 15px" OnClick="LinkButtonPrint_Click">
                                    <span class="material-symbols-rounded">print</span>
                                        </asp:LinkButton>
                                        <span class="tool-tiptext" style="width: 100px; margin-left: -40px;">Print receipt</span>
                                    </div>
                                </asp:TableCell>
                            </asp:TableRow>
                            <asp:TableRow>
                                <asp:TableCell Style="display: flex; justify-content: flex-end;">
                                    <div class="tool-tip">
                                        <span class="material-symbols-rounded" style="font-weight: 700; color: rgb(52, 205, 133); transform: translateY(8px);">info</span>
                                        <span class="tool-tiptext" style="width: 270px; margin-left: -135px;">To enable printing. Please make sure your browser allows pop-ups for this website</span>
                                    </div>
                                    <span class="note">Note</span>
                                </asp:TableCell>
                            </asp:TableRow>
                        </asp:Table>
                    </div>
                </div>
            </div>
        </section>
        <footer>
            <span>Designed By
                <asp:HyperLink ID="HyperLinkHYASoftware" runat="server" NavigateUrl="#">HYA - Software</asp:HyperLink>
                | <span class="fas fa-copyright"></span>
                2022 All rights reserved.
            </span>
        </footer>
    </form>
</body>
</html>
