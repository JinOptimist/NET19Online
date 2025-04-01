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
            url: url + actionUrl,
            method: "Post",
            data: obj,
            dataType: "json",
            success: function (data) {
                parent.find('.method-output').text(JSON.stringify(data));
            }
        });
    });
});