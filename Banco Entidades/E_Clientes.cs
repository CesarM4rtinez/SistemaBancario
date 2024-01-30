using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Banco.Entidades
{
    public class E_Clientes
    {
        public int    ID_CLIENTE        { get; set; }
        public int    ID_TP_PERSONA     { get; set; }
        public string NOM_CLIENTE       { get; set; }
        public string APE_PATE_CLIENTE  { get; set; }
        public string APE_MATE_CLIENTE  { get; set; }
        public string DIRECCION_CLIENTE { get; set; }
        public string TEL_CEL_CLIENTE   { get; set; }
        public string TEL_FIJO_CLIENTE  { get; set; }
        public string DNI               { get; set; }
        public string NOM_CARGO_CLIENTE { get; set; }
        public decimal SUELDO           { get; set; }
    }
}
