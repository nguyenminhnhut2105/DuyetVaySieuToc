
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
                getAutoId();

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
                url: '/QuanLyNhaSanXuat/Delete',
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
                    else
                    {
                     
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
                url: '/QuanLyNhaSanXuat/GetDetail',
                data:
                    {
                        id: id
                    },
                type: 'GET',
                dataType: 'json',
                success: function (response) {
                    if (response.status == true) {
                        var data = response.data;
                        $('#MaNhaSX').val(data.MANHASX);
                        $('#TenNhaSX').val(data.TENNHASX);
                        $('#NgayTao').val(data.NGAYTAO);
                        $('#DiaChi').val(data.DIACHI);
                        $('#Sdt').val(data.SDT);
                        $('#Email').val(data.EMAIL);
                    
                       


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
                var id = $('#MANHASX').val();
                var TenNhaSX = $('#TENNHASX').val();
                var ngaytao = $('#NGAYTAO').val();
                var DiaChi = $('#DIACHI').val();
                var Sdt = $('#SDT').val();
                var Email = $('#EMAIL').val();

                var NhaSanXuat =
                    {

                        TENNHASX: TenNhaSX,
                        NGAYTAO: ngaytao,
                        DIACHI: DiaChi,
                        SDT: Sdt,
                        EMAIL: Email,
                        MANHASX: id
                    }
                $.ajax({
                    url: '/QuanLyNhaSanXuat/Add',
                    data:
                    {
                        strCategory: JSON.stringify(NhaSanXuat)
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
                var id = ($('#MaNhaSX').val());
                var TenNhaSX = $('#TenNhaSX').val();
                var ngaytao = $('#NgayTao').val();
                var DiaChi = $('#DiaChi').val();
                var Sdt = $('#Sdt').val();
                var Email = $('#Email').val();
            
                var NhaSanXuat =
                    {
                        TENNHASX:TenNhaSX,
                        NGAYTAO: ngaytao,
                        DIACHI: DiaChi,
                        SDT: Sdt,
                        EMAIL: Email,
                        MANHASX:id
                    }
                $.ajax({
                    url: '/QuanLyNhaSanXuat/Update',
                    data:
                    {
                        strUpdate: JSON.stringify(NhaSanXuat)
                    },
                    type: 'POST',
                    dataType: 'json',
                    success: function (response) {

                        if (response.status == true) {

                           
                                $('#modalUpdate').modal('hide');
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
        resetForm: function () {

            $('#TENNHASX').val('');
            $('#NGAYTAO').val('');
            $('#DIACHI').val('');
            $('#EMAIL').val('');
            $('#SDT').val('');
        },

        KiemTra: function () {
            var bl = false;
            var nhasanxuat = $("#txtnhasx").val();
            var diachi = $('#txtdiachi').val();
            if ((nhasanxuat) == "") {
                $('#txtnhasx').css('border-color', 'Red');
                bootbox.alert({
                    message: "This is the small alert!",
                    size: 'small'
                });

                bl = false;
                return bl;
            }
            else if ((diachi) == "") {
                $('#txtdiachi').css('border-color', 'Red');
                bootbox.alert({
                    message: "Ban chua nhap dia chi",
                    size: 'small'
                });
                bl = false;
                return bl;
            }
            return true;
            $('#txtnhasx').css('border-color', 'lightgrey');
            $('#txtdiachi').css('border-color', 'lightgrey');


        },
        loadData: function (changePageSize) {
            $.ajax({
                url: '/QuanLyNhaSanXuat/LoadData',
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
                                MANHASX: item.MANHASX,
                                TENNHASX: item.TENNHASX,
                                DIACHI: item.DIACHI,
                                SDT: item.SDT,
                                EMAIL: item.EMAIL,
                                
                                NGAYTAO: item.NGAYTAO,
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

function getAutoId() {
    $.post("/QuanLyNhaSanXuat/GetAutoId", function (data) {
        $("#MANHASX").val(data);
    });
}
homeController.init();