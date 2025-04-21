document.querySelectorAll(".remove-item").forEach(button => {
    button.addEventListener("click", async function () {
        const id = this.dataset.id;

        if (!confirm("Удалить этого певца?")) return;

        const token = document.querySelector('input[name="__RequestVerificationToken"]').value;

        const response = await fetch("/Singer/Delete", {
            method: "POST",
            headers: {
                "Content-Type": "application/x-www-form-urlencoded",
                "RequestVerificationToken": token
            },
            body: `id=${encodeURIComponent(id)}`
        });

        if (response.ok) {
            this.closest(".singer").remove();
        } else {
            alert("Ошибка при удалении");
        }
    });
});
