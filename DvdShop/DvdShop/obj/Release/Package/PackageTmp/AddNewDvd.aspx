<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AddNewDvd.aspx.cs" Inherits="DvdShop.AddNewDvd" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Add Dvd</title>
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
        <h2>Add New Dvd</h2>
        <hr />
        <table>
            <tr>
                <td>Title:</td>
                <td><asp:TextBox ID="TextBoxTitle" runat="server" Width="176px"></asp:TextBox></td>
                <td><asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Title Required" ControlToValidate="TextBoxTitle" ForeColor="Red"></asp:RequiredFieldValidator></td>
            </tr>
            <tr>
                <td>Description: </td>
                <td><asp:TextBox ID="TextBoxDescription" runat="server" TextMode="MultiLine"></asp:TextBox></td>
                 <td><asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="Description Required" ForeColor="Red" ControlToValidate="TextBoxDescription"></asp:RequiredFieldValidator></td>
            </tr>
            <tr>
                <td>Category: </td>
                <td>
                    <asp:DropDownList ID="DropDownListCategory" runat="server" Height="20px" Width="178px">
                    </asp:DropDownList>
                </td>
                 <td><asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="Category Required" ForeColor="Red" ControlToValidate="DropDownListCategory"></asp:RequiredFieldValidator></td>
            </tr>
            <tr>
                <td>Audio Quality: </td>
                <td>
                    <asp:DropDownList ID="DropDownListAudio" runat="server" Height="20px" Width="174px">
                        <asp:ListItem>1.0 Mono</asp:ListItem>
                        <asp:ListItem>2.0 Stereo</asp:ListItem>
                        <asp:ListItem>5.1 Surround</asp:ListItem>
                    </asp:DropDownList>
                </td>
                 <td><asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ErrorMessage="Audio Quality Required" ForeColor="Red" ControlToValidate="DropDownListAudio"></asp:RequiredFieldValidator></td>
            </tr>
            <tr>
                <td>Video Quality</td>
                <td>
                    <asp:DropDownList ID="DropDownListVideo" runat="server" CssClass="auto-style1" Height="16px" Width="176px">
                        <asp:ListItem>360p</asp:ListItem>
                        <asp:ListItem>480p</asp:ListItem>
                        <asp:ListItem>720p</asp:ListItem>
                        <asp:ListItem>1080p</asp:ListItem>
                        <asp:ListItem>2k</asp:ListItem>
                        <asp:ListItem>4k</asp:ListItem>
                    </asp:DropDownList>
                </td>
                 <td><asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ErrorMessage="Video Qualtiy Required" ForeColor="Red" ControlToValidate="DropDownListVideo"></asp:RequiredFieldValidator></td>
            </tr>
            <tr>
                <td>Language</td>
                <td>
                    <asp:DropDownList ID="DropDownListLanguage" runat="server" Height="19px" Width="176px">
                        <asp:ListItem>Bangla</asp:ListItem>
                        <asp:ListItem>Korean</asp:ListItem>
                        <asp:ListItem>English</asp:ListItem>
                        <asp:ListItem>Hindi</asp:ListItem>
                        <asp:ListItem>En-Hi Dual  Audio</asp:ListItem>
                    </asp:DropDownList>
                </td>
                 <td><asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ErrorMessage="Language Required" ForeColor="Red" ControlToValidate="DropDownListLanguage"></asp:RequiredFieldValidator></td>
            </tr>
            <tr>
                <td></td>
                <td><asp:Button ID="Button1" runat="server" Text="ADD" OnClick="Button1_Click"></asp:Button></td>
                <td></td>
            </tr>
        </table>
    </center>
    </div>
    </form>
</body>
</html>
