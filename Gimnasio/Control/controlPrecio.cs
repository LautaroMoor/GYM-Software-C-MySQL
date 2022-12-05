using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gimnasio
{
    class controlPrecio
    {
        public string ctrlModificarPrecios(precio Precio)
        {
            modeloPrecio modelo = new modeloPrecio();
            string rta = "";
            if ((string.IsNullOrEmpty(Precio.Cantidad.ToString())) ||
                (string.IsNullOrEmpty(Precio.Valor.ToString())))
                rta = "Escriba el nuevo valor!";
            else
            {
                modelo.modificarPrecio(Precio);
                rta = "¡Modificacion exitosa!";
            }
            return rta;
        }
    }
}
