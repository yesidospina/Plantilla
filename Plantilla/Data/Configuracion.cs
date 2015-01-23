using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Configuration;


namespace Data
{
    public class Configuracion
    {
        //cadena de conexion
        static string cadenaConexion = @"Data Source=YESID-PC\SQLEXPRESS;Initial Catalog=BD_INFOANALISIS;User ID=yesidospina;Password=yesidospina";
        //static string cadenaConexion = @"Data Source=LANALIDESA50002;Initial Catalog=BD_INFOANALISIS;User ID=administrador;Password=Agros890";
        //static string cadenaConexion = @"Data Source=YESID-PC\SQLEXPRESS;Initial Catalog=BD_INFOANALISIS;User ID=administrador;Password=Agros890";
        
        

        public static string CadenaConexion
        {
            get { return cadenaConexion; }
        }
    }
}
