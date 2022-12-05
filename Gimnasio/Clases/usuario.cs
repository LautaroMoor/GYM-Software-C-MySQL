using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace Gimnasio
{
    class usuario
    {
        //ATRIBUTOS
        private int id;
        private String usuarii;
        private String password;
        private String passwordConfirma;
        private String nombre;
        private int idTipo;
        public int Id { get => id; set => id = value; }
        public String Usuarii { get => usuarii; set => usuarii = value; }
        public String Password { get => password; set => password = value; }
        public String PasswordConfirma { get => passwordConfirma; set => passwordConfirma = value; }
        public String Nombre { get => nombre; set => nombre = value; }
        public int IdTipo { get => idTipo; set => idTipo = value; }
    }
}
