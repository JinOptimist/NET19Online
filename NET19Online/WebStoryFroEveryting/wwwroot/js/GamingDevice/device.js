$(document).ready(function () {
    const deviceId = parseInt($('input[name="deviceId"]').val()); // получаем ID устройства

    $('.addresses').on('click', '.address', function () {
        const $original = $(this);
        const currentText = $original.text().trim();
        const stockAddressId = parseInt($original.data('id')); // получаем ID адреса

        if ($original.find('input').length > 0) return; // если уже в режиме редактирования — выходим

        // Создаем input и крестик
        const $input = $('<input>', {
            type: 'text',
            value: currentText,
            style: 'width: 80%; margin-right: 5px;'
        });

        const $deleteBtn = $('<button>', {
            text: '×',
            class: 'delete-address-btn',
            style: 'border: none; background: none; color: red; font-size: 1.2em; cursor: pointer;'
        }).data('id', stockAddressId); // сохраняем ID для удаления

        // Заменяем span на input + кнопка
        $original.empty().append($input).append($deleteBtn).addClass('editing');

        $input.focus(); // фокусируем поле ввода

        // Сохранение при потере фокуса или Enter
        $input.on('keypress', function (e) {
            if (e.which === 13) $(this).blur(); // Enter → сохранить
        });

        function saveAddress() {
            const newValue = $input.val().trim();

            if (!newValue) {
                alert('Адрес не может быть пустым');
                $original.empty()
                    .text(currentText)
                    .removeClass('editing');
                return;
            }

            $.ajax({
                url: `/${deviceId}/StockAddresses/${stockAddressId}/Update`,
                method: 'PUT',
                contentType: 'application/json',
                data: JSON.stringify(newValue), // отправляем новое значение как raw string
                success: function () {
                    $original.empty()
                        .text(newValue)
                        .removeClass('editing');
                },
                error: function () {
                    alert('Ошибка при обновлении адреса');
                    $original.empty()
                        .text(currentText)
                        .removeClass('editing');
                }
            });
        }
    });

    // Удаление адреса по нажатию на крестик
    $('.addresses').on('click', '.delete-address-btn', function (e) {
        e.stopPropagation(); // чтобы не активировалось редактирование
        console.log('Клик по крестику');


        const $btn = $(this);
        const stockAddressId = parseInt($btn.data('id'));
        const $span = $btn.parent('.address');

        if (!confirm('Вы уверены, что хотите удалить этот адрес?')) return;

        $.ajax({
            url: `/${deviceId}/StockAddresses/${stockAddressId}/Remove`,
            method: 'DELETE',
            success: function () {
                $span.remove(); // удаляем элемент из DOM
            },
            error: function () {
                alert('Ошибка при удалении адреса');
            }
        });
    });
    
});