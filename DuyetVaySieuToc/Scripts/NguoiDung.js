

    $(document).ready(function () {
        $("#add1").click(function () {
            $.ajax({
                url: "/NguoiDung/GetAutoId",
                type: "GET",
                dateType: "text",
                data: {

                },
                success: function (result) {
                    result = $("#MAND").val(result);



                }
            });


        })
    });


