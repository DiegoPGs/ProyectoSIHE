using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.Odbc;

namespace ProyectoPension
{
    public partial class DatosPerro : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            String cPerro=Request.Params.Get("cPerro").ToString();
            Response.Write("la clave del perro " + cPerro);
            String query = "select cPerro,nombre,edad,cRaza,cDueno from perro where cPerro=?";
            OdbcConnection conexion = new ConexionBD().con;
            OdbcCommand comando = new OdbcCommand(query, conexion);
            comando.Parameters.AddWithValue("cPerro", cPerro);
            OdbcDataReader lector = comando.ExecuteReader();
            lector.Read();
            Label1.Text = lector.GetString(1);
            Label2.Text = lector.GetInt32(2).ToString();
            Label3.Text = lector.GetInt32(3).ToString();
            Label4.Text = lector.GetInt32(4).ToString();
            conexion.Close();
        }
    }
}