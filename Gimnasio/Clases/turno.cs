using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gimnasio
{
    class turno
    {
        private DateTime fechaTurno;
        private int dniSocio;
        private int dniProfesor;
        public DateTime FechaTurno { get => fechaTurno; set => fechaTurno = value; }
        public int DniSocio { get => dniSocio; set => dniSocio = value; }
        public int DniProfesor { get => dniProfesor; set => dniProfesor = value; }
    }
}
