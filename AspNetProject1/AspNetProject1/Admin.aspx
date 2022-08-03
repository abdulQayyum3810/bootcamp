<%@ Page Title="" Language="C#" MasterPageFile="~/User.Master" AutoEventWireup="true" CodeBehind="Admin.aspx.cs" Inherits="AspNetProject1.WebForm2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

    <script src="Scripts/account.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">


    <h2 class="text-center mb-2">Accounts Data</h2>
    <div class="border rounded border-info p-3 mb-5">
   <button type="button" class="btn btn-primary mb-5" id="newUser" onclick="newUserClick()" data-toggle="modal" data-target="#userModal">
    <i class="mr-1 fa fa-plus"></i>Add New
  </button>
                <!--Customer Modal -->
  <div class="modal fade" id="userModal" tabindex="-1" aria-labelledby="userModalLabel" aria-hidden="true">
    <div class="modal-dialog">
      <div class="modal-content">
        <div class="modal-header">
          <h5 class="modal-title" id="userModalLabel">Add User</h5>
          <button type="button" class="close" data-dismiss="modal" aria-label="Close">
            <span aria-hidden="true">&times;</span>
          </button>
        </div>
        <div class="modal-body">

            <div class="alert alert-danger d-none text-center w-75 m-auto" role="alert" id="userError">
                Please Enter Valid customer Data
            </div>
            <div class="alert alert-success d-none text-center w-75 m-auto" role="alert" id="userSuccess">
                Customer has been added successfully
            </div>

            <div class="row">
                <div class="form-group col-6">
                    <label for="userFName">Username</label>
                    <input type="text" name="username" id="username"  class="form-control">

                </div>
            
                <div class="form-group col-6 ">
                    <label for="userFName">First Name</label>
                    <input type="text" name="userFName" id="userFName"  class="form-control">

                </div>
             </div>

            <div class="row">
                <div class="form-group col-6 ">
                    <label for="userLName">Last Name</label>
                    <input type="text" name="userLName" id="userLName"  class="form-control">

                </div>
                <div class="form-group col-6">
                    <label for="userEmail">Email</label>
                    <input type="email" name="userEmail" id="userEmail" class="form-control">
                </div>
            </div>


            <div class="row">
            <div class="form-group col-6">
                <label for="userPassword">Password</label>
                <input type="email" name="userPassword" id="userPassword" class="form-control">
            </div>
                <div class="form-group col-6">
                    <label for="userType">User Type</label>
                    <select name="userType" id="userType" class="custom-select" required>
                        <option value="select" selected disabled>select</option>
                        <option value="admin">Admin</option>
                        <option value="accountant">Accountant</option>
                    </select>
                    <div class="invalid-feedback">
                        Please provide user type.
                    </div>
                </div>
            </div>

         
        </div>
        <div class="modal-footer">
          <button type="button" class="btn btn-secondary" data-dismiss="modal">Close</button>
          <%--<button type="button" class="btn btn-primary" id="addProduct">Add Product</button>--%>
            <asp:Button text="Add User" runat="server" ID="addUserBtn" CssClass="btn btn-primary"  OnClientClick="return addUser()"/>
        </div>
      </div>
    </div>
  </div>   




                <table id="accountsTable" class="table table-bordered table-hover table-striped table-light">

                    <thead>
                        <tr>
                            <th> Username</th>
                            <th>First Name</th>
                            <th>Last Name</th>
                            <th>Email</th>
                            <th >Password</th>
                            <th>Type</th>
                            <th>Edit</th>
                            <th>Delete</th>
                        </tr>
                    </thead>
        
                </table>

           </div>

</asp:Content>
