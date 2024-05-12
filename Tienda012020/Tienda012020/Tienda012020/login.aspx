<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="login.aspx.cs" Inherits="Tienda012020.login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>Login</title>
    <style type="text/css">
        .auto-style1 {
            font-size: large;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <strong><span class="auto-style1">Inicio</span></strong><br />
            <br />
            Correo:<asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
            <br />
            Contraseña:<asp:TextBox ID="TextBox2" runat="server" TextMode="Password"></asp:TextBox>
            <br />
            <asp:Button ID="Button1" runat="server" Text="Entrar" OnClick="Button1_Click" />
            <br />
            <br />
            <asp:Label ID="Label1" runat="server"></asp:Label>
            <br />
            <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="~/RegistroUsuario.aspx">Crear cliente nuevo</asp:HyperLink>
        </div>
    </form>
</body>
</html>
