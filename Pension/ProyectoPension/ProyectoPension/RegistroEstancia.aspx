<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="RegistroEstancia.aspx.cs" Inherits="ProyectoPension.RegistroEstancia" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>Registro Estancia</title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Salir" />
            <br />
            <br />
            Bienvenido Administrador<br />
            <br />
            Selecciona un perro:<asp:DropDownList ID="DropDownList1" runat="server" >
            </asp:DropDownList>
            <br />
            <br />
            Fecha Inicio:<asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
            <br />
            <br />
            Fecha Fin:<asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
            <br />
            <br />
            <asp:Button ID="Button2" runat="server" Text="Agregar estancia" OnClick="Button2_Click" />
            <br />
            <br />
            <asp:Label ID="Label1" runat="server"></asp:Label>
            <br />
            <br />
        </div>
    </form>
</body>
</html>
