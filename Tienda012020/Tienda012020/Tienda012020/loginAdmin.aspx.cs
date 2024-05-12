using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.Odbc;

namespace Tienda012020
{
    public partial class loginAdmin : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            String query = "select nombre from administrador where correo=? and passwd=?";
            //Validaciones, verificar si el usuario escribio algo y si el correo
            //electronico es valido
            if(TextBox1.Text.Contains("@")==true && TextBox2.Text != "")
            {
                OdbcConnection conexion = new ConexionBD().con;
                OdbcCommand comando = new OdbcCommand(query, conexion);
                //Pasarle los parametros al query
                comando.Parameters.AddWithValue("correo", TextBox1.Text);
                comando.Parameters.AddWithValue("passwd", TextBox2.Text);
                OdbcDataReader lector = comando.ExecuteReader();
                if (lector.HasRows == true)
                {
                    lector.Read();
                    Session["admin"] = lector.GetString(0);
                    //Session["nombreUsuario"] = lector.GetString(0);
                    Response.Redirect("Reportes.aspx");
                }
                else
                {
                    Label1.Text = "Credenciales incorrectas";
                    Session.Abandon();
                }
                conexion.Close();
            }
            else
            {
                Label1.Text = "Credenciales incorrectas";
            }
        }
    }
}