<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ReportePerroDueno.aspx.cs" Inherits="ProyectoPension.ReportePerroDueno" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            Reporte Perro-Dueño (ejemplo de reporte fijo)<br />
            <br />
            Dueño:<asp:DropDownList ID="DropDownList1" runat="server">
            </asp:DropDownList>
            <br />
            Raza:<asp:DropDownList ID="DropDownList2" runat="server">
            </asp:DropDownList>
            <br />
            <br />
            <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Generar reporte" />
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
