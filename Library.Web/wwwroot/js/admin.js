function sendEditBookCommand(id) {
    var model = { "Id": id };

    $.ajax({
        type: "GET",
        data: model,
        url: "/Admin/Book/Edit",
        contentType: "application/json"
    });
}

function sendDeleteBookCommand(id) {
    var model = { "Id": id };
    console.log(model);
    $.ajax({
        type: "POST",
        data: model,
        url: "/Admin/Book/Delete",
        contentType: "application/json",
    });
}