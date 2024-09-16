using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Banco.Entidades
{
    public class E_Usuarios
    {
        public int    ID_USER    { get; set; }
        public string USUARIO    { get; set; }
        public string CONTRASEÑA { get; set; }

        public bool   ADMIN      { get; set; }
        public bool   PRESTAMOS  { get; set; }

        public bool   CUENTAS    { get; set; }
        public bool   TARJETAS   { get; set; }
    }
}
