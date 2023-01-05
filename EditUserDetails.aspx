﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="EditUserDetails.aspx.cs" Inherits="AIU_ATM.EditUserDetails" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">

<head runat="server">
    <title>Edit User Information</title>
    <meta charset="UTF-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1.0" />
    <link rel="stylesheet" href="Content/Site.css" />
    <link rel="stylesheet" href="Content/font-face.css" />
    <link rel="stylesheet" href="Content/font-awesome-5.15.4.min.css" />
    <link rel="stylesheet" href="Content/google-material-symbols-rounded.css" />
    <script src="Scripts/jquery-3.6.1.min.js"></script>
    <script src="Scripts/typed.min.js"></script>

    <style>
        /* navbar styling */
        .navbar.sticky {
            padding: 10.6px 0;
        }

        /* input table styling */
        .contact .right form .field,
        .contact .right form .fields .field {
            height: 45px;
            width: 100%;
            margin-bottom: 36px;
        }

        .contact .contact-content {
            justify-content: center;
        }

        .contact .title::before {
            width: 300px;
        }

        .contact .title::after {
            content: "edit user information";
            color: rgb(52, 205, 133);
        }

        .contact .right form .email {
            margin-left: 0px;
        }

        /* other content styling */
        .btn {
            padding: 8px;
            width: 35%;
            height: 100%;
            font-size: 17px;
            font-weight: 400;
            font-family: 'Poppins', sans-serif;
        }

        .errors-block {
            color: crimson;
            font-size: 14px;
        }

        .text {
            font-size: 17px;
            font-weight: 500;
        }

        .typing {
            color: rgb(52, 205, 133);
        }
    </style>
    <script>
        $('document').ready(function () {
            $('#CheckBoxUserType').on("change", function () {
                $("#TableRowBalance").toggle(!this.checked);
                $("#TableRowPinCode").toggle(!this.checked);
                $("#TableRowConfirmPin").toggle(!this.checked);
                if ($(this).prop("checked") === true) {
                    $("#contact").css("margin-bottom", "8em");
                }
                else {
                    $("#contact").css("margin-bottom", "16em");
                }
            });
            var typed = new Typed(".typing", {
                strings: ["Bank", "Edit Info."],
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

        <%-- Input form --%>

        <section class="contact" id="contact" style="margin-bottom: 16em;">
            <div class="max-width">
                <h2 class="title"></h2>
                <div class="inputTable">
                    <asp:Table ID="Table1" runat="server" Height="100%" Width="100%" CellSpacing="20">
                        <asp:TableRow runat="server">
                            <asp:TableCell runat="server">
                                <asp:Label ID="LabelName" runat="server" Text="Name" CssClass="text">
                                </asp:Label>
                            </asp:TableCell>
                            <asp:TableCell runat="server">
                                <asp:TextBox ID="TextBoxFirstName" placeholder="First" runat="server" CssClass="input"></asp:TextBox>
                            </asp:TableCell>
                            <asp:TableCell runat="server">
                                <asp:TextBox ID="TextBoxMidName" placeholder="Middle" runat="server" CssClass="input"></asp:TextBox>
                            </asp:TableCell>
                            <asp:TableCell runat="server">
                                <asp:TextBox ID="TextBoxLastName" placeholder="Last" runat="server" CssClass="input"></asp:TextBox>
                            </asp:TableCell>
                        </asp:TableRow>
                        <asp:TableRow runat="server">
                            <asp:TableCell runat="server">
                                <asp:Label ID="LabelUserName" runat="server" Text="Username" CssClass="text">
                                </asp:Label>
                            </asp:TableCell>
                            <asp:TableCell runat="server">
                                <asp:TextBox ID="TextBoxUserName" placeholder="Username" runat="server" CssClass="input"></asp:TextBox>
                            </asp:TableCell>
                        </asp:TableRow>
                        <asp:TableRow runat="server">
                            <asp:TableCell runat="server">
                                <asp:Label ID="LabelPassword" runat="server" Text="Password" CssClass="text">
                                </asp:Label>
                            </asp:TableCell>
                            <asp:TableCell runat="server">
                                <asp:TextBox ID="TextBoxPassword" placeholder="Password" type="password" runat="server" CssClass="input"></asp:TextBox>
                            </asp:TableCell>
                            <asp:TableCell runat="server">
                                <asp:Label ID="LabelConfirmPassword" runat="server" Text="Confirm Password" CssClass="text"></asp:Label>
                            </asp:TableCell>
                            <asp:TableCell runat="server">
                                <asp:TextBox ID="TextBoxConfirmPassword" placeholder="Confirm Password" runat="server" type="password" CssClass="input" Style="transform: translateX(-50%);"></asp:TextBox>
                            </asp:TableCell>
                        </asp:TableRow>
                        <asp:TableRow runat="server">
                            <asp:TableCell runat="server">
                                <asp:Label ID="LabelEmail" runat="server" Text="E-mail" CssClass="text">
                                </asp:Label>
                            </asp:TableCell>
                            <asp:TableCell runat="server">
                                <asp:TextBox ID="TextBoxEmail" placeholder="Email" type="email" runat="server" CssClass="input"></asp:TextBox>
                            </asp:TableCell>
                        </asp:TableRow>
                        <asp:TableRow runat="server">
                            <asp:TableCell runat="server">
                                <asp:Label ID="LabelBirthDate" runat="server" Text="Birthdate" CssClass="text">
                                </asp:Label>
                            </asp:TableCell>
                            <asp:TableCell runat="server">
                                <asp:TextBox ID="TextBoxBirthDate" placeholder="dd/mm/yyyy" type="date" runat="server" CssClass="input"></asp:TextBox>
                            </asp:TableCell>
                        </asp:TableRow>
                        <asp:TableRow runat="server">
                            <asp:TableCell runat="server">
                                <asp:Label ID="LabelGender" runat="server" Text="Gender" CssClass="text">
                                </asp:Label>
                            </asp:TableCell>
                            <asp:TableCell runat="server">
                                <asp:RadioButton ID="RadioButtonMale" runat="server" GroupName="gender" Text=" Male" CssClass="text" />
                            </asp:TableCell>
                            <asp:TableCell runat="server" Style="transform: translateX(-75%);">
                                <asp:RadioButton ID="RadioButtonFemale" runat="server" GroupName="gender" Text=" Female" CssClass="text" />
                            </asp:TableCell>
                        </asp:TableRow>
                        <asp:TableRow runat="server">
                            <asp:TableCell runat="server">
                                <asp:Label ID="LabelContact" runat="server" Text="Contact" CssClass="text">
                                </asp:Label>
                            </asp:TableCell>
                            <asp:TableCell runat="server">
                                <asp:TextBox ID="TextBoxContact" placeholder="Phone Number" runat="server" CssClass="input" >
                                </asp:TextBox>
                            </asp:TableCell>
                            <asp:TableCell runat="server">
                            </asp:TableCell>
                        </asp:TableRow>
                        <asp:TableRow runat="server">
                            <asp:TableCell runat="server">
                                <asp:Label ID="LabelAddress" runat="server" Text="Address/City" CssClass="text">
                                </asp:Label>
                            </asp:TableCell>
                            <asp:TableCell runat="server">
                                <asp:TextBox ID="TextBoxAddress" placeholder="Mazzeh Damascus, Syria" runat="server" CssClass="input"></asp:TextBox>
                            </asp:TableCell>
                        </asp:TableRow>
                        <asp:TableRow runat="server" ID="TableRowBalance">
                            <asp:TableCell runat="server"></asp:TableCell>
                            <asp:TableCell runat="server">
                                <asp:DropDownList ID="DropDownListAccountType" CssClass="dropDownList" runat="server" Style="font-size: 18px; width: 60%; height: 40px;">
                                    <asp:ListItem Text="Current Account" />
                                    <asp:ListItem Text="Saving Account" />
                                    <asp:ListItem Text="Salary Account" />
                                </asp:DropDownList>
                            </asp:TableCell>
                            <asp:TableCell runat="server">
                                <asp:Label ID="LabelBalance" runat="server" Text="Balance" CssClass="text"></asp:Label>
                            </asp:TableCell>
                            <asp:TableCell runat="server">
                                <asp:TextBox ID="TextBoxBalance" placeholder="$" runat="server" ReadOnly="true" CssClass="input" Style="transform: translateX(-60%);"></asp:TextBox>
                            </asp:TableCell>
                        </asp:TableRow>
                        <asp:TableRow runat="server" ID="TableRowPinCode">
                            <asp:TableCell runat="server"></asp:TableCell>
                            <asp:TableCell runat="server"></asp:TableCell>
                            <asp:TableCell runat="server">
                                <asp:Label ID="LabelPin" runat="server" Text="Pin Code" CssClass="text"></asp:Label>
                            </asp:TableCell>
                            <asp:TableCell runat="server">
                                <asp:TextBox ID="TextBoxPin" placeholder="####" runat="server" CssClass="input" Style="transform: translateX(-60%);"></asp:TextBox>
                            </asp:TableCell>
                        </asp:TableRow>
                        <asp:TableRow runat="server" ID="TableRowConfirmPin">
                            <asp:TableCell runat="server"></asp:TableCell>
                            <asp:TableCell runat="server"></asp:TableCell>
                            <asp:TableCell runat="server">
                                <asp:Label ID="LabelConfirmPin" runat="server" Text="Confirm Pin" CssClass="text"></asp:Label>
                            </asp:TableCell>
                            <asp:TableCell runat="server">
                                <asp:TextBox ID="TextBoxConfirmPin" placeholder="####" runat="server" CssClass="input" Style="transform: translateX(-60%);"></asp:TextBox>
                            </asp:TableCell>
                        </asp:TableRow>
                        <asp:TableRow runat="server">
                            <asp:TableCell runat="server">
                            </asp:TableCell>
                            <asp:TableCell runat="server">
                            </asp:TableCell>
                            <asp:TableCell runat="server" Style="text-align: end; transform: translateX(70%);">
                                <asp:Button ID="ButtonConfirm" runat="server" type="submit" Text="Confirm" CssClass="btn" />
                            </asp:TableCell>
                            <asp:TableCell runat="server" Style="text-align: end;">
                                <asp:Button ID="ButtonCancel" runat="server" Text="Cancel" CssClass="btn" OnClick="ButtonCancel_Click" />
                            </asp:TableCell>
                        </asp:TableRow>
                    </asp:Table>
                </div>
            </div>
        </section>
        <footer>
            <span>Designed By <asp:HyperLink ID="HyperLinkHYASoftware" runat="server">HYA - Software</asp:HyperLink> | <span class="fas fa-copyright"></span>
                2022 All rights reserved.
            </span>
        </footer>
    </form>
</body>
</html>
