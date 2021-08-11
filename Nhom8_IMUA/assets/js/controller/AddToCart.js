$(document).ready(function () {
    $('.ajax-cart').off().click(function () {
        console.log($(this).data("id"));
        $.ajax({
            type: "POST",
            url: 'Cart/AddToCart',
            data: {
                id: $(this).data("id"),
                quantity: 1
            },
            dataType: 'json',
            success: function (data) {
                alert("Thêm giỏ hàng thành công!");
                $(".cart__number").html("(" + data.SoLuong + ")");
            },
            error: function () {
                alert("Lỗi trong khi thêm vào giỏ hàng!");
            }
        });
        return false;
    })
});