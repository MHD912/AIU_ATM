<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AddTransaction.aspx.cs" Inherits="AIU_ATM.AddTransaction" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Create Transaction</title>
    <meta charset="UTF-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1.0" />
    <link rel="stylesheet" href="Content/font-face.css" />
    <link rel="stylesheet" href="Content/font-awesome-5.15.4.min.css" />
    <link rel="stylesheet" href="content/bootstrap.min.css" />
    <link rel="stylesheet" href="Content/Site.css" />
    <link rel="stylesheet" href="Content/google-material-symbols-rounded.css" />
    <script src="Scripts/jquery-3.6.1.min.js"></script>
    <script src="Scripts/typed.min.js"></script>

    <style>
        /* navbar styling */
        .navbar.sticky {
            padding: 7.5px 0;
            display: block
        }

            .navbar.sticky a:hover {
                text-decoration: none;
            }

        /* input table styling */
        .contact .inputTable {
            display: flex;
            align-items: flex-start;
            justify-content: center;
        }

        /* content styling */
        table {
            border-collapse: separate;
        }

            table tr {
                vertical-align: -webkit-baseline-middle;
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

        .contact .title::after {
            content: "create new transaction";
        }

        .contact .title::before {
            width: 7em;
        }

        .contact .right form .email {
            margin-left: 0px;
        }

        /* invalid-feedback styling */
        .form-group {
            margin-bottom: 10px;
        }

        .form-control.is-invalid {
            padding-right: 0.75em;
        }

        .invalid-feedback {
            margin: -9.6px 0;
            transform: translate(5px,9.6px);
        }


        /* other styling */
        .btn {
            padding: 8px;
            width: 35%;
            height: 100%;
            font-size: 17px;
            font-family: 'Poppins', sans-serif;
        }

        .text {
            font-size: 17px;
            font-weight: 500;
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
            $('input').click(function () {
                $(this).removeClass('is-invalid');
            });
            $("select").change(function () {
                $(this).find("option:selected").each(function () {
                    var optionValue = $(this).attr("value");
                    if (optionValue === "Transfer") {
                        $("#TableRowSenderUsername").show();
                        $("#TableRowRecipientUsername").show();
                        $("#TableRowAccountUsername").hide();
                    } else {
                        $("#TableRowSenderUsername").hide();
                        $("#TableRowRecipientUsername").hide();
                        $("#TableRowAccountUsername").show();
                    }
                });
            }).change();

            var typed = new Typed(".typing", {
                strings: ["Bank", "New Transaction"],
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

    <form id="form1" runat="server">
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
                            <asp:HyperLink ID="homeHyperLink" runat="server" NavigateUrl="~/AdminDashboard.aspx" ForeColor="White">
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

        <%-- Input form --%>

        <section class="contact" id="contact" style="margin-bottom: 8em;">
            <div class="max-width">
                <h2 class="title"></h2>
                <div class="inputTable">
                    <asp:Table ID="Table1" runat="server" CellSpacing="20" Width="45%">
                        <asp:TableRow runat="server" ID="TableRowAccountUsername">
                            <asp:TableCell runat="server">
                                <asp:Label ID="LabelAccountUsername" runat="server" Text="Account" CssClass="text"></asp:Label>
                            </asp:TableCell>
                            <asp:TableCell runat="server" Style="width: 61.115%;">
                                <div class="form-group">
                                    <asp:TextBox ID="TextBoxAccountNo" placeholder="Account Number" runat="server" CssClass="form-control"></asp:TextBox>
                                    <asp:Label ID="LabelAccountNoFeedback" CssClass="invalid-feedback" runat="server" Text="Label"></asp:Label>
                                </div>
                            </asp:TableCell>
                        </asp:TableRow>
                        <asp:TableRow runat="server" ID="TableRowSenderUsername">
                            <asp:TableCell runat="server">
                                <asp:Label ID="LabelSenderUsername" runat="server" Text="Sender account" CssClass="text"></asp:Label>
                            </asp:TableCell>
                            <asp:TableCell runat="server">
                                <div class="form-group" Style="width: 61.115%;">
                                    <asp:TextBox ID="TextBoxSenderNo" placeholder="AccountNumber" runat="server" CssClass="form-control"></asp:TextBox>
                                    <asp:Label ID="LabelSenderNoFeedback" CssClass="invalid-feedback" runat="server" Text="Label"></asp:Label>
                                </div>
                            </asp:TableCell>
                        </asp:TableRow>
                        <asp:TableRow runat="server" ID="TableRowRecipientUsername">
                            <asp:TableCell runat="server">
                                <asp:Label ID="LabelRecipientUsername" runat="server" Text="Recipient account" CssClass="text"></asp:Label>
                            </asp:TableCell>
                            <asp:TableCell runat="server">
                                <div class="form-group" Style="width: 61.115%;">
                                    <asp:TextBox ID="TextBoxRecipientNo" placeholder="AccountNumber" runat="server" CssClass="form-control"></asp:TextBox>
                                    <asp:Label ID="LabelRecipientNoFeedback" CssClass="invalid-feedback" runat="server" Text="Label"></asp:Label>
                                </div>
                            </asp:TableCell>
                        </asp:TableRow>
                        <asp:TableRow runat="server">
                            <asp:TableCell runat="server">
                                <asp:Label ID="LabelType" runat="server" Text="Transaction type" CssClass="text"></asp:Label>
                            </asp:TableCell>
                            <asp:TableCell runat="server">
                                <div class="form-group">
                                    <asp:DropDownList ID="DropDownListTransactionType" runat="server" CssClass="form-control" Style="width: 70%;">
                                        <asp:ListItem>Deposit</asp:ListItem>
                                        <asp:ListItem>Withdraw</asp:ListItem>
                                        <asp:ListItem>Transfer</asp:ListItem>
                                    </asp:DropDownList>
                                    <asp:Label ID="LabelTransactionTypeFeedback" CssClass="invalid-feedback" runat="server" Text="Label"></asp:Label>
                                </div>
                            </asp:TableCell>
                        </asp:TableRow>
                        <asp:TableRow runat="server">
                            <asp:TableCell runat="server">
                                <asp:Label ID="LabelAmount" runat="server" Text="Amount" CssClass="text"></asp:Label>
                            </asp:TableCell>
                            <asp:TableCell runat="server" Style="width: 61.115%;">
                                <div class="form-group">
                                    <asp:TextBox ID="TextBoxAmount" placeholder="Value" runat="server" CssClass="form-control" Style="width: 70%;" ></asp:TextBox>
                                    <asp:Label ID="LabelAmountFeedback" CssClass="invalid-feedback" runat="server" Text="Label"></asp:Label>
                                </div>
                            </asp:TableCell>
                        </asp:TableRow>
                        <asp:TableRow runat="server">
                            <asp:TableCell runat="server" Style="vertical-align: middle;">
                                <div class="tool-tip">
                                    <span class="material-symbols-rounded" style="font-weight: 700; color: rgb(52, 205, 133); transform: translateY(8px);">info</span>
                                    <span class="tool-tiptext" style="width: 300px; margin-left: -150px;">To enable printing. Please make sure your browser allows pop-ups for this website</span>
                                </div>
                                <span class="note">Note</span>
                            </asp:TableCell>
                            <asp:TableCell runat="server" Style="display: flex; justify-content: flex-end;">
                                <div class="tool-tip">
                                    <asp:LinkButton ID="LinkButtonPrint" runat="server" CssClass="btn" Style="transform: translateX(-10px); width: 47px; height: 40.8px;" OnClick="LinkButtonPrint_Click">
                                    <span class="material-symbols-rounded">print</span>
                                    </asp:LinkButton>
                                    <span class="tool-tiptext" style="width: 100px; margin-left: -60px;">Print receipt</span>
                                </div>
                                <asp:Button ID="ButtonSubmit" runat="server" type="submit" Text="Submit" CssClass="btn" OnClick="ButtonSubmit_Click" />
                            </asp:TableCell>
                        </asp:TableRow>
                    </asp:Table>
                </div>
            </div>
        </section>
    </form>
    <footer>
        <span>Designed By
            <asp:HyperLink ID="HyperLinkHYASoftware" runat="server" NavigateUrl="#">HYA - Software</asp:HyperLink>
            | <span class="fas fa-copyright"></span>
            2022 All rights reserved.
        </span>
    </footer>
</body>
</html>
