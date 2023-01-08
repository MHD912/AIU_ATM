<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="AIU_ATM.AdminLogin" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Login</title>
    <meta charset="UTF-8" />
    <meta http-equiv="X-UA-Compatible" content="IE=edge" />
    <meta name="viewport" content="width=device-width, initial-scale=1.0" />
    <link rel="stylesheet" href="Content/font-face.css" />
    <link rel="stylesheet" href="Content/font-awesome-5.15.4.min.css" />
    <link rel="stylesheet" href="content/bootstrap.min.css" />
    <link rel="stylesheet" href="Content/Site.css" />
    <script src="Scripts/jquery-3.6.1.min.js"></script>
    <script src="Scripts/typed.min.js"></script>

    <style>
        /* navbar styling */
        .navbar.sticky {
            padding: 8.75px 0;
            display: block
        }

            .navbar.sticky a:hover {
                text-decoration: none;
            }

        /* input styling */
        .contact .right form .field,
        .contact .right form .fields .field {
            height: 45px;
            width: 100%;
            margin-bottom: 36px;
        }

        .contact .contact-content {
            justify-content: center;
        }

            .contact .contact-content .column {
                width: calc(45% - 30px);
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
            border: none;
            font-size: 20px;
            font-weight: 500;
            border-radius: 6px;
            cursor: pointer;
            transition: all 0.3s ease;
            font-family: 'Poppins', sans-serif;
        }

            .btn:hover {
                background: #218838;
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
                strings: ["Bank", "Login"],
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
            <ul class="menu" style="margin-bottom: 0;">
                <li>
                    <asp:HyperLink ID="homeHyperLink" runat="server" NavigateUrl="~/Default.aspx" ForeColor="White">
                        <span class="fas fa-home" style="font-size: 25px;"/>
                    </asp:HyperLink>
                </li>
            </ul>
        </div>
    </nav>


    <!-- Login section -->

    <section class="contact" id="contact" style="margin-bottom: 8em;">
        <div class="max-width" style="">
            <h2 class="title" style="margin-bottom: 3em;">Login</h2>
            <div class="contact-content">
                <div class="column right">
                    <div class="text">Enter your information:</div>

                    <form id="form1" runat="server">
                        <div class="form-group">
                            <asp:TextBox ID="username" CssClass="form-control" placeholder="Username" runat="server" Wrap="False" TabIndex="1" required="true"></asp:TextBox>
                            <asp:Label ID="LabelUsernameFeedback" CssClass="invalid-feedback" runat="server" Text="Label"></asp:Label>
                        </div>

                        <div class="form-group">
                            <asp:TextBox ID="password" CssClass="form-control" placeholder="Password" runat="server" Wrap="False" type="password" TabIndex="2" required="true"></asp:TextBox>
                            <asp:Label ID="LabelPasswordFeedback" CssClass="invalid-feedback" runat="server" Text="Label"></asp:Label>
                        </div>
                        <div style="width: 100%; display: flex; justify-content: center;">
                            <asp:Button CssClass="btn" ID="btnLogin" runat="server" Text="Login" Height="53px" Width="98px" OnClick="btnLogin_Click" TabIndex="3" />
                        </div>
                    </form>
                </div>
            </div>
        </div>
    </section>
    <footer>
        <span>Designed By <a href="#">HYA - Software</a> | <span class="fas fa-copyright"></span>
            2022 All rights reserved.
        </span>
    </footer>
</body>
</html>
