$(document).ready(function () {
    $(".del").off().click(function () {
        $.ajax({
            url: "Cart/RemoveCart",
            type: "POST",
            data: {
                id: $(this).data("id")
            },
            dataType: "json",
            success: function () {

            },
            error: function () {
                alert("Lỗi trong khi sua vào giỏ hàng!");
            }
        });
        return false;
    })
});