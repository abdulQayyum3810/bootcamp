<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="index.aspx.cs" Inherits="IncrementInput.index" %>

<!DOCTYPE html>

<link rel="stylesheet" href="https://cdn.jsdelivr.net/npm/bootstrap@4.6.2/dist/css/bootstrap.min.css" integrity="sha384-xOolHFLEh07PJGoPkLv1IbcEPTNtaed2xpHsD9ESMhqIYd0nLMwNLD69Npy4HI+N" crossorigin="anonymous">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <div class="container p-5">
    <form id="form1" runat="server">
        
        <div class="form-group">
            <asp:TextBox ID="input" runat="server" CssClass="form-control mb-5"></asp:TextBox>
            <asp:Button ID="submit" runat="server" Text="submit"  OnClick="submit_Click" CssClass="brn btn-primary btn-block" />
        </div>
         
    </form>
           </div>
</body>
</html>
