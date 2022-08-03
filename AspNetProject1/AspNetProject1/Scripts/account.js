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
            'columnDefs': [
      
                { 'visible': false, 'targets': [4] }
            ],
            columns: [
                { "data": "username" },
                { "data": "fname" },
                { "data": "lname" },
                { "data": "email" },
                { "data": "password" },
                { "data": "type" },
                
                {
                    'data': 'username',

                    'render': function (data) { return '<button type="button" id="editUserBtn" data-toggle="modal" data-target="#userModal" class="btn  btn-outline-primary px-4" onclick="editUserClick(' + data + ')">Edit</button>' }

                }
                ,
                {
                    'data': 'username',
                    'render': function (data) { return '<button type="button" id="deleteUserBtn" class="btn  btn-outline-danger " onclick="deleteUserClick(' + data + ')">Delete</button>' }

                }

            ]
        })
    }
})





function newUserClick() {
    
    $("#userFName").val("")
    $("#username").val("")
    $("#userLName").val("")
    $("#userEmail").val("")
    $("#userPassword").val("")
    $('#addUserBtn').val("Add User")
    $('#addUserBtn').attr('onclick', 'return addUser()');
    $("#userSuccess").addClass("d-none")
    $("#userError").addClass("d-none")
    $("#userSuccess").text("Added User Successfully")
    $("#userModalLabel").text("Add User")
}


function addUser() {

    $.ajax({

        url: "Admin.aspx/AddUserWeb",
        method: "post",
        dataType: "json",
        contentType: "application/json",
        data: JSON.stringify({ "name": pname, "price": price }),
        async: true,
        success: function (data) {
            data = JSON.parse(data.d)
            console.log(data)
            populateUserTable(data)

            $("#userError").addClass("d-none")

            $("#userSuccess").removeClass("d-none")
        }

    });

    return false

}


function deleteUserClick(username) {
    $("#userSuccess").text("Added Customer Successfully")
    console.log("delet customer", id);
    $.ajax({

        url: "Admin.aspx/DeleteUserWeb",
        method: "post",
        dataType: "json",
        contentType: "application/json",
        data: JSON.stringify({ "username": username }),
        async: true,
        success: function (data) {
            data = JSON.parse(data.d)


            populateUserTable(data)
        }

    });
    return false
}




function editUserClick(id) {

    $("#userSuccess").addClass("d-none")
    $("#userError").addClass("d-none")
    $("#userSuccess").text("Updated User Successfully")
    $("#userModalLabel").text("Updated User Data")

    console.log(id)
    var table = $("#userTable").DataTable();
    var data = table
        .rows()
        .data();
    var userData;
    for (let i = 0; i < data.length; i++) {
        let temp = data[i]
        if (temp.id === id) {
            console.log(data[i])
            userData = data[i]
        }
    }
    $("#userName").val(userData.name)
    $("#userPrice").val(userData.price)
    $('#addUserBtn').attr('onclick', 'return updateUser(' + id + ')');
    $('#addUserBtn').val("Update")
}

function updateUser(id) {
    var name = $("#userName").val();
    var price = $("#producPrice").val();

    if (!name || !price || !alphaNumericCheck(name) || isNaN(price)) {
        $("#userSuccess").addClass("d-none")
        $("#userError").removeClass("d-none")
        return false
    }


    $.ajax({

        url: "Admin.aspx/UpdateUserWeb",
        method: "post",
        dataType: "json",
        contentType: "application/json",
        data: JSON.stringify({ "id": id, "name": name, "price": price }),
        async: true,
        success: function (data) {
            data = JSON.parse(data.d)
            console.log(data)

            populateUserTable(data)
            $("#userError").addClass("d-none")

            $("#userSuccess").removeClass("d-none")
        }

    });

    return false

}

function validateUser() {
    var username = $("#userFName").val()
    var fname = $("#username").val()
    var lname = $("#userLName").val()
    var email = $("#userEmail").val()
    var pass = $("#userPassword").val()
    var type = $("#userType").val()

    if (!username || !fname || !lname || !email || !pass || !type || !userAlphaNumericCheck(username)|| validateEmail(email)) {
        $("#userSuccess").addClass("d-none")
        $("#userError").removeClass("d-none")
        return false
    }


}

function isUserNameAvailable() {

}

function userAlphaNumericCheck(name) {
    var regEx = /^[0-9a-zA-Z]+$/;
    if (name.match(regEx)) {
        return true;
    }

    else {
        return false;
    }
}