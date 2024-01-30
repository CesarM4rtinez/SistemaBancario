using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Banco.Entidades
{
    public class E_MovimientoTarjeta
    {
        public int ID_MV_TARJETA        { get; set; }
        public int ID_TARJETA_CREDITO   { get; set; }
        public int ID_CLIENTE           { get; set; }
        public int ID_EM                { get; set; }
        public int ID_SUCURSAL          { get; set; }
        public decimal MONTO_SALIDA     { get; set; }
    }
}
