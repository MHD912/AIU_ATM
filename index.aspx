<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="index.aspx.cs" Inherits="Test.index" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>AIU Bank | Home</title>
    <meta charset="UTF-8" />
    <meta name="viewport" content="width = device-width, initial-scale=1.0" />
    <link rel="stylesheet" href="style.css" />
    <link rel="stylesheet" href="source/css/all.min.css" />
    <link rel="stylesheet" href="source/css/fontawesome.min.css" />
    <script src="https://code.jquery.com/jquery-3.6.0.min.js"></script>
    <script src="https://cdnjs.cloudflare.com/ajax/libs/typed.js/2.0.12/typed.min.js"></script>
    <script src="script.js"></script>
    <style>
        .home {
            background: url(source/wallpaper.png) no-repeat center;
            color: #111;
        }

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

        .typing {
            color: rgb(52, 205, 133);
        }
    </style>
    <script>
        $('document').ready(function () {
            var typed = new Typed(".typing", {
                strings: [". . ."],
                typeSpeed: 100,
                backSpeed: 60,
                loop: true
            });
        });
    </script>
</head>
<body>
    <form id="form1" runat="server">
        <div class="scroll-up-btn">
            <i class="fas fa-angle-up"></i>
        </div>

        <!-- Navigation bar -->

        <nav class="navbar">
            <!-- Max-width class helps in responsiveness of the website -->
            <div class="max-width">
                <!-- Logo class returns the client to home page once clicked -->
                <div class="logo">
                    <a href="#home">AIU|<span> Bank</span>
                    </a>
                </div>
            </div>
        </nav>

        <!-- Home section start -->

        <section class="home" id="home">
            <!-- Max-width class helps in responsiveness of the website -->
            <div class="max-width">
                <div class="home-content">
                    <div class="text-2">Welcome to AIU ATM System <span class="typing" style="color: #111;"></span></div>
                    <br />
                    <br />
                    <br />
                    <br />
                    <div class="text-1">-What do you want to do?</div>
                    <br />
                    <br />
                    <asp:Button CssClass="btn" ID="ButtonAdmin" runat="server" Text="Admin Login" OnClick="ButtonAdmin_Click" />
                    <asp:Button CssClass="btn" ID="ButtonCustomer" runat="server" Text="Insert Card" OnClick="ButtonCustomer_Click" />
                </div>
            </div>
        </section>
    </form>
</body>
</html>
