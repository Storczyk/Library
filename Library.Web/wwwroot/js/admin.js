function sendEditBookCommand(id) {
    var model = { "Id": id };
    console.log(model);
    $.ajax({
        type: "GET",
        data: model,
        url: "/Admin/Book/Edit",
        contentType: "application/json"
    });
}

function sendDeleteBookCommand(Id) {
    $.ajax({
        type: "POST",
        data: JSON.stringify({ Id }),
        url: "/Admin/Book/Delete",
        contentType: "application/json"

    });
}