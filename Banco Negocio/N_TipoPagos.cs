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
    public class N_TipoPagos
    {
        public static DataTable Listado_tipoPago(string cTexto)
        {
            D_TipoPagos Datos = new D_TipoPagos();
            return Datos.Listado_tipoPago(cTexto);
        }
        
        public static DataTable Listado_tipoPagoCaido(string cTexto)
        {
            D_TipoPagos Datos = new D_TipoPagos();
            return Datos.Listado_tipoPagoCaido(cTexto);
        }
        public static string Guardar_tipoPago(int nOpcion, E_TipoPagos oCl)
        {
            D_TipoPagos Datos = new D_TipoPagos();
            return Datos.Guardar_tipoPago(nOpcion, oCl);
        }

        public static string Eliminar_tipoPago(int ID_DIM_TP_PAGO)
        {
            D_TipoPagos Datos = new D_TipoPagos();
            return Datos.Eliminar_tipoPago(ID_DIM_TP_PAGO);
        }
        
        public static string Levantar_tipoPagoCaido(int ID_DIM_TP_PAGO)
        {
            D_TipoPagos Datos = new D_TipoPagos();
            return Datos.Levantar_tipoPagoCaido(ID_DIM_TP_PAGO);
        }
    }
}
