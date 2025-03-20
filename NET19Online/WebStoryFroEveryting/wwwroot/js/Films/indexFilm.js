$(document).ready(function () {
    $('.block-elements ').click(function () {

        $('.main-layout .block-elements').removeClass('active')
        $(this).addClass('active');
        $('.main-layout .block-elements').removeClass('block-element')
        $(this).addClass('block-element')


        $('.soft-remove').click(function () {
            const ITEM = $(this).closest('.block-elements');
            ITEM.remove();

        });

    });
});