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
    public class N_MovimientoAbono
    {
        public static DataTable ListadoMV_abonoGeneral(string cTexto)
        {
            D_MovimientoAbono Datos = new D_MovimientoAbono();
            return Datos.ListadoMV_abonoGenerales(cTexto);
        }
        
        public static DataTable Listado_AbonosCaidos(string cTexto)
        {
            D_MovimientoAbono Datos = new D_MovimientoAbono();
            return Datos.Listado_AbonosCaidos(cTexto);
        }
        
        public static DataTable Listado_ClientesPrincipales(string cTexto)
        {
            D_MovimientoAbono Datos = new D_MovimientoAbono();
            return Datos.Listado_ClientesPrincipales(cTexto);
        }

        public static string Guardar_MV_abono(int nOpcion, E_MovimientoAbono oCl)
        {
            D_MovimientoAbono Datos = new D_MovimientoAbono(); ;
            return Datos.GuardarMV_abono(nOpcion, oCl);
        }

        public static string Eliminar_MV_abono(int ID_MV_ABONO)
        {
            D_MovimientoAbono Datos = new D_MovimientoAbono();
            return Datos.EliminarMV_abono(ID_MV_ABONO);
        }
        
        public static string Levantar_abonosCaidos(int Codigo_cl)
        {
            D_MovimientoAbono Datos = new D_MovimientoAbono();
            return Datos.Levantar_abonosCaidos(Codigo_cl);
        }

        public static DataTable MV_abonoCuenta()
        {
            D_MovimientoAbono Datos = new D_MovimientoAbono();
            return Datos.MV_abonoCuenta();
        }

        public static DataTable MV_abonoPrestamo()
        {
            D_MovimientoAbono Datos = new D_MovimientoAbono();
            return Datos.MV_abonoPrestamo();
        }

        public static DataTable MV_abonoCliente()
        {
            D_MovimientoAbono Datos = new D_MovimientoAbono();
            return Datos.MV_abonoCliente();
        }

        public static DataTable MV_abonoEmpleado()
        {
            D_MovimientoAbono Datos = new D_MovimientoAbono();
            return Datos.MV_abonoEmpleado();
        }

        public static DataTable MV_abonoSucursal()
        {
            D_MovimientoAbono Datos = new D_MovimientoAbono();
            return Datos.MV_abonoSucursal();
        }
    }
}
