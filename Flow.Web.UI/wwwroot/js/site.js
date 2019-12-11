// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your Javascript code.
var AddEditForm = function (pv, e, h, p) {

    var url = "" + e + "?handler=" + h + "&" + p + "=" + pv;
    if (pv > 0)
        $('#title').html("تعديل");
    else
        $('#title').html("جديد");

    $("#FormModelDiv").load(url, function () {
        $("#FormModel").modal("show");

    });
}

var SubmitAction = function (pv, e, h, p,pvv) {

    var url = "" + e + "?handler=" + h + "&" + p + "=" + pv + pvv;
    if (pv > 0)
        $('#title').html("تعديل");
    else
        $('#title').html("جديد");

    $("#FormModelDiv").load(url, function () {
        $("#FormModel").modal("show");

    });
}