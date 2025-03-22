$(document).ready(function () {


    $('.main-layout .block-elements').removeClass('active')
    $(this).addClass('active');
    $('.main-layout .block-elements').removeClass('block-element')
    $(this).addClass('block-element')


    $('.soft-remove').click(function () {
        const ITEM = $(this).closest('.block-elements');
        ITEM.remove();
    });


    $('.name').click(function () {
        const viewModelContainer = $(this);
        viewModelContainer.hide();
        const oldName = viewModelContainer.text().trim();
        const updateModeContainer = $(this).closest('.main-layout .block-elements')
            .find('.update-mode');
        updateModeContainer.show();
        updateModeContainer.find(".new-name").val(oldName);
    });

    $('.close').click(function () {
        const closeModeContainer = $(this).closest(".update-mode");
        closeModeContainer.hide();
        const nameShow = $(this).closest(".block-elements").find(".name");
        nameShow.show();
    });

    $(".update-mode .update").click(function () {

        const id = $(this).closest(".update-mode").attr("id");
        const newName = $(this).closest(".update-mode").find(".new-name").val();
        const url = `/api/Film/UpdateName?id=${id}&newName=${newName}`;
        $.get(url);

        const closeModeContainer = $(this).closest(".update-mode");
        closeModeContainer.hide();
        const newNameShow = $(this).closest(".block-elements").find(".name");
        newNameShow.text(newName);
        newNameShow.show();
    });

    $(".delete-movie").click(function () {

        const id = $(this).closest(".update-mode").attr("id");
        const url = `/api/Film/DeleteMovie?id=${id}`;

        $.get(url).done(function () {
            location.reload();
        });
    });

    $(".new-name").on("keyup", function () {
        const Newname = $(this).val();
        $('.create-name').text(Newname);
    });

    $(".new-image").on("keyup", function () {
        const newImage = $(this).val();
        $(this).closest(".block-elements").find(".image-container img").attr("src", newImage)
    });


    $(".create").click(function () {

        const newName = $(this).closest(".block-elements").find(".new-name").val();
        const newImage = $(this).closest(".block-elements").find(".new-image").val();
        const idol = {
            Name: newName,
            Src: newImage
        };
 
   
        $.post("/api/Film/create", idol).then(function (id) {
            location.reload();
        });
    });




});