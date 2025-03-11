$(document).ready(function () {
    $('[name=NameHunter]').on('keyup', function () {
        const name = $('[name=NameHunter]').val();
        $('.huntersPreview .name').text(name);
    })

    $('[name=Image]').on('keyup', function () {
        const image = $('[name=Image]').val();
        $('.huntersPreview .image img').attr('src', image);
    })
});


