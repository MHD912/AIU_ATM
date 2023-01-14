<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Receipt.aspx.cs" Inherits="AIU_ATM.Receipt" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Print Receipt</title>
    <meta charset="UTF-8" />
    <style>
        .print-section {
            display: none;
        }
    </style>
    <script src="Scripts/jquery-3.6.1.min.js"></script>
    <script src="Scripts/printThis.js"></script>
    <script>
        function close_window(url) {
            var newWindow = window.open('', '_self', ''); //open the current window
            newWindow.close(url);
        }
        $('document').ready(function () {
            $('.print-section').printThis({
                printDelay: 500,
                loadCSS: "Content/ReceiptStyling.css",
                pageTitle: "Transaction Receipt",
                beforePrint: function () {
                    $('.print-section').css('display', '');
                    if ($('#RadioButtonTransfer').prop("checked") === true) {
                        $("#LabelTransactionType").text("Transfer");
                        $("#TableRowSenderAccount").show();
                        $("#TableRowReceipientAccount").show();
                        $("#TableRowCustomerAccount").hide();
                    }
                    else if ($('#RadioButtonDeposit').prop("checked") === true) {
                        $("#LabelTransactionType").text("Deposit");
                        $("#TableRowSenderAccount").hide();
                        $("#TableRowReceipientAccount").hide();
                        $("#TableRowCustomerAccount").show();
                    }
                    else {
                        $("#LabelTransactionType").text("Withdraw");
                        $("#TableRowSenderAccount").hide();
                        $("#TableRowReceipientAccount").hide();
                        $("#TableRowCustomerAccount").show();
                    }
                },
                afterPrint: function () {
                    close_window('Receipt.aspx');
                }
            });
        });
    </script>
</head>
<body>
    <p>You will be automatically redirected to the main page...</p>
    <form id="form1" runat="server">
        <div class="print-section" style="margin-top: 9%;">
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
                                        Receipt #: 123<br />
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
                                        12345 Tanzim Kafar Souseh<br />
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
            <asp:RadioButton ID="RadioButtonTransfer" runat="server" GroupName="TransactionType" />
        </div>
    </form>
</body>
</html>
