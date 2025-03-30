$(document).ready(function () {
    const baseUrl = 'https://localhost:7170/';
    const urlGetProduct = `${baseUrl}getProduct`;
    const urlAddProduct = `${baseUrl}addProduct`;

    $.get(urlGetProduct)
        .then(function (products) {
            products.forEach((product) => {
                const clone = $('.swapMeetProduct.template').clone();
                clone.removeClass('template');
                clone.find('.name').text(product.name);
                clone.find('.image img').attr('src', product.src);
                clone.find('.description').text(product.description);
                clone.find('.price').text(`${product.price}$`);
                $('.swapMeetProducts').append(clone);
            });
        });

    $('.createProduct button').click(function () {
        const name = $('.nameProduct').val();
        const src = $('.imageProduct').val();
        const description = $('.descriptionProduct').val();
        const price = $('.priceProduct').val();

        const url = `${urlAddProduct}?name=${name}&src=${src}
                     &description=${description}&price=${price}`;
        $.get(url);
    })
});



