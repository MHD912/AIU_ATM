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
    <link rel="stylesheet" href="Content/google-material-symbols-rounded.css" />
    <link rel="stylesheet" href="Content/owl.carousel.min.css" />
    <script src="Scripts/jquery-3.6.1.min.js"></script>
    <script src="Scripts/jquery.waypoints.min.js"></script>
    <script src="Scripts/owl.carousel.min.js"></script>
    <script src="Scripts/typed.min.js"></script>
    <script src="Scripts/script.js"></script>
    <style>
        /* button styling */
        .btn {
            width: 6em;
            height: 2.5em;
            font-weight: 400;
            font-size: 21px;
            cursor: pointer;
        }

        /* navigation bar styling */
        .navbar .logo a {
            color: #333;
        }

            .navbar .logo a span {
                color: rgb(52, 205, 133);
            }

            .navbar .logo a:hover {
                color: rgb(52, 205, 133);
            }

                .navbar .logo a:hover span {
                    color: #333;
                }

        /* menu styling */
        .menu {
            display: flex;
            align-items: center;
            margin-right: -170px;
        }

        /* typed script styling */

        .typing {
            color: rgb(52, 205, 133);
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
    <div class="scroll-up-btn">
        <i class="fas fa-angle-up"></i>
    </div>

    <form id="form1" runat="server">

        <!-- Navigation bar -->

        <nav class="navbar">
            <!-- Max-width class helps in responsiveness of the website -->
            <div class="max-width" id="navbar-max-width">
                <!-- Logo class returns the client to home page once clicked -->
                <div class="logo">
                    <asp:HyperLink ID="logoHyperLink" runat="server" NavigateUrl="#home">
                        AIU|<span> Bank</span> 
                    </asp:HyperLink>
                </div>
                <!-- Animated 3-bars menu icon -->
                <label for="menu-hamburger" class="menu-btn">
                    <div class="menu-hamburger"></div>
                </label>
                <!--Navigation bar menu -->
                <ul class="menu">
                    <li><a href="#about" class="menu-btn">About</a></li>
                    <li><a href="#services" class="menu-btn">Services</a></li>
                    <li><a href="#branches" class="menu-btn">Branches</a></li>
                    <li><a href="#contact" class="menu-btn">Contact</a></li>
                    <li><asp:LinkButton ID="LinkButtonLogoutAsText" CssClass="menu-btn" runat="server">Logout</asp:LinkButton></li>
                    <li style="margin-left: 70px">
                        <div class="tool-tip">
                            <asp:LinkButton ID="LinkButtonLogout" CssClass="logout-button" runat="server" TabIndex="-1" OnClick="LinkButtonLogout_Click">
                                <i id="logout-icon1" class="material-symbols-rounded" style="font-weight:600; font-size: 32px;">logout</i>
                                <i id="logout-icon2" class="material-symbols-rounded" style="font-weight:600; font-size: 32px;">door_open</i>
                            </asp:LinkButton>
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
                    <div class="text-2" style="margin-bottom: 2em">Welcome to AIU ATM System <span style="color: #111;">. . .</span></div>
                    <div class="text-1" style="margin-bottom: 4em; color: rgb(52, 205, 133); font-weight: 600;"><span class="typing" style="font-weight: 300; color: #111;"></span></div>
                    <asp:LinkButton ID="LinkButtonLogin" CssClass="btn" runat="server" OnClick="LinkButtonLogin_Click" TabIndex="1">Login</asp:LinkButton>
                </div>
            </div>
        </section>

        <!-- About section -->

        <section class="about" id="about" style="padding: 5em 0 11em">
            <!-- Max-width class helps in responsiveness of the website -->
            <div class="max-width">
                <h2 class="title">About Us</h2>
                <div class="about-content">
                    <div class="column left">
                        <div class="flip-card">
                            <div class="flip-card-inner">
                                <div class="flip-card-front">
                                    <img src="Content/Images/aiu-5.jpg" alt="Avatar" style="width: 400px; height: 400px;">
                                </div>
                                <div class="flip-card-back">
                                    <img src="Content/Images/logo_en_350_43.png" alt="Avatar" style="width: 400px; height: 400px;">
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="column right">
                        <div class="text" id="text">
                            AIU group for banking <span>&</span> ATM services<span>:</span>
                            <br id="text-464px">
                        </div>
                        <p>
                            Because we don't know what should we write about as of now, this is a random text. We will think
                            about that later. What's important now is to perfectly tone this project to our liking. But of
                            course, we will work on filling this part of the website with real information about us...
                            As of now, what do you think of our compostion skills. Okay that's
                            enough I am really out of words right now I will stop writing here.
                        </p>
                        <asp:HyperLink ID="HyperLinkDownloadBrochure" runat="server" NavigateUrl="#about">Download Brochure</asp:HyperLink>
                    </div>
                </div>
            </div>
        </section>

        <!-- Services section -->

        <section class="services" id="services" style="padding: 6em 0 10em">
            <!-- Max-width class helps in responsiveness of the website -->
            <div class="max-width">
                <h2 class="title">Our services</h2>
                <div class="services-content">
                    <div class="card" id="card1">
                        <div class="box">
                            <i class="material-symbols-rounded">credit_card</i>
                            <div class="text">ATM Services</div>
                            <p>
                                Hassle free depositng and withdrawing from with our special ATM system
                            </p>
                        </div>
                    </div>
                    <div class="card" id="card2">
                        <div class="box">
                            <i class="material-symbols-rounded">repeat</i>
                            <div class="text">Transfer Money</div>
                            <p>
                                Move money where ever you want safely and securely
                            </p>
                        </div>
                    </div>
                    <div class="card" id="card3">
                        <div class="box">
                            <i class="material-symbols-rounded">real_estate_agent</i>
                            <div class="text">Loan Service</div>
                            <p>
                                Kickstart your business with the funding you need with the loan plan which suits you best
                            </p>
                        </div>
                    </div>
                </div>
            </div>
        </section>

        <!-- Branches section -->

        <section class="branches" id="branches">
            <div class="max-width">
                <h2 class="title">Our branches</h2>
                <div class="carousel owl-carousel">
                    <div class="card">
                        <div class="box">
                            <img src="Content/Images/default_page.jpg" alt="">
                            <div class="text">Kafar Souseh</div>
                            <p>The main branch with next to Sham City Center mall.</p>
                        </div>
                    </div>
                    <div class="card">
                        <div class="box">
                            <img src="Content/Images/default_page.jpg" alt="">
                            <div class="text">Al-Mazzah</div>
                            <p>Our latest branch is ready to provide services to our curomters. Next to AIU university HQ.</p>
                        </div>
                    </div>
                    <div class="card">
                        <div class="box">
                            <img src="Content/Images/default_page.jpg" alt="">
                            <div class="text">Bab Tuma</div>
                            <p>A three story building behind Bab Tuma square.</p>
                        </div>
                    </div>
                    <div class="card">
                        <div class="box">
                            <img src="Content/Images/default_page.jpg" alt="">
                            <div class="text">Jaramanah</div>
                            <p>Located next to Jaramanah mall.</p>
                        </div>
                    </div>
                    <div class="card">
                        <div class="box">
                            <img src="Content/Images/default_page.jpg" alt="">
                            <div class="text">Al-Zahra</div>
                            <p>Coming Soon...</p>
                        </div>
                    </div>
                </div>
            </div>
        </section>

        <!-- Contact section -->

        <section class="contact" id="contact">
            <div class="max-width">
                <h2 class="title" style="margin-bottom: 2em;">Contact us</h2>
                <div class="contact-content">
                    <div class="column left">
                        <div class="text">Get in Touch</div>
                        <p>
                            We always try to keep in touch with customers. If you have any questions. You can reach to us
                            through the contact information provided down below!
                        </p>
                        <div class="icons">
                            <div class="row">
                                <i class="fas fa-user"></i>
                                <div class="info">
                                    <div class="head">Name</div>
                                    <div class="sub-title">AIU Bank Group</div>
                                </div>
                            </div>
                            <div class="row">
                                <i class="fas fa-map-marker-alt"></i>
                                <div class="info">
                                    <div class="head">Addess</div>
                                    <div class="sub-title">Damascus, Syria</div>
                                </div>
                            </div>
                            <div class="row">
                                <i class="fas fa-envelope"></i>
                                <div class="info">
                                    <div class="head">Email</div>
                                    <div class="sub-title">aiu.bank.sy@gmail.com</div>
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="column right">
                        <div class="text">Message us</div>
                        <div class="fields">
                            <div class="field name">
                                <asp:TextBox ID="TextBoxName" runat="server" placeholder="Name" required="true"></asp:TextBox>
                            </div>
                            <div class="field email">
                                <asp:TextBox ID="TextBoxEmail" CssClass="input" runat="server" placeholder="Email" required="true"></asp:TextBox>
                            </div>
                        </div>
                        <div class="field">
                            <asp:TextBox ID="TextBoxSubject" CssClass="input" runat="server" placeholder="Subject" required="true"></asp:TextBox>
                        </div>
                        <div class="field textarea">
                            <asp:TextBox ID="TextBoxDescription" CssClass="input" Columns="30" Rows="10" runat="server" placeholder="Description" TextMode="MultiLine" required="true"></asp:TextBox>
                        </div>
                        <div class="button">
                            <asp:Button ID="ButtonSend" CssClass="button" runat="server" Text="Send message" />
                        </div>
                    </div>
                </div>
            </div>
        </section>

        <footer>
            <span>Designed By
                <asp:HyperLink ID="HyperLinkHYASoftware" runat="server">HYA - Software</asp:HyperLink>
                | <span class="fas fa-copyright"></span>
                2022 All rights reserved.
            </span>
        </footer>
    </form>
</body>
</html>
