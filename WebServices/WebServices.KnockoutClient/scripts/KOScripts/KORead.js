$(function () {
    ko.applyBindings(modelView);
    modelView.viewUser();
});
var modelView = {
    Users: ko.observableArray([]),
    viewUser: function () {
        var thisObj = this;
        try {
            $.ajax({
                url: 'http://localhost:63079/Users',
                type: 'GET',
                dataType: 'json',
                contentType: 'application/json',
                success: function (data) {
                    thisObj.Users(data.value);//Here we are assigning values to KO Observable array  
                },
                error: function (err) {
                    alert(err.status + " : " + err.statusText);
                }
            });
        } catch (e) {
            window.location.href = '/User';
        }
    },
    //Create  
    Id: ko.observable(),
    FirstName: ko.observable(),
    LastName: ko.observable(),
    IsEnabled: ko.observable(),
    PasswordChangedDate: ko.observable(),
    ExpiryDate: ko.observable(),
    PasswordHash: ko.observable(),
    LogOnName: ko.observable(),
    createUser: function () {
        try {
            $.ajax({
                url: 'http://localhost:63079/Users',
                type: 'POST',
                dataType: 'json',
                data: ko.toJSON(this), //Here the data wil be converted to JSON  
                contentType: 'application/json',
                success: successCallback,
                error: errorCallback
            });
        } catch (e) {
            window.location.href = '/User';
        }
    }//End create  
}
function successCallback(data) {
    window.location.href = '/User';
}
function errorCallback(err) {
    window.location.href = '/User';
   
}