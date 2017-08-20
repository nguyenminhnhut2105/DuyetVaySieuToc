$('#checkthongtin').click(function () {
    $('#check_cart').slideUp();
    $('#thongtin').slideDown();

});
$("body").delegate(".btn-delete", "click", function () {
    var total = $("#cart-total").text().trim();
    soluong = $('#check_cart').find(".SoLuongThayDoi").val();
    alert(soluong);
    var kq = parseInt(total) - parseInt(soluong);
    $.ajax({
        type: 'Get',
        url: '@Url.Action("DeleteItemAjax","GioHang")',
        data: { maSP: this.name },

        success: function (ketqua) {

            $('#ajaxdeleleupdate').html(ketqua);


        }
    });


});
function ThayDoi(masanPham, soluong) {
    $.ajax({
        type: 'Get',
        url: '@Url.Action("UpdateItemAjax", "GioHang")',
        data:
        {
            maSP: masanPham,
            sl: soluong

        },
        success: function (ketqua) {

            $('#ajaxdeleleupdate').html(ketqua);
            //$("#cart-total").html(ketqua);


        }
    });
}