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


    $('.jersey.create input[type="button"]').on('click', function () {
        const url = "/api/jersey/CreateJersey";
        const createArea = $('.jersey.create');
        

        const athleteName = createArea.find('input[name=AthleteName]').val();
        const img = createArea.find('input[name="Img"]').val();
        const secondImg = createArea.find('input[name="SecondImg"]').val();
        const number = createArea.find('input[name="Number"]').val();
        const club = createArea.find('input[name="Club"]').val();
        const price = createArea.find('input[name="Price"]').val();
        const inStock = createArea.find('input[name="InStock"]').val();

        const obj = {
            AthleteName: athleteName,
            Img: img,
            SecondImg: secondImg,
            Number: number,
            Club: club,
            Price: price,
            InStock: inStock
        };
        $.post(url, obj).then(function (id) {
            const clone = $('.jersey.template').clone();
            clone.removeClass('template');
            clone.find('img').attr('src', img).attr('data-mainimg', img).attr('data-secondimg', secondImg);
            clone.find('.name').text(name);
            clone.find('a.button.more').attr('href', '/jerseys/detail?jerseyid=' + id);
            clone.find('a.button.red').attr('href', '/jerseys/remove?jerseyid=' + id);
            clone.insertBefore(createArea);
        });
    });
});