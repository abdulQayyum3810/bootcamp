
$(document).ready(function () {
    // call for customers on page load
    $.ajax({

        url: "Admin.aspx/GetAllCustomers",
        method: "post",
        dataType: "json",
        contentType: "application/json",
        async: true,
        select:true,
        success: function (data) {
            data = JSON.parse(data.d)
            console.log(data)
            populateCustomerTable(data)
        }
    });
    // call for products on page load

    $.ajax({

        url: "Admin.aspx/GetAllProducts",
        method: "post",
        dataType: "json",
        contentType: "application/json",
        async: true,
        success: function (data) {
            data = JSON.parse(data.d)
            console.log(data)
            populateProductTable(data)
        }
    })

});




function populateCustomerTable(data) {

    $("#customerTable").dataTable({
        data: data,

        "paging": true,
        "lengthChange": false,
        "searching": true,
        "ordering": true,
        "info": true,
        "autoWidth": true,
        "bDestroy": true,
        columns: [
            { "data": "id" },
            { "data": "fname" },
            { "data": "lname" },
            { "data": "email" },
            
            {
                'data': 'id',
                
                'render': function (data) { return '<button type="button" id="editBtn" data-toggle="modal" data-target="#customerModal" class="btn  btn-outline-primary px-4" onclick="editCustomerClick2(' + data + ')">Edit</button>' }

            }
            ,
            {
                'data': 'id',
                'render': function (data) { return '<button type="button" id="deleteBtn" class="btn  btn-outline-danger " onclick="deleteCustomerClick(' + data + ')">Delete</button>' }

            }


        ]
    });
}



function editCustomerClick2(id) {

    $("#customerSuccess").addClass("d-none")
    $("#customerSuccess").text("Update Customer Successfully")
    $("#customerModalLabel").text("Updated Customer Data")
    $("#customerError").addClass("d-none")
    console.log(id)
    var table = $("#customerTable").DataTable();
    var data = table
        .rows()
        .data();
    var customerData;
    for (let i = 0; i < data.length; i++) {
        let temp = data[i]
        if (temp.id === id) {
            console.log(data[i])
            customerData = data[i]
        }
    }
    $("#customerFName").val(customerData.fname)
    $("#customerLName").val(customerData.lname)
    $("#customerEmail").val(customerData.email)
    $('#addCustomerBtn').attr('onclick', 'return updateCustomer(' + id + ')');
    $('#addCustomerBtn').val("Update")
}
function updateCustomer(id) {
    var fname = $("#customerFName").val();
    var lname = $("#customerLName").val();
    var email = $("#customerEmail").val();
    if (!fname || !email || !validateEmail(email)) {
        $("#customerSuccess").addClass("d-none")
        $("#customerError").removeClass("d-none")
        return false
    }


    $.ajax({

        url: "Admin.aspx/UpdateCustomerWeb",
        method: "post",
        dataType: "json",
        contentType: "application/json",
        data: JSON.stringify({"id":id,"fname":fname,"lname":lname,"email":email}),
        async: true,
        success: function (data) {
            data = JSON.parse(data.d)
            console.log(data)

            populateCustomerTable(data)
            $("#customerError").addClass("d-none")

            $("#customerSuccess").removeClass("d-none")
        }

    });

    return false

}



function deleteCustomerClick(id) {
    $("#customerSuccess").text("Added Customer Successfully")
    console.log("delet customer", id);
    $.ajax({

        url: "Admin.aspx/DeleteCustomerWeb",
        method: "post",
        dataType: "json",
        contentType: "application/json",
        data: JSON.stringify({ "id":id}),
        async: true,
        success: function (data) {
            data = JSON.parse(data.d)
            

            populateCustomerTable(data)
        }

    });
    return false
}
function newCustomerClick() {
    $("#customerModalLabel").text("Add Customer ")
    $('#addCustomerBtn').attr('onclick', 'return addCustomer()');
    $('#addCustomerBtn').val("Add Customer")
    $("#customerFName").val("")
    $("#customerLName").val("")
    $("#customerEmail").val("")

}
function addCustomer() {
    
    var fname = $("#customerFName").val();
    var lname = $("#customerLName").val();
    var email = $("#customerEmail").val();
    if (!fname || !email || !validateEmail(email)) {
        $("#customerSuccess").addClass("d-none")
        $("#customerError").removeClass("d-none")
        return false
    }


    $.ajax({

        url: "Admin.aspx/AddCustomerWeb",
        method: "post",
        dataType: "json",
        contentType: "application/json",
        data:JSON.stringify( { "fname": fname, "lname": lname, "email": email }),
        async: true,
        success: function (data) {
            data = JSON.parse(data.d)
            console.log(data)
          
            populateCustomerTable(data)
            $("#customerError").addClass("d-none")

            $("#customerSuccess").removeClass("d-none")
        }

    });
    
    return false

}

function addProduct() {

    var pname = $("#productName").val();
    var price = $("#producPrice").val();

    if (!pname || !price || isNaN(price) || !alphaNumericCheck(pname)) {
        $("#productSuccess").addClass("d-none")
        $("#productError").removeClass("d-none")
        return false
    }

    $.ajax({

        url: "Admin.aspx/AddProductWeb",
        method: "post",
        dataType: "json",
        contentType: "application/json",
        data: JSON.stringify({ "name": pname, "price": price }),
        async: true,
        success: function (data) {
            data = JSON.parse(data.d)
            console.log(data)
            populateProductTable(data)
            
            $("#productError").addClass("d-none")
            
            $("#productSuccess").removeClass("d-none")
        }

    });
    
    return false

}

function populateProductTable(data) {

    $("#productTable").dataTable({
        data: data,
        "bDestroy": true,
        columns: [
            { "data": "id" },
            { "data": "name" },
            { "data": "price" }

        ]
    })
}
function editCustomerClick() {

}



function alphaNumericCheck(name) {
    var regEx = /^[0-9a-zA-Z]+$/;
    if (name.match(regEx)) {
        return true;
    }
    
    else {
        return false;
    }
}
function validateEmail(email) {
    var regEx = /^(([^<>()\[\]\\.,;:\s@"]+(\.[^<>()\[\]\\.,;:\s@"]+)*)|(".+"))@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}])|(([a-zA-Z\-0-9]+\.)+[a-zA-Z]{2,}))$/;;
    if (email.match(regEx)) {
        return true;
    }
    
    else {
        return false;
    }
}


