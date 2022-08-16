<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="StudentData.aspx.cs" Inherits="AssignmentAPIFrontEnd.StudentData" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link rel="stylesheet" href="https://cdn.jsdelivr.net/npm/bootstrap@4.6.2/dist/css/bootstrap.min.css" integrity="sha384-xOolHFLEh07PJGoPkLv1IbcEPTNtaed2xpHsD9ESMhqIYd0nLMwNLD69Npy4HI+N" crossorigin="anonymous">
    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/4.7.0/css/font-awesome.min.css">
    <script src="https://code.jquery.com/jquery-3.5.1.js"></script>
    
    <%-- For data tables --%>
    <link rel="stylesheet" href="https://cdn.datatables.net/1.12.1/css/dataTables.bootstrap4.min.css">
    <script src="https://cdn.datatables.net/1.12.1/js/jquery.dataTables.min.js"></script>
     <script src="https://cdn.datatables.net/1.12.1/js/dataTables.bootstrap4.min.js"></script>
</head>
<body>
    <form id="form1" runat="server">
        <h2 class="text-center mb-3 mt-5">Student Records</h2>
        <div class="w-50 mx-auto border border-info py-5 px-2">
            
            <table id="studentTable" class="table table-bordered table-striped ">

                    <thead>
                        <tr>
                            <th> ID</th>
                            <th>Name</th>
                            <th>Department</th>
                        </tr>
                    </thead>
        
                </table>
        </div>
    </form>

    <script>

            $(document).ready(function () {
                // call for customers on page load
                $.ajax({

                    url: "http://localhost/AssignmentAPI/api/values",
                    method: "get",
                    dataType: "json",
                    contentType: "application/json",
                    async: true,
                    success: function (data) {
                        console.log(data)
                        data = JSON.parse(data)
                        
                        populateStudentTable(data)
                    }
                });
                
            });
        function populateStudentTable(data) {

            $("#studentTable").dataTable({
                data: data,
                "paging": true,
                "lengthChange": false,
                "searching": true,
                "ordering": true,
                "info": true,
                "autoWidth": true,
                "bDestroy": true,
                columns: [
                    { "data": "Id" },
                    { "data": "Name" },
                    { "data": "Department" }

                    
                ]
            })
        }



    </script>
</body>
</html>
