$("#addNote").on("click", function () {
    var text = $("#noteText").val();
    var userId = $("#customerId").val();
    if (text.length > 0) {
        $.get(noteUrl+"?Text=" + text+"&UserId="+userId, function (data) {
             
            if (data.success) {
                $("#noteText").val("");
                var div = $("<div></div>");
                $(div).addClass("note mt-3").html("<strong>Just Now</strong> <br />"+text);
                $(".notes").prepend(div);
                $("#notescount").text(parseInt($("#notescount").text()) + 1);
            }
        });
    }
});