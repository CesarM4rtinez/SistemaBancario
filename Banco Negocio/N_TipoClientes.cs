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
    public class N_TipoClientes
    {
        public static DataTable Listado_tp_cl(string cTexto)
        {
            D_TipoClientes Datos = new D_TipoClientes();
            return Datos.Listado_tp_cl(cTexto);
        }

        public static DataTable Listado_tipoClienteCaido(string cTexto)
        {
            D_TipoClientes Datos = new D_TipoClientes();
            return Datos.Listado_tipoClienteCaido(cTexto);
        }

        public static string Guardar_tp_cl(int nOpcion, E_TipoClientes oCl)
        {
            D_TipoClientes Datos = new D_TipoClientes(); ;
            return Datos.Guardar_tp_cl(nOpcion, oCl);
        }
        
        public static string Eliminar_tp_cl(int ID_TP_PERSONA)
        {
            D_TipoClientes Datos = new D_TipoClientes();
            return Datos.Eliminar_tp_cl(ID_TP_PERSONA);
        }

        public static string Levantar_tipoClienteCaido(int ID_TP_PERSONA)
        {
            D_TipoClientes Datos = new D_TipoClientes();
            return Datos.Levantar_tipoClienteCaido(ID_TP_PERSONA);
        }
    }
}
