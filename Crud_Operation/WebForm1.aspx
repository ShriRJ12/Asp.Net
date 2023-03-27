<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="CRUD_Operation.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:Label runat="server">Name</asp:Label>
        <asp:TextBox runat="server" ID="txtname"></asp:TextBox>
        <br />
        <br />
        <asp:Label runat="server">Password</asp:Label>
        <asp:TextBox runat="server" ID="txtpass"></asp:TextBox>
        <br />
        <br />
        <asp:Label runat="server">Address</asp:Label>
        <asp:TextBox runat="server" ID="txtadd"></asp:TextBox>
        <br />
        <br />
        <asp:button runat="server" ID="button" Text="Submit" OnClick="button_Click1"></asp:button>
         
        <br />
        <br />
        <br />
        <br />
        <asp:GridView ID="GridView1" runat="server" Height="178px"  style="margin-left: 14px" OnRowCommand="GridView1_RowCommand">
            <Columns>
                    <asp:TemplateField HeaderText="Actions">
                        <ItemTemplate>
                            <asp:LinkButton ID="lnkbtnDelete" CommandName="lnkbtnDelete" CommandArgument='<%#Eval("ID")%>' runat="server">Delete</asp:LinkButton>
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
        </asp:GridView>
        <br />
        <br />
        <br />
         
    </div>
    </form>
    </body>
</html>
