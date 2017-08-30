function sendDeleteBookCommand(id) {
    $.ajax({
        type: "POST",
        data: JSON.stringify({ id }),
        dataType: 'json',
        url: "/Admin/Book/Delete",
        contentType: "application/json",
        complete: function() {
            window.location.href = "/Admin/Book/Index";
        }
    });
}