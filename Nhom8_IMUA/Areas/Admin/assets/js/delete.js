$(document).ready(function () {
    $(".delBtn").click(function (e) {
        e.preventDefault();
        var result = confirm("Bạn muốn xóa tin tức này không?");
        if (result) {
            $.ajax({
                url: "/Admin/TinTucs/Delete",
                type: "POST",
                data: {
                    id: $(this).data("id")
                },
                dataType: "json",
                success: function (data) {
                    if (data != null) {
                        window.location.reload();
                    } else {
                        alert("loi");
                    }
                },
                error: function () {
                    alert("Lỗi trong khi xóa!");
                }
            });
        }
    })
});