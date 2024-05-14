using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.Odbc;

namespace ProyectoPension
{
    public partial class ReporteFlexible : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (CheckBoxList1.Items.Count == 0)
            {
                CheckBoxList1.Items.Add(new ListItem("Nombre del dueño", "dueno.nombre"));
                CheckBoxList1.Items.Add(new ListItem("Correo del dueño", "dueno.correo"));
                CheckBoxList1.Items.Add(new ListItem("Direccion del dueño", "dueno.direccion"));
                CheckBoxList1.Items.Add(new ListItem("Nombre del perro", "perro.nombre"));
                CheckBoxList1.Items.Add(new ListItem("Edad del perro", "perro.edad"));
                CheckBoxList1.Items.Add(new ListItem("Raza del perro", "raza.nombre"));
            }

            if(DropDownList1.Items.Count==0)
            {
                String queryDueno = "select cDueno,nombre from dueno";
                OdbcConnection conexionDueno = new ConexionBD().con;
                OdbcCommand comandoDueno = new OdbcCommand(queryDueno, conexionDueno);
                OdbcDataReader lectorDueno = comandoDueno.ExecuteReader();
                //Cargar datos a los dropdowns
                DropDownList1.DataSource = lectorDueno;
                DropDownList1.DataValueField = "cDueno";
                DropDownList1.DataTextField = "nombre";
                DropDownList1.DataBind();
                conexionDueno.Close();
            }

            if (DropDownList2.Items.Count == 0)
            {
                String queryRaza = "select cRaza,nombre from raza";
                OdbcConnection conexionRaza = new ConexionBD().con;
                OdbcCommand comandoRaza = new OdbcCommand(queryRaza, conexionRaza);
                OdbcDataReader lectorRaza = comandoRaza.ExecuteReader();
                //Cargar datos a los dropdowns
                DropDownList2.DataSource = lectorRaza;
                DropDownList2.DataValueField = "cRaza";
                DropDownList2.DataTextField = "nombre";
                DropDownList2.DataBind();
                conexionRaza.Close();
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            //Ejecutar el select para cargar los datos en el gridview
            String query = "select ";// dueno.nombre,dueno.correo,dueno.direccion,perro.nombre,perro.edad,raza.nombre ";
            String from = "from dueno,perro,raza ";
            String where = "where dueno.cDueno = perro.cDueno and perro.cRaza = raza.cRaza ";
                //"and dueno.cDueno=? and raza.cRaza=?";
            //Formar el select del reporte flexible
            for(int i = 0; i < CheckBoxList1.Items.Count; i++)
            {
                if (CheckBoxList1.Items[i].Selected == true)
                {
                    query = query + CheckBoxList1.Items[i].Value.ToString() + ",";
                }
            }
            query = query.TrimEnd(',');
            query = query + " ";
            if (CheckBox1.Checked == true)
            {
                //Sacar el parametro del dropdown y pegarlo al where
                where = where + " and dueno.cDueno=? "; 
            }
            if (CheckBox2.Checked == true)
            {
                where = where + " and raza.cRaza=? ";
            }
            //Estrategia para probar el select
            //Response.Write(query + from + where);
            //Abrir conexion
            OdbcConnection conexion = new ConexionBD().con;
            //Crear comando
            OdbcCommand comando = new OdbcCommand(query + from + where, conexion);
            if (CheckBox1.Checked == true)
            {
                //Solo puedo poner parametros despues de crear el comando
                comando.Parameters.AddWithValue("cDueno", DropDownList1.SelectedValue);
            }
            if (CheckBox2.Checked == true)
            {
                comando.Parameters.AddWithValue("cRaza", DropDownList2.SelectedValue);
            }
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

        protected void Button2_Click(object sender, EventArgs e)
        {
            //Ejecutar el select para cargar los datos en el gridview
            String query = "select ";// dueno.nombre,dueno.correo,dueno.direccion,perro.nombre,perro.edad,raza.nombre ";
            String from = "from dueno,perro,raza ";
            String where = "where dueno.cDueno = perro.cDueno and perro.cRaza = raza.cRaza ";
            //"and dueno.cDueno=? and raza.cRaza=?";
            //Formar el select del reporte flexible
            for (int i = 0; i < CheckBoxList1.Items.Count; i++)
            {
                if (CheckBoxList1.Items[i].Selected == true)
                {
                    query = query + CheckBoxList1.Items[i].Value.ToString() + ",";
                }
            }
            query = query.TrimEnd(',');
            query = query + " ";
            if (CheckBox1.Checked == true)
            {
                //Sacar el parametro del dropdown y pegarlo al where
                where = where + " and dueno.cDueno=? ";
            }
            if (CheckBox2.Checked == true)
            {
                where = where + " and raza.cRaza=? ";
            }
            //Estrategia para probar el select
            //Response.Write(query + from + where);
            //Abrir conexion
            OdbcConnection conexion = new ConexionBD().con;
            //Crear comando
            OdbcCommand comando = new OdbcCommand(query + from + where, conexion);
            if (CheckBox1.Checked == true)
            {
                //Solo puedo poner parametros despues de crear el comando
                comando.Parameters.AddWithValue("cDueno", DropDownList1.SelectedValue);
            }
            if (CheckBox2.Checked == true)
            {
                comando.Parameters.AddWithValue("cRaza", DropDownList2.SelectedValue);
            }
            //Ejecutar el comando en un datareader
            OdbcDataReader lector = comando.ExecuteReader();

            //Generar mi propia tabla
            //Como navegar un lector?
            String tabla = "";
            tabla=tabla+"<table border=1>";
            while (lector.Read()) //Lector read, lee un renglo de la tabla
            {
                tabla = tabla + "<tr>";
                for (int i = 0; i < lector.FieldCount; i++)
                {
                    tabla = tabla + "<td>";
                    tabla = tabla + lector.GetValue(i).ToString();
                    tabla = tabla + "</td>";
                }
                tabla = tabla + "</tr>";
            }
            tabla = tabla + "</table>";
            Label1.Text = tabla;
            conexion.Close();
        }
    }
}