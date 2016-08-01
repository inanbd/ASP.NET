<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Index.aspx.cs" Inherits="DvdShop.Index" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Login</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <center>
            <h2>Dvd Shop Login</h2>
            <hr />

            <table>
                <tr>
                    <td>Username: </td>
                    <td><asp:TextBox ID="TextBox1" runat="server"></asp:TextBox></td>
                    <td><asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="Username Required" ControlToValidate="TextBox1" ForeColor="Red"></asp:RequiredFieldValidator></td>
                </tr>
                <tr>
                    <td>Password: </td>
                    <td><asp:TextBox ID="TextBox2" runat="server" TextMode="Password"></asp:TextBox></td>
                    <td><asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Password Required" ControlToValidate="TextBox2" ForeColor="Red"></asp:RequiredFieldValidator></td>
                </tr>
                <tr>
                    <td></td>
                    <td>&nbsp;</td>
                    
                </tr>
                <tr>
                    <td></td>
                    <td><asp:Button ID="Button1" runat="server" Text="Login" OnClick="Button1_Click"></asp:Button></td>
                    <td></td>
                </tr>
                <tr>
                    <td></td>
                    <td><asp:Label ID="Label1" runat="server" ForeColor="Red"></asp:Label></td>
                    <td></td>
                </tr>
            </table>
        </center>
    </div>
    </form>
</body>
</html>
