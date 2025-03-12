$(document).ready(function () {
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
                const clone = $(".newHunters.hunters").clone();
                clone.removeClass("sample");
                clone.attr("data-id", id);
                clone.find(".newHunters.image img").attr("src", image);
                clone.find(".newHunters.name").text(name);
                clone.insertBefore($(".newHunters"));                
            });
    });

});



