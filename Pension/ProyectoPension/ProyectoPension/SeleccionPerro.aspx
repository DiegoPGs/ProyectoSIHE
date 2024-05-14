<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SeleccionPerro.aspx.cs" Inherits="ProyectoPension.SeleccionPerro" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            Selecciona un perro:<asp:DropDownList ID="DropDownList1" runat="server">
            </asp:DropDownList>
            <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Ir a pagina del perro" />
        </div>
    </form>
</body>
</html>
