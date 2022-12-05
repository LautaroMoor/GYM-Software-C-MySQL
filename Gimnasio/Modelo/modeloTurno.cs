using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace Gimnasio
{
    class modeloTurno
    {
        static MySqlConnection miConexion = conexion.getConexion();
        static string sql = "";
        static MySqlCommand comando;
        static MySqlDataReader reader;
        public bool existeTurno(turno Turno)
        {
            bool rta = false;
            miConexion.Open();
            sql = "SELECT * FROM turno WHERE fechaTurno = @fechaTurno AND dniSocio = @dniSocio";
            comando = new MySqlCommand(sql, miConexion);
            comando.Parameters.AddWithValue("@fechaTurno", Turno.FechaTurno);
            comando.Parameters.AddWithValue("@dniSocio", Turno.DniSocio);
            reader = comando.ExecuteReader();
            if (reader.HasRows)
                rta = true;
            miConexion.Close();
            return rta;
        }
        public bool registrarTurno(turno Turno)
        {
            miConexion.Open();
            try { 
                sql = "INSERT INTO turno(fechaTurno, dniSocio, dniProfesor)" + " VALUES(@fechaTurno, @dniSocio, @dniProfesor)";
                MySqlCommand comando = new MySqlCommand(sql, miConexion);
                comando.Parameters.AddWithValue("@fechaTurno", Turno.FechaTurno);
                comando.Parameters.AddWithValue("@dniSocio", Turno.DniSocio);
                comando.Parameters.AddWithValue("@dniProfesor", Turno.DniProfesor);
                int tuplas = comando.ExecuteNonQuery();
                miConexion.Close();
                if (tuplas > 0)
                    return true;
                else
                    return false;
            }
            catch (MySqlException ex)
            {
                miConexion.Close();
                throw new Exception("Ese DNI no existe en la base de datos");
            }
        }

    }
}
