<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AddUser.aspx.cs" Inherits="Tennisklub.AddUser" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <asp:Label ID="Label1" runat="server" Text="Fornavn"></asp:Label>
        <br />
        <asp:TextBox ID="Fornavn" runat="server"></asp:TextBox>
        <br />
        <asp:Label ID="Label2" runat="server" Text="Efternavn"></asp:Label>
        <br />
        <asp:TextBox ID="Efternavn" runat="server"></asp:TextBox>
        <br />
        <asp:Label ID="Label3" runat="server" Text="Adresse"></asp:Label>
        <br />
        <asp:TextBox ID="Adresse" runat="server"></asp:TextBox>
        <br />
        <asp:Label ID="Label4" runat="server" Text="Telefon"></asp:Label>
        <br />
        <asp:TextBox ID="Telefon" runat="server"></asp:TextBox>
        <br />
        <asp:Label ID="Label5" runat="server" Text="Email"></asp:Label>
        <br />
        <asp:TextBox ID="Email" runat="server"></asp:TextBox>
        <br />
        <asp:Label ID="Label6" runat="server" Text="Indmeldelses dato"></asp:Label>
        <br />
        <asp:Calendar ID="Indmeldelsesdato" runat="server"></asp:Calendar>
        <asp:Label ID="Label7" runat="server" Text="Alder"></asp:Label>
        <br />
        <asp:TextBox ID="Alder" runat="server"></asp:TextBox>
        <br />
        <asp:Button ID="TilføjSpillerKnap" runat="server" Text="Tilføj" OnClick="TilføjSpillerKnap_Click" />
        <br />
    </form>
</body>
</html>
