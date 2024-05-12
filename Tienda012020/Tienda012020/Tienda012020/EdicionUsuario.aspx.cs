using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.Odbc;

namespace Tienda012020
{
    public partial class EdicionUsuario : System.Web.UI.Page
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
            //Si ya hay algo en los textboxes, no cargarlos, solo si están vacios
            //Me había equivocado aquí con un != en vez de un ==
            //Ya esta resuelto
            if (TextBox1.Text == "")
            {
                String query = "select * from cliente where correo=?";
                OdbcConnection conexion = new ConexionBD().con;
                OdbcCommand comando = new OdbcCommand(query, conexion);
                //pasarle el parametro al query
                comando.Parameters.AddWithValue("correo", Session["correoUsuario"].ToString());
                OdbcDataReader lector = comando.ExecuteReader();
                if (lector.HasRows == true)
                {
                    //avanzar al lector al primer renglon, si no, no me deja leer
                    lector.Read();
                    //Sacar los datos de acuerdo al orden en la base de datos
                    //0: correo,1: passwd,2: nombre <-- indices de las columnas
                    Label1.Text = lector.GetString(0);  //correo
                    TextBox1.Text = lector.GetString(2);//nombre
                    TextBox2.Text = lector.GetString(1);//password
                    TextBox3.Text = lector.GetString(1);//confirmacion del password
                }
                else
                {
                    Label2.Text = "Error al cargar tu información";
                }
                conexion.Close();
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            if (TextBox2.Text == TextBox3.Text)
            {
                String query = "update cliente set nombre=?,passwd=? where correo=?";
                OdbcConnection conexion = new ConexionBD().con;
                OdbcCommand comando = new OdbcCommand(query, conexion);
                //Pasarle los parametros al comando
                comando.Parameters.AddWithValue("nombre", TextBox1.Text);
                comando.Parameters.AddWithValue("passwd", TextBox2.Text);
                comando.Parameters.AddWithValue("correo", Session["correoUsuario"].ToString());
                //Ejecutar el nonquery
                try
                {
                    comando.ExecuteNonQuery();
                    Label2.Text = "Se actualizaron tus datos ";
                }
                catch(Exception ex)
                {
                    Label2.Text = "Problema para actualizar los datos " + ex.ToString();
                }
                conexion.Close();
            }
            else
            {
                Label2.Text = "La contraseña y la confirmación no coinciden";
            }
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            Response.Redirect("Tienda.aspx");
        }
    }
}