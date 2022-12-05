using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


//NO SE SI ESTO ESTA BIEN


namespace Gimnasio
{
    class socio
    {
        private int DNI, cp, vieneVeces;
        private Int64 telefono;
        private String nombre, apellido, domicilio, email, lesiones, activo, lesionado;
        private DateTime fecha;

        public int DNI1 { get => DNI; set => DNI = value; }
        public int Cp { get => cp; set => cp = value; }
        public int VieneVeces { get => vieneVeces; set => vieneVeces = value; }
        public long Telefono { get => telefono; set => telefono = value; }
        public string Nombre { get => nombre; set => nombre = value; }
        public string Apellido { get => apellido; set => apellido = value; }
        public string Domicilio { get => domicilio; set => domicilio = value; }
        public string Email { get => email; set => email = value; }
        public string Lesiones { get => lesiones; set => lesiones = value; }
        public string Activo { get => activo; set => activo = value; }
        public string Lesionado { get => lesionado; set => lesionado = value; }
        public DateTime Fecha { get => fecha; set => fecha = value; }
    }
}
