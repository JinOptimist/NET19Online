$(document).ready(function () {
    const url = "/hub/hunter";
    const hub = new signalR
        .HubConnectionBuilder()
        .withUrl(url)
        .build();

    $('.hide-image').click(function () {
        $(this).closest('.hunters').remove();
    });

    $(".removeIcon").click(function () {
        const hunter = (this).closest(".hunters");
        const id = $(hunter).attr('data-id');
        hunter.remove();
        $.get("/api/underwaterHunter/remove?id=" + id);
    });

    $(".creatHunter").click(function () {
        const name = $(".new-name").val();
        const nationality = $(".new-nationality").val();
        const maxDepth = $(".new-maxDepth").val();
        const image = $(".new-image").val();
        const hunter = {
            name: name,
            nationality: nationality,
            maxDepth: maxDepth,
            image: image
        };
        $.get("/api/underwaterHunter/create?name=" + name
            + "&nationality=" + nationality + "&maxDepth=" + maxDepth + "&image=" + image)
            .then(function (id) {
                const defaultValueForLikeDislike = 0;
                const clone = $(".createrNewhunter.template").clone();
                clone.removeClass("template");
                clone.attr("data-id", id);
                clone.find(".image img").attr("src", image);
                clone.find(".dislikesCount").text(`${defaultValueForLikeDislike}`);
                clone.find(".likesCount").text(`${defaultValueForLikeDislike}`);
                clone.find(".name").text(name);
                clone.find(".nationality").text(`Nationality: ${nationality}`);
                clone.find(".maxDepth").text(`MaxHuntingDepth: ${maxDepth} meters`);
                clone.appendTo(".allHunters.creater");
            });
    });

    $(".image-like").click(function () {
        const idHunter = $(this)
            .closest(".hunters")
            .attr("data-id");
        $.get("/api/underwaterHunter/Like?id=" + idHunter);
    })

    hub.on("Like", function (id, likesCount) {
        $(`.hunters[data-id= ${id}]`)
            .find(".likesCount")
            .text(likesCount);
    });

    $(".image-dislike").click(function () {
        const idHunter = $(this)
            .closest(".hunters")
            .attr("data-id");
        $.get("/api/underwaterHunter/Dislike?id=" + idHunter);
    })

    hub.on("Dislike", function (id, dislikesCount) {
        $(`.hunters[data-id= ${id}]`)
            .find(".dislikesCount")
            .text(dislikesCount);
    });

    hub.start();
});



