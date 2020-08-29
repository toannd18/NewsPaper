$(document).ready(function () {

    registerEvents();
})

function registerEvents() {
    web.validatorDate();
    $('#PublishDate').datepicker({
        format: 'dd/mm/yyyy',
        autoclose: true
    })
    $('#CategoryIds').select2({
        placeholder: "---- Chọn thể loại ---",
        allowClear: true
    })
    CKEDITOR.replace("Text")
    $('#btnOpen').on('click', function (e) {
        e.preventDefault();
        BrowseServer()
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
    
    document.getElementById('PhotoURL').value = fileUrl;
    
}