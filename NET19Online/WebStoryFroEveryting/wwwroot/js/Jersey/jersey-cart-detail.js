$(document).ready(function () {
    let positionsInCart = $('input[name="positionsInCart"]').val();
    let cartItemCounter = $('span.position-in-cart');
    if (positionsInCart > 0) {
        cartItemCounter.html(positionsInCart);
        cartItemCounter.removeClass('hidden');
    }
    else {
        cartItemCounter.addClass('hidden');
    }
    $('a.button.addToCart-button').on('click', function () {
        const target = $(this);
        const url = "/api/jerseycart/addtocart";
        const parent = $(this).closest('.jersey-detail-info');
        const jerseyid = parent.find('input[name="jerseyId"]').val();


        $.ajax({
            url: url,
            type: "POST",
            contentType: "application/json; charset=utf-8",
            data: JSON.stringify(jerseyid),
            dataType : "json",
            success: function (response) {
                target.removeClass('addToCart-button');
                target.addClass('addedToCart-button');
                target.text('Добавлено в корзину');
                positionsInCart++;
                cartItemCounter.html(positionsInCart);
                if (positionsInCart > 0) {
                    cartItemCounter.html(positionsInCart);
                    cartItemCounter.removeClass('hidden');
                }
                else {
                    cartItemCounter.addClass('hidden');
                }
            }
        });
    });
});