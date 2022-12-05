using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gimnasio
{
    class pago
    {
        private DateTime fechaPago;
        private int dniSocio;
        private int precio;

        public DateTime FechaPago { get => fechaPago; set => fechaPago = value; }
        public int DniSocio { get => dniSocio; set => dniSocio = value; }
        public int Precio { get => precio; set => precio = value; }
    }
}
