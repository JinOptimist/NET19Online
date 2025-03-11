$(document).ready(function () {
    $('.block-elements .name').click(function () {

        $('.block-elements').removeClass('active')
        $(this).addClass('active');
        $(this).addClass('to-remove');

        $('.soft-remove').click(function () {
            const ITEM = $(this).closest('.block-elements');
            ITEM.remove();

        });

     });



});