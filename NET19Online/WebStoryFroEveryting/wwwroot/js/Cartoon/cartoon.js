$(document).ready(function () {
    const base_usr = 'http://localhost:5032/';
    const urlGetCartoon = `${base_usr}getCartoons`;
    const urlAddCartoon = `${base_usr}addCartoons`;

    const point = $.get(urlGetCartoon);
    point.done(function (data, status, jqXHR) {
        console.log("Запрос успешен, статус:", status, data);
    });
    point.fail(function (jqXHR, status, error) {
        console.log("Запрос не удался, ошибка:", error);
    });

    $.get(urlGetCartoon)
        .then(function (data) {

            for (var i = 0; i < data.length; i++) {
                const item = data[i];
                const clone = $('.cartoon.block-elements').clone();
                clone.find('block-elements').removeClass();
                clone.find('.name').text(item.name);
                clone.find('.image img').attr('src', item.src);
                $('.cartoons').append(clone);
            }
        });

    $('.add-new-cartoons-container button').click(function () {
        const name = $('.new-name').val();
        const src = $('.new-src').val();
        const url = `${urlAddCartoon}?name=${name}&src=${src}`;
        $.get(url);
    })
});
