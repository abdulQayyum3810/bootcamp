<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="AspNetProject1.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link rel="stylesheet" href="https://cdn.jsdelivr.net/npm/bootstrap@4.6.2/dist/css/bootstrap.min.css"
        integrity="sha384-xOolHFLEh07PJGoPkLv1IbcEPTNtaed2xpHsD9ESMhqIYd0nLMwNLD69Npy4HI+N" crossorigin="anonymous">
        <script src="https://code.jquery.com/jquery-3.5.1.js"></script>

    <script src="https://cdn.jsdelivr.net/npm/bootstrap@4.6.2/dist/js/bootstrap.bundle.min.js"
        integrity="sha384-Fy6S3B9q64WdZWQUiU+q4/2Lc9npb8tCaSX9FK7E8HnRr0Jz8D6OP9dO5Vg3Q9ct"
        crossorigin="anonymous"></script>
    <script src="Scripts/login.js"></script>
    <title></title>
</head>
<body>
    <div class="  container h-100 w-50 p-3" id="outerContainer">
        <h1 class="display-4 mb-4">Login</h1>
        <form id="loginFrom" class="border border-info p-5 rounded bg-light" runat="server">


            <div class="alert alert-danger d-none text-center w-75 m-auto" role="alert" id="loginError">
                Username or password incorrect
            </div>



            <div class="form-group ">
                <label for="username">Username</label>
                <input type="text" name="username" id="username" required class="form-control" runat="server">
            </div>
            <div class="form-group">
                <label for="password">Password</label>
                <input type="password" name="password" id="password" required class="form-control" runat="server">
            </div>
            
        <asp:Button ID="loginBtn" Text="Login" runat="server" CssClass="btn btn-success btn-block w-25 m-auto" OnClientClick="return userAuthentication()" />
               
        </form>
    </div>

    <script>
        
        //$("#loginButton").on("click", () => {
        //    $("#loginError").removeClass("d-none")
        //    $("#type").addClass("is-invalid")

        //})

    </script>
</body>
</html>
