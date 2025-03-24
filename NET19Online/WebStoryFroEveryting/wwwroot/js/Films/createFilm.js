$(document).ready(function () {

    $('[name="Name"]').on("keyup", function () {
        const nameItem = $('[name="Name"]').val();
        $('.name').text(nameItem);
    });

    $('[name="Src"]').on("keyup", function () {

        const img = $('[name="Src"]').val();
        $('.image-container img').attr('src', img);
    });

});