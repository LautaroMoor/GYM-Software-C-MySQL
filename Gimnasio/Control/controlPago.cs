using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gimnasio
{
    class controlPago
    {
        public string ctrlRegistroPagos(pago Pago)
        {
            modeloPago modelo = new modeloPago();
            string rta = "";
            if ((string.IsNullOrEmpty(Pago.FechaPago.ToString())) ||
                (string.IsNullOrEmpty(Pago.DniSocio.ToString())) ||
                (string.IsNullOrEmpty(Pago.Precio.ToString())))
                rta = "Llene todos los campos de texto para registrar el pago!";
            else
            {
                if (modelo.existePago(Pago))
                    rta = "¡La persona con el DNI " + Pago.DniSocio + " ya pago ese mes en ese año";
                else
                {
                    modelo.registrarPago(Pago);
                    rta = "¡Pago con exito!";
                }
            }
            return rta;
        }
    }
}
