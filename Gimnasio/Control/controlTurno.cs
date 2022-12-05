using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gimnasio
{
    class controlTurno
    {
        public string ctrlRegistroTurnos(turno Turno)
        {
            modeloTurno modelo = new modeloTurno();
            string rta = "";
            if ((string.IsNullOrEmpty(Turno.FechaTurno.ToString())) ||
                (string.IsNullOrEmpty(Turno.DniSocio.ToString())) ||
                (string.IsNullOrEmpty(Turno.DniProfesor.ToString())))
                rta = "Llene todos los campos de texto para registrar!";
            else
            {
                if (modelo.existeTurno(Turno))
                    rta = "¡La persona con el DNI " + Turno.DniSocio + " ya reservo el turno para esa fecha!";
                else
                {
                    modelo.registrarTurno(Turno);
                    rta = "¡Turno reservado con exito!";
                }
            }
            return rta;
        }
    }
}
