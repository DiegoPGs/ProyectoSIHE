<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ReporteFlexible.aspx.cs" Inherits="ProyectoPension.ReporteFlexible" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            Reporte flexible:<br />
            <br />
            Columnas del reporte:<br />
            <asp:CheckBoxList ID="CheckBoxList1" runat="server">
            </asp:CheckBoxList>
            <br />
            Parámetros de búsqueda:<br />
            <asp:CheckBox ID="CheckBox1" runat="server" />
            Nombre dueño:
            <asp:DropDownList ID="DropDownList1" runat="server">
            </asp:DropDownList>
            <br />
            <asp:CheckBox ID="CheckBox2" runat="server" />
            Raza del perro:
            <asp:DropDownList ID="DropDownList2" runat="server">
            </asp:DropDownList>
            <br />
            <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Buscar" />
            <asp:Button ID="Button2" runat="server" OnClick="Button2_Click" Text="Buscar tabla padre" />
            <br />
            <br />
            <asp:GridView ID="GridView1" runat="server">
            </asp:GridView>
            <br />
            <asp:Label ID="Label1" runat="server"></asp:Label>
        </div>
    </form>
</body>
</html>
