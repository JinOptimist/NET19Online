$(document).ready(function () {
  const url = "/hub/chat";
  const hub = new signalR.HubConnectionBuilder().withUrl(url).build();

  $(".send-new-message").click(sendMessage);
  $(".new-message").on("keyup", function (e) {
    // on Enter press
    if (e.which == 13) {
      sendMessage();
    }
  });

  function sendMessage() {
    const messageText = $(".new-message").val();
    hub.invoke("AddMessage", messageText);
  }

  hub.on("NewMessageArrived", function (userName, message) {
    AddMessageToPage(userName, message)
  });

  hub.on("NewUserInChat", function (userName) {
	AddMessageToPage('SYSTEM', `${userName} вошёл в чат`);
  });

  function AddMessageToPage(userName, message){
	const newMessageTag = $(".message.template").clone();
    newMessageTag.removeClass("template");
    newMessageTag.find(".author").text(userName);
    newMessageTag.find(".text").text(message);
    $(".messages").append(newMessageTag);
  }

  hub.start().then(function () {
    hub.invoke("EnterToChat");
  }); // open connection with server
});
