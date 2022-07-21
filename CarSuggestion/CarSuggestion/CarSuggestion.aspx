<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CarSuggestion.aspx.cs" Inherits="CarSuggestion.CarSuggestion" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link href = "https://code.jquery.com/ui/1.10.4/themes/ui-lightness/jquery-ui.css"
         rel = "stylesheet">
      <script src = "https://code.jquery.com/jquery-1.10.2.js"></script>
      <script src = "https://code.jquery.com/ui/1.10.4/jquery-ui.js"></script>
    <link rel="stylesheet" href="https://cdn.jsdelivr.net/npm/bootstrap@4.0.0/dist/css/bootstrap.min.css" integrity="sha384-Gn5384xqQ1aoWXA+058RXPxPg6fy4IWvTNh0E263XmFcJlSAwiGgFAW/dAiS6JXm" crossorigin="anonymous">
    <style>
         p, div, input {
            font: 16px Calibri;
        }
        .ui-autocomplete { 
            cursor:pointer; 
            height:120px; 
            overflow-y:scroll;
            background-color:aliceblue;
        }    
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div class="container text-center d-flex pt-5">
         <div class="form-control ">
             <label for="input">Enter Name of the car</label>
            <input type="text" id="input" class="form-group" />
        </div>
            </div>

    </form>




   
    <script>
        const inputCar = document.getElementById("input");
        inputCar.addEventListener("input", () => {
            if (!inputCar.value) {
                BindControls([])
                return
            }
            else {
                $.ajax({
                    url: 'CarSuggestion.aspx/CarSuggestionList',
                    type: 'post',
                    data: JSON.stringify({ "name": $("#input").val() }),

                    contentType: 'application/json',
                    success: function (data) {
                        BindControls(data.d)
                        console.log(data.d)
                    }
                });
            }
            console.log(inputCar.value);
            console.log("Ajax ran");
        })



        function BindControls(list) {

            $('#input').autocomplete({
                source: list,
                minLength: 0,
                scroll: true
            }).focus(function () {
                $(this).autocomplete("search", "");
            });
        }
</script>

</body>
</html>
