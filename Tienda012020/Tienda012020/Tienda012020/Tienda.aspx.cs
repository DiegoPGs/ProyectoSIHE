using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.Odbc;

namespace Tienda012020
{
    public partial class Tienda : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //Verificar que exista una sesion valida
            if (Session["nombreUsuario"] == null)
            {//Usuario tramposo que no puso credenciales correctas
                //Limpiar sesion
                Session.Abandon();
                //Mandar al usuario al login
                Response.Redirect("login.aspx");
            }
            //Si puso bien sus credenciales, le damos la bienvenida
            Label1.Text = "Bienvenid@ " + Session["nombreUsuario"];

            if (DropDownList1.Items.Count == 0)
            {//Solo cargo los datos una vez para evitar que se borre la seleccion
                //Cargar dropdownlist
                String query = "select cProd,nombre from producto";
                ConexionBD objetoParaConexion = new ConexionBD();
                OdbcConnection conexion = objetoParaConexion.con;
                OdbcCommand comando = new OdbcCommand(query, conexion);
                OdbcDataReader lector = comando.ExecuteReader();
                //Cargar los datos del lector al dropdownlist
                DropDownList1.DataSource = lector;
                DropDownList1.DataValueField = "cProd"; //<-- es el nombre de la columna como
                                                        //viene en el select
                                                        //no se muestra al usuario
                DropDownList1.DataTextField = "nombre"; //<-- nombre de la columna como viene
                                                        //viene en el select
                                                        //este si se muestra al usuario
                DropDownList1.DataBind();
                //Deshabilitar el boton carrito para que el usuario no lo pueda utilizar sin
                //haber seleccionado un producto
                Button3.Enabled = false;
                conexion.Close();
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            //Cerrar la sesion
            Session.Abandon();
            //Redireccionar el usuario al login
            Response.Redirect("login.aspx");
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            //Para guardar el precio del producto
            double precio;
            //Sacar el producto del dropdown y meterlo al listbox
            //Sacamos la clave unica del producto
            int claveProd = Int32.Parse(DropDownList1.SelectedValue.ToString());
            //Sacamos el nombre del producto
            //Selected Item tiene dos propiedades: value y text
            //text es lo que ve el usuario
            //value es la referencia (normalmente la llave primaria de una tabla)
            String nombreProd = DropDownList1.SelectedItem.Text;
            Label2.Text = nombreProd;
            //Extraemos el precio de la base de datos para sumarlo al total
            OdbcConnection conexion = new ConexionBD().con;
            String query = "select precio from producto where cProd=?";
            OdbcCommand comando = new OdbcCommand(query, conexion);
            comando.Parameters.AddWithValue("cProd", claveProd);
            OdbcDataReader lector = comando.ExecuteReader();
            if (lector.HasRows)
            {
                lector.Read(); //Avanzamos al primer renglon
                precio = lector.GetDouble(0); //el select solo tiene una columna, la 0
                Label3.Text = precio.ToString();
            }
            Session["cProd"] = claveProd;
            //Habilitar el botón carrito para que el usuario pueda meter su producto al
            //listbox
            Button3.Enabled = true;
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            if (Session["total"] == null)
            {//es el primer producto comprado
                try
                {
                    Session["total"] = Double.Parse(Label3.Text) * Double.Parse(TextBox1.Text);
                }
                catch(Exception ex)
                {
                    Session["total"] = 0;
                }
            }
            else
            {//ya hay productos en el ticket
                //Las sesiones se guardan como objetos, por eso hay que hacer un parsing a doble del string
                Session["total"] = Double.Parse(Session["total"].ToString())+Double.Parse(Label3.Text) * Double.Parse(TextBox1.Text);
            }
            //Lo metemos al listbox, junto con la llave primaria del producto para poder registrar las ventas
            //Como value del listbox guardamos las claves de los productos comprados y la cantidad
            String cProdCant = Session["cProd"].ToString() + "#" + TextBox1.Text;
            ListBox1.Items.Add(new ListItem(Label2.Text + " x " + TextBox1.Text, cProdCant));
            Label4.Text = Session["total"].ToString();
            //Limpiar los controles para no confundir al usuario
            Label2.Text = "";
            Label3.Text = "";
            TextBox1.Text = "";
            Button3.Enabled = false; //Deshabilitar el boton para que el usuario no lo
                                     //pueda usar sin haber seleccionado un producto
        }

        protected void Button4_Click(object sender, EventArgs e)
        {
            //Los parametros del query venta son el folio y la cantidad de productos comprados
            String queryVenta = "insert into venta values(?,GETDATE(),?)";
            //Los parametros del query cliProdVenta son el correo del usuario,
            //la clave del producto y el folio de la venta
            String queryCliProdVenta = "insert into cliProdVenta values(?,?,?)";
            Random r = new Random();
            for (int i = 0; i < ListBox1.Items.Count; i++)
            {
                //Sacar del listbox el primer renglon
                String cProdCant = ListBox1.Items[i].Value;
                //El primer elemento me da la clave del producto y el segundo la cantidad
                String[] cProdCantSeparado = cProdCant.Split('#');
                //Crear conexion a la base de datos
                OdbcConnection conexion = new ConexionBD().con;
                //bandera para ver si se pudo insertar en la tabla venta - verificar que la llave
                //aleatoria no existe
                bool exito = false;
                int folio=0;
                while (exito == false)
                {
                    //Crear comando
                    OdbcCommand comandoVenta = new OdbcCommand(queryVenta, conexion);
                    folio = r.Next(1000000);
                    comandoVenta.Parameters.AddWithValue("folio", folio);
                    comandoVenta.Parameters.AddWithValue("cantidad", cProdCantSeparado[1]);
                    try
                    {
                        comandoVenta.ExecuteNonQuery();
                        //Si llegue aqui es que pude insertar en la tabla venta
                        exito = true;
                    }
                    catch (Exception ex)
                    {
                        Label5.Text = "Excepcion: " + ex.ToString();
                    }
                }
                OdbcCommand comandoCliProdVenta = new OdbcCommand(queryCliProdVenta, conexion);
                comandoCliProdVenta.Parameters.AddWithValue("correo", Session["correoUsuario"]);
                comandoCliProdVenta.Parameters.AddWithValue("cProd", cProdCantSeparado[0]);
                comandoCliProdVenta.Parameters.AddWithValue("folio", folio);
                try
                {
                    comandoCliProdVenta.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    Label5.Text = "Exception: " + ex.ToString();
                }
                conexion.Close();
            }
        }

        protected void Button5_Click(object sender, EventArgs e)
        {
            Response.Redirect("EdicionUsuario.aspx");
        }
    }
}