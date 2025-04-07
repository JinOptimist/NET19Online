$(document).ready(function () {

    $('#myButtonAPI').click(function () {
        $.get('/api/methods', function (data) {
            $('#nameMethods').empty();
            data.forEach(function (methodName) {
                $('#nameMethods').append(`<div>${methodName}</div>`);
            });
        });
        $('#dropdown').slideToggle(200);
    });

    $('#myButtonMethodWithParameters').click(function () {
        $.get('/MethodWithParameters', function (data) {

            console.log(data);
            $('#nameMethodWithParameters').empty();

            data.forEach(function (item, index) {

                $('#nameMethodWithParameters').append(`<div id="method${index}">Метод:${item.method}</div>`);

                let parametersContainer = $(`<div id="paramsForMethod${index}"></div>`);
                item.parameters.forEach(function (paramet) {
                    parametersContainer.append(`<div>Параметр:${paramet.name}</div>`);

                    if (paramet.properties.length > 0) {
                        let propertiesContainer = $(`<div id="propertiesForMethod${index}"></div>`);
                        paramet.properties.forEach(function (propert) {
                            propertiesContainer.append(`<div>Проперти:${propert.name}</div>`)
                        });
                        parametersContainer.append(propertiesContainer);
                    }
                });


                $(`#method${index}`).after(parametersContainer);
            });
        });
        $('#dropdownMethod').slideToggle(200);
    });

});
