using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.Odbc;

namespace ProyectoPension
{
    public partial class RegistroEstancia : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //Validar la sesion
            if(Session["claveUsuario"]==null)
            {
                //la variable de sesion no existe...
                //Redireccionar al usuario al login
                Response.Redirect("login.aspx");
            }
            //Extraer una variable de sesión
            //Response.Write("Clave del usuario: "
            //    +Session["claveUsuario"].ToString());
            String query = "select cPerro,nombre from perro";
            OdbcConnection conexion = new ConexionBD().con;
            OdbcCommand comando = new OdbcCommand(query, conexion);
            OdbcDataReader lector = comando.ExecuteReader();
            //El lector lo usamos para llenar el dropdowlist
            DropDownList1.DataSource = lector;
            //Indicamos que cPerro es el valor relacionado al
            //texto
            DropDownList1.DataValueField = "cPerro";
            //Indicamos que nombre es el texto a mostrar
            DropDownList1.DataTextField = "nombre";
            //Ligamos el lector al dropdownlist
            DropDownList1.DataBind();
            //Cerrar la conexion
            conexion.Close();
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Session.Clear();
            Session.Abandon();
            Response.Redirect("login.aspx");
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            //Registrar la estancia del perro
            //cEstancia,fechaIni,fechaFin,cPerro
            String query = "insert into estancia values(?,?,'"+TextBox2.Text+"',?)";
            String queryLlave = "select * from estancia where cEstancia=?";
            Random r=new Random();
            int cEstancia=1;
            OdbcConnection conexion = new ConexionBD().con;
            OdbcDataReader lector=null;
            while (lector==null || lector.HasRows==true)
            {
                //Verificar que la llave que estoy generando no exista
                cEstancia = r.Next(1000000);
                OdbcCommand comandoLlave = new OdbcCommand(queryLlave, conexion);
                comandoLlave.Parameters.AddWithValue("cEstancia", cEstancia);
                lector = comandoLlave.ExecuteReader();
            }
            //Ya hay una clave de estancia valida en cEstancia

            OdbcCommand comandoInsert = new OdbcCommand(query, conexion);
            comandoInsert.Parameters.AddWithValue("cEstancia", cEstancia);
            comandoInsert.Parameters.AddWithValue("fechaIni", TextBox1.Text);
            //comandoInsert.Parameters.AddWithValue("fechaFin", TextBox2.Text);
            comandoInsert.Parameters.AddWithValue("cPerro", DropDownList1.SelectedValue);
            try
            {
                //ExecuteNonQuery sirve para inserts, updates y deletes
                int resultado = comandoInsert.ExecuteNonQuery();
                Label1.Text = "Se insertó correctamente la estancia " + resultado;
            }
            catch(Exception ex)
            {
                Label1.Text = ex.ToString();
            }
        }
    }
}