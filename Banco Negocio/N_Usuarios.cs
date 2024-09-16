using Banco.Datos;
using Banco.Entidades;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Banco.Negocio
{
    public class N_Usuarios
    {
        public static DataTable Listado_us(string cTexto)
        {
            D_Usuarios Datos = new D_Usuarios();
            return Datos.Listado_us();
        }
        
        public static DataTable Listado_tipoUsuarioCaido(string cTexto)
        {
            D_Usuarios Datos = new D_Usuarios();
            return Datos.Listado_tipoUsuarioCaido();
        }

        public static string Guardar_us(int nOpcion, E_Usuarios oUs)
        {
            D_Usuarios Datos = new D_Usuarios();
            return Datos.Guardar_us(nOpcion, oUs);
        }
        
        public static string Eliminar_us(int Codigo_us)
        {
            D_Usuarios Datos = new D_Usuarios();
            return Datos.Eliminar_us(Codigo_us);
        }

        
        public static string Levantar_UsuarioCaido(int Codigo_us)
        {
            D_Usuarios Datos = new D_Usuarios();
            return Datos.Levantar_UsuarioCaido(Codigo_us);
        }

        public static DataTable Login_us(string USUARIO, string CONTRASEÑA)
        {
            D_Usuarios Datos = new D_Usuarios();
            return Datos.Login_us(USUARIO, CONTRASEÑA);
        }
    }
}