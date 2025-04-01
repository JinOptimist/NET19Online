$(document).ready(function () {
    const base_usr = 'http://localhost:5032/';
    const urlGetCartoon = `${base_usr}getCartoons`;
    const urlAddCartoon = `${base_usr}addCartoons`;

    const point = $.get(urlGetCartoon);
    point.done(function (data, status, jqXHR) {
        console.log("Запрос успешен, статус:", status);
    });

    point.fail(function (jqXHR, status, error) {
        console.log("Запрос не удался, ошибка:", error);
    });

    


})