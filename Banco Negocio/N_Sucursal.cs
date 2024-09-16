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
    public class N_Sucursal
    {
        public static DataTable Listado_suc(string cTexto)
        {
            D_Sucursal Datos = new D_Sucursal();
            return Datos.Listado_suc(cTexto);
        }
        
        public static DataTable Listado_sucursalesCaidas(string cTexto)
        {
            D_Sucursal Datos = new D_Sucursal();
            return Datos.Listado_sucursalesCaidas(cTexto);
        }
        public static string Guardar_suc(int nOpcion, E_Sucursal oCl)
        {
            D_Sucursal Datos = new D_Sucursal(); 
            return Datos.Guardar_suc(nOpcion, oCl);
        }

        public static string Eliminar_suc(int ID_SUCURSAL)
        {
            D_Sucursal Datos = new D_Sucursal();
            return Datos.Eliminar_suc(ID_SUCURSAL);
        }
        public static string Levantar_sucursalCaida(int ID_SUCURSAL)
        {
            D_Sucursal Datos = new D_Sucursal();
            return Datos.Levantar_sucursalCaida(ID_SUCURSAL);
        }
    }
}
