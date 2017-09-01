function CountItemsInCart() {
    $.get("/ShoppingCart/HowManyItemsInCart",
        function (data) {
            $('#counter').text('(' + data + ')')
        });
}
function SendAddToCartCommand(Id) {
    $.ajax({
        type: "POST",
        data: JSON.stringify({ Id }),
        dataType: 'json',
        url: "/ShoppingCart/AddToCart",
        contentType: "application/json",
        complete: function () {
            CountItemsInCart();
        }
    });
}
function Delete(Id) {
    $.ajax({
        type: "POST",
        url: "/ShoppingCart/RemoveFromCart",
        data: JSON.stringify({ Id }),
        contentType: "application/json",
        dataType: 'json',
        complete: function () {
            window.location.reload();
        }
    });
}
