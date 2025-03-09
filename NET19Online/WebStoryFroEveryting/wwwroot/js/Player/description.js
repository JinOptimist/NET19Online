$(document).ready(function () {
    $(".tags .tag").click(function () {
        $(this).addClass("active");
    });

    $(".tags .tag").click(function () {
        $(this).closest(".player-container").addClass("tag-border");
    });
});