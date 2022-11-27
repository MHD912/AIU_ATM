<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AdminLogin.aspx.cs" Inherits="Test.AdminLogin" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Admin Login</title>
    <meta charset="UTF-8" />
    <meta http-equiv="X-UA-Compatible" content="IE=edge" />
    <meta name="viewport" content="width=device-width, initial-scale=1.0" />
    <link rel="stylesheet" href="style.css" />
    <link rel="stylesheet" href="source/css/all.min.css" />
    <link rel="stylesheet" href="source/css/fontawesome.min.css" />
    <script src="https://code.jquery.com/jquery-3.6.0.min.js"></script>
    <script src="script.js"></script>

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

        .section .title::before {
            width: 250px;
        }

        .contact .title::after {
            content: "";
        }

        .contact .right form .email {
            margin-left: 0px;
        }

        .btn {
            width: 100%;
            height: 100%;
            border: 2px solid rgb(52, 205, 133);
            background: rgb(52, 205, 133);
            color: #fff;
            font-size: 20px;
            font-weight: 500;
            border-radius: 6px;
            cursor: pointer;
            transition: all 0.3s ease;
            font-family: 'Poppins', sans-serif;
        }

            .btn:hover {
                color: rgb(52, 205, 133);
                background: none;
            }

        footer {
            width: 100%;
            height: 100%;
            position: fixed;
        }
    </style>
</head>

<body>

    <!-- Navigation bar -->

    <nav class="navbar sticky">
        <!-- Max-width class helps in responsiveness of the website -->
        <div class="max-width">
            <!-- Logo class returns the client to home page once clicked -->
            <div class="logo">
                <asp:HyperLink ID="logoHyperLink" runat="server" NavigateUrl="~/index.aspx">
                   AIU|<span> Bank</span> 
                </asp:HyperLink>
            </div>
            <!-- Navigation bar menu -->
            <ul class="menu">
                <li>
                    <asp:HyperLink ID="homeHyperLink" runat="server" NavigateUrl="~/index.aspx" ForeColor="White">
                        <span class="fas fa-home" style="font-size: 25px;"/>
                    </asp:HyperLink>
                </li>
            </ul>
        </div>
    </nav>


    <!-- Login section -->

    <section class="contact" id="contact">
        <div class="max-width">
            <h2 class="title">Admin Login</h2>
            <div class="contact-content">
                <div class="column right">
                    <div class="text">Enter your information:</div>

                    <form id="form1" runat="server">
                        <div class="field name">
                            <asp:TextBox ID="username" placeholder="Username" runat="server" Wrap="False"></asp:TextBox>
                            <div class="errors-block">
                            </div>
                        </div>

                        <div class="field">
                            <asp:TextBox ID="password" placeholder="Password" runat="server" Wrap="False" type="password"></asp:TextBox>
                            <div class="errors-block">
                            </div>
                        </div>

                        <div class="button" style="width: 100%; height: 80px; display: flex; align-items: center; justify-content: center;">
                            <asp:Button CssClass="btn" ID="btnLogin" runat="server" Text="Login" Height="53px" Width="98px" />
                        </div>

                    </form>
                </div>
            </div>
        </div>
    </section>

    <br />
    <br />
    <br />
    <br />
    <br />
    <br />
    <footer>
        <span>Created By <a href="#" style="color: rgb(219, 186, 36);">Hussein</a> | <span class="fas fa-copyright"></span>
            2022 All rights reserved.
        </span>
    </footer>
</body>
</html>
