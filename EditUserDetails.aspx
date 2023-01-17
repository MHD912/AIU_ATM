<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="EditUserDetails.aspx.cs" Inherits="AIU_ATM.EditUserDetails" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">

<head runat="server">
    <title>Edit User Information</title>
    <meta charset="UTF-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1.0" />
    <link rel="stylesheet" href="Content/Site.css" />
    <link rel="stylesheet" href="Content/font-face.css" />
    <link rel="stylesheet" href="Content/font-awesome-5.15.4.min.css" />
    <link rel="stylesheet" href="content/bootstrap.min.css" />
    <link rel="stylesheet" href="Content/google-material-symbols-rounded.css" />
    <script src="Scripts/jquery-3.6.1.min.js"></script>
    <script src="Scripts/typed.min.js"></script>

    <style>
        /* navbar styling */
        .navbar.sticky {
            padding: 7.55px 0;
            display: block;
            position: fixed;
        }

            .navbar.sticky a:hover {
                text-decoration: none;
            }

        /* input table styling */
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

        /* invalid-feedback styling */
        .form-group {
            margin-bottom: 2px;
        }

        .invalid-feedback {
            margin: -9.6px 0;
            transform: translateY(9.6px);
        }

        /* other content styling */
        .btn {
            padding: 8px;
            width: 35%;
            height: 100%;
            font-size: 17px;
            font-family: 'Poppins', sans-serif;
            background: rgb(52, 205, 133);
            color: #fff;
            border-radius: 6px;
            border: none;
            transition: all 0.3s ease;
        }

            .btn:hover {
                background-color: #218838;
                color: #fff;
            }

        .text {
            font-size: 17px;
            font-weight: 500;
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
            if ($("#CheckBoxUserType").prop("checked") === true) {
                $("#TableRowBalance").hide();
                $("#TableRowPinCode").hide();
                $("#TableRowConfirmPin").hide();
                $("#contact").css("margin-bottom", "8em");
            }
            else {
                $("#TableRowBalance").show();
                $("#TableRowPinCode").show();
                $("#TableRowConfirmPin").show();
                $("#contact").css("margin-bottom", "20em");
            }
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

        <section class="contact" id="contact" style="margin-bottom: 20em;">
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
                                <div class="form-group">
                                    <asp:TextBox ID="TextBoxFirstName" placeholder="First" runat="server" CssClass="form-control"  ></asp:TextBox>
                                    <asp:Label ID="LabelFirstNameFeedback" CssClass="invalid-feedback" runat="server" Text="Label"></asp:Label>
                                </div>
                            </asp:TableCell>
                            <asp:TableCell runat="server">
                                <div class="form-group">
                                    <asp:TextBox ID="TextBoxMidName" placeholder="Middle" runat="server" CssClass="form-control"  ></asp:TextBox>
                                    <asp:Label ID="LabelMidNameFeedback" CssClass="invalid-feedback" runat="server" Text="Label"></asp:Label>
                                </div>
                            </asp:TableCell>
                            <asp:TableCell runat="server">
                                <div class="form-group">
                                    <asp:TextBox ID="TextBoxLastName" placeholder="Last" runat="server" CssClass="form-control"  ></asp:TextBox>
                                    <asp:Label ID="LabelLastNameFeedback" CssClass="invalid-feedback" runat="server" Text="Label"></asp:Label>
                                </div>
                            </asp:TableCell>
                        </asp:TableRow>
                        <asp:TableRow runat="server">
                            <asp:TableCell runat="server">
                                <asp:Label ID="LabelUserName" runat="server" Text="Username" CssClass="text">
                                </asp:Label>
                            </asp:TableCell>
                            <asp:TableCell runat="server">
                                <div class="form-group">
                                    <asp:TextBox ID="TextBoxUserName" placeholder="Username" runat="server" CssClass="form-control"  ></asp:TextBox>
                                    <asp:Label ID="LabelUserNameFeedback" CssClass="invalid-feedback" runat="server" Text="Label"></asp:Label>
                                </div>
                            </asp:TableCell>
                        </asp:TableRow>
                        <asp:TableRow runat="server">
                            <asp:TableCell runat="server">
                                <asp:Label ID="LabelPassword" runat="server" Text="Password" CssClass="text">
                                </asp:Label>
                            </asp:TableCell>
                            <asp:TableCell runat="server">
                                <div class="form-group">
                                    <asp:TextBox ID="TextBoxPassword" placeholder="Password" type="password" runat="server" CssClass="form-control"  ></asp:TextBox>
                                    <asp:Label ID="LabelPasswordFeedback" CssClass="invalid-feedback" runat="server" Text="Label"></asp:Label>
                                </div>
                            </asp:TableCell>
                            <asp:TableCell runat="server">
                                <asp:Label ID="LabelConfirmPassword" runat="server" Text="Confirm Password" CssClass="text"></asp:Label>
                            </asp:TableCell>
                            <asp:TableCell runat="server">
                                <div class="form-group">
                                    <asp:TextBox ID="TextBoxConfirmPassword" placeholder="Confirm Password" runat="server" type="password" CssClass="form-control" Style="transform: translateX(-50%);"  ></asp:TextBox>
                                    <asp:Label ID="LabelConfirmPasswordFeedback" CssClass="invalid-feedback" runat="server" Text="Label"></asp:Label>
                                </div>
                            </asp:TableCell>
                        </asp:TableRow>
                        <asp:TableRow runat="server">
                            <asp:TableCell runat="server">
                                <asp:Label ID="LabelEmail" runat="server" Text="E-mail" CssClass="text">
                                </asp:Label>
                            </asp:TableCell>
                            <asp:TableCell runat="server">
                                <div class="form-group">
                                    <asp:TextBox ID="TextBoxEmail" placeholder="Email" type="email" runat="server" CssClass="form-control" TextMode="Email" ></asp:TextBox>
                                    <asp:Label ID="LabelEmailFeedback" CssClass="invalid-feedback" runat="server" Text="Label"></asp:Label>
                                </div>
                            </asp:TableCell>
                        </asp:TableRow>
                        <asp:TableRow runat="server">
                            <asp:TableCell runat="server">
                                <asp:Label ID="LabelBirthDate" runat="server" Text="Birthdate" CssClass="text">
                                </asp:Label>
                            </asp:TableCell>
                            <asp:TableCell runat="server">
                                <div class="form-group">
                                    <asp:TextBox ID="TextBoxBirthDate" placeholder="dd/mm/yyyy" type="date" runat="server" CssClass="form-control"  ></asp:TextBox>
                                    <asp:Label ID="LabelBirthDateFeedback" CssClass="invalid-feedback" runat="server" Text="Label"></asp:Label>
                                </div>
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
                                <asp:Label ID="LabelContact" runat="server" Text="Contact" CssClass="text"></asp:Label>
                            </asp:TableCell>
                            <asp:TableCell runat="server">
                                <div class="form-group">
                                    <asp:TextBox ID="TextBoxContact" placeholder="Phone Number" runat="server" CssClass="form-control"  ></asp:TextBox>
                                    <asp:Label ID="LabelContactFeedback" CssClass="invalid-feedback" runat="server" Text="Label"></asp:Label>
                                </div>
                            </asp:TableCell>
                        </asp:TableRow>
                        <asp:TableRow runat="server">
                            <asp:TableCell runat="server">
                                <asp:Label ID="LabelAddress" runat="server" Text="Address/City" CssClass="text"></asp:Label>
                            </asp:TableCell>
                            <asp:TableCell runat="server">
                                <div class="form-group">
                                    <asp:TextBox ID="TextBoxAddress" placeholder="Mazzeh Damascus, Syria" runat="server" CssClass="form-control"  ></asp:TextBox>
                                    <asp:Label ID="LabelAddressFeedback" CssClass="invalid-feedback" runat="server" Text="Label"></asp:Label>
                                </div>
                            </asp:TableCell>
                        </asp:TableRow>
                        <asp:TableRow runat="server" ID="TableRowBalance">
                            <asp:TableCell runat="server"></asp:TableCell>
                            <asp:TableCell runat="server">
                                <div class="form-group">
                                    <asp:DropDownList ID="DropDownListAccountType" CssClass="dropDownList" runat="server" Style="font-size: 18px; width: 60%; height: 40px;" AutoPostBack="true">
                                        <asp:ListItem Text="Current Account" />
                                        <asp:ListItem Text="Saving Account" />
                                        <asp:ListItem Text="Salary Account" />
                                    </asp:DropDownList>
                                    <asp:Label ID="LabelAccountTypeFeedback" CssClass="invalid-feedback" runat="server" Text="Label"></asp:Label>
                                </div>
                            </asp:TableCell>
                            <asp:TableCell runat="server">
                                <asp:Label ID="LabelBalance" runat="server" Text="Balance" CssClass="text"></asp:Label>
                            </asp:TableCell>
                            <asp:TableCell runat="server">
                                <div class="form-group">
                                    <asp:TextBox ID="TextBoxBalance" placeholder="$" runat="server" CssClass="form-control" Style="transform: translateX(-60%);" ></asp:TextBox>
                                    <asp:Label ID="LabelBalanceFeedback" CssClass="invalid-feedback" runat="server" Text="Label"></asp:Label>
                                </div>
                            </asp:TableCell>
                        </asp:TableRow>
                        <asp:TableRow runat="server" ID="TableRowPinCode">
                            <asp:TableCell runat="server"></asp:TableCell>
                            <asp:TableCell runat="server"></asp:TableCell>
                            <asp:TableCell runat="server">
                                <asp:Label ID="LabelPin" runat="server" Text="Pin Code" CssClass="text"></asp:Label>
                            </asp:TableCell>
                            <asp:TableCell runat="server">
                                <div class="form-group">
                                    <asp:TextBox ID="TextBoxPin" placeholder="####" runat="server" CssClass="form-control" Style="transform: translateX(-60%);" ></asp:TextBox>
                                    <asp:Label ID="LabelPinFeedback" CssClass="invalid-feedback" runat="server" Text="Label"></asp:Label>
                                </div>
                            </asp:TableCell>
                        </asp:TableRow>
                        <asp:TableRow runat="server" ID="TableRowConfirmPin">
                            <asp:TableCell runat="server"></asp:TableCell>
                            <asp:TableCell runat="server"></asp:TableCell>
                            <asp:TableCell runat="server">
                                <asp:Label ID="LabelConfirmPin" runat="server" Text="Confirm Pin" CssClass="text"></asp:Label>
                            </asp:TableCell>
                            <asp:TableCell runat="server">
                                <div class="form-group">
                                    <asp:TextBox ID="TextBoxConfirmPin" placeholder="####" runat="server" CssClass="form-control" Style="transform: translateX(-60%);"></asp:TextBox>
                                    <asp:Label ID="LabelConfirmPinFeedback" CssClass="invalid-feedback" runat="server" Text="Label"></asp:Label>
                                </div>
                            </asp:TableCell>
                        </asp:TableRow>
                        <asp:TableRow runat="server">
                            <asp:TableCell runat="server">
                            </asp:TableCell>
                            <asp:TableCell runat="server">
                                <asp:CheckBox ID="CheckBoxUserType" runat="server" CssClass="text" Text="Register as admin" Style="display: none;" />
                            </asp:TableCell>
                            <asp:TableCell runat="server" Style="text-align: end; transform: translateX(65%);">
                                <asp:Button ID="ButtonConfirm" runat="server" type="submit" Text="Confirm" CssClass="btn" OnClick="ButtonConfirm_Click" />
                            </asp:TableCell>
                            <asp:TableCell runat="server" Style="text-align: end;">
                                <asp:Button ID="ButtonDiscard" runat="server" Text="Discard" CssClass="btn" OnClick="ButtonDiscard_Click" />
                            </asp:TableCell>
                        </asp:TableRow>
                    </asp:Table>
                </div>
            </div>
        </section>
        <footer>
            <span>
                Designed By <asp:HyperLink ID="HyperLinkHYASoftware" runat="server" NavigateUrl="#">HYA - Software</asp:HyperLink> | <span class="fas fa-copyright"></span>
                2022 All rights reserved.
            </span>
        </footer>
    </form>
</body>
</html>
