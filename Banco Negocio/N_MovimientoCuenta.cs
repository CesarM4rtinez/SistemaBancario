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
    public class N_MovimientoCuenta
    {
        public static DataTable ListadoMV_cuentaGeneral(string cTexto)
        {
            D_MovimientoCuenta Datos = new D_MovimientoCuenta();
            return Datos.ListadoMV_cuentaGenerales(cTexto);
        }
        
        public static DataTable Listado_MVcuentasCaidas(string cTexto)
        {
            D_MovimientoCuenta Datos = new D_MovimientoCuenta();
            return Datos.Listado_MVcuentasCaidas(cTexto);
        }

        public static DataTable Listado_ClientesPrincipales(string cTexto)
        {
            D_MovimientoCuenta Datos = new D_MovimientoCuenta();
            return Datos.Listado_ClientesPrincipales(cTexto);
        }

        public static string Guardar_MV_cuenta(int nOpcion, E_MovimientoCuenta oCl)
        {
            D_MovimientoCuenta Datos = new D_MovimientoCuenta(); ;
            return Datos.GuardarMV_cuenta(nOpcion, oCl);
        }

        public static string Eliminar_MV_cuenta(int ID_MV_CUENTA)
        {
            D_MovimientoCuenta Datos = new D_MovimientoCuenta();
            return Datos.EliminarMV_cuenta(ID_MV_CUENTA);
        }
        
        public static string Levantar_cuentasCaidas(int ID_MV_CUENTA)
        {
            D_MovimientoCuenta Datos = new D_MovimientoCuenta();
            return Datos.Levantar_cuentasCaidas(ID_MV_CUENTA);
        }

        public static DataTable MV_cuentaCuenta()
        {
            D_MovimientoCuenta Datos = new D_MovimientoCuenta();
            return Datos.MV_cuentaCuenta();
        }

        public static DataTable MV_cuentaCliente()
        {
            D_MovimientoCuenta Datos = new D_MovimientoCuenta();
            return Datos.MV_cuentaCliente();
        }

        public static DataTable MV_cuentaEmpleado()
        {
            D_MovimientoCuenta Datos = new D_MovimientoCuenta();
            return Datos.MV_cuentaEmpleado();
        }

        public static DataTable MV_cuentaSucursal()
        {
            D_MovimientoCuenta Datos = new D_MovimientoCuenta();
            return Datos.MV_cuentaSucursal();
        }
    }
}
