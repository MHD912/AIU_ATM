<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="TransferMoney.aspx.cs" Inherits="AIU_ATM.TransferMoney" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Transfer Money</title>
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
            font-family: 'Poppins', sans-serif;
            font-weight: 500;
            cursor: pointer;
            width: 550px;
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
                    <asp:LinkButton ID="LinkButtonBack" runat="server" Style="margin-right: 60px;" OnClick="LinkButtonBack_Click">
                        <span class="material-symbols-rounded" style="font-size: 42px; font-weight: 300; transform: translate(-10px, 7px);" >arrow_circle_left</span>
                    </asp:LinkButton>
                    <asp:HyperLink ID="logoHyperLink" runat="server" NavigateUrl="~/Default.aspx">
                        AIU|<span class="typing"></span> 
                    </asp:HyperLink>
                </div>
                <!-- Navigation bar menu -->
                <ul class="menu" style="margin-right: -13%;">
                    <li style="transform: translateY(-3px);">
                        <div class="tool-tip">
                            <asp:HyperLink ID="homeHyperLink" runat="server" NavigateUrl="~/AdminDashboard.aspx" ForeColor="White">
                                <i class="fas fa-home" style="font-size: 26px;"></i>
                            </asp:HyperLink>
                            <span class="tool-tiptext" style="width: 80px; margin-left: -27px; top: 141%;">Dashboard</span>
                        </div>
                    </li>
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

        <section class="home" id="home">
            <!-- Max-width class helps in responsiveness of the website -->
            <div class="max-width">
                <div class="home-content">
                    <div class="text-2" style="color: #333;">Hi there customer <span style="color: rgb(52, 205, 133);">; )</span></div>
                    <div class="text-1" style="margin: 2em 0 2em;">
                        - Your balance is<span style="color: rgb(52, 205, 133);">:</span> 0 S.P
                    </div>
                    <div>
                        <asp:Table ID="TableActions" runat="server" CellSpacing="5">
                            <asp:TableRow>
                                <asp:TableCell>
                                    <asp:Label ID="LabelRecipient" CssClass="text-1" Style="font-size: 20px;" runat="server" Text="Recipient: "></asp:Label>
                                </asp:TableCell>
                                <asp:TableCell>
                                    <asp:TextBox ID="TextBoxRecipient" CssClass="input" Style="width: 285px; margin-top: 10px; margin-right: 5px; margin-bottom: 10px; height: 50px" placeholder="Account Number" runat="server"></asp:TextBox>
                                </asp:TableCell>
                            </asp:TableRow>
                            <asp:TableRow>
                                <asp:TableCell>
                                    <asp:Label ID="LabelTransferValue" CssClass="text-1" Style="font-size: 20px;" runat="server" Text="Transfer Value: "></asp:Label>
                                </asp:TableCell>
                                <asp:TableCell>
                                    <asp:TextBox ID="TextBoxTransferValue" CssClass="input" Style="width: 205px; margin-top: 10px; margin-right: 5px; height: 50px" placeholder="150000" runat="server"></asp:TextBox>S.P
                                </asp:TableCell>
                            </asp:TableRow>
                        </asp:Table>
                        <asp:Button ID="ButtonTransfer" class="btn" Style="display: block; margin-top: 30px; margin-bottom: 30px; width: 400px; font-size: 23px;" runat="server" Text="Transfer Money" OnClick="ButtonTransfer_Click" />
                    </div>
                </div>
            </div>
        </section>
    </form>
</body>
</html>

