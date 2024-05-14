using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.Odbc;

namespace ProyectoPension
{
    public partial class login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            /*
            //Prueba base de datos
            //Abrir conexion utilizando la clase ConexionBD
            OdbcConnection conexion = new ConexionBD().con;

            String query = "select * from dueno";
            //Crear comando de base de datos
            OdbcCommand comando = new OdbcCommand(query, conexion);
            //Ejecutar el comando y recibirlo en un lector
            //Siempre uso lector cuando ejecuto un select
            OdbcDataReader lector = comando.ExecuteReader();
            //Pasarle los datos al gridview
            GridView1.DataSource = lector;
            //Ligar los datos al gridview
            GridView1.DataBind();*/

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            String correo = TextBox1.Text;
            String password = TextBox2.Text;

            String query = "select cDueno from dueno where correo=? and password=?";
            try
            {
                OdbcConnection conexion = new ConexionBD().con;
                OdbcCommand comando = new OdbcCommand(query, conexion);
                //Sustituye el primer signo de interrogacion
                comando.Parameters.AddWithValue("paramCorreo", correo);
                //Sustituye el primer signo de interrogacion
                comando.Parameters.AddWithValue("paramPassword", password);
                Int32 claveDueno = (Int32)comando.ExecuteScalar();

                conexion.Close();
                //Limpiar y reiniciar la sesion
                Session.Clear();
                //Session.Abandon();
                Session.Timeout = 15;
                Session.Add("claveUsuario", claveDueno);
                Response.Redirect("RegistroEstancia.aspx");
            }
            catch(Exception ex)
            {
                Response.Write("Credenciales incorrectas");
                TextBox1.Text = "";
                TextBox2.Text = "";
            }
        }
    }
}