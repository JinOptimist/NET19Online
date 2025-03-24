$(document).ready(function () {
    const base_url = 'https://localhost:7117/';
    const urlGetStatues = `${base_url}getStatues`;
    const urlAddStatue = `${base_url}addStatue`;

    $.get(urlGetStatues)
        .then(function (statues) {
            for (var i = 0; i < statues.length; i++) {
                const statue = statues[i];
                const clone = $('.statue.template').clone();
                clone.removeClass('template');
                clone.find('.name').text(statue.name);
                clone.find('.image img').attr('src', statue.src);
                clone.find('.desc').text(statue.description);
                $('.statues').append(clone);
            }
        });

    $('.add-new-statue-container button').click(function () {
        const name = $('.new-name').val();
        const src = $('.new-src').val();
        const url = `${urlAddStatue}?name=${name}&cost=11&desc=${name}&src=${src}`;
        $.get(url);
    })
});