$(document).ready(function () {
    const base_url = 'https://localhost:7117/';
    const urlGetLogos = `${base_url}getlogos`;
    const urlAddLogo = `${base_url}addlogo`;

    $.get(urlGetLogos)
        .then(function (logos) {
            for (var i = 0; i < logos.length; i++) {
                const logo = logos[i];
                const div = $('<div class="logo"><div class="logo-img"><img src="' + logo.img + '"/></div><div class="logo-clubname">' + logo.clubName + '</div></div>');
                $('#logos').append(div);
            }
        });

    $('#create-logo input[type="submit"]').click(function () {
        const clubName = $('input[name="create-logo-clubname"]').val();
        const img = $('input[name="create-logo-img"]').val();
        const url = `${urlAddLogo}?clubName=${clubName}&img=${img}`;
        $.get(url);
    })
});