$(document).ready(function () {
  const url = "/hub/idol";
  const hub = new signalR.HubConnectionBuilder().withUrl(url).build();

  hub.on("IdolWasAdded", function (idolSrc) {
    const notification = $(".notification.template").clone();
    notification.removeClass("template");
	notification.click(removeNotification);
    const imageTag = $("<img>");
    imageTag.attr("src", idolSrc);
    notification.append(imageTag);
    $(".notification-container").append(notification);
  });

  function removeNotification(){
	$(this).remove();
  }

  hub.start(); // open connection with server
});
