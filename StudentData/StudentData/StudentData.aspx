<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="StudentData.aspx.cs" Inherits="StudentData.StudentData" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link rel="stylesheet" href="https://cdn.jsdelivr.net/npm/bootstrap@4.0.0/dist/css/bootstrap.min.css" integrity="sha384-Gn5384xqQ1aoWXA+058RXPxPg6fy4IWvTNh0E263XmFcJlSAwiGgFAW/dAiS6JXm" crossorigin="anonymous">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
            <div class="container text-center p-5">
                <h2>Please select a student</h2>
            <asp:DropDownList ID="StudentListDropDown"  runat="server" CssClass="m-3" ></asp:DropDownList>
            <h2 id="student-data">
            </h2>
        </div>
    </form>

     <script src="https://code.jquery.com/jquery-3.4.1.min.js"></script>
    <script>
        const studentList = document.getElementById("StudentListDropDown");
        studentList.addEventListener("change", () => {
            var rollNo = studentList.value;
            $.ajax({
                url: 'StudentData.aspx/GetStudentData',
                type: 'post',
                data: JSON.stringify({ "rollNo": rollNo }),
                contentType: 'application/json',
                async: true,
                success: function (data) {

                    var html = `
                                <table class="table table-bordered table-hover table-success">
                                        <tr>
                                            <td>Roll Number</td>
                                            <td>${data.d.RollNo}</td>
                                        </tr>
                                        <tr>
                                            <td>Name</td>
                                            <td>${data.d.Name}</td>
                                        </tr>
                                        <tr>
                                            <td>Department</td>
                                            <td>${data.d.Department}</td>
                                        </tr>

                                    </table>`

                                                   
                    $("#student-data").html(html)
                    console.log(data)
                }
            });
        })
    </script>
</body>
</html>
