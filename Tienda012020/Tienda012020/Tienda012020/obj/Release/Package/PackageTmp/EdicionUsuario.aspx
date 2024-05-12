<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="EdicionUsuario.aspx.cs" Inherits="Tienda012020.EdicionUsuario" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            Editar información personal<br />
            <br />
            <asp:Button ID="Button2" runat="server" OnClick="Button2_Click" Text="Regresar a tienda" />
            <br />
            <br />
            Correo: <asp:Label ID="Label1" runat="server"></asp:Label>
            <br />
            <br />
            Nombre:
            <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
            <br />
            <br />
            Contraseña:
            <asp:TextBox ID="TextBox2" runat="server" TextMode="Password"></asp:TextBox>
            <br />
            <br />
            Confirmación contraseña:
            <asp:TextBox ID="TextBox3" runat="server" TextMode="Password"></asp:TextBox>
            <br />
            <br />
            <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Actualizar información" />
            <br />
            <br />
            <asp:Label ID="Label2" runat="server"></asp:Label>
        </div>
    </form>
</body>
</html>
