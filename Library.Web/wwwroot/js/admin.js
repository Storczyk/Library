function sendEditBookCommand(id) {
    var model = { "Id": id };
    $.ajax({
        type: "GET",
        data: model,
        url: "/Admin/Book/Edit",
        dataType: 'json',
        contentType: "application/json",
        success: function (data) {
            alert(data.redirect);
        }
    });
}

function sendDeleteBookCommand(id) {
    $.ajax({
        type: "POST",
        data: JSON.stringify({ id }),
        dataType: 'json',
        url: "/Admin/Book/Delete",
        contentType: "application/json",
        complete: function() {
            window.location.href = "Index";
        }
    });
}