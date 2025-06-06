﻿$(document).ready(function () {
    const base_url = 'https://localhost:7000/';
    const urlGetTools = `${base_url}getTools`;
    const urlAddTool = `${base_url}addTool`;

    
    $.get(urlGetTools)
        .done(function (tools) {
            console.log("Получены инструменты:", tools);
            if (!Array.isArray(tools)) {
                console.error("Ошибка: получены не массив данных!");
                return;
            }

            tools.forEach(tool => {
                const clone = $('.tool.sample').clone();
                clone.removeClass('sample');
                clone.find('.name').text(tool.name);
                clone.find('.image img').attr('src', tool.src);
                clone.find('.desc').text(tool.description);
                clone.find('.price').text(tool.price);
                $('.tools').append(clone);
            });
        })
        .fail(function (err) {
            console.error("Ошибка при получении инструментов:", err);
        });

   
    $('.add-new-tool-container button').click(function () {
        console.log("Клик по кнопке создания!");

        const name = $('.new-name').val();
        const src = $('.new-src').val();
        const desc = $('.new-desc').val();
        const price = $('.new-price').val();

        if (!name || !desc || !src || !price) {
            alert('Заполните все поля!');
            return;
        }

        const newTool = {
            name: name,
            src: src,
            desc: desc,
            price: price
        };

       
        $.post(urlAddTool, newTool)
            .done(function () {
                alert('Инструмент добавлен!');
                location.reload(); 
            })
            .fail(function (err) {
                console.error("Ошибка при добавлении инструмента:", err);
                alert('Ошибка при добавлении инструмента.');
            });
    });
});
