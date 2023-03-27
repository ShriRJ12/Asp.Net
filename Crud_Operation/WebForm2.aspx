<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm2.aspx.cs" Inherits="CRUD_Operation.WebForm2" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Label runat="server" style="color: #FF0066">Name</asp:Label>
            <asp:TextBox runat="server" ID="txtname"></asp:TextBox>
            <br />
            <br />
            <asp:Label runat="server" style="color: #3333CC">PRN</asp:Label>
            <asp:TextBox runat="server" ID="txtprn"></asp:TextBox>
            <br />
            <br />
            <asp:Label runat="server" style="color: #009933">College</asp:Label>
            <asp:TextBox runat="server" ID="txtcollege"></asp:TextBox>
             <br />
            <br />
            <asp:button runat="server" ID="button" Text="Submit" OnClick="button_Click" style="background-color: #33CC33" ></asp:button>
            <br />
            <asp:GridView runat="server" ID="Gridview1" OnRowCommand="Gridview1_RowCommand" CellPadding="4" ForeColor="#333333" GridLines="None">
                <AlternatingRowStyle BackColor="White" />
                <Columns>
                    <asp:TemplateField HeaderText="Actions">
                        <ItemTemplate>
                            <asp:LinkButton ID="lnkbtnDelete" CommandName="lnkbtnDelete" CommandArgument='<%#Eval("ID")%>' runat="server">Delete</asp:LinkButton>
                             <asp:LinkButton ID="linkbtnEdit" CommandName="linkbtnEdit" CommandArgument='<%#Eval("ID")%>' runat="server">Edit</asp:LinkButton>
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
                <FooterStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
                <HeaderStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
                <PagerStyle BackColor="#FFCC66" ForeColor="#333333" HorizontalAlign="Center" />
                <RowStyle BackColor="#FFFBD6" ForeColor="#333333" />
                <SelectedRowStyle BackColor="#FFCC66" Font-Bold="True" ForeColor="Navy" />
                <SortedAscendingCellStyle BackColor="#FDF5AC" />
                <SortedAscendingHeaderStyle BackColor="#4D0000" />
                <SortedDescendingCellStyle BackColor="#FCF6C0" />
                <SortedDescendingHeaderStyle BackColor="#820000" />
            </asp:GridView>
        </div>
    </form>
</body>
</html>
