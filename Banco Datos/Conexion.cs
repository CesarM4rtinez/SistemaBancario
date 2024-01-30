using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Banco.Datos
{
    public class Conexion
    {
        private string Base;
        private string Servidor;
        private string Usuario;
        private string Clave;
        private bool   Seguridad;
        private static Conexion Con = null;

        /// MODIFICAR CONEXIÓN - Server Name: **** 
        ///                    - Login: *** 
        ///                    - Password: **** 
        /// DE  SQL SERVER  

        private Conexion()
        {
            this.Base      = "SISTEMA_BANCARIO";
            this.Servidor  = "OVI\\PRODUCCION";   /* "NOMBRE ACTUAL DEL PC\\INSTANCIA DE SQL SERVER" */
            this.Usuario   = "sa";
            this.Clave     = "C3$4r2003";
            this.Seguridad = false;
        }

        public SqlConnection CrearConexion()
        {
            SqlConnection Cadena = new SqlConnection();
            try
            {
                Cadena.ConnectionString = "Server=" + this.Servidor + "; Database=" + this.Base + ";";
                if (Seguridad)
                {
                    Cadena.ConnectionString = Cadena.ConnectionString + "Integrated Security = SSPI"; // SSPI = Interfaz de Proveedor de Soporte de Seguridad. Para especificar la autenticación de Windows integrada al SQL Server.
                }
                else
                {
                    Cadena.ConnectionString = Cadena.ConnectionString + "User Id=" + this.Usuario + "; Password=" + this.Clave;
                }
            }
            catch (Exception ex)
            {
                Cadena = null;
                throw ex;
            }
            return Cadena;
        }

        public static Conexion getInstancia()
        {
            if (Con == null)
            {
                Con = new Conexion();
            }
            return Con;
        }
    }
}
