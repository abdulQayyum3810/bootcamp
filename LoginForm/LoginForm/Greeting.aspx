<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Greeting.aspx.cs" Inherits="LoginForm.Greeting" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link rel="stylesheet" href="https://cdn.jsdelivr.net/npm/bootstrap@4.6.2/dist/css/bootstrap.min.css" integrity="sha384-xOolHFLEh07PJGoPkLv1IbcEPTNtaed2xpHsD9ESMhqIYd0nLMwNLD69Npy4HI+N" crossorigin="anonymous">

</head>
<body>
    <form id="form1" runat="server">
        <div class="container text-center">
            <div class="jumbotron">
                  <h2 class="h2" id="greet" runat="server"></h2>
                  <p class="lead">May you rise each texting day with fully charged cell phone in your hand,inspiring message in your mind, me in your heart,and a clear signal all day long. Nice day</p>
                  <hr class="my-4">
                  <p>if you want to leave just hit logout button below</p>
                  <asp:Button Text="Logout" runat="server" ID="logout" OnClick="logout_Click" CssClass="btn btn-danger"/>
            </div>
        
        </div>
    </form>
</body>
</html>
