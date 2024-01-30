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
    public class N_MovimientoTarjeta
    {
        public static DataTable ListadoMV_tarjetaGeneral(string cTexto)
        {
            D_MovimientoTarjeta Datos = new D_MovimientoTarjeta();
            return Datos.ListadoMV_tarjetaGenerales(cTexto);
        }
        
        public static DataTable Listado_MVtarjetasCaidas(string cTexto)
        {
            D_MovimientoTarjeta Datos = new D_MovimientoTarjeta();
            return Datos.Listado_MVtarjetasCaidas(cTexto);
        }
        
        public static DataTable Listado_ClientesPrincipales(string cTexto)
        {
            D_MovimientoTarjeta Datos = new D_MovimientoTarjeta();
            return Datos.Listado_ClientesPrincipales(cTexto);
        }

        public static string Guardar_MV_tarjeta(int nOpcion, E_MovimientoTarjeta oCl)
        {
            D_MovimientoTarjeta Datos = new D_MovimientoTarjeta(); ;
            return Datos.GuardarMV_tarjeta(nOpcion, oCl);
        }

        public static string Eliminar_MV_tarjeta(int Codigo_cl)
        {
            D_MovimientoTarjeta Datos = new D_MovimientoTarjeta();
            return Datos.EliminarMV_tarjeta(Codigo_cl);
        }
        
        public static string Levantar_MVtarjetasCaidas(int Codigo_cl)
        {
            D_MovimientoTarjeta Datos = new D_MovimientoTarjeta();
            return Datos.Levantar_MVtarjetasCaidas(Codigo_cl);
        }

        public static DataTable MV_tarjetaTarjeta()
        {
            D_MovimientoTarjeta Datos = new D_MovimientoTarjeta();
            return Datos.MV_tarjetaTarjeta();
        }

        public static DataTable MV_tarjetaCliente()
        {
            D_MovimientoTarjeta Datos = new D_MovimientoTarjeta();
            return Datos.MV_tarjetaCliente();
        }

        public static DataTable MV_tarjetaEmpleado()
        {
            D_MovimientoTarjeta Datos = new D_MovimientoTarjeta();
            return Datos.MV_tarjetaEmpleado();
        }

        public static DataTable MV_tarjetaSucursal()
        {
            D_MovimientoTarjeta Datos = new D_MovimientoTarjeta();
            return Datos.MV_tarjetaSucursal();
        }
    }
}
