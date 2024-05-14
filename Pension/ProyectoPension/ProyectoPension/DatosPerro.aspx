<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="DatosPerro.aspx.cs" Inherits="ProyectoPension.DatosPerro" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            Nombre perro:<asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
            <br />
            Edad:<asp:Label ID="Label2" runat="server" Text="Label"></asp:Label>
            <br />
            Raza:<asp:Label ID="Label3" runat="server" Text="Label"></asp:Label>
            <br />
            Dueño:<asp:Label ID="Label4" runat="server" Text="Label"></asp:Label>
        </div>
    </form>
</body>
</html>
