$(function () {
    ko.applyBindings(modelDetail);
    modelDetail.detailUser();
});
var modelDetail = {
    //Update  
    User: {},
    detailUser: function () {
        var thisObj = this;
        try {
            $.ajax({
                url: 'http://localhost:63079/Users(guid\'' + selectedUser + '\')',
                type: 'GET',
                dataType: 'json',
                data: ko.toJSON(this),
                contentType: 'application/json',
                success: function (data) {
                    thisObj.User = data;
                },
                error: errorCallback
            });
        } catch (e) {
            window.location.href = '/User';
        }
    }
    //End detail here
}
function successCallback(data) {
    window.location.href = '/User';
}
function errorCallback(err) {
    window.location.href = '/User/Update/';
}