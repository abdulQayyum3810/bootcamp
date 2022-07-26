<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="LoginForm.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link rel="stylesheet" href="https://cdn.jsdelivr.net/npm/bootstrap@4.6.2/dist/css/bootstrap.min.css" integrity="sha384-xOolHFLEh07PJGoPkLv1IbcEPTNtaed2xpHsD9ESMhqIYd0nLMwNLD69Npy4HI+N" crossorigin="anonymous">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div class="container">
            <p id="errorCatch" runat="server" class="text-center text-danger mt-5 pt-5"></p>

            <div class="form-group">
                <label for="usename">Username</label>
                <asp:TextBox ID="username" runat="server" CssClass="form-control"></asp:TextBox>
            </div>
            
            <div class="form-group">
                <label for="password">Password</label>
                <asp:TextBox ID="password" runat="server" CssClass="form-control"></asp:TextBox>
            </div>
            
            
            <asp:Button  ID="submit" runat="server" Text="Login" OnClick="submit_Click" CssClass="btn btn-success"/>
        </div>
    </form>
</body>
</html>
