<%@ Page Title="" Language="C#" MasterPageFile="~/User.Master" AutoEventWireup="true" CodeBehind="Admin.aspx.cs" Inherits="AspNetProject1.WebForm2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

    <script src="Scripts/admin.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">


    <h2 class="text-center mb-2">Accounts Data</h2>
    <div class="border rounded border-info p-3 mb-5">
    <a class="btn btn-primary mb-5"><i class="mr-1 fa fa-plus"></i>Add New</a>

                <table id="accountsTable" class="table table-bordered table-hover table-striped table-light">

                    <thead>
                        <tr>
                            <th> Username</th>
                            <th>First Name</th>
                            <th>Last Name</th>
                            <th>Email</th>
                            <th>Type</th>
                        </tr>
                    </thead>
        
                </table>

           </div>

</asp:Content>
