$(document).ready(function () {
    let cartItems = [];

    const url = "/hub/device";
    const hub = new signalR.HubConnectionBuilder().withUrl(url).build();

    //обновление девайсов
    hub.on('GamingDeviceWasAdded', function (device) {
        addDeviceToPage(device);
    });

    hub.on('GamingDeviceWasRemoved', function (deviceId) {
        $(`.device[data-id="${deviceId}]`).fadeOut(200, function () {
            $(this).remove();
        });
    });

    //крестик в карточке товара для его сокрытия из общей выборки
    $('.remove-button').click(function () {
        const device = $(this).closest('.device');
        device.remove();
    });

    //работа с выбранными товарами и корзиной 
    const selectedProducts = new Set();
    let cartCount = 0;

    $('.device').click(function () {
        $(this).toggleClass('selected');

        const deviceId = $(this).data('id');

        if ($(this).hasClass('selected')) {
            selectedProducts.add(deviceId);
        } else {
            selectedProducts.delete(deviceId);
        }

        updateSelectionCounter();
    });

    function updateSelectionCounter() {
        const count = selectedProducts.size;

        if (count > 0) {
            positionAddToCartButton();
            $('#add-to-cart-widget').removeClass('hidden');
        } else {
            $('#add-to-cart-widget').addClass('hidden');
        }
    }

    function positionAddToCartButton() {
        const $cartIndicator = $('#cart-indicator');
        const cartVisible = !$cartIndicator.hasClass('hidden');

        if (cartVisible) {
            const cartHeight = $cartIndicator.outerHeight(true);
            $('#add-to-cart-widget').css('bottom', `${30 + cartHeight}px`);
        } else {
            $('#add-to-cart-widget').css('bottom', '20px');
        }
    }

    //добавление товаров в корзину
    $('#add-to-cart-widget').on('click', function () {

        const productIds = Array.from(selectedProducts);

        $.ajax({
            url: '/Cart/AddToCart',
            method: 'POST',
            contentType: 'application/json',
            data: JSON.stringify({ productIds }),
            success: function (response) {
                $('#cart-count').text(response.total); 
                $('#cart-indicator').removeClass('hidden');

                $('.device.selected').removeClass('selected');
                selectedProducts.clear();
                $('#add-to-cart-widget').addClass('hidden');
            },
            error: function () {
                alert('Ошибка при добавлении товаров в корзину.');
            }
        });

        positionAddToCartButton();
    });


    //показ корзины
    $('#cart-indicator').on('click', function (e) {
        e.preventDefault();

        const $modal = $('#cart-modal');
        const $container = $('#cart-items-container');

        $container.empty();

        $.ajax({
            url: '/Cart/GetCartDevices',
            method: 'GET',
            success: function (itemsFromServer) {

                cartItems = [];

                const grouped = {};
                itemsFromServer.forEach(item => {
                    if (!grouped[item.id]) {
                        grouped[item.id] = { ...item, count: 1 };
                    } else {
                        grouped[item.id].count += 1;
                    }
                });

                cartItems = Object.values(grouped);

                renderCart(cartItems);
                $modal.removeClass('hidden');
            },
            error: function () {
                $container.append('<p>Ошибка загрузки данных корзины.</p>');
                $modal.removeClass('hidden');
            }
        });
    });
    function renderCart(items) {
        const $container = $('#cart-items-container');
        $container.empty();

        let totalItems = 0;
        let totalPrice = 0;

        if (items.length === 0) {
            $container.append('<p>Корзина пуста.</p>');
            $('#cart-item-count').text('0');
            $('#cart-total').text('0.00');
            return;
        }

        items.forEach(item => {
            totalItems += item.count;
            totalPrice += item.price * item.count;

            const itemHtml = `
            <div class="cart-item" data-id="${item.id}">
                <div class="brand">${item.brand}</div>
                <div class="name">${item.name}</div>
                <img src="${item.src}" alt="${item.name}" style="max-width: 100px;" />
                <div class="price">${item.price} BYN</div>

                <div class="quantity-controls">
                    <button class="btn-minus">-</button>
                    <span class="quantity">${item.count}</span>
                    <button class="btn-plus">+</button>
                </div>
            </div>
            <hr />
        `;
            $container.append(itemHtml);
        });

        $('#cart-item-count').text(totalItems);
        $('#cart-total').text(totalPrice.toFixed(2));
    }

    $('#cart-items-container').on('click', '.btn-minus, .btn-plus', function () {
        const $item = $(this).closest('.cart-item');
        const id = parseInt($item.data('id'));

        const itemIndex = cartItems.findIndex(i => i.id === id);

        if ($(this).hasClass('btn-minus') && cartItems[itemIndex].count > 1) {
            cartItems[itemIndex].count--;
        } else if ($(this).hasClass('btn-plus')) {
            cartItems[itemIndex].count++;
        }

        renderCart(cartItems);
    });

    $('#close-cart-modal').on('click', function () {
        $('#cart-modal').addClass('hidden');
    });

    //оплатить
    $('#checkout-button').on('click', function () {
        const total = parseFloat($('#cart-total').text());

        if (total <= 0) {
            alert("Корзина пуста");
            return;
        }

        const ownerId = 1;

        $.ajax({
            url: 'https://localhost:7180/addTransaction',
            method: 'GET',
            contentType: 'application/json',
            data: { ownerId, total },
            statusCode: {
                416: function () {
                    $('#add-balance-modal').removeClass('hidden');
                }
            },
            success: function () {
                alert("✅ Оплата прошла успешно!");
                $('#cart-items-container').empty().append('<p>Корзина пуста.</p>');
                $('#cart-item-count').text('0');
                $('#cart-total').text('0.00');
                $('#cart-indicator').addClass('hidden');

                localStorage.removeItem('cart');
            },
            error: function (xhr, status, error) {
                if (xhr.status === 416) {
                    $('#add-balance-modal').removeClass('hidden');
                } else {
                    alert('❌ Ошибка при оплате: ' + error);
                }
            }
        });
    });

    $('#clear-button').on('click', function () {
        $.ajax({
            url: '/Cart/ClearCart',
            method: 'POST',
            success: function () {
                $('#cart-items-container').empty().append('<p>Корзина пуста.</p>');
                $('#cart-item-count').text('0');
                $('#cart-total').text('0.00');
                $('#cart-indicator').addClass('hidden');
            },
            error: function () {
                alert('Ошибка при очистке корзины');
            }
        });
    });

    

    //пополнение баланса
    $('#add-balance-form').on('submit', function (e) {
        e.preventDefault();

        const amount = $('input[name="amount"]').val();
        const ownerId = 1;

        $.ajax({
            url: 'https://localhost:7180/addBalance',
            method: 'POST',
            data: { ownerId, amount },
            success: function () {
                alert("Баланс пополнен");
                $('#add-balance-modal').addClass('hidden');
                $('#add-balance-form')[0].reset();

                $('#checkout-button').trigger('click');
            },
            error: function (xhr, status, error) {
                alert("Ошибка при пополнении баланса: " + error);
            }
        });
    });

    $('#close-add-balance-modal').on('click', function () {
        $('#add-balance-modal').addClass('hidden');
    });


    //добавление нового девайса
    $('#add-device-btn').on('click', function () {
        $('#add-device-modal').removeClass('hidden');
    });

    $('#close-add-device-modal').on('click', function () {
        $('#add-device-modal').addClass('hidden');
    });

    $('#add-device-form').on('submit', function (e) {
        e.preventDefault();

        const formData = $(this).serializeArray();
        const deviceData = {};

        $.each(formData, function (_, field) {
            deviceData[field.name] = field.value;
        });

        $.ajax({
            url: '/AddDevice',
            method: 'POST',
            contentType: 'application/json',
            data: JSON.stringify(deviceData),
            success: function (response) {
                alert('Товар успешно добавлен');

                $('#add-device-form')[0].reset();
                $('#add-device-modal').addClass('hidden');
            },
            error: function () {
                alert('Ошибка при добавлении товара');
            }
        });
    });

    function addDeviceToPage(device) {
        const deviceHtml = `
            <div class="device" data-id="${device.id}">
            <button class="remove-button">×</button>
            <div class="device-top">
                <div class="brand">${device.brand}</div>
                <div class="name">${device.name}</div>
                <div class="image-container">
                    <img src="${device.src}" />
                </div>
            </div>
            <div class="device-bottom">
                <div class="price">${device.price} BYN</div>
                <div class="device-buttons-horizontal">
                    <a href="/GamingDevice/GamingDevice?deviceId=${device.id}" class="primary-button">Подробнее</a>
                    <button class="delete-button primary-button" data-id="${device.id}">Удалить</button>
                </div>
            </div>
        </div>
        `;

        $('.devices').prepend(deviceHtml);


    }

    //превью создаваемого девайса
    const $brandInput = $('input[name="Brand"]');
    const $nameInput = $('input[name="Name"]');
    const $priceInput = $('input[name="Price"]');
    const $srcInput = $('input[name="Src"]');
    function getPreviewElements() {
        return {
            preview: $('#device-preview'),
            brand: $('#preview-brand'),
            name: $('#preview-name'),
            price: $('#preview-price'),
            image: $('#preview-image')
        };
    }

    function updatePreview(field) {
        const { preview, brand, name, price, image } = getPreviewElements();

        if (!preview.length) {
            console.error('#device-preview не найден');
            return;
        }

        if (field === 'brand') {
            const val = $brandInput.val();
            brand.text(val || '').toggle(!!val);
        }

        if (field === 'name') {
            const val = $nameInput.val();
            name.text(val || '').toggle(!!val);
        }

        if (field === 'price') {
            const val = $priceInput.val();
            const priceText = val ? parseFloat(val).toFixed(2) + ' BYN' : '';
            price.text(priceText).toggle(!!val);
        }

        if (field === 'src') {
            const val = $srcInput.val();
            if (val) {
                image.attr('src', val);
            } else {
                image.attr('src', 'https://turbok.by/img/no-photo--lg.png ');
            }
        }

        const anyVisible =
            brand.is(':visible') ||
            name.is(':visible') ||
            price.is(':visible') ||
            $srcInput.val();

        if (anyVisible && field) {
            preview.show(); 
        } else {
            preview.hide();
        }
    }

    $brandInput.on('input', function () { updatePreview('brand'); });
    $nameInput.on('input', function () { updatePreview('name'); });
    $priceInput.on('input', function () { updatePreview('price'); });
    $srcInput.on('input', function () { updatePreview('src'); });

    $('#add-device-btn').on('click', function () {
        const $modal = $('#add-device-modal');
        $modal.removeClass('hidden');
        updatePreview(); 
    });

    $('#close-add-device-modal').on('click', function () {
        $('#add-device-modal').addClass('hidden');

        $('#preview-brand').text('Бренд').hide();
        $('#preview-name').text('Название').hide();
        $('#preview-price').text('0 BYN').hide();
        $('#preview-image').attr('src', 'https://turbok.by/img/no-photo--lg.png ');
        $('#device-preview').hide();
    });

    //удаление девайса
    $(document).on('click', '.delete-button', function () {
        const deviceId = $(this).data('id');

        $.ajax({
            url: `/Remove/${deviceId}`,
            method: 'DELETE',
            success: function () {
                $(`.device[data-id="${deviceId}"]`).fadeOut(300, function () {
                    $(this).remove();
                });
                
            },
            error: function () {
                alert('Ошибка при удалении');
            }
        });
    });

    hub.start();

});
