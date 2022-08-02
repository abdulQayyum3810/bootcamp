$(document).ready(function () {
    // call for customers on page load
    $.ajax({

        url: "Admin.aspx/GetAllAccounts",
        method: "post",
        dataType: "json",
        contentType: "application/json",
        async: true,
        success: function (data) {
            data = JSON.parse(data.d)
            console.log(data)
            populateAccountsTable(data)
        }
    });


    function populateAccountsTable(data) {
        $("#accountsTable").dataTable({
            data: data,
            columns: [
                { "data": "username" },
                { "data": "fname" },
                { "data": "lname" },
                { "data": "email" },
                { "data": "type" },

            ]
        })
    }
})
