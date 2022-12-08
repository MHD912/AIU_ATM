<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ViewCustomerDetails.aspx.cs" Inherits="AIU_ATM.ViewCustomerDetails" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>View Customer Information</title>
    <meta charset="UTF-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1.0" />
    <link rel="stylesheet" href="style.css" />
    <link rel="stylesheet" href="source/css/all.min.css" />
    <link rel="stylesheet" href="source/css/fontawesome.min.css" />
    <script src="https://code.jquery.com/jquery-3.6.0.min.js"></script>
    <script src="https://cdnjs.cloudflare.com/ajax/libs/typed.js/2.0.12/typed.min.js"></script>

    <style>
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
            content: "customer inforamtion";
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
            <ul class="menu">
                <li>
                    <asp:HyperLink ID="homeHyperLink" runat="server" NavigateUrl="~/AdminDashboard.aspx" ForeColor="White">
                        <span class="fas fa-home" style="font-size: 25px;"/>
                    </asp:HyperLink>
                </li>
            </ul>
        </div>
    </nav>

    <%-- Input form --%>

    <section class="contact" id="contact" style="margin-bottom: 11em;">
        <div class="max-width">
            <h2 class="title"></h2>
            <form id="form1" runat="server">
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
                            <asp:TableCell runat="server">
                                <asp:Label ID="LabelBalance" runat="server" Text="Balance" CssClass="text">
                                </asp:Label>
                            </asp:TableCell>
                            <asp:TableCell runat="server">
                                <asp:TextBox ID="TextBoxBalance" placeholder="$" runat="server" ReadOnly="true" CssClass="input"></asp:TextBox>
                            </asp:TableCell>
                        </asp:TableRow>
                        <asp:TableRow runat="server" ID="TableRowPinCode">
                            <asp:TableCell runat="server">
                                <asp:Label ID="LabelPin" runat="server" Text="Pin Code" CssClass="text">
                                </asp:Label>
                            </asp:TableCell>
                            <asp:TableCell runat="server">
                                <asp:TextBox ID="TextBoxPin" placeholder="####" runat="server" ReadOnly="true" CssClass="input"></asp:TextBox>
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
            </form>
        </div>
    </section>
    <footer>
        <span>Designed By <a href="#">Hussein912</a> | <span class="fas fa-copyright"></span>
            2022 All rights reserved.
        </span>
    </footer>
</body>

</html>
