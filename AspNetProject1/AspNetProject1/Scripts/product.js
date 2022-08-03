
$(document).ready(function () {
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
function populateProductTable(data) {

    $("#productTable").dataTable({
        data: data,
        "bDestroy": true,
        columns: [
            { "data": "id" },
            { "data": "name" },
            { "data": "price" },
            {
                'data': 'id',

                'render': function (data) { return '<button type="button" id="productEditBtn" data-toggle="modal" data-target="#productModal" class="btn  btn-outline-primary px-4" onclick="editProductClick(' + data + ')">Edit</button>' }

            }
            ,
            {
                'data': 'id',
                'render': function (data) { return '<button type="button" id="productDeleteBtn" class="btn  btn-outline-danger " onclick="deleteProductClick(' + data + ')">Delete</button>' }

            }

        ]
    })
}





function newProductClick() {
    $('#addProductBtn').val("Add Product")
    $("#productName").val("")
    $("#producPrice").val("")
    $('#addProductBtn').attr('onclick', 'return addProduct()');
    $("#productSuccess").addClass("d-none")
    $("#productError").addClass("d-none")
    $("#productSuccess").text("Added Product Successfully")
    $("#productModalLabel").text("Add Product")
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


function deleteProductClick(id) {
    $("#productSuccess").text("Added Customer Successfully")
    console.log("delet customer", id);
    $.ajax({

        url: "Admin.aspx/DeleteProductWeb",
        method: "post",
        dataType: "json",
        contentType: "application/json",
        data: JSON.stringify({ "id": id }),
        async: true,
        success: function (data) {
            data = JSON.parse(data.d)


            populateProductTable(data)
        }

    });
    return false
}




function editProductClick(id) {

    $("#productSuccess").addClass("d-none")
    $("#productError").addClass("d-none")
    $("#productSuccess").text("Updated Product Successfully")
    $("#productModalLabel").text("Update Product Data")
   
    console.log(id)
    var table = $("#productTable").DataTable();
    var data = table
        .rows()
        .data();
    var productData;
    for (let i = 0; i < data.length; i++) {
        let temp = data[i]
        if (temp.id === id) {
            console.log(data[i])
            productData = data[i]
        }
    }
    $("#productName").val(productData.name)
    $("#productPrice").val(productData.price)
    $('#addProductBtn').attr('onclick', 'return updateProduct(' + id + ')');
    $('#addProductBtn').val("Update")
}

function updateProduct(id) {
    var name = $("#productName").val();
    var price = $("#producPrice").val();

    if (!name || !price || !alphaNumericCheck(name)|| isNaN(price)) {
        $("#productSuccess").addClass("d-none")
        $("#productError").removeClass("d-none")
        return false
    }


    $.ajax({

        url: "Admin.aspx/UpdateProductWeb",
        method: "post",
        dataType: "json",
        contentType: "application/json",
        data: JSON.stringify({"id":id, "name": name, "price": price}),
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





























