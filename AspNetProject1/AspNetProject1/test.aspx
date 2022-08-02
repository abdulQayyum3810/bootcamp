<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="test.aspx.cs" Inherits="AspNetProject1.test" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Button runat="server" ID="submit" OnClick="submit_Click" Text="submit"/>
            <asp:GridView ID="grid" runat="server">

            </asp:GridView>
        </div>
    </form>
</body>
</html>
