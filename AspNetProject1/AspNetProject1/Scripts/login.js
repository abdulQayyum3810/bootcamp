function userAuthentication() {
    var username = $("#username").val();
    var password = $("#password").val();
    $.ajax({


        url: "Login.aspx/AuthenticateUSer",
        method: "post",
        dataType: "json",

        contentType: "application/json",
        async: true,
        data: JSON.stringify({ "username": username, "password": password }),
        success: function (data) {
            if (data.d === "admin") {
                window.location.replace("Admin.aspx");

            }
            else if (data.d === "accountant") {
                
                window.location.replace("Accountant.aspx");
            }
            else {
                $("#loginError").removeClass("d-none")
            }

            console.log(data)
        }
    });

    return false
}