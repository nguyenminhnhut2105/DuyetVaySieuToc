
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
            $('.btn-delete').off('click').on('click', function ()
            {
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
                url: '/QuanLySanPham/Delete',
                data:
                    {
                        id: id
                    },
                type: 'POST',
                dataType: 'json',
                success: function (response) {
                    if (response.status == true)
                    {
                       

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
                url: '/QuanLySanPham/GetDetail',
                data:
                    {
                        id: id
                    },
                type: 'GET',
                dataType: 'json',
                success: function (response) {
                    if (response.status == true) {
                        var data = response.data;
                        $('#maloai').val(data.MALOAISP);
                        $('#tenloai').val(data.TENLOAISP);
                        $('#ngaytao').val(data.NGAYTAO);


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
                var id = ($('#maloaisp').val());
                var TenLoaiSP = $('#TENLOAISP').val();
                var ngaytao = $('#NGAYTAO').val();
                var LOAISANPHAM =
                    {

                        TENLOAISP: TenLoaiSP,
                        NGAYTAO: ngaytao,
                        MALOAISP: id
                    }
                $.ajax({
                    url: '/QuanLySanPham/Add',
                    data:
                    {
                        strCategory: JSON.stringify(LOAISANPHAM)
                    },
                    type: 'POST',
                    dataType: 'json',
                    success: function (response) {

                        if (response.status == true)
                        {
                         
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
                var id = ($('#maloai').val());
                var TenLoaiSP = $('#tenloai').val();
                var ngaytao = $('#ngaytao').val();
                var LOAISANPHAM =
                    {

                        TENLOAISP: TenLoaiSP,
                        NGAYTAO: ngaytao,
                        MALOAISP: id
                    }
                $.ajax({
                    url: '/QuanLySanPham/Update',
                    data:
                    {
                        strUpdate: JSON.stringify(LOAISANPHAM)
                    },
                    type: 'POST',
                    dataType: 'json',
                    success: function (response) {

                        if (response.status == true)
                        {
                            bootbox.alert("Save Success", function ()
                            {
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

            $('#TENLOAISP').val('');
            $('#NGAYTAO').val('');

        },

        KiemTra: function () {
            var bl = false;
            var nhasanxuat = $("#TENLOAISP").val();
            if ((nhasanxuat) == "") {
                $('#TENLOAISP').css('border-color', 'Red');
                bootbox.alert({
                    message: "Vui lòng nhập tên loại vào!",
                    size: 'small'
                });

                bl = false;
                return bl;
            }
            return true;
            $('#TENLOAISP').css('border-color', 'lightgrey');
          


        },
        loadData: function (changePageSize) {
            $.ajax({
                url: '/QuanLySanPham/LoadData',
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
                                MALOAISP: item.MALOAISP,
                                TENLOAISP: item.TENLOAISP,
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
    $.post("/QuanLySanPham/GetAutoId", function (data) {
        $("#maloaisp").val(data);
    });
}
homeController.init();