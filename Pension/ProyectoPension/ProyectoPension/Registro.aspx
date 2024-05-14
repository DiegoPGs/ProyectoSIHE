<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Registro.aspx.cs" Inherits="ProyectoPension.Registro" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            Registro de nuevo usuario:<br />
            <br />
            Nombre:<asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
            <br />
            Telefono:<asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
            <br />
            Dirección:<asp:TextBox ID="TextBox3" runat="server"></asp:TextBox>
            <br />
            Correo:<asp:TextBox ID="TextBox4" runat="server"></asp:TextBox>
            <br />
            Password:<asp:TextBox ID="TextBox5" runat="server"></asp:TextBox>
            <br />
            Confirmar pasword:<asp:TextBox ID="TextBox6" runat="server"></asp:TextBox>
            <br />
            <asp:Button ID="Button1" runat="server" Text="Registar" />
        </div>
    </form>
</body>
</html>
