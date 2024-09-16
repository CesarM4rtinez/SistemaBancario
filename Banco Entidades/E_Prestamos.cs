using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Banco.Entidades
{
    public class E_Prestamos
    {
        public int    ID_PRESTAMO        { get; set; }
        public int    ID_CLIENTE         { get; set; }
        public int    ID_CUENTA          { get; set; }
        public int    ID_TARJETA_CREDITO { get; set; }
        public int    ID_TP_PRESTAMO     { get; set; }
        public int    ID_DIM_TP_PAGO     { get; set; }
        public decimal MONTO_PRESTADO    { get; set; }
    }
}
