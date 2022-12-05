using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gimnasio
{
    class controlSocio
    {
        public string ctrlRegistroSocios(socio socioo)
        {
            modeloSocio modelo = new modeloSocio();
            string rta = "";
            if ((string.IsNullOrEmpty(socioo.DNI1.ToString())) ||
                (string.IsNullOrEmpty(socioo.Nombre)) ||
                (string.IsNullOrEmpty(socioo.Apellido)) ||
                (string.IsNullOrEmpty(socioo.Domicilio)) ||
                (string.IsNullOrEmpty(socioo.Cp.ToString())) ||
                (string.IsNullOrEmpty(socioo.Fecha.ToString())) ||
                (string.IsNullOrEmpty(socioo.Telefono.ToString())) ||
                (string.IsNullOrEmpty(socioo.Email)) ||
                (string.IsNullOrEmpty(socioo.Activo.ToString())) ||
                (string.IsNullOrEmpty(socioo.VieneVeces.ToString())) ||
                (string.IsNullOrEmpty(socioo.Lesionado.ToString())) ||
                (string.IsNullOrEmpty(socioo.Lesiones)))
                rta = "Llene todos los campos de texto para registrar!";
            else
            {
                    if (modelo.existeSocio(socioo))
                        rta = "¡La persona con el DNI " + socioo.DNI1 + " ya esta registrada!";
                    else
                    {
                        modelo.registrarSocio(socioo);
                        rta = "¡Registro con exito!";
                    }
            }
            return rta;
        }
        public string ctrlEliminarSocios(socio socioo)
        {
            modeloSocio modelo = new modeloSocio();
            string rta = "";
            if (string.IsNullOrEmpty(socioo.DNI1.ToString())) 
                rta = "Ponga DNI";
            else
            {
                if (modelo.existeSocio(socioo))
                {
                    modelo.eliminarSocio(socioo);
                    rta = "¡Eliminacion exitosa!";
                }

                else
                    rta = "¡La persona con el DNI " + socioo.DNI1 + " no existe!";
            }
            return rta;
        }
        public string ctrlModificarSocios(socio socioo)
        {
            modeloSocio modelo = new modeloSocio();
            string rta = "";
            if ((string.IsNullOrEmpty(socioo.DNI1.ToString())) ||
                (string.IsNullOrEmpty(socioo.Nombre)) ||
                (string.IsNullOrEmpty(socioo.Apellido)) ||
                (string.IsNullOrEmpty(socioo.Domicilio)) ||
                (string.IsNullOrEmpty(socioo.Cp.ToString())) ||
                (string.IsNullOrEmpty(socioo.Fecha.ToString())) ||
                (string.IsNullOrEmpty(socioo.Telefono.ToString())) ||
                (string.IsNullOrEmpty(socioo.Email)) ||
                (string.IsNullOrEmpty(socioo.Activo.ToString())) ||
                (string.IsNullOrEmpty(socioo.VieneVeces.ToString())) ||
                (string.IsNullOrEmpty(socioo.Lesionado.ToString())) ||
                (string.IsNullOrEmpty(socioo.Lesiones)))
                rta = "Llene todos los campos de texto para modificar!";
            else
            {
                if (modelo.existeSocio(socioo))
                {
                    modelo.modificarSocio(socioo);
                    rta = "¡Modificacion exitosa!";
                }
                else
                    rta = "¡La persona con el DNI " + socioo.DNI1 + " no esta registrada por lo cual no se pudo modificar!";
            }
            return rta;
        }
        }
}
