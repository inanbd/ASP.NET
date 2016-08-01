<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="RequestForADvd.aspx.cs" Inherits="DvdShop.RequestForADvd" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .auto-style1 {
            margin-left: 0px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <center>
            <h2>Request For A  Dvd</h2>
            <hr />
            <table>
                <tr>
                    <td>Title: </td>
                    <td><asp:TextBox ID="TextBox1" runat="server" CssClass="auto-style1" Width="174px"></asp:TextBox></td>
                </tr>
                <tr>
                    <td>Description: </td>
                    <td><asp:TextBox ID="TextBox2" runat="server" TextMode="MultiLine"></asp:TextBox></td>
                </tr>

                <tr>
                    <td></td>
                    <td><asp:Button ID="Button1" runat="server" Text="Request" OnClick="Button1_Click"></asp:Button></td>
                </tr>

            </table>

        </center>
    </div>
    </form>
</body>
</html>
