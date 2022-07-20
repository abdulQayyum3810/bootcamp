<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="Calculator.WebForm1" %>

<!DOCTYPE html>
<link rel="stylesheet" href="https://cdn.jsdelivr.net/npm/bootstrap@4.0.0/dist/css/bootstrap.min.css" integrity="sha384-Gn5384xqQ1aoWXA+058RXPxPg6fy4IWvTNh0E263XmFcJlSAwiGgFAW/dAiS6JXm" crossorigin="anonymous">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    
</head>
<body>
    <div class="container">
    <form id="form1" runat="server">
        <br >
            <h1 class="h1 mb-5 text-center">Calculator</h1>

            <div class="form-group row">
                <label for="xi" class=" col-2 col-form-label">X=</label>
                <div class="col-sm-10">
                <input class="form-control is-invalid" id="xi" type="text" runat="server" name="x" >
                    <div class="invalid-feedback">
                    Looks good!
                 </div>
                </div>
                
            </div>
          
            <div class="form-group row">
                <label for="y"class=" col-2 col-form-label">Y=</label>
                <div class="col-sm-10">
                    <input class="form-control" id="yi" type="text" runat="server" name="y">
                </div>
           </div>

            <div class="form-group row">
            <label for="opperation" class=" col-2 col-form-label">Select Opperation</label>

                <div class="col-sm-10">
            <select class="custom-select " id="opperation" runat="server">
                <option readonly disabled selected>--select---</option>
                <option>Add</option>
                <option>Subtract</option>
                <option>Multiply</option>
                <option>Divide</option>
            </select>
            </div>
            </div>
            <div class="form-row">
                <div class="col-2 mt-5">
                    <asp:Button runat="server" ID="calculate" CssClass="btn btn-success" OnClick="calculate_Click" OnClientClick="javascript: return validateForm()" Text="Calculate" />
                </div>
                <div class="col-auto mt-5">
                    <div class="form-group row">
                        <label for="output" class="col-form-label">Output=</label>
                        <div class="col">
                            <input type="text" class="form-control text-center font-weight-bold"  id="output" readonly runat="server"  >
                        </div>
                    </div>
                </div>
            </div>

            

            </form>
        </div>
    <script type="text/javascript">

        var x ;
        var y;
        function validateForm() {
            var x = document.getElementById("xi").value;
            var y = document.getElementById("yi").value;
            var opp = document.getElementById("opperation").value;
            console.log(opp)
            if (isNaN(x) || !x || isNaN(y) || !y) {
                window.alert("Input fields are empty or invalid(not number)")
                return false
            }
            if (opp === "--select---") {
                window.alert("Please Select a valid opperation")
                return false
            }
            return true
        }

    </script>
        
</body>
</html>
