<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CarSuggestion.aspx.cs" Inherits="CarSuggestion.CarSuggestion" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:TextBox ID="input" runat="server"></asp:TextBox>
            <asp:DropDownList  ID="carsDropdown" runat="server"></asp:DropDownList>
        </div>
    </form>
    <script src="https://code.jquery.com/jquery-3.4.1.min.js"></script>
    <script>
        const inputCar = document.getElementById("input");
        inputCar.addEventListener("input", () => {
            if (!inputCar.value) {
                return
            }
            else {
                $.ajax({
                    url: 'CarSuggestion.aspx/CarSuggestionList',
                    type: 'post',
                    data: JSON.stringify({ "name": $("#input").val() }),

                    contentType: 'application/json',
                    success: function (data) {
                        console.log(data.d)
                        var select = document.getElementById("carsDropdown");
                        $("#carsDropdown").empty()
                        var options = data.d
                        for (var i = 0; i < options.length; i++) {
                            var opt = options[i];
                            var el = document.createElement("option");
                            el.textContent = opt;
                            el.value = opt;
                            select.appendChild(el);
                        }
                    }
                });
            }
            console.log(inputCar.value);
            console.log("Ajax ran");
        })
    </script>
</body>
</html>
