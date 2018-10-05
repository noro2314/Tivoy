$("#addNote").on("click", function () {
    var text = $("#noteText").val();
    var userId = $("#customerId").val();
    if (text.length > 0) {
        $.get(noteUrl+"?Text=" + text+"&UserId="+userId, function (data) {
             
            if (data.success) {
                $("#noteText").val("");
            }
        });
    }
});