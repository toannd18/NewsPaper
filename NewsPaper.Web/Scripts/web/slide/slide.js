$(document).ready(function () {
    table = $("#dataTable").DataTable({
        processing: true,
        serverSide: true,
        ajax: {
            url: '/admin/slides/GetPagingList',
            type: 'post',
            dateType: 'json'
        },
        deferRender: true,
        //rder: [[0, 'desc']],
        columnDefs: [
            {
                className: 'dt-head-center', targets: '_all'
              
            }
        ],
        columns: [
            {
                data: 'Name'
            },
            {
                data: 'Description',
            },
            {
                data: 'Image', render: function (data) {
                    return `<img src="${data}" class="img-thumbnail" style="max-width: 200px;">`
                }
            },
            {
                data: 'Url',
            },
            {
                data: 'DisplayOrder', render: function (data) {
                    return data == undefined ? "Không sắp xếp" : data;
                }
            },
            {
                data: 'Status', render: function (data) {
                    var ckeck = data ? 'badge-success' : 'badge-danger';
                    var title = data ? 'Enabled' : 'Disabled';
                    return `<span class="badge ${ckeck}">${title}</span>`
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
    $('#btnCreate').on('click', function (e) {
        e.preventDefault()
        location.href = "/admin/slides/Get"
    })
    $('#btnUpdate').on('click', function (e) {
        e.preventDefault();
        var ma = table.row('.selected').data();
        if (ma === undefined) {
            web.notify("Bạn chưa chọn dữ liệu", 'info');
            return false;
        }
        location.href = "/admin/slides/Get/" + ma.Id
    })
    $('#btnDetele').on('click', function (e) {
        e.preventDefault();
        var ma = table.row('.selected').data();
        if (ma === undefined) {
            web.notify("Bạn chưa chọn dữ liệu", 'info');
            return;
        }
        deleteSlide(ma);
    })
}

function deleteSlide(data) {
    web.confirm("Bạn có muốn xóa thể loại: " + data.Name, function () {
        $.ajax({
            type: "post",
            url: "/admin/Slides/DeleteById/" + data.Id,
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

