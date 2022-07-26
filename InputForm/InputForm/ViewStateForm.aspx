<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ViewStateForm.aspx.cs" Inherits="InputForm.ViewStateForm" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <script src="https://code.jquery.com/jquery-3.6.0.min.js" integrity="sha256-/xUj+3OJU5yExlq6GSYGSHk7tPXikynS7ogEvDej/m4=" crossorigin="anonymous"></script>
    <link rel="stylesheet" href="https://cdn.jsdelivr.net/npm/bootstrap@4.6.2/dist/css/bootstrap.min.css" integrity="sha384-xOolHFLEh07PJGoPkLv1IbcEPTNtaed2xpHsD9ESMhqIYd0nLMwNLD69Npy4HI+N" crossorigin="anonymous">
</head>
<body>
    <form id="form1" runat="server">
        <div class="container">

            <p id="errorCatch" runat="server"></p>

            <div class="form-group">
                <label for="username">Username</label>
                <asp:TextBox ID="username" runat="server" CssClass="form-control"></asp:TextBox>
            </div>

            <div class="form-group">
                <label for="password">Password</label>
                <asp:TextBox ID="password" runat="server"  CssClass="form-control"></asp:TextBox>
            </div>
            <asp:Button ID="submit" runat="server" CssClass="btn btn-primary" OnClick="submit_Click" Text="Submit" OnClientClick="javascript: return populateHiddenfields()"/>
            <asp:Button ID="restorFromViewState" CssClass="btn btn-success" runat="server" Text="Restore From View State" OnClick="restorFromViewState_Click"/>
            <asp:Button ID="restorFromHiddenfields" CssClass="btn btn-info" runat="server" Text="Restore From Hidden Fields" OnClick="restorFromHiddenfields_Click" />
            <asp:HiddenField ID="userHidden" runat="server" />
            <asp:HiddenField ID="passwordHidden" runat="server" />
        </div>

        <script>

            function populateHiddenfields() {
                try {
                       // get username and password and set them in the respective hidden fields
                    var user = $("#username").val();
                    var pass = $("#password").val();
                    $("#userHidden").val(user)
                    $("#passwordHidden").val(pass)
                    return true
                }
                catch(err){
                    $("#errorCatch").val("please enter a valid input")
                    return false
                }
            }


        </script>
    </form>
</body>
</html>
