function CountItemsInCart() {
    $.get("/Cart/HowManyItemsInCart",
        function (data) {
            $('#counter').text('(' + data + ')');
        });
}
function SendAddToCartCommand(Id, Quantity) {
    if (Quantity == 0) {
        alert("You cannot order this book - current quantity is 0");
    }
    else {
        $.ajax({
            type: "POST",
            data: JSON.stringify({ Id }),
            dataType: 'json',
            url: "/Cart/AddToCart",
            contentType: "application/json",
            complete: function () {
                CountItemsInCart();
                CommandResult();
            }
        });
    }
}
function Delete(Id) {
    $.ajax({
        type: "POST",
        url: "Cart/RemoveFromCart",
        data: JSON.stringify({ Id }),
        contentType: "application/json",
        dataType: 'json',
        complete: function () {
            window.location.reload();
            CommandResult();
        }
    });
}

function CommandResult() {
    $('#TempMessage').load("/Base/ShortMessage");
}

function CommandResultShowMessage() {
    $('#tdata').css('display', 'inline-block').fadeTo(10000, 0).slideUp(2000, function () {
        $(this).remove();
    });
}

function BookReturment(orderDetailId) {
    $.ajax({
        type: "POST",
        url: "/Admin/Orders/BookReturment",
        data: JSON.stringify({ orderDetailId }),
        contentType: "application/json",
        dataType: 'json',
        complete: function () {
            window.location.reload();
            CommandResult();
        }
    });
}