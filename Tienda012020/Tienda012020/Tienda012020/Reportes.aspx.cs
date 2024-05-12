using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.Odbc;

namespace Tienda012020
{
    public partial class Reportes : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["admin"] == null)
            //if(Session["nombreUsuario"]==null)
            {//No hay un usuario autenticado...
                Session.Abandon();
                Response.Redirect("loginAdmin.aspx");
            }
            if (DropDownList1.Items.Count == 0) 
            {
                String query = "select venta.folio,cliente.nombre,producto.nombre,venta.cantidad,venta.fecha from cliente inner join cliProdVenta on cliente.correo=cliProdVenta.correo inner join producto on cliProdVenta.cProd=producto.cProd inner join venta on cliProdVenta.folio=venta.folio ";
                OdbcConnection conexion = new ConexionBD().con;
                OdbcCommand comando = new OdbcCommand(query, conexion);

                OdbcDataReader lector = comando.ExecuteReader();
                String[] llavesPrimarias = { "folio" }; //Nombres de las columnas con las llaves
                                                        //primarias
                //Ligar los resultados del select con el gridview para mostrar el reporte
                GridView1.DataSource = lector;  //Asignar el lector como fuente de los datos
                GridView1.AutoGenerateSelectButton = true; //Permite al usuario seleccionar un 
                                                           //elemento del gridview
                GridView1.DataKeyNames = llavesPrimarias;  //Toma el arreglo de llaves primarias
                GridView1.DataBind();           //Ligar el lector al gridview

                //Si no tiene items el dropdown, le cargamos los clientes
                String queryDropDown = "select correo,nombre from cliente";
                comando = new OdbcCommand(queryDropDown, conexion);
                lector = comando.ExecuteReader();
                DropDownList1.DataSource = lector;
                //no lo ve el usuario
                DropDownList1.DataValueField = "correo";
                //lo ve el usuario
                DropDownList1.DataTextField = "nombre";
                //acordarse de hacer bind, por que si no, el dropdown no carga
                DropDownList1.DataBind();

                String queryDropDownProd = "select cProd,nombre from producto";
                comando = new OdbcCommand(queryDropDownProd, conexion);
                lector = comando.ExecuteReader();
                DropDownList2.DataSource = lector;
                DropDownList2.DataValueField = "cProd";//no se ve
                DropDownList2.DataTextField = "nombre";//si se ve
                DropDownList2.DataBind();

                Button2.Enabled = false;
                conexion.Close();
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            String query = "select venta.folio,cliente.nombre,producto.nombre,venta.cantidad,venta.fecha from cliente inner join cliProdVenta on cliente.correo=cliProdVenta.correo inner join producto on cliProdVenta.cProd=producto.cProd inner join venta on cliProdVenta.folio=venta.folio ";
            String where = "where ";//where cliente.correo=?

            if (CheckBox1.Checked == true)
            {
                query = query + where + "cliente.correo=? ";
            }
            if (CheckBox2.Checked == true)
            {
                if (query.Contains("where"))
                {
                    query = query + " and producto.cProd=? ";
                }
                else
                {
                    query = query + where + " producto.cProd=? ";
                }
            }

            OdbcConnection conexion = new ConexionBD().con;
            OdbcCommand comando = new OdbcCommand(query, conexion);
            //Cargar el parametro del correo
            //SelectedValue regresa el valor seleccionado que no veo del dropdownlist
            //normalmente, la llave primaria de una tabla
            if (CheckBox1.Checked == true)
            {
                String correo = DropDownList1.SelectedValue.ToString();
                comando.Parameters.AddWithValue("correo", correo);
            }
            if (CheckBox2.Checked == true)
            {
                String cProd = DropDownList2.SelectedValue.ToString();
                comando.Parameters.AddWithValue("cProd", cProd);
            }
            OdbcDataReader lector = comando.ExecuteReader();
            String[] llavesPrimarias = { "folio" };
            //Ligar los resultados del select con el gridview para mostrar el reporte
            GridView1.DataSource = lector;  //Asignar el lector como fuente de los datos
            GridView1.AutoGenerateSelectButton = true;
            GridView1.DataKeyNames = llavesPrimarias;
            GridView1.DataBind();           //Ligar el lector al gridview
            conexion.Close();
        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            Label1.Text = GridView1.SelectedDataKey.Value.ToString();
            Button2.Enabled = true;
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            String queryCliProdVenta = "delete from cliProdVenta where folio=?";
            String queryVenta = "delete from venta where folio=?";
            OdbcConnection conexion = new ConexionBD().con;
            OdbcCommand comando = new OdbcCommand(queryCliProdVenta, conexion);
            comando.Parameters.AddWithValue("folio", Label1.Text);
            try
            {
                comando.ExecuteNonQuery();
                comando = new OdbcCommand(queryVenta, conexion);
                comando.Parameters.AddWithValue("folio", Label1.Text);
                comando.ExecuteNonQuery();
                Label2.Text="Se borró la venta " + Label1.Text;
                Label1.Text = "";
                Button2.Enabled = false;

                //Recargar el gridview
                String query = "select venta.folio,cliente.nombre,producto.nombre,venta.cantidad,venta.fecha from cliente inner join cliProdVenta on cliente.correo=cliProdVenta.correo inner join producto on cliProdVenta.cProd=producto.cProd inner join venta on cliProdVenta.folio=venta.folio";
                comando = new OdbcCommand(query, conexion);

                OdbcDataReader lector = comando.ExecuteReader();
                String[] llavesPrimarias = { "folio" };
                //Ligar los resultados del select con el gridview para mostrar el reporte
                GridView1.DataSource = lector;  //Asignar el lector como fuente de los datos
                GridView1.AutoGenerateSelectButton = true;
                GridView1.DataKeyNames = llavesPrimarias;
                GridView1.DataBind();           //Ligar el lector al gridview
            }
            catch (Exception ex)
            {
                Label2.Text = "Error al borrar la venta " + ex.ToString();
            }
            conexion.Close();
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            Session.Abandon();
            Response.Redirect("loginAdmin.aspx");
        }
    }
}