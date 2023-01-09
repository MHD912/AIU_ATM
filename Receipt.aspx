<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Receipt.aspx.cs" Inherits="AIU_ATM.Receipt" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Transaction Receipt</title>
    <meta charset="UTF-8" />
    <script src="Scripts/jquery-3.6.1.min.js"></script>
    <script src="Scripts/printThis.js"></script>
    <script src="Scripts/printReceipt.js"></script>
    <style>
        /* invoice styling */
        .invoice-box {
            max-width: 800px;
            margin: auto;
            padding: 30px;
            border: 1px solid #eee;
            box-shadow: 0 0 10px rgba(0, 0, 0, 0.15);
            font-size: 16px;
            line-height: 24px;
            font-family: 'Helvetica Neue', 'Helvetica', Helvetica, Arial, sans-serif;
            color: #555;
        }

            .invoice-box table {
                width: 100%;
                line-height: inherit;
                text-align: left;
            }

                .invoice-box table td {
                    padding: 5px;
                    vertical-align: top;
                }

                .invoice-box table tr td:nth-child(2) {
                    text-align: right;
                }

                .invoice-box table tr.top table td {
                    padding-bottom: 20px;
                }

                    .invoice-box table tr.top table td.title-invoice {
                        font-size: 45px;
                        line-height: 45px;
                        color: #333;
                    }

                .invoice-box table tr.information table td {
                    padding-bottom: 40px;
                }

                .invoice-box table tr.heading td {
                    background: #eee;
                    border-bottom: 1px solid #ddd;
                    font-weight: bold;
                }

                .invoice-box table tr.details td {
                    padding-bottom: 20px;
                }

                .invoice-box table tr.item td {
                    border-bottom: 1px solid #eee;
                }

                .invoice-box table tr.item.last td {
                    border-bottom: none;
                }

                .invoice-box table tr.total td:nth-child(2) {
                    border-top: 2px solid #eee;
                    font-weight: bold;
                }

        @media only screen and (max-width: 600px) {
            .invoice-box table tr.top table td {
                width: 100%;
                display: block;
                text-align: center;
            }

            .invoice-box table tr.information table td {
                width: 100%;
                display: block;
                text-align: center;
            }
        }

        /** RTL **/
        .invoice-box.rtl {
            direction: rtl;
            font-family: Tahoma, 'Helvetica Neue', 'Helvetica', Helvetica, Arial, sans-serif;
        }

            .invoice-box.rtl table {
                text-align: right;
            }

                .invoice-box.rtl table tr td:nth-child(2) {
                    text-align: left;
                }
    </style>
    <script>
        //function close_window(url) {
        //    var newWindow = window.open('', '_self', ''); //open the current window
        //    newWindow.close(url);
        //}
        //$('document').ready(function () {
        //    $('body').printThis({
        //        printDelay: 2000,
        //        pageTitle: "Transaction Receipt",
        //        beforePrint: function () {
        //            $('.print-section').css('display', '');
        //            if ($('#RadioButtonTransfer').prop("checked") === true) {
        //                $("#LabelTransactionType").text("Transfer");
        //                $("#TableRowSenderAccount").show();
        //                $("#TableRowReceipientAccount").show();
        //                $("#TableRowCustomerAccount").hide();
        //            }
        //            else if ($('#RadioButtonDeposit').prop("checked") === true) {
        //                $("#LabelTransactionType").text("Deposit");
        //                $("#TableRowSenderAccount").hide();
        //                $("#TableRowReceipientAccount").hide();
        //                $("#TableRowCustomerAccount").show();
        //            }
        //            else {
        //                $("#LabelTransactionType").text("Withdraw");
        //                $("#TableRowSenderAccount").hide();
        //                $("#TableRowReceipientAccount").hide();
        //                $("#TableRowCustomerAccount").show();
        //            }

        //        },
        //        afterPrint: function () {
        //            close_window('Receipt.aspx');
        //        }
        //    });
        //});
    </script>
