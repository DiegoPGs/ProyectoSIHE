using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.Odbc;

namespace ProyectoPension
{
    public partial class ReportePerroDueno : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (DropDownList1.Items.Count == 0 && DropDownList2.Items.Count == 0)
            {
                //Cargar en dropdowns dato de raza y datos de dueño
                String queryDueno = "select cDueno,nombre from dueno";
                String queryRaza = "select cRaza,nombre from raza";
                //Abrir conexion
                OdbcConnection conexionRaza = new ConexionBD().con;
                OdbcConnection conexionDueno = new ConexionBD().con;
                //Crear comandos
                OdbcCommand comandoDueno = new OdbcCommand(queryDueno, conexionRaza);
                OdbcCommand comandoRaza = new OdbcCommand(queryRaza, conexionDueno);
                //Ejecutar comandos
                OdbcDataReader lectorDueno = comandoDueno.ExecuteReader();
                OdbcDataReader lectorRaza = comandoRaza.ExecuteReader();
                //Cargar datos a los dropdowns
                DropDownList1.DataSource = lectorDueno;
                DropDownList1.DataValueField = "cDueno";
                DropDownList1.DataTextField = "nombre";
                DropDownList1.DataBind();

                DropDownList2.DataSource = lectorRaza;
                DropDownList2.DataValueField = "cRaza";
                DropDownList2.DataTextField = "nombre";
                DropDownList2.DataBind();
                //Cerrar conexion
                conexionRaza.Close();
                conexionDueno.Close();
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            //Ejecutar el select para cargar los datos en el gridview
            String query = "select dueno.nombre,dueno.correo,dueno.direccion,perro.nombre,perro.edad,raza.nombre ";
            String from = "from dueno,perro,raza ";
            String where = "where dueno.cDueno = perro.cDueno and perro.cRaza = raza.cRaza "+
                "and dueno.cDueno=? and raza.cRaza=?";
            //Estrategia para probar el select
            Response.Write(query + from + where);
            //Abrir conexion
            OdbcConnection conexion = new ConexionBD().con;
            //Crear comando
            OdbcCommand comando = new OdbcCommand(query + from + where, conexion);
            comando.Parameters.AddWithValue("cDueno", DropDownList1.SelectedValue);
            comando.Parameters.AddWithValue("cRaza", DropDownList2.SelectedValue);
            //Ejecutar el comando en un datareader
            OdbcDataReader lector = comando.ExecuteReader();
            //Cargar datos al gridview
            GridView1.DataSource = lector;
            GridView1.DataBind();
            //Si no hay datos, aviso al usuario
            if (lector.HasRows == false)
            {
                Label1.Text = "Tu consulta no generó resultados";
            }
            else
            {
                Label1.Text = "";
            }  
            //Cerrar conexion
            conexion.Close();
        }
    }
}