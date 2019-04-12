$(document).ready(function () {
    ko.applyBindings(modelView);
});
var baseUrl = "http://localhost:63079/";
var modelView = {
    Users: ko.observableArray([]),
    dataSource: new kendo.data.DataSource({
        transport: {
            read: function (options) {
                try {
                    $.ajax({
                        url: 'http://localhost:63079/Users',
                        type: 'GET',
                        dataType: 'json',
                        contentType: 'application/json',
                        success: function (data) {
                            options.success(data.value);
                        },
                        error: function (err) {
                            alert(err.status + " : " + err.statusText);
                        }
                    });
                } catch (e) {
                    window.location.href = '/User';
                }
            },
            create: function (options) {
                const { data } = options;
                const user = {
                    Id: uuidv4(),
                    FirstName: data.FirstName.trim(),
                    LastName: data.LastName.trim(),
                    IsEnabled:(typeof data.IsEnabled === 'boolean') ? data.IsEnabled : false,
                    LogOnName: data.LogOnName.trim(),
                    PasswordHash: data.PasswordHash.trim(),
                    ExpiryDate: data.ExpiryDate,
                    PasswordChangedDate: data.PasswordChangedDate,
                }
                $.ajax({
                    url: baseUrl + 'Users/',
                    type: 'POST',
                    data: ko.toJSON(user),
                    contentType: 'application/json',
                    success: successCallback,
                    error: (result) => {
                        console.log("error to create")
                    },
                });
            },
            update: function (options) {
                const user = options.data
                const userWrapper = {
                    Id: user.Id.trim(),
                    FirstName: user.FirstName.trim(),
                    LastName: user.LastName.trim(),
                    IsEnabled:(typeof user.IsEnabled === 'boolean') ? user.IsEnabled : false,
                    LogOnName: user.LogOnName.trim(),
                    PasswordHash: user.PasswordHash.trim(),
                    ExpiryDate: user.ExpiryDate,
                    PasswordChangedDate: user.PasswordChangedDate,
                }
                $.ajax({

                    url: baseUrl + 'Users/(guid\'' + user.Id + '\')',
                    type: 'PUT',
                    dataType: 'json',
                    data: ko.toJSON(userWrapper),
                    contentType: 'application/json',
                    success: successCallback,
                    error: (result) => {
                        console.log("error to update")
                    },
                });
            },
            destroy: function (options) {
                const user = options.data
                $.ajax({
                    url: baseUrl + 'Users/(guid\'' + user.Id + '\')',
                    type: 'DELETE',
                    success: successCallback,
                    error: function (result) {
                        console.log("error to delete");
                    }
                });
            },
        },
        schema:
        {
            model:
            {
                id: "Id",
                fields: {
                    Id: { editable: false,  nullable: true },
                    FirstName: { type: "string", validation: { required: true }},
                    LastName: { type: "string", validation: { required: true } },
                    IsEnabled: { type: "boolean" },
                    PasswordHash: { type: "string", validation: { required: true } },
                    PasswordChangedDate: { type: "date", validation: { required: true }},
                    ExpiryDate: { type: "date", validation: { required: true } },
                    LogOnName: { type: "string", validation: { required: true } },
                }
            }
        }
    })
};
function successCallback(data) {
    window.location.href = '/User';
}
function errorCallback(err) {
    window.location.href = '/User';
}
function uuidv4() {
    return 'xxxxxxxx-xxxx-4xxx-yxxx-xxxxxxxxxxxx'.replace(/[xy]/g, function(c) {
        var r = Math.random() * 16 | 0, v = c == 'x' ? r : (r & 0x3 | 0x8);
        return v.toString(16);
    });
}
