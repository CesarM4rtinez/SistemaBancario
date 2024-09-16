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
    public class N_TipoTarjetas
    {
        public static DataTable Listado_tp_tj(string cTexto)
        {
            D_TipoTarjetas Datos = new D_TipoTarjetas();
            return Datos.Listado_tp_tj(cTexto);
        }
        
        public static DataTable Listado_tipoTarjetaCaida(string cTexto)
        {
            D_TipoTarjetas Datos = new D_TipoTarjetas();
            return Datos.Listado_tipoTarjetaCaida(cTexto);
        }

        public static string Guardar_tp_tj(int nOpcion, E_TipoTarjetas oCl)
        {
            D_TipoTarjetas Datos = new D_TipoTarjetas(); ;
            return Datos.Guardar_tp_tj(nOpcion, oCl);
        }

        public static string Eliminar_tp_tj(int ID_TP_Tarjeta)
        {
            D_TipoTarjetas Datos = new D_TipoTarjetas();
            return Datos.Eliminar_tp_tj(ID_TP_Tarjeta);
        }
        
        public static string Levantar_tipoTarjetaCaida(int ID_TP_Tarjeta)
        {
            D_TipoTarjetas Datos = new D_TipoTarjetas();
            return Datos.Levantar_tipoTarjetaCaida(ID_TP_Tarjeta);
        }
    }
}
