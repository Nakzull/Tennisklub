<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Kreditkort.aspx.cs" Inherits="Tennisklub.Kreditkort" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
        </div>
        <asp:Label ID="Label1" runat="server" Text="Navn"></asp:Label>
        <br />
        <asp:TextBox ID="Navn" runat="server"></asp:TextBox>
        <br />
        <asp:Label ID="Label2" runat="server" Text="Kortnummer"></asp:Label>
        <br />
        <asp:TextBox ID="Kortnummer" runat="server"></asp:TextBox>
        <br />
        <asp:Label ID="Label3" runat="server" Text="Udløbsdato"></asp:Label>
        <asp:Calendar ID="Udløbsdato" runat="server"></asp:Calendar>
        <br />
        <asp:Button ID="Button1" runat="server" Text="Tilføj kort" OnClick="Button1_Click" />
    </form>
</body>
</html>
