$(document).ready(function () {
    table = $("#dataTable").DataTable({
        processing: true,
        serverSide: true,
        ajax: {
            url: '/admin/Categories/GetPagingList',
            type: 'post',
            dateType: 'json'
        },
        deferRender: true,
        //rder: [[0, 'desc']],
        columnDefs: [
            {
                className: 'dt-head-center', targets: '_all',
                orderable: false, targets: [2, 3]
            }
        ],
        columns: [
            {
                data: 'Name'
            },
            {
                data: 'MetaDescription',
            },
            {
                data: 'CreatedDate', render: function (data) {
                    return moment(data).format("DD/MM/YYYY");
                }
            },
            {
                data: 'UpdatedDate', render: function (data) {
                    return moment(data).format("DD/MM/YYYY");
                }
            },
        ],
        select: {
            style: 'single'
        }
    });
    registerEvents();
})

function registerEvents() {
    $("#btnCreate").on("click", function (e) {
        e.preventDefault();
        loadDetails(null);

    })

    $("#btnUpdate").on("click", function (e) {
        e.preventDefault();
        var ma = table.row('.selected').data();
        if (ma === undefined) {
            web.notify("Bạn chưa chọn dữ liệu",'info');
            return false;
        }
        loadDetails(ma.Id);

    })

    $("#showModal").on('click', '.btn-info', function (e) {
        e.preventDefault();
        saveCategory();
    })

    $('#btnDetele').on('click', function (e) {
        e.preventDefault();
        var ma = table.row('.selected').data();
        if (ma === undefined) {
            web.notify("Bạn chưa chọn dữ liệu",'info');
            return;
        }
        deleteCategory(ma);
    })
    
}

function loadDetails(id) {
    $.ajax({
        type: "GET",
        url: "/admin/Categories/Get",
        data: { id: id },
        beforeSend: function () {
            web.startLoading();
        },
    })
        .done(function (data) {
            $("#showModalBody").html(data);
            $("#showModalLabel").html(id===null?"Tạo mới":"Cập nhật");
            $("#showModal").modal("show");
            //$('#frmCategory').removeData('validator');
            //$('#frmCategory').removeData('unobtrusiveValidation');
            //$.validator.unobtrusive.parse($('#frmCategory'));
            web.frmValidation('#frmCategory');
            web.stopLoading();
        })
        .fail(function (jqXHR) {
            web.notify(`Có lỗi xảy ra: ${jqXHR.statusCode}`,'error')
        })
}

function saveCategory() {
    if (!$('#frmCategory').valid()) return ;
    var data = $('#frmCategory').serialize();
    $.ajax({
        type: "post",
        url: "/admin/Categories/Save",
        data: data,
        beforeSend: function () {
            web.startLoading();
        },
    }).done(function (data) {
        web.notify('Lưu thành công', 'success');
        $("#showModal").modal("hide");
        web.stopLoading();
        
        table.ajax.reload();
    }).fail(function (jqXHR) {
        web.notify(`Lỗi xảy ra: ${jqXHR.statusCode}`, 'success');
        web.stopLoading();
    })
}

function deleteCategory(data) {
    web.confirm("Bạn có muốn xóa thể loại: " + data.Name, function () {
        $.ajax({
            type: "post",
            url: "/admin/Categories/DeleteById/"+data.Id,
            beforeSend: function () {
                web.startLoading();
            },
        }).done(function (reps) {
            web.notify('Xóa thành công', 'success');
            web.stopLoading();
            table.ajax.reload();
        }).fail(function (jqXHR) {
            web.notify(`Lỗi xảy ra: ${jqXHR.statusCode}`, 'success');
            web.stopLoading();
        })
    })

}