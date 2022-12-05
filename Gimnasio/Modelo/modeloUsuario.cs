using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace Gimnasio
{
    class modeloUsuario
    {
        static MySqlConnection miConexion = conexion.getConexion();
        static string sql = "";
        static MySqlCommand comando;
        static MySqlDataReader reader;
        public bool existeUsuario(usuario user)
        {
            bool rta = false;
            miConexion.Open();
            sql = "Select * from usuario where User Like @user";
            comando = new MySqlCommand(sql, miConexion);
            comando.Parameters.AddWithValue("@User", user.Usuarii);
            reader = comando.ExecuteReader();
            if (reader.HasRows)
                rta = true;
            miConexion.Close();
            return rta;
        }
        public bool registrarUsuario(usuario user)
        {
            miConexion.Open();
            sql = "INSERT INTO usuario (idUser, User, Password, Nombre, idTipoUser)" + " VALUES(@idUser, @User, @Password, @Nombre, @idTipoUser)";
        MySqlCommand comando = new MySqlCommand(sql, miConexion);
            comando.Parameters.AddWithValue("@idUser", null);
            comando.Parameters.AddWithValue("@User", user.Usuarii);
            comando.Parameters.AddWithValue("@Password", user.Password);
            comando.Parameters.AddWithValue("@Nombre", user.Nombre);
            comando.Parameters.AddWithValue("@idTipoUser", user.IdTipo);
            int tuplas = comando.ExecuteNonQuery();
            miConexion.Close();
            if (tuplas > 0)
                return true;
            else
                return false;
        }
    }
}
