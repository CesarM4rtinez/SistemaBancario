using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Banco.Entidades
{
    public class E_Empleado
    {
        public int      ID_EM          { get; set; }
        public int      ID_CARGO_EM    { get; set; }
        public int      ID_USER        { get; set; }
        public int      ID_SUCURSAL    { get; set; }
        public string   NOM_EMPLEADO   { get; set; }
        public string   APE_PATE       { get; set; }
        public string   APE_MATE       { get; set; }
        public string   DIRECCION      { get; set; }
        public string   DNI_EM         { get; set; }
        public decimal  SUELDO         { get; set; }
    }
}
