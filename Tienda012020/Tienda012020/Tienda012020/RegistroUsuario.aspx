<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="RegistroUsuario.aspx.cs" Inherits="Tienda012020.RegistroUsuario" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>Registro de Cliente</title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <strong>Registro de cliente</strong><br />
            <br />
            Nombre:<asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
            <br />
            Correo:<asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
            <br />
            Contraseña:<asp:TextBox ID="TextBox3" runat="server"></asp:TextBox>
            <br />
            Confirmar contraseña:<asp:TextBox ID="TextBox4" runat="server"></asp:TextBox>
            <br />
            <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Crear cuenta" />
            <br />
            <br />
            <asp:Label ID="Label1" runat="server"></asp:Label>
            <br />
            <br />
            <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="~/login.aspx">Iniciar sesión</asp:HyperLink>
        </div>
    </form>
</body>
</html>
