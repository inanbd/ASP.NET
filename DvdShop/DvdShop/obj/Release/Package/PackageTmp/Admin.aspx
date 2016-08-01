<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Admin.aspx.cs" Inherits="DvdShop.Admin" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Admin Home</title>
</head>
<body>
    <form id="form1" runat="server">
    <center>
        <h2>Admin Home</h2>
        <hr />
        <div>
            <asp:Button ID="Button6" runat="server" Text="Add New Dvd" OnClick="Button6_Click" />
            <asp:Button ID="Button1" runat="server" Text="Search/View/Edit/Delete Dvd" OnClick="Button1_Click" />
            <asp:Button ID="Button4" runat="server" Text="Search User" OnClick="Button4_Click" />
            <asp:Button ID="Button5" runat="server" Text="View Customer Requests" OnClick="Button5_Click" />
            <asp:Button ID="Button2" runat="server" Text="Logout" OnClick="Button2_Click1"></asp:Button>
        </div>
    </center>
    </form>
</body>
</html>
