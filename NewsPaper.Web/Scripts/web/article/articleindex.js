$(document).ready(function () {
    table = $("#dataTable").DataTable({
        processing: true,
        serverSide: true,
        ajax: {
            url: '/admin/Articles/GetPagingList',
            type: 'post',
            dateType: 'json'
        },
        deferRender: true,
        //rder: [[0, 'desc']],
        columnDefs: [
            {
                className: 'dt-head-center', targets: '_all',
                orderable: false, targets: [4, 5]
            }
        ],
        columns: [
            {
                data: 'Headline'
            },
            {
                data: 'ByLine',
            },
            {
                data: 'PublishDate', render: function (data) {
                    return moment(data).format("DD/MM/YYYY");
                }
            },
            {
                data: 'NewsCategories', render: function (data) {
                    var categoryName = '';
                    data.forEach(function(item, index)
                    {
                        var name = item.Name;
                        categoryName += index == 0 ? name : `; ${name}`;
                    })
                    return categoryName;
                }
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
    $('#btnCreate').on('click', function (e) {
        e.preventDefault()
        location.href = "/admin/articles/edit"
    })
    $('#btnUpdate').on('click', function (e) {
        e.preventDefault();
        var ma = table.row('.selected').data();
        if (ma === undefined) {
            web.notify("Bạn chưa chọn dữ liệu", 'info');
            return false;
        }
        location.href = "/admin/articles/edit/" + ma.Id
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
            url: "/admin/Articles/DeleteById/" + data.Id,
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