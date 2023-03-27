<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Edit_form.aspx.cs" Inherits="CRUD_Operation.Edit_form" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
     
            <asp:Label runat="server">Name</asp:Label>
            <asp:TextBox runat="server" ID="txtname" name="Txtname"></asp:TextBox>
            <br /> 
            <br />
            <asp:Label runat="server" >PRN</asp:Label>
            <asp:TextBox runat="server" ID="txtprn" ></asp:TextBox>
            <br />
            <br />
            <asp:Label runat="server">College</asp:Label>
            <asp:TextBox runat="server" ID="txtcollege" ></asp:TextBox>
             <br />
            <br />
            <asp:button runat="server" ID="btnUpdate" Text="Update" OnClick="btnUpdate_Click" ></asp:button>
            <br />
        
        </div>
    </form>
</body>
</html>
