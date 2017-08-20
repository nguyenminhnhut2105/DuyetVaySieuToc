
//$(document).on("click", ".editcomment", function () {
//        var idcomment = $(this).data('id');
//        var noidungcomment = $(this).data('value');
//        var tdn=$(this).data('tdn');
//        var masp = $(this).data('masp');
//        var nbl = $(this).data('nbl');
//        $(".modal-body #NoiDungBLMoi").val(noidungcomment);
//        $(".modal-body #macomment").val(idcomment);
//        $(".modal-body #tendangnhap").val(tdn);
//        $(".modal-body #masp").val(masp);
//        $(".modal-body #ngaybl").val(nbl);
//       //Close update
//        $('#editcomment1').modal('show');
//    });
//       // delete
//$(document).on("click", ".xoabinhluan", function ()
//{
//        var idcomment = $(this).data('id');
//        $(".modal-body #mabl").val(idcomment);
//    });
   


$(document).on("click", ".editcomment", function () {
    var idcomment = $(this).data('id');
    var noidungcomment = $(this).data('value');
    var tdn = $(this).data('tdn');
    var masp = $(this).data('masp');
    var nbl = $(this).data('nbl');
    $(".modal-body #NoiDungBLMoi").val(noidungcomment);
    $(".modal-body #macomment").val(idcomment);
    $(".modal-body #tendangnhap").val(tdn);
    $(".modal-body #masp").val(masp);
    $(".modal-body #ngaybl").val(nbl);
    //Close update
    $('#editcomment1').modal('show');
});
$(document).on("click", ".xoabinhluan", function () {
    var idcomment = $(this).data('id');
    $(".modal-body #mabl").val(idcomment);
    $('#deletebinhluan1').modal('show');
});