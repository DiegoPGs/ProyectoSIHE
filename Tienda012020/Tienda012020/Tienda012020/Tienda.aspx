<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Tienda.aspx.cs" Inherits="Tienda012020.Tienda" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <style type="text/css">
        .auto-style1 {
            font-size: medium;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <strong><span class="auto-style1">Tienda</span></strong><br />
            <br />
            <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Salir de la tienda" />
            &nbsp;&nbsp;&nbsp;
            <asp:Button ID="Button5" runat="server" OnClick="Button5_Click" Text="Editar información personal" />
            <br />
            <br />
            <asp:Label ID="Label1" runat="server"></asp:Label>
            <br />
            <br />
            Selecciona un producto:
            <asp:DropDownList ID="DropDownList1" runat="server" >
            </asp:DropDownList>
            <asp:Button ID="Button2" runat="server" Text="Seleccionar" OnClick="Button2_Click" />
            <br />
            <br />
            Poducto seleccionado:
            <asp:Label ID="Label2" runat="server"></asp:Label>
&nbsp;&nbsp;&nbsp; Precio:
            <asp:Label ID="Label3" runat="server"></asp:Label>
            &nbsp;&nbsp;&nbsp;&nbsp; Cantidad:<asp:TextBox ID="TextBox1" runat="server" Width="65px"></asp:TextBox>
            <asp:Button ID="Button3" runat="server" Text="Agregar al carrito" OnClick="Button3_Click" />
            <br />
            <br />
            Carrito de compras:<asp:ListBox ID="ListBox1" runat="server" Height="86px" Width="207px"></asp:ListBox>
            &nbsp;Importe total:
            <asp:Label ID="Label4" runat="server"></asp:Label>
            <br />
            <br />
            <asp:Button ID="Button4" runat="server" OnClick="Button4_Click" Text="Finalizar compra" />
            <br />
            <br />
            <asp:Label ID="Label5" runat="server"></asp:Label>
            <br />
            <br />
        </div>
    </form>
</body>
</html>
