using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Banco.Entidades
{
    public class E_Cuentas
    {
        public int    ID_CUENTA      { get; set; }
        public int    ID_TIPO_CUENTA { get; set; }
        public int    ID_CLIENTE     { get; set; }
        public decimal SALDO_ACTUAL   { get; set; }
    }
}
