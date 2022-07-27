<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="StaffList.aspx.cs" Inherits="StaffRecord.StaffList" EnableEventValidation = "false" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:GridView ID="staffList" AutoGenerateColumns="false" runat="server"  OnRowDataBound="OnRowDataBound" OnSelectedIndexChanged="OnSelectedIndexChanged">
                <Columns>
                    <asp:BoundField DataField="Id" HeaderText="Employee Id" />
                    <asp:BoundField DataField="Name" HeaderText="Employee Name" />
                    <asp:BoundField DataField="Role" HeaderText="Job Role" />

                </Columns>

            </asp:GridView>
            <asp:LinkButton ID="lnkDummy" runat="server"></asp:LinkButton>
        </div>
    </form>
</body>
</html>
