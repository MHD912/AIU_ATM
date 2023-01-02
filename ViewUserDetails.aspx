<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ViewUserDetails.aspx.cs" Inherits="AIU_ATM.ViewUserDetails" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>View User Information</title>
    <meta charset="UTF-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1.0" />
    <link rel="stylesheet" href="Content/Site.css" />
    <link rel="stylesheet" href="Content/font-face.css" />
    <link rel="stylesheet" href="Content/font-awesome-5.15.4.min.css" />
    <link rel="stylesheet" href="Content/google-material-symbols-rounded.css" />
    <script src="Scripts/jquery-3.6.1.min.js"></script>
    <script src="Scripts/typed.min.js"></script>

    <style>
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

        .contact .right form .field,
        .contact .right form .fields .field {
            height: 45px;
            width: 100%;
            margin-bottom: 36px;
        }

        .contact .contact-content {
            justify-content: center;
        }

        .errors-block {
            color: crimson;
            font-size: 14px;
        }

        section .title::before {
            width: 270px;
        }

        .contact .title::after {
            content: "user inforamtion";
            color: rgb(52, 205, 133);
        }

        .contact .right form .email {
            margin-left: 0px;
        }

        .input {
            height: 100%;
            width: 100%;
            border: 1px solid lightgray;
            border-radius: 6px;
            outline: none;
            padding: 4px 15px;
            font-size: 17px;
            font-family: 'Poppins', sans-serif;
        }

        .btn {
            padding: 8px;
            width: 35%;
            height: 100%;
            border: 2px solid rgb(52, 205, 133);
            background: rgb(52, 205, 133);
            color: #fff;
            font-size: 17px;
            font-weight: 400;
            border-radius: 6px;
            cursor: pointer;
            transition: all 0.3s ease;
            font-family: 'Poppins', sans-serif;
        }

            .btn:hover {
                color: rgb(52, 205, 133);
                background: none;
            }

        .inputTable {
            height: 100%;
            width: 100%;
            align-self: center;
            align-items: center;
            height: 350px;
            margin: auto;
            border-radius: 5px;
        }

        .text {
            font-size: 17px;
            font-weight: 500;
        }

        footer {
            width: 100%;
            position: absolute;
        }

        .typing {
            color: rgb(52, 205, 133);
        }
    </style>
    <script>
        $('document').ready(function () {
            var typed = new Typed(".typing", {
                strings: ["Bank", "View Info."],
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

        <%-- Input form --%>

        <section class="contact" id="contact" style="margin-bottom: 12em;">
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
                                <asp:TextBox ID="TextBoxFirstName" placeholder="First" runat="server" CssClass="input" ReadOnly="true"></asp:TextBox>
                            </asp:TableCell>
                            <asp:TableCell runat="server">
                                <asp:TextBox ID="TextBoxMidName" placeholder="Middle" runat="server" ReadOnly="true" CssClass="input"></asp:TextBox>
                            </asp:TableCell>
                            <asp:TableCell runat="server">
                                <asp:TextBox ID="TextBoxLastName" placeholder="Last" runat="server" ReadOnly="true" CssClass="input"></asp:TextBox>
                            </asp:TableCell>
                        </asp:TableRow>
                        <asp:TableRow runat="server">
                            <asp:TableCell runat="server">
                                <asp:Label ID="LabelUserName" runat="server" Text="Username" CssClass="text">
                                </asp:Label>
                            </asp:TableCell>
                            <asp:TableCell runat="server">
                                <asp:TextBox ID="TextBoxUserName" placeholder="Username" runat="server" ReadOnly="true" CssClass="input"></asp:TextBox>
                            </asp:TableCell>
                        </asp:TableRow>
                        <asp:TableRow runat="server">
                            <asp:TableCell runat="server">
                                <asp:Label ID="LabelPassword" runat="server" Text="Password" CssClass="text">
                                </asp:Label>
                            </asp:TableCell>
                            <asp:TableCell runat="server">
                                <asp:TextBox ID="TextBoxPassword" placeholder="Password" type="password" runat="server" ReadOnly="true" CssClass="input"></asp:TextBox>
                            </asp:TableCell>
                        </asp:TableRow>
                        <asp:TableRow runat="server">
                            <asp:TableCell runat="server">
                                <asp:Label ID="LabelEmail" runat="server" Text="E-mail" CssClass="text">
                                </asp:Label>
                            </asp:TableCell>
                            <asp:TableCell runat="server">
                                <asp:TextBox ID="TextBoxEmail" placeholder="Email" type="email" runat="server" ReadOnly="true" CssClass="input"></asp:TextBox>
                            </asp:TableCell>
                        </asp:TableRow>
                        <asp:TableRow runat="server">
                            <asp:TableCell runat="server">
                                <asp:Label ID="LabelBirthDate" runat="server" Text="Birthdate" CssClass="text">
                                </asp:Label>
                            </asp:TableCell>
                            <asp:TableCell runat="server">
                                <asp:TextBox ID="TextBoxBirthDate" placeholder="dd/mm/yyyy" type="date" runat="server" ReadOnly="true" CssClass="input"></asp:TextBox>
                            </asp:TableCell>
                        </asp:TableRow>
                        <asp:TableRow runat="server">
                            <asp:TableCell runat="server">
                                <asp:Label ID="LabelGender" runat="server" Text="Gender" CssClass="text">
                                </asp:Label>
                            </asp:TableCell>
                            <asp:TableCell runat="server">
                                <asp:TextBox ID="TextBoxGender" runat="server" placeholder="Gender" ReadOnly="true" CssClass="input"></asp:TextBox>
                            </asp:TableCell>
                        </asp:TableRow>
                        <asp:TableRow runat="server">
                            <asp:TableCell runat="server">
                                <asp:Label ID="LabelContact" runat="server" Text="Contact" CssClass="text">
                                </asp:Label>
                            </asp:TableCell>
                            <asp:TableCell runat="server">
                            </asp:TableCell>
                            <asp:TableCell runat="server">
                                <asp:TextBox ID="TextBoxContact" placeholder="Phone Number" runat="server" ReadOnly="true" CssClass="input" Style="transform: translateX(-107%);">
                                </asp:TextBox>
                            </asp:TableCell>
                        </asp:TableRow>
                        <asp:TableRow runat="server">
                            <asp:TableCell runat="server">
                                <asp:Label ID="LabelAddress" runat="server" Text="Address/City" CssClass="text">
                                </asp:Label>
                            </asp:TableCell>
                            <asp:TableCell runat="server">
                                <asp:TextBox ID="TextBoxAddress" placeholder="Mazzeh Damascus, Syria" runat="server" ReadOnly="true" CssClass="input"></asp:TextBox>
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
                                <asp:TextBox ID="TextBoxBalance" placeholder="$" runat="server" ReadOnly="true" CssClass="input" style="transform: translateX(-60%);"></asp:TextBox>
                            </asp:TableCell>
                        </asp:TableRow>
                        <asp:TableRow runat="server" ID="TableRowPinCode">
                            <asp:TableCell runat="server"></asp:TableCell>
                            <asp:TableCell runat="server"></asp:TableCell>
                            <asp:TableCell runat="server">
                                <asp:Label ID="LabelPin" runat="server" Text="Pin Code" CssClass="text">
                                </asp:Label>
                            </asp:TableCell>
                            <asp:TableCell runat="server">
                                <asp:TextBox ID="TextBoxPin" placeholder="####" runat="server" ReadOnly="true" CssClass="input" style="transform: translateX(-60%);"></asp:TextBox>
                            </asp:TableCell>
                        </asp:TableRow>
                        <asp:TableRow runat="server">
                            <asp:TableCell runat="server">
                            </asp:TableCell>
                            <asp:TableCell runat="server">
                            </asp:TableCell>
                            <asp:TableCell runat="server" Style="text-align: end; transform: translateX(70%);">
                                <asp:Button ID="ButtonDelete" runat="server" Text="Delete" CssClass="btn" />
                            </asp:TableCell>
                            <asp:TableCell runat="server" Style="text-align: end;">
                                <asp:Button ID="ButtonEdit" runat="server" Text="Edit" CssClass="btn" OnClick="ButtonEdit_Click" />
                            </asp:TableCell>
                        </asp:TableRow>
                    </asp:Table>
                </div>
            </div>
        </section>
    </form>
    <footer>
        <span>Designed By <a href="#">HYA - Software</a> | <span class="fas fa-copyright"></span>
            2022 All rights reserved.
        </span>
    </footer>
</body>

</html>
