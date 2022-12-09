<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="AIU_ATM.Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>AIU Bank | Home</title>
    <meta charset="UTF-8" />
    <meta name="viewport" content="width = device-width, initial-scale=1.0" />
    <link rel="stylesheet" href="Content/Site.css" />
    <link rel="stylesheet" href="Content/font-face.css" />
    <link rel="stylesheet" href="Content/font-awesome-5.15.4.min.css" />
    <script src="Scripts/jquery-3.6.1.min.js"></script>
    <script src="Scripts/typed.min.js"></script>
    <style>
        
        /*button styling*/

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

        /*navigation bar styling*/

        .navbar .logo a {
            color: #333;
        }

            .navbar .logo a span {
                color: rgb(52, 205, 133);
            }

        .navbar.sticky .logo a span {
            color: #333;
        }

        .navbar .logo a:hover {
            color: rgb(52, 205, 133);
        }

        .navbar.sticky .logo a:hover {
            color: #333;
        }

        .navbar .logo a:hover span {
            color: #333;
        }

        .navbar.sticky .logo a:hover span {
            color: #333;
        }

        /*typed script styling*/

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
                strings: ["Your first choice for monetary needs", "Reliable and trustworthy", "Creating banking trust", "Let us help you invest in your future !!"],
                typeSpeed: 30,
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

        <nav class="navbar">
            <!-- Max-width class helps in responsiveness of the website -->
            <div class="max-width">
                <!-- Logo class returns the client to home page once clicked -->
                <div class="logo">
                    <asp:HyperLink ID="logoHyperLink" runat="server" NavigateUrl="~/Default.aspx">
                        AIU|<span> Bank</span> 
                    </asp:HyperLink>
                </div>
                <!-- Navigation bar menu -->
                <ul class="menu" style="color: #333;">
                    <li><a href="#about" class="menu-btn">About</a></li>
                    <li><a href="#services" class="menu-btn">Services</a></li>
                    <li><a href="#teams" class="menu-btn">Teams</a></li>
                    <li><a href="#contact" class="menu-btn">Contact</a></li>
                </ul>
            </div>
        </nav>

        <!-- Home section start -->

        <section class="home" id="home" style="margin-bottom: -3em;">
            <!-- Max-width class helps in responsiveness of the website -->
            <div class="max-width">
                <div class="home-content">
                    <div class="text-2" style="margin-bottom: 2em">Welcome to AIU ATM System <span style="color: #111;">. . .</span></div>
                    <div class="text-1" style="margin-bottom: 5em; color: rgb(52, 205, 133); font-weight: 600;"><span class="typing" style="font-weight: 300; color: #111;"></span></div>
                    <asp:Button CssClass="btn" ID="ButtonLogin" runat="server" Text="Login" OnClick="ButtonLogin_Click" />
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
