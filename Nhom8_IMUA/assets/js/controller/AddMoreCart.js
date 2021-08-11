$(document).ready(function () {
    $('#addtocart').off().click(function () {
        $.ajax({
            type: "POST",
            url: 'Cart/AddToCart',
            data: {
                id: parseInt($('#ma').text()),
                quantity: parseInt($('#ipQuantity').val())
            },
            dataType: "json",
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