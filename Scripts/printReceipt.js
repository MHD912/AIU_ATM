$(document).ready(function () {

    // Print invoice script
    $('#HyperLinkPrint').click(function () {
        $('.print-section').printThis({
            printDelay: 1,
            pageTitle: "Transaction Invoice"
        });
    });
});