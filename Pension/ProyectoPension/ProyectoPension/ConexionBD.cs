using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
//2.1 importar biblioteca ODBC
using System.Data.Odbc;

namespace ProyectoPension
{
    public class ConexionBD
    {
        //2.2 Declarar propiedad conexion --> con
        public OdbcConnection con { get; set; }

        public ConexionBD()
        {
            //Sacar el connection string del web config!!!
            //2.3 Acceder al webconfig del proyecto
            System.Configuration.Configuration webConfig;
            webConfig = System.Web.Configuration
                .WebConfigurationManager
                .OpenWebConfiguration("/ProyectoPension");
            //2.4 Declarar connectionString y extraerlo del
            //objeto de configuracion
            System.Configuration.ConnectionStringSettings connectionString;
            connectionString = webConfig
                .ConnectionStrings
                .ConnectionStrings["BDPension"];
            //2.5 Crear conexion a la BD, con el connectionString
            con = new OdbcConnection(connectionString.ToString());
            //2.6 Abrir conexion para dejarla lista para la aplicacion
            con.Open();
        }
    }
}