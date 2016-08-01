<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SearchDvd.aspx.cs" Inherits="DvdShop.SearchDvd" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <center>
            <h2>Search DVD</h2>
            <hr />

            <asp:TextBox ID="TextBoxSearch" runat="server"></asp:TextBox><asp:Button ID="Button1" runat="server" Text="Search" OnClick="Button1_Click"></asp:Button>
            <br />
            <asp:Label ID="LabelResult" runat="server" Text="Result: "></asp:Label>
            <br />
            <asp:GridView ID="GridView1" runat="server"></asp:GridView>


        </center>
    </div>
    </form>
</body>
</html>
