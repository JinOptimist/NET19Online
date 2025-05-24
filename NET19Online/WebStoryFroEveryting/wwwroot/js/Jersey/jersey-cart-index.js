$(document).ready(function () {
    let positionsInCart = $('input[name="positionsInCart"]').val();
    $('span.position-in-cart').html(positionsInCart);
    $('a.button.addToCart-button').on('click', function () {
        const target = $(this);
        const url = "/api/jerseycart/addtocart";
        const parent = $(this).closest('.jersey');
        const jerseyid = parent.find('input[name="jersey-id"]').val();


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
                $('span.position-in-cart').html(positionsInCart);
            }
        });
    });
});