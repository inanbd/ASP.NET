<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="User.aspx.cs" Inherits="DvdShop.User" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>User Home</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <center>
            <h2>Customer Home</h2>
            <hr />
            <asp:Button ID="Button2" runat="server" Text="View Dvd List" OnClick="Button2_Click"></asp:Button>
            <asp:Button ID="Button3" runat="server" Text="Request For a Dvd" OnClick="Button3_Click"></asp:Button>
            <asp:Button ID="Button4" runat="server" Text="Logout" OnClick="Button4_Click" />
            <br />
            <br />
            <asp:Label ID="Label1" runat="server" Text=""></asp:Label>
        </center>
    </div>
    </form>
</body>
</html>
