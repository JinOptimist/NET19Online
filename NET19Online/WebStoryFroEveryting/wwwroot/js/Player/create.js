$(document).ready(function () {
    $('[name="Name"]').on("keyup", function () {
        const currentName = $('[name="Name"]').val();
        $('.player .name').text(currentName);
    });

    $('[name="Src"]').on("keyup", function () {
        const currentSrc = $('[name="Src"]').val();
        $('.player .image-container img').attr('src', currentSrc);
    })

    $('[name="Position"]').on("keyup", function () {
        const currentPosition = $('[name="Position"]').val();
        $('.player .position').text(currentPosition);
    });

    $('[name="Weight"]').on("keyup", function () {
        const currentWeight = $('[name="Weight"]').val();
        $('.player .weight').text(currentWeight);
    });


    $('[name="Height"]').on("keyup", function () {
        const currentHeight = $('[name="Height"]').val();
        $('.player .height').text(currentHeight);
    });
});