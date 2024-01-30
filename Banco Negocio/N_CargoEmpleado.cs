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
    public class N_CargoEmpleado
    {
        public static DataTable ListadoCargoEmpleado(string cTexto)
        {
            D_CargoEmpleado Datos = new D_CargoEmpleado();
            return Datos.ListadoCargoEmpleado(cTexto);
        }

        public static DataTable Listado_CargoCaido(string cTexto)
        {
            D_CargoEmpleado Datos = new D_CargoEmpleado();
            return Datos.Listado_CargoCaido(cTexto);
        }

        public static string GuardarCargoEmpleado(int nOpcion, E_CargoEmpleado oCl)
        {
            D_CargoEmpleado Datos = new D_CargoEmpleado(); ;
            return Datos.GuardarCargoEmpleado(nOpcion, oCl);
        }

        public static string EliminarCargoEmpleado(int ID_CARGO)
        {
            D_CargoEmpleado Datos = new D_CargoEmpleado();
            return Datos.EliminarCargoEmpleado(ID_CARGO);
        }

        public static string Levantar_cargoCaido(int ID_CARGO)
        {
            D_CargoEmpleado Datos = new D_CargoEmpleado();
            return Datos.Levantar_cargoCaido(ID_CARGO);
        }
    }
}
