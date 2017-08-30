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

function sendDeleteBookCommand(id) {
    var Id = id;
    console.log(JSON.stringify({ id }));
    $.ajax({
        type: "POST",
        data: JSON.stringify({ Id }),
        url: "/Admin/Book/Delete",
        contentType: "application/json"
    });
}