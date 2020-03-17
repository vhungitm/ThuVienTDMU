var PhieuMuon = {
    init: function () {
        PhieuMuon.registerEvents();
    },
    registerEvents: function () {
        $("a[name='TrangThai']").off('click').on('click', function (e) {
            e.preventDefault();
            var btn = $(this);
            var id = btn.data('id');
            $.ajax({
                url: "/Admin/PhieuMuon/ThayDoiTrangThai",
                data: { id: id },
                dataType: "json",
                type: "POST",
                success: function (response) {
                    console.log(response);
                    if (response.TrangThai > 0) {
                        btn.removeClass().addClass("btn btn-primary");
                        btn.text('Đã trả');
                        alert("Thay đổi trạng thái trả sách thành công!");
                    }
                    else if (response.TrangThai == 0) {
                        btn.removeClass().addClass("btn btn-danger");
                        btn.text('Chưa trả');
                        alert("Thay đổi trạng thái trả sách thành công!");
                    }
                    else {
                        alert("Lỗi");
                    }
                }
            });
        });
    }
}
PhieuMuon.init();