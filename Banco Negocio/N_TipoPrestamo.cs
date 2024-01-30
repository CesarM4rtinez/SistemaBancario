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
    public class N_TipoPrestamo
    {
        public static DataTable Listado_tipoPrestamo(string cTexto)
        {
            D_TipoPrestamo Datos = new D_TipoPrestamo();
            return Datos.Listado_tipoPrestamo(cTexto);
        }
        
        public static DataTable Listado_tipoPrestamoCaido(string cTexto)
        {
            D_TipoPrestamo Datos = new D_TipoPrestamo();
            return Datos.Listado_tipoPrestamoCaido(cTexto);
        }

        public static string Guardar_tipoPrestamo(int nOpcion, E_TipoPrestamo oCl)
        {
            D_TipoPrestamo Datos = new D_TipoPrestamo(); ;
            return Datos.Guardar_tipoPrestamo(nOpcion, oCl);
        }

        public static string Eliminar_tipoPrestamo(int ID_TP_PRESTAMO)
        {
            D_TipoPrestamo Datos = new D_TipoPrestamo();
            return Datos.Eliminar_tipoPrestamo(ID_TP_PRESTAMO);
        }
        
        public static string Levantar_tipoPrestamoCaido(int ID_TP_PRESTAMO)
        {
            D_TipoPrestamo Datos = new D_TipoPrestamo();
            return Datos.Levantar_tipoPrestamoCaido(ID_TP_PRESTAMO);
        }
    }
}
