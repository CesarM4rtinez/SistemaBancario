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
    public class N_Empleado
    {
        public static DataTable ListadoEmpleadoGeneral(string cTexto)
        {
            D_Empleado Datos = new D_Empleado();
            return Datos.ListadoEmpleadoGeneral(cTexto);
        }

        public static string Guardar_empleado(int nOpcion, E_Empleado oCl)
        {
            D_Empleado Datos = new D_Empleado(); ;
            return Datos.GuardarEmpleado(nOpcion, oCl);
        }

        public static string Eliminar_empleado(int Codigo_cl)
        {
            D_Empleado Datos = new D_Empleado();
            return Datos.EliminarEmpleado(Codigo_cl);
        }

        public static DataTable empleadoCargo()
        {
            D_Empleado Datos = new D_Empleado();
            return Datos.empleadoCargo();
        }

        public static DataTable empleadoUsuario()
        {
            D_Empleado Datos = new D_Empleado();
            return Datos.empleadoUsuario();
        }

        public static DataTable empleadoSucursal()
        {
            D_Empleado Datos = new D_Empleado();
            return Datos.empleadoSucursal();
        }

        public static DataTable Listado_EmpleadosCaidos(string cTexto)
        {
            D_Empleado Datos = new D_Empleado();
            return Datos.Listado_EmpleadosCaidos(cTexto);
        }

        public static string Levantar_empleadoCaido(int ID_EM)
        {
            D_Empleado Datos = new D_Empleado();
            return Datos.Levantar_empleadoCaido(ID_EM);
        }
    }
}