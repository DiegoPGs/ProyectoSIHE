<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="login.aspx.cs" Inherits="ProyectoPension.login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            Entrar al sitio:<br />
            <br />
            Correo:<asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
            <br />
            Contraseña:<asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
            <br />
            <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Entrar" />
            <br />
            <br />
            <br />
            <a href="Registro.aspx">Registro de nuevo usuario</a>
        </div>
    </form>
</body>
</html>
