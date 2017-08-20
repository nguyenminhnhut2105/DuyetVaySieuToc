$(document).ready(function () {
    $("body").delegate(".addcart", "click", function () {
        $.ajax({
            type: 'POST',
            url: '@Url.Action("ThemGioHangAjax", "GioHang")',
            data: { maSP: this.name },
            success: function (ketqua) {

                $('#divGioHang').html(ketqua);

            }

        })

    });

});