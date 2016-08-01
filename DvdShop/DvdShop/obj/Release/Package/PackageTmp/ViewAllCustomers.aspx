<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ViewAllCustomers.aspx.cs" Inherits="DvdShop.ViewAllCustomers" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <center>
            <h2>All Customers</h2>
            <hr />
            <asp:GridView ID="GridView1" runat="server"></asp:GridView>
        </center>
    </div>
    </form>
</body>
</html>
