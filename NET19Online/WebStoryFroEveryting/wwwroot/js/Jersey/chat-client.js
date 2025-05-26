$(document).ready(function () {
    let isHide = false;
    $('#chat-header').on('click', function () {
        if (isHide) {
            $('#chat-main-area').show();
            isHide = false;
        }
        else {
            $('#chat-main-area').hide();
            isHide = true;
        }
    });

    const url = "/hub/jerseyChat";
    const hub = new signalR.HubConnectionBuilder().withUrl(url).build();

    function AddMessageToPage(message) {
        $('#chat-message-list').append('<div class="msg msg-me"> <blockquote>' + message +'</blockquote></div>');
    }

    hub.on("SendMessage", function (message) {
        $('#chat-message-list').append('<div class="msg msg-them"> <blockquote>' + message + '</blockquote></div>');
    });

    hub.on("SendToAdminConnectionId", function (message) {
        hub.invoke("ClientEnterToChat");
    });

    $('#chat-button-input').on('click', function () {
        message = $('#chat-text-input').val();
        $('#chat-text-input').val('');
        AddMessageToPage(message);
        hub.invoke("SendMessageToAdmin", message);
    });

    hub.start().then(function () {
        hub.invoke("ClientEnterToChat");
    });
});