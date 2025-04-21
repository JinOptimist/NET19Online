$(document).ready(function () {
    $(".remove-item").click(function () {
        const singerId = $(this).data("id");
        if (confirm("Удалить этого певца?")) {

            $.ajax({
                url: "/Singer/Delete", 
                type: "POST",
                data: { id: singerId }, 
                success: function (response) {
                    $(`.singer[data-id="${singerId}"]`).remove(); 
                    location.reload(); 
                },
                error: function () {
                    alert("Ошибка при отправке запроса");
                }
            });
        }
    });
});
