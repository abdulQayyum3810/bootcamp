<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ResultPage.aspx.cs" Inherits="Calculator.ResultPage" %>

<!DOCTYPE html>
<link rel="stylesheet" href="https://cdn.jsdelivr.net/npm/bootstrap@4.0.0/dist/css/bootstrap.min.css" integrity="sha384-Gn5384xqQ1aoWXA+058RXPxPg6fy4IWvTNh0E263XmFcJlSAwiGgFAW/dAiS6JXm" crossorigin="anonymous">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <div class="container p-5 w-100">
    <form id="form1" runat="server">
        
             <asp:TextBox runat="server" ID="output" ReadOnly CssClass="bg-light w-100 text-center border border-info"></asp:TextBox>

           
    </form>
    </div>
</body>
</html>
