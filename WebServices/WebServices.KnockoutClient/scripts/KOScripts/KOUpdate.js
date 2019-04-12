$(function () {
    getUser();
});
var User;
var getUser = function() {
    try {
     $.ajax({
                url: 'http://localhost:63079/Users(guid\'' + selectedUser + '\')',
                type: 'GET',
                dataType: 'json',
                contentType: 'application/json',
                success: function (data) {
                    User = data;//Here we are assigning values to KO Observable array
                    var modelUpdate = {
                        Id: ko.observable(data.Id),                                 
                        FirstName: ko.observable(data.FirstName),
                        LastName: ko.observable(data.LastName),
                        IsEnabled: ko.observable(data.IsEnabled),
                        PasswordChangedDate: ko.observable(data.PasswordChangedDate),
                        ExpiryDate: ko.observable(data.ExpiryDate),
                        PasswordHash: ko.observable(data.PasswordHash),
                        LogOnName: ko.observable(data.LogOnName),
                        updateUser: function () {
                            try {
                                console.log('que eres duke',this)
                                $.ajax({
                                    url: 'http://localhost:63079/Users(guid\'' + selectedUser + '\')',
                                    type: 'PUT',
                                    dataType: 'json',
                                    data: ko.toJSON(this),
                                    contentType: 'application/json',
                                    success: successCallback,
                                    error: errorCallback
                                });
                            } catch (e) {
                                window.location.href = '/User';
                            }
                        }
                    }
                    ko.applyBindings(modelUpdate);
                },
                error: function (err) {
                    alert(err.status + " : " + err.statusText);
                }
            });
        } catch (e) {
            window.location.href = '/User';
        }
};

function successCallback(data) {
    window.location.href = '/User';
}
function errorCallback(err) {
    window.location.href = '/User/';
}