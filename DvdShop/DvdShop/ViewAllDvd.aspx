<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ViewAllDvd.aspx.cs" Inherits="DvdShop.ViewAllDvd" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <center>
        <h2>View All Dvd List</h2>
        <hr />

            <asp:TextBox ID="TextBoxSearch" runat="server"></asp:TextBox>
            <asp:Button ID="Button4" runat="server" OnClick="Button4_Click" Text="Search" />
        <br />
            <br />
        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" CellPadding="4" ForeColor="#333333" GridLines="None" 
            DataKeyNames="Id" onrowcancelingedit="GridView1_RowCancelingEdit" 
            onrowdatabound="GridView1_RowDataBound" onrowdeleting="GridView1_RowDeleting" 
            onrowediting="GridView1_RowEditing" onrowupdating="GridView1_RowUpdating"
            >
            <AlternatingRowStyle BackColor="White" />
            <Columns>
                <asp:BoundField DataField="Id" HeaderText="Movie ID" />

             
                <asp:TemplateField HeaderText="Title">
                    <EditItemTemplate>
                        <asp:TextBox ID="TextBoxTitle" runat="server" Text='<%# Bind("MovieTitle") %>'></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                            ControlToValidate="TextBoxTitle" ErrorMessage="Title is required">*</asp:RequiredFieldValidator>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="LabelTitle" runat="server" Text='<%# Bind("MovieTitle") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>


                <asp:TemplateField HeaderText="Description">
                    <EditItemTemplate>
                        <asp:TextBox ID="TextBoxDescription" runat="server" Text='<%# Bind("Description") %>'></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
                            ControlToValidate="TextBoxDescription" ErrorMessage="Description is required">*</asp:RequiredFieldValidator>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="LabelDescription" runat="server" Text='<%# Bind("Description") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>

           
                 <asp:TemplateField HeaderText="Actors">
                     <EditItemTemplate>
                         <asp:TextBox ID="TextBoxActors" runat="server" Text='<%# Bind("Actors") %>'></asp:TextBox>
                     </EditItemTemplate>
                     <ItemTemplate>
                        <asp:Label ID="LabelActors" runat="server" Text='<%# Bind("Actors") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>

           
                 <asp:TemplateField HeaderText="Category">
                    <EditItemTemplate>
                        <asp:DropDownList ID="DropDownListCategory" runat="server"
                            SelectedValue='<%# Bind("Category") %>'
                            >
                            <asp:ListItem>Action</asp:ListItem>
                            <asp:ListItem>Adventure</asp:ListItem>
                            <asp:ListItem>Animation</asp:ListItem>
                            <asp:ListItem>Comedy</asp:ListItem>
                            <asp:ListItem>Drama</asp:ListItem>
                            <asp:ListItem>Family</asp:ListItem>
                            <asp:ListItem>Fantasy</asp:ListItem>
                            <asp:ListItem>History</asp:ListItem>
                            <asp:ListItem>Horror</asp:ListItem>
                            <asp:ListItem>Musical</asp:ListItem>
                            <asp:ListItem>Mystery</asp:ListItem>
                            <asp:ListItem>Romance</asp:ListItem>
                            <asp:ListItem>Sci-Fi</asp:ListItem>
                            <asp:ListItem>Sport</asp:ListItem>
                            <asp:ListItem>Thriller</asp:ListItem>
                            <asp:ListItem>War</asp:ListItem>
                            <asp:ListItem>Western</asp:ListItem>
                            <asp:ListItem>Detactive</asp:ListItem>
                        </asp:DropDownList>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="LabelCategory" runat="server" Text='<%# Bind("Category") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>



                <asp:TemplateField HeaderText="AudioQuality">
                    <EditItemTemplate>
                        <asp:DropDownList ID="DropDownListAudioQuality" runat="server"
                            SelectedValue='<%# Bind("AudioQuality") %>'
                            >
                            <asp:ListItem>1.0 Mono</asp:ListItem>
                            <asp:ListItem>2.0 Stereo</asp:ListItem>
                            <asp:ListItem>5.1 Surround</asp:ListItem>
                        </asp:DropDownList>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="LabelAudioQuality" runat="server" Text='<%# Bind("AudioQuality") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                
            


                <asp:TemplateField HeaderText="Video Quality">
                    <EditItemTemplate>
                        <asp:DropDownList ID="DropDownListVideoQuality" runat="server"
                            SelectedValue='<%# Bind("VideoQuality") %>'
                            >
                            <asp:ListItem>360p</asp:ListItem>
                            <asp:ListItem>480p</asp:ListItem>
                            <asp:ListItem>720p</asp:ListItem>
                            <asp:ListItem>1080p</asp:ListItem>
                            <asp:ListItem>2k</asp:ListItem>
                            <asp:ListItem>4k</asp:ListItem>
                        </asp:DropDownList>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="LabelVideoQuality" runat="server" Text='<%# Bind("VideoQuality") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>


                <asp:TemplateField HeaderText="Language">
                    <EditItemTemplate>
                        <asp:DropDownList ID="DropDownListLanguage" runat="server"
                            SelectedValue='<%# Bind("Language") %>'
                            >
                            <asp:ListItem>Bangla</asp:ListItem>
                            <asp:ListItem>Korean</asp:ListItem>
                            <asp:ListItem>English</asp:ListItem>
                            <asp:ListItem>Hindi</asp:ListItem>
                            <asp:ListItem>En-Hi Dual  Audio</asp:ListItem>
                        </asp:DropDownList>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="LabelLanguage" runat="server" Text='<%# Bind("Language") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>

                <asp:CommandField HeaderText="Options" ShowDeleteButton="True" ShowEditButton="True" />
            </Columns>
            <EditRowStyle BackColor="#2461BF" />
            <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
            <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
            <RowStyle BackColor="#EFF3FB" />
            <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
            <SortedAscendingCellStyle BackColor="#F5F7FB" />
            <SortedAscendingHeaderStyle BackColor="#6D95E1" />
            <SortedDescendingCellStyle BackColor="#E9EBEF" />
            <SortedDescendingHeaderStyle BackColor="#4870BE" />
        </asp:GridView>
        <asp:ValidationSummary ID="ValidationSummary1" runat="server" />
        <asp:Button ID="Button1" runat="server" Text="Undo" OnClick="Button1_Click"></asp:Button>
        <asp:Button ID="Button2" runat="server" Text="Refresh" OnClick="Button2_Click"></asp:Button>
        <asp:Button ID="Button3" runat="server" Text="Confirm Changes" OnClick="Button3_Click"></asp:Button>
    </center>
    </div>
    </form>
</body>
</html>