</head>
<body>
    <form id="form1" runat="server">
        <div class="print-section" style="margin-top: 9%; ">
            <div class="invoice-box">
                <asp:Table ID="Table1" runat="server" CellPadding="0" CellSpacing="0">
                    <asp:TableRow CssClass="top">
                        <asp:TableCell ColumnSpan="2">
                            <asp:Table ID="Table2" runat="server">
                                <asp:TableRow>
                                    <asp:TableCell CssClass="title-invoice">
                                    <img src="Content/Images/invoice_logo.png" style="width: 100%; max-width: 300px" />
                                    </asp:TableCell>
                                    <asp:TableCell>
                                        <br />
                                        Invoice #: 123<br />
                                        Created:
                                        <asp:Label ID="LabelDate" runat="server" Text="January 1, 2015"></asp:Label>
                                    </asp:TableCell>
                                </asp:TableRow>
                            </asp:Table>
                        </asp:TableCell>
                    </asp:TableRow>
                    <asp:TableRow CssClass="information">
                        <asp:TableCell ColumnSpan="2">
                            <asp:Table ID="Table3" runat="server">
                                <asp:TableRow>
                                    <asp:TableCell>
                                        AIU| Bank, Group.<br />
                                        12345
                                        <asp:Label ID="LabelAddress" runat="server" Text="Tanzim Kafar Souseh"></asp:Label><br />
                                        Damascus, SY 12345
                                    </asp:TableCell>
                                    <asp:TableCell>
                                        <asp:Label ID="LabelCustomerName" runat="server" Text="customer name"></asp:Label><br />
                                        <asp:Label ID="LabelEmail" runat="server" Text="customer-email@example.com"></asp:Label><br />
                                        <asp:Label ID="LabelAccountType" runat="server" Text="account type"></asp:Label>
                                    </asp:TableCell>
                                </asp:TableRow>
                            </asp:Table>
                        </asp:TableCell>
                    </asp:TableRow>
                    <asp:TableRow CssClass="heading">
                        <asp:TableCell>Transaction</asp:TableCell>
                        <asp:TableCell>ID #</asp:TableCell>
                    </asp:TableRow>
                    <asp:TableRow CssClass="details">
                        <asp:TableCell>
                            <asp:Label ID="LabelTransactionType" runat="server" Text="Transfer"></asp:Label>
                        </asp:TableCell>
                        <asp:TableCell>
                            <asp:Label ID="LabelTransactionID" runat="server" Text="1000"></asp:Label>
                        </asp:TableCell>
                    </asp:TableRow>
                    <asp:TableRow CssClass="heading">
                        <asp:TableCell>Description</asp:TableCell>
                        <asp:TableCell>Account ID #</asp:TableCell>
                    </asp:TableRow>
                    <asp:TableRow ID="TableRowSenderAccount" CssClass="item">
                        <asp:TableCell>Sender account</asp:TableCell>
                        <asp:TableCell>
                            <asp:Label ID="LabelSenderAccountID" runat="server" Text="1001"></asp:Label>
                        </asp:TableCell>
                    </asp:TableRow>
                    <asp:TableRow ID="TableRowReceipientAccount" CssClass="item last">
                        <asp:TableCell>Receipient account</asp:TableCell>
                        <asp:TableCell>
                            <asp:Label ID="LabelReceipientAccountID" runat="server" Text="1201"></asp:Label>
                        </asp:TableCell>
                    </asp:TableRow>
                    <asp:TableRow ID="TableRowCustomerAccount" CssClass="item last">
                        <asp:TableCell>Customer account</asp:TableCell>
                        <asp:TableCell>
                            <asp:Label ID="LabelCustomerAccountID" runat="server" Text="1051"></asp:Label>
                        </asp:TableCell>
                    </asp:TableRow>
                    <asp:TableRow CssClass="total">
                        <asp:TableCell></asp:TableCell>
                        <asp:TableCell>
                            Value:
                            <asp:Label ID="LabelTransactionValue" runat="server" Text="150000.00"></asp:Label>
                            SP
                        </asp:TableCell>
                    </asp:TableRow>
                </asp:Table>
            </div>
        </div>
        <div style="display: none;">
            <asp:RadioButton ID="RadioButtonDeposit" runat="server" GroupName="TransactionType" />
            <asp:RadioButton ID="RadioButtonWithdraw" runat="server" GroupName="TransactionType" />
            <asp:RadioButton ID="RadioButtonTransfer" runat="server" GroupName="TransactionType"  />
        </div>
    </form>
</body>
</html>
