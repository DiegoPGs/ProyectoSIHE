using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.Odbc;

namespace Tienda012020
{
    public partial class RegistroUsuario : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            String nombre = TextBox1.Text;
            String correo = TextBox2.Text;
            String contrasena = TextBox3.Text;
            String confirmacion = TextBox4.Text;

            if (contrasena == confirmacion)
            {
                //Las contraseñas coinciden, intentar hacer el insert
                //Requiere parametros: correo, passwd y nombre
                String query = "insert into cliente values(?,?,?)";
                OdbcConnection conexion = new ConexionBD().con;
                OdbcCommand comando = new OdbcCommand(query, conexion);
                comando.Parameters.AddWithValue("correo", correo);
                comando.Parameters.AddWithValue("passwd", contrasena);
                comando.Parameters.AddWithValue("nombre", nombre);
                try
                {
                    comando.ExecuteNonQuery();
                    Label1.Text = "Cuenta creada";
                    Button1.Enabled = false;
                }
                catch (Exception ex)
                {
                    Label1.Text = "El correo ya existe";
                }
                conexion.Close();
            }
            else
            {
                Label1.Text = "La confirmación no coincide con la contraseña";
            }
        }
    }
}