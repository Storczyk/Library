function CountItemsInCart() {
    $.get("/Default/ShoppingCart/HowManyItemsInBasket",
        function (data) {
            $('#counter').text(data)
        });
}
function sendAddToCartCommand(Id) {
    $.ajax({
        type: "POST",
        data: JSON.stringify({ Id }),
        dataType: 'json',
        url: "/Default/ShoppingCart/AddToCart",
        contentType: "application/json",
        complete: function () {
            CountItemsInBasket();
        }
    });
}
function Delete(Id) {
    $.ajax({
        type: "POST",
        url: "/Default/ShoppingCart/RemoveFromCart",
        data: JSON.stringify({ Id }),
        contentType: "application/json",
        dataType: 'json',
        complete: function () {
            CountItemsInBasket();
        }
    });
}