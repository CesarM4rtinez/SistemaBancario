using System;
using Banco.Datos;
using Banco.Entidades;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Banco.Negocio
{
    public class N_Clientes
    {
        public static DataTable Listado_cl(string cTexto)
        {
            D_Clientes Datos = new D_Clientes();
            return Datos.Listado_cl(cTexto);
        }
        
        public static DataTable Listado_ClientesCaidos(string cTexto)
        {
            D_Clientes Datos = new D_Clientes();
            return Datos.Listado_ClientesCaidos(cTexto);
        }

        public static string Guardar_cl(int nOpcion, E_Clientes oCl)
        {
            D_Clientes Datos = new D_Clientes(); ;
            return Datos.Guardar_cl(nOpcion, oCl);
        }

        public static string Eliminar_cl(int ID_CLIENTE)
        {
            D_Clientes Datos = new D_Clientes();
            return Datos.Eliminar_cl(ID_CLIENTE);
        }
        
        public static string Levantar_clienteCaido(int ID_CLIENTE)
        {
            D_Clientes Datos = new D_Clientes();
            return Datos.Levantar_cliente(ID_CLIENTE);
        }

        public static DataTable TIPO_PERSONA()
        {
            D_Clientes Datos = new D_Clientes();
            return Datos.TIPO_PERSONA();
        }
    }
}
