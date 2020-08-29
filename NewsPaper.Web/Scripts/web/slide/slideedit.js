$(document).ready(function () {

    registerEvents();
})
function registerEvents() {
    web.frmValidation('#frmSlide');
    $('#btnOpen').on('click', function (e) {
        e.preventDefault();
        BrowseServer()
    })
    $('#btnSave').on('click', function (e) {
     
        saveSlide();
    })
}
function BrowseServer() {
    // You can use the "CKFinder" class to render CKFinder in a page:
    var finder = new CKFinder();

    // The path for the installation of CKFinder (default = "/ckfinder/").
    finder.basePath = '/Scripts/ckfinder/';

    //Startup path in a form: "Type:/path/to/directory/"
    //finder.startupPath = startupPath;

    // Name of a function which is called when a file is selected in CKFinder.
    finder.selectActionFunction = openPopup;

    // Additional data to be passed to the selectActionFunction in a second argument.
    // We'll use this feature to pass the Id of a field that will be updated.
    //finder.selectActionData = functionData;

    // Name of a function which is called when a thumbnail is selected in CKFinder.
    //finder.selectThumbnailActionFunction = ShowThumbnails;

    // Launch CKFinder
    finder.popup();
}

function openPopup(fileUrl) {

    document.getElementById('Image').value = fileUrl;
}

function saveSlide() {
    if (!$('#frmSlide').valid()) {
        return;
    }
        
    var id = $('#Id').val();
    var name = $('#Name').val();
    var description = $('#Description').val();
    var image = $('#Image').val();
    var url = $('#Url').val();
    var displayOrder = $('#DisplayOrder').val();
    var status = $('#Status').prop('checked');
    var content = $('#Content').val();
    var token = $('form').find("input[name='__RequestVerificationToken']").val();
    $.ajax({
        type: "post",
        url: "/admin/slides/Save",
        data: {
            __RequestVerificationToken: token,
            Id: id,
            Name: name,
            Description: description,
            Image: image,
            Url: url,
            DisplayOrder: displayOrder,
            Status: status,
            Content:content
        },
        beforeSend: function () {
            web.startLoading();
        },
    }).done(function (data) {
        web.notify('Lưu thành công', 'success');
        web.stopLoading();
        setTimeout(location.href = '/admin/slides', 100);
    }).fail(function (jqXHR) {
        console.log(jqXHR);
        web.stopLoading();
        if (jqXHR.status === 200) {
            web.notify('Lưu thành công', 'success');
            return setTimeout(location.href = '/admin/slides', 100);
        }
        web.notify(`Lỗi xảy ra: ${jqXHR.status}`, 'success');
      
    })
}