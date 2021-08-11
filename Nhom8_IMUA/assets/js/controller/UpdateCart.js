$(document).ready(function () {
    $(".qty").off().change(function () {
        $.ajax({
            url: "Cart/UpdateCart",
            type: "POST",
            data: {
                id: $(this).data("id"),
                quantity: $(this).val()
            },
            dataType: "json",
            success: function (data) {

            },
            error: function () {
                alert("Lỗi trong khi sua vào giỏ hàng!");
            }
        });
        return false;
    })
});