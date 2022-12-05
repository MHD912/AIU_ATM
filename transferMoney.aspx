<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="transferMoney.aspx.cs" Inherits="Test.transferMoney" %>


<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Admin Dashboard</title>
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

        .dropDownList {
            font-family: 'Poppins', sans-serif;
            font-size: 18px;
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
            margin-inline-end: 60px;
            outline: none;
        }

            .dropDownList .listItem {
                color: #222;
                background: #fff;
            }

                .dropDownList .listItem:hover {
                    color: rgb(52, 205, 133);
                    background: none;
                }

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
            <div class="max-width">
                <!-- Logo class returns the client to home page once clicked -->
                <div class="logo">
                    <a href="#home">AIU|<span class="typing"></span>
                    </a>
                </div>
            </div>
        </nav>

        <!-- Home section start -->

        <section class="home" id="home">
            <!-- Max-width class helps in responsiveness of the website -->
            <div class="max-width">
                <div class="home-content">
                    <div class="text-2" style="color: #333;">Hi there customer <span style="color: rgb(52, 205, 133);">; )</span></div>
                    <br />
                    <br />
                    <br />
                    <br />
                    <div class="text-1" style="margin-bottom:32px;">-your balance is: 0 S.P
                    </div>
                    <div>

                    <div class="text-1">TO: </div>
                        <input style="width:285px; margin-top:10px; margin-right:5px;margin-bottom:10px ;height:50px" class="btn" id="Text2" type="text" /><br />
                    <div class="text-1">Transfer: </div>
                        <input style="width:205px; margin-top:10px; margin-right:5px; height:50px" class="btn" id="Text1" type="text" /> S.P<br />
                        <asp:Button style="display:block; margin-top:30px; margin-bottom:30px; width:400px;" class="btn" ID="transfer" runat="server" Text="transfer money" OnClick="transfer_Click" />
                    </div>
                    

                    
                </div>
            </div>
        </section>
    </form>
</body>
</html>
