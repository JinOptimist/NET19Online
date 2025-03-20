$(document).ready(function () {
    $(".view-mode").click(function () {
        const viewModeContainer = $(this);
        viewModeContainer.hide();
        const oldName = viewModeContainer.text().trim();
        const updateModeContainer = $(this).parent().find(".update-mode");
        updateModeContainer.show();
        updateModeContainer.find(".new-name").val(oldName);
    });

    $(".close").click(function () {
        const updateModeContainer = $(this).closest(".update-mode");
        updateModeContainer.hide();
        updateModeContainer.parent().find(".view-mode").show();
    });

    $(".update-mode .update").click(function () {
        const id = $(this).closest(".player").attr("data-id");
        const newName = $(this).closest(".update-mode").find(".new-name").val();
        const url = `/api/player/UpdateName?id=${id}&newName=${newName}`;
        $.get(url);

        const updateModeContainer = $(this).closest(".update-mode");
        updateModeContainer.hide();
        const viewModeContainer = updateModeContainer.parent().find(".view-mode");
        viewModeContainer.text(newName);
        viewModeContainer.show();
    });

    $(".ajax-remove").click(function () {
        if (confirm("Are you sure?")) {
            const player = $(this).closest(".player");
            const id = player.attr("data-id");
            player.remove();

            $.get("/api/player/remove?id=" + id);
        }
    });

    $(".new-image").on("keyup", function () {
        const newImage = $(this).val();
        $(this).closest(".player-create-container").find(".image-container img").attr("src", newImage);
    });

    $(".create").click(function () {
        const newNameTag = $(this).closest(".player-create-container").find(".new-name");
        const newImageTag = $(this).closest(".player-create-container").find(".new-image");
        const newPositionTag = $(this).closest(".player-create-container").find(".new-position");
        const newWeightTag = $(this).closest(".player-create-container").find(".new-weight");
        const newHeightTag = $(this).closest(".player-create-container").find(".new-height");
        const name = newNameTag.val();
        const image = newImageTag.val();
        const position = newPositionTag.val();
        const weight = newWeightTag.val();
        const height = newHeightTag.val();
        const player = {
            Name: name,
            Src: image,
            Position: position,
            Weight: weight,
            Height: height
        };
        $.post("/api/player/create", player);
    });

});
