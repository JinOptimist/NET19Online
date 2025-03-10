$(document).ready(function () {
  let counter = 1;
  const idolIdToRemoveIds = [];

  $(".idol .image-container img").click(function () {
    // after user click on image

    $(".idol .image-container img").removeClass("active");
    $(this).addClass("active");
  });

  $(".user-with-idol-ages").click(() => {
    console.log(++counter);
  });

  $(".soft-remove").click(function () {
    const idolTag = $(this).closest(".idol");
    idolTag.addClass("to-remove");
    const idolId = idolTag.attr("data-id");
	idolIdToRemoveIds.push(idolId);
	console.log(idolIdToRemoveIds);
  });

  $('.remove-all-selected-button').click(function(){
	const str = idolIdToRemoveIds.join(',');
	$('[name=idsToRemove]').val(str);
  });
});
