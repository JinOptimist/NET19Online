$(document).ready(function () {

    const url = "/hub/jerseychat";
    const hub = new signalR.HubConnectionBuilder().withUrl(url).build();
    let activeId = 0;
    let clientsCount = 0;

    hub.on("SendMessageWithId", function (id, message) {
        $('.chat-message-list[data-client-id="' + id + '"]').append('<div class="msg msg-them"> <blockquote>' + message + '</blockquote><div/>')
    });

    hub.on("SendToAdminThatThereIsNewClientInChat", function (id) {
        newbuttondiv = $('<div class="connection" data-client-id="' + id + '"> Пользователь ' + ++clientsCount + '</div>');
        newmessagediv = $('<div class="chat-message-list" data-client-id="' + id + '"></div>');
        newbuttondiv.on('click', function () {
            activeId = $(this).attr('data-client-id');
            $('.chat-message-list').hide();
            $('.chat-message-list[data-client-id="' + activeId + '"]').show();
            $('.connection').removeClass('buttonactive');
            $(this).addClass('buttonactive');
        });
        $('#active-connections').append(newbuttondiv);
        $('#chat-message-input').before(newmessagediv);
        if ($('.chat-message-list').length > 1) {
            $(newmessagediv).hide();
        } else {
            $(newbuttondiv).addClass('buttonactive');
            activeId = id;
        }
        
        
    });
  
    $('#chat-button-input').on('click', function () {
        message = $('#chat-text-input').val();
        $('#chat-text-input').val('');
        $('.chat-message-list[data-client-id="' + activeId + '"]').append('<div class="msg msg-me"> <blockquote>' + message + '</blockquote><div/>');
        hub.invoke("SendMessageToClient", activeId, message);
    });

    
    hub.start().then(function () {
        hub.invoke("AdminEnterToChat");
    });
});