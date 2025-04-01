$(document).ready(function () {
    const url = '/api/jersey/';
    $('.method-info button').on('click', function () {
        const parent = $(this).closest('.method-info');
        const actionUrl = $(parent).find('.method-name').text();
        const inputList = $(parent).find('input');
        let obj = {};
        inputList.each(function () {
            let propName = $(this).attr('name');
            let propValue = $(this).val();
            obj[propName] = propValue;
        });

        $.ajax({
            url: url + actionUrl, // указываем URL
            method: "Post",            // HTTP метод, по умолчанию GET
            data: obj,         // данные, которые отправляем на сервер
            dataType: "json",         // тип данных загружаемых с сервера
            success: function (data) {
                // вешаем свой обработчик события success
                parent.find('.method-output').text(JSON.stringify(data));
                console.log(data);
            }
            
        });

        //$.post(url + actionUrl, obj).then(function (obj) {
         //   parent.find('.method-output').text(obj);
        //});
    });
});