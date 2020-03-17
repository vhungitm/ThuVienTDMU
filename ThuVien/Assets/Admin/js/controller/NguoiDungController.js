var NguoiDung = {
    init: function () {
        NguoiDung.registerEvents();
    },
    registerEvents: function () {
        $("a[name='TrangThai']").off('click').on('click', function (e) {
            e.preventDefault();
            var btn = $(this);
            var id = btn.data('id');
            $.ajax({
                url: "/Admin/NguoiDung/ThayDoiTrangThai",
                data: { id: id },
                dataType: "json",
                type: "POST",
                success: function (response) {
                    console.log(response);
                    if (response.TrangThai > 0) {
                        btn.removeClass().addClass("btn btn-primary");
                        btn.text('Kích hoạt');
                        alert("Thay đổi trạng thái kích hoạt thành công!");
                    }
                    else if (response.TrangThai == 0) {
                        btn.removeClass().addClass("btn btn-danger");
                        btn.text('Khóa');
                        alert("Thay đổi trạng thái kích hoạt thành công!");
                    }
                    else {
                        alert("Lỗi");
                    }
                }
            });
        });
    }
}
NguoiDung.init();