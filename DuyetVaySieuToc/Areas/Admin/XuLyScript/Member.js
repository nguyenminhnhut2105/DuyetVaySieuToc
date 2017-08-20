/// <reference path="E:\Aptech_CanTho\DuyetVaySieuToc\scripts/toastr.js" />

var homeconfig =
    {
        pageSize: 5,
        pageIndex: 1,

    }
var homeController =
    {
        init: function () {
            homeController.loadData(true);
            homeController.registerEvent();
        },
        registerEvent: function () {

            $('#btnAddNew').off('click').on('click', function () {
                $('#modalAddUpdate').modal('show');
                homeController.resetForm();
               

            });
            $('#btnSave').off('click').on('click', function (e) {

                homeController.Add();
            });
            $('.btn-edit').off('click').on('click', function () {
                $('#modalUpdate').modal('show');
                var id = $(this).data('id');
                homeController.loadDetail(id);
            });
            $('#btnUpdate').off('click').on('click', function (e) {

                homeController.Update();

            });
            $('.btn-delete').off('click').on('click', function () {
                var id = $(this).data('id');
                bootbox.confirm("Bạn có thực sự muốn xóa không ?", function (result) {
                    if (result == true) {
                        homeController.deleteCategory(id);
                    }
                });
            });

        },
        deleteCategory: function (id) {
            $.ajax({
                url: '/QuanLyNguoiDung/Delete',
                data:
                    {
                        id: id
                    },
                type: 'POST',
                dataType: 'json',
                success: function (response) {
                    if (response.status == true) {


                        homeController.loadData(true);
                    }
                    else {


                        bootbox.alert(response.message);
                    }
                },
                error: function (err) {
                    console.log(err);
                }
            });
        },
        loadDetail: function (id) {
            $.ajax({
                url: '/QuanLyNguoiDung/GetDetail',
                data:
                    {
                        id: id
                    },
                type: 'GET',
                dataType: 'json',
                success: function (response) {
                    if (response.status == true) {
                        var data = response.data;
                        $('#MANDs').val(data.MAND);
                        $('#MaLoaind').val(data.MALOAIND);
                        $('#NgaySinhs').val(data.NgaySinh);
                        $('#DiaChis').val(data.DIACHI);
                        $('#sdts').val(data.SDT);
                        $('#HOTENs').val(data.HOTEN);
                        $('#TaiKhoans').val(data.TAIKHOAN);
                        $('#MatKhaus').val(data.MATKHAU);
                        $('#EMAILs').val(data.EMAIL);


                    }
                    else {
                        bootbox.alert(response.message);
                    }
                },
                error: function (err) {
                    console.log(err);
                }
            });
        },
        Add: function () {
            if (homeController.KiemTra() == false) {
                return false;
            }
            else {
                var id = ($('#MAND').val());
                var MaLoaind = $('#MALOAIND').val();
                var ngaysinh = $('#NgaySinh').val();
                var DiaChi = $('#DIACHI').val();
                var sdt = $('#SDT').val();
                var EMAIL = $('#EMAIL').val();
                var HOTEN = $('#HOTEN').val();
                var TaiKhoan = $('#TAIKHOAN').val();
                var MatKhau = $('#MATKHAU').val();
                var LOAISANPHAM =

                    {

                        MALOAIND: MaLoaind,
                        NgaySinh: ngaysinh,
                        DIACHI: DiaChi,
                        SDT: sdt,
                        TAIKHOAN: TaiKhoan,
                        MATKHAU:MatKhau,
                        HOTEN: HOTEN,
                        MAND: id
                    }
                $.ajax({
                    url: '/QuanLyNguoiDung/Add',
                    data:
                    {
                        strCategory: JSON.stringify(LOAISANPHAM)
                    },
                    type: 'POST',
                    dataType: 'json',
                    success: function (response) {

                        if (response.status == true) {

                            $('#modalAddUpdate').modal('hide');
                            homeController.loadData(true);


                        }
                        else {
                            bootbox.alert(response.message);
                        }
                    },
                    error: function (err) {
                        console.log(err);
                    }
                });

            }

        },
        Update: function () {
            if (homeController.KiemTra() == false) {
                return false;
            }
            else {
                var id = ($('#MANDs').val());
                var MALOAIND = $('#MaLoaind').val();
                var NgaySinh = $('#NgaySinhs').val();
                var DIACHI = $('#DiaChis').val();
                var SDT = $('#sdts').val();
                var EMAIL = $('#EMAILs').val();
                var HOTEN = $('#HOTENs').val();
                var TaiKhoan = $('#TaiKhoans').val();
                var MatKhau = $('#MatKhaus').val();
                var LOAISANPHAM =
                    {

                        MALOAIND: MALOAIND,
                        NgaySinh: NgaySinh,
                        DIACHI: DIACHI,
                        SDT: SDT,
                        TAIKHOAN: TaiKhoan,
                        MATKHAU:MatKhau,
                        EMAIL: EMAIL,
                        HOTEN: HOTEN,
                        MAND: id
                    }
                $.ajax({
                    url: '/QuanLyNguoiDung/Update',
                    data:
                    {
                        strUpdate: JSON.stringify(LOAISANPHAM)
                    },
                    type: 'POST',
                    dataType: 'json',
                    success: function (response) {

                        if (response.status == true) {
                            bootbox.alert("Save Success", function () {
                                $('#modalUpdate').modal('hide');
                                homeController.loadData(true);
                            });

                        }
                        else {
                            bootbox.alert(response.message);
                        }
                    },
                    error: function (err) {
                        console.log(err);
                    }
                });

            }

        },
        resetForm: function () {

            $('#MALOAIND').val('');
            $('#HOTEN').val('');
            $('#NgaySinh').val('');
            $('#DIACHI').val('');
            $('#SDT').val('');
            $('#EMAIL').val('');
            $('#TAIKHOAN').val('');
            $('#MATKHAU').val('');


        },

        KiemTra: function () {
            var bl = false;
            var nhasanxuat = $("#MALOAIND").val();
            var diachi = $('#HOTEN').val();
            var ngaysinh = $('#NgaySinh').val();
         
            var matkhau = $('#MATKHAU').val();
            dinhdang = /^([a-zA-Z0-9_.+-])+\@(([a-zA-Z0-9-])+\.)+([a-zA-Z0-9]{2,4})+$/; 
            KTemail = dinhdang.test($('#EMAIL').val());
            var sdt = $('#SDT').val();
            if ((nhasanxuat) == "") {
                $('#MALOAIND').css('border-color', 'Red');
                toastr.warning("Vui lòng nhập đầy đủ");
                bl = false;
                return bl;
            }
            else if (matkhau=="" || matkhau.length < 6)
            {
                $('#HOTEN').css('border-color', 'Red');
                toastr.warning("Mật khẩu phải lớn hơn 6 ký tự");
                bl = false;
                return bl;
            }
            else if (!KTemail) {
                $('#HOTEN').css('border-color', 'Red');
                toastr.warning("Email không hợp lệ");
                bl = false;
                return bl;
            }
            else if ((diachi) == "")
            {
                $('#HOTEN').css('border-color', 'Red');
                toastr.warning("Vui lòng nhập đầy đủ");
                bl = false;
                return bl;
            }
            else if ((sdt)=="" || isNaN(sdt) == true )
            {
                $('#SDT').css('border-color', 'Red');
                toastr.warning("Vui lòng nhập số  >=9 và <=12");
                bl = false;
                return bl;
            }
            else if ((ngaysinh) == "") {
                $('#NgaySinh').css('border-color', 'Red');
                toastr.warning("Vui lòng chọn ngày sinh");
                bl = false;
                return bl;
            }

            return true;
            $('#MATKHAU').css('border-color', 'lightgrey');
            $('#MALOAIND').css('border-color', 'lightgrey');
            $('#HOTEN').css('border-color', 'lightgrey');
            $('#NgaySinh').css('border-color', 'lightgrey');


        },
        loadData: function (changePageSize) {
            $.ajax({
                url: '/QuanLyNguoiDung/LoadData',
                type: 'GET',
                data: {
                    //name: name,
                    //status: status,
                    page: homeconfig.pageIndex,
                    pageSize: homeconfig.pageSize
                },
                dataType: 'json',
                success: function (response) {
                    if (response.status) {
                        var data = response.data;
                        var html = '';
                        var template = $('#data-template').html();
                        $.each(data, function (i, item) {
                            html += Mustache.render(template,
                            {
                                MAND: item.MAND,
                                MALOAIND: item.MALOAIND,
                                HOTEN: item.HOTEN,
                                EMAIL:item.EMAIL,
                                TAIKHOAN: item.TAIKHOAN,
                                MATKHAU: item.MATKHAU,
                                DIACHI: item.DIACHI,
                                SDT:item.SDT,
                                NgaySinh: item.NgaySinh,
                            });

                        });
                        $('#tblContent').html(html);
                        homeController.paging(response.total, function () {
                            homeController.loadData();
                        }, changePageSize);
                        homeController.registerEvent();
                    }
                }
            })
        },
        paging: function (totalRow, callback, changePageSize) {
            var totalPage = Math.ceil(totalRow / homeconfig.pageSize);
            if ($('#pagination a').length === 0 || changePageSize === true) {
                $('#pagination').empty();
                $('#pagination').removeData("twbs-pagination");
                $('#pagination').unbind("page");
            }

            $('#pagination').twbsPagination(
                {
                    totalPages: totalPage,
                    first: "Đầu",
                    next: "Tiếp",
                    last: "Cuối",
                    prev: "Trước",
                    visiblePages: 10,
                    onPageClick: function (event, page) {
                        homeconfig.pageIndex = page;
                        setTimeout(callback, 200);
                    }
                });
        }
    }


homeController.init();