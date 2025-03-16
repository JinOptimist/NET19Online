$(document).ready(function () {
    $('.jersey').on({
        mouseenter: function () {
            const img = $(this).find('img');
            const imgMainImg = img.attr('data-mainimg');
            const imgSecondImg = img.attr('data-secondimg');
            img.attr('src', imgSecondImg);
            console.log('hover');
        },
        mouseleave: function () {
            const img = $(this).find('img');
            const imgMainImg = img.attr('data-mainimg');
            const imgSecondImg = img.attr('data-secondimg');
            img.attr('src', imgMainImg);
        }
    });
});