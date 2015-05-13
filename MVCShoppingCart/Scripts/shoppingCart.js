﻿var main = function () {
    $(".RemoveLink").click(function () {
        var recordToDelete = $(this).attr("data-id");
        var postToUrl = $(this).attr("data-url");
        if (recordToDelete != '') {
            $.post(postToUrl, { "id": recordToDelete },
                function (data) {
                    if (data.ItemCount == 0) {
                        $('#row-' + data.DeleteId).fadeOut('slow');
                    } else {
                        $('#item-count-' + data.DeleteId).text(data.ItemCount);
                    }
                    $('#cart-subtotal').text(data.CartSubTotal);
                    $('#cart-salestax').text(data.CartSalesTax);
                    $('#cart-total').text(data.CartTotal);
                    $('#update-message').text(data.Message);
                });
        }
    });
};

$(document).ready(main);