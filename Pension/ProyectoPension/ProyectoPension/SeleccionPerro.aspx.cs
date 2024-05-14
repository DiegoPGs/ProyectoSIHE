using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.Odbc;

namespace ProyectoPension
{
    public partial class SeleccionPerro : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (DropDownList1.Items.Count == 0)
            {
                String query = "select cPerro, nombre from perro";
                OdbcConnection conexion = new ConexionBD().con;
                OdbcCommand comando = new OdbcCommand(query, conexion);
                OdbcDataReader lector = comando.ExecuteReader();
                DropDownList1.DataSource = lector;
                DropDownList1.DataValueField = "cPerro";
                DropDownList1.DataTextField = "nombre";
                DropDownList1.DataBind();
                conexion.Close();
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            String cPerro = DropDownList1.SelectedValue.ToString();

            Response.Redirect("DatosPerro.aspx?cPerro=" + cPerro);

        }
    }
}