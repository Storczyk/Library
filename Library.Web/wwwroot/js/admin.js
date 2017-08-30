function sendEditBookCommand(id) {
    var model = { "Id": id };

    $.ajax({
        type: "GET",
        data: model,
        url: "/Admin/Book/Edit",
        contentType: "application/json"
    });
}