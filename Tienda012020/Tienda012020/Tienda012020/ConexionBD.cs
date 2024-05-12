using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
//Siempre debe de importarse
using System.Data.Odbc;

namespace Tienda012020 //<-- debe ser el nombre del proyecto
{
    //nunca se declaran atributos en esta parte!!!
    public class ConexionBD
    {
        //Aqui van los atributos de la clase
        public OdbcConnection con { get; set; }

        public ConexionBD()
        {
            //Abrir el web config para sacar el string de conexion
            System.Configuration.Configuration webConfig; 
            webConfig = System.Web.Configuration
                .WebConfigurationManager
                .OpenWebConfiguration("/Tienda012020"); //<-- hay que decirle donde se encuentra el web.config
            //Sacar el string de conexion del web config
            System.Configuration.ConnectionStringSettings connectionString;
            connectionString = webConfig
                .ConnectionStrings
                .ConnectionStrings["BDTienda"]; //<-- nombre del string de conexion
            con = new OdbcConnection(connectionString.ToString());
            con.Open();
        }
    }
}