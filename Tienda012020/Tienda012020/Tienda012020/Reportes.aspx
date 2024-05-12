<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Reportes.aspx.cs" Inherits="Tienda012020.Reportes" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            Reportes<br />
            <asp:Button ID="Button3" runat="server" OnClick="Button3_Click" Text="Cerrar sesión" />
            <br />
            Ventas por usuario: nombre del usuario, productos, cantidad y fecha<br />
            <br />
            <asp:CheckBox ID="CheckBox1" runat="server" />
            Filtrar por usuario:
            <asp:DropDownList ID="DropDownList1" runat="server">
            </asp:DropDownList>
            <br />
            <asp:CheckBox ID="CheckBox2" runat="server" />
            Filtrar por producto:<asp:DropDownList ID="DropDownList2" runat="server">
            </asp:DropDownList>
            <br />
            <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Generar reporte" />
            <br />
            <asp:GridView ID="GridView1" runat="server" OnSelectedIndexChanged="GridView1_SelectedIndexChanged" >
            </asp:GridView>
            <br />
            Venta seleccionada:
            <asp:Label ID="Label1" runat="server"></asp:Label>
            <asp:Button ID="Button2" runat="server" OnClick="Button2_Click" Text="Borrar venta" />
            <br />
            <br />
            <asp:Label ID="Label2" runat="server"></asp:Label>
        </div>
    </form>
</body>
</html>
