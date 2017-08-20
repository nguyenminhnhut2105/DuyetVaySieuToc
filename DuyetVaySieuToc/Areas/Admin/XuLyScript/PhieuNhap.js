
var homeController =
    {
        init: function () {
            homeController.registerEvent();
        },
        registerEvent: function () {

         //   $('#btnAdd').off('click').on('click', function () {
         //       var id_cuoi = $(".tblChiTietPhieuNhap").find("tr:last-child").attr("data-id");
         //       var idAuto = '';
         //       $.ajax({
         //           url: "/QuanLyNhapHang/GetAutoId",
         //           type: "GET",
         //           dateType: "text",
         //           data: {

         //           },
         //           success: function (result) {
         //               idAuto = result;
         //               i = parseInt(id_cuoi) + 1;

         //               var trnoidung = '   <tr class="trAppended" data-id="' + idAuto + '">  ' +
         //'               <td>  ' +
         //'                   <input type="hidden" class="form-control" id="maphieunhap" name="[' + id_cuoi + '].MAPHIEUNHAP" value="' + idAuto + '">  ' +
         //'               </td>  ' +
         //'               <td>  ' +
         //'                   <select class="ddlSanPham" name="[' + id_cuoi + '].MASANPHAM">  ' +

         //'                   </select>  ' +
         //'               </td>  ' +
         //'               <td>  ' +
         //'                   <input type="number" name="[' + id_cuoi + '].DONGIANHAP" class="form-control" id="txtDonGia" value="0">  ' +
         //'               </td>  ' +
         //'               <td>  ' +
         //'                   <input type="number" name="[' + id_cuoi + '].SOLUONGNHAP" class="form-control" id="txtSoLuong" value="0">  ' +
         //'               </td>  ' +

         //'               <td>  ' +
         //'                   <input class="btnDelete btn btn-danger" style="width:30px;height:30px" value="-">  ' +
         //'               </td>  ' +
         //'          </tr>  ';
         //               //Tạo 1 thẻ tr bao ngoài nội dung
         //               // var trnoidung = "<tr class=\"trAppended\" data-id=\"" + i + "\">" + tdnoidung + "</tr>";
         //               $(".tblChiTietPhieuNhap").append(trnoidung);
         //           }
         //       });



         //       loadIDLENTHE();

         //   });
            //Xử lý sự kiện xóa
            $("body").delegate(".btnDelete", "click", function () {
                // phần tử cha phía ngoài
                $(this).closest("tr").remove();
                CapNhapID();

            });
        },

    }



function loadIDLENTHE() {
    $(".trAppended").each(function () {
        //Lấy thuộc tính data-id của thẻ tr hiện
        var id = $(this).attr("data-id");
        var nameMaPhieuNhap = "[" + id + "].MAPHIEUNHAP"; //Tạo ra mã sản phẩm
        var nameMaSanPham = "[" + id + "].MASANPHAM"; //Tạo ra mã sản phẩm
        var nameSoLuongNhap = "[" + id + "].SOLUONGNHAP"; //Tạo ra số lượng nhập
        var nameDonGiaNhap = "[" + id + "].DONGIANHAP";   //Tạo ra đơn giá nhập
        $(this).find("#maphieunhap").attr("name", nameMaPhieuNhap);//Gán name đơn giá nhập
        $(this).find(".ddlSanPham").attr("name", nameMaSanPham);//Gán name cho dropdownlist
        $(this).find("#txtDonGia").attr("name", nameDonGiaNhap);//Gán name đơn giá nhập
        $(this).find("#txtSoLuong").attr("name", nameSoLuongNhap);//Gán name số lượng nhập

    })
};


function CapNhapID() {  
//Lấy lại tr 1
    var id_cuoi = $(".tblChiTietPhieuNhap").find(".trFirstChild").attr("data-id");
    i = parseInt(id_cuoi) + 1;

    $(".trAppended").each(function () {
        var id = i;
        $(this).attr("data-id", i);
        //Cập nhật lại id khi xóa
        var nameMaPhieuNhap = "[" + id + "].MAPHIEUNHAP"; //Tạo ra mã sản phẩm
        var nameMaSanPham = "[" + id + "].MASANPHAM"; //Tạo ra mã sản phẩm
        var nameSoLuongNhap = "[" + id + "].SOLUONGNHAP"; //Tạo ra số lượng nhập
        var nameDonGiaNhap = "[" + id + "].DONGIANHAP";   //Tạo ra đơn giá nhập
        $(this).find(".ddlSanPham").attr("name", nameMaSanPham);//Gán name cho dropdownlist
        $(this).find("#txtDonGia").attr("name", nameDonGiaNhap);//Gán name đơn giá nhập
        $(this).find("#txtSoLuong").attr("name", nameSoLuongNhap);//Gán name số lượng nhập
        $(this).find("#maphieunhap").attr("name", nameMaPhieuNhap);//Gán name số lượng nhập
        i++;
    })
}

homeController.init();