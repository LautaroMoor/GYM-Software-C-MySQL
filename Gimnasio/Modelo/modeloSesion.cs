using MySql.Data.MySqlClient;
using System;

namespace Gimnasio
{
    class modeloSesion
    {
        static MySqlConnection miConexion = conexion.getConexion();
        static string sql = "";
        static MySqlCommand comando;
        static MySqlDataReader reader;

        public usuario miUsuario(String usuario)
        {
            usuario user = null;
            miConexion.Open();
            sql = "Select * from usuario where User Like @user";
            comando = new MySqlCommand(sql, miConexion);
            comando.Parameters.AddWithValue("@User", usuario);
            reader = comando.ExecuteReader();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    user = new usuario();
                    user.Id = int.Parse(reader["idUser"].ToString());
                    user.Usuarii = reader["user"].ToString();
                    user.Password = reader["password"].ToString();
                    user.Nombre = reader["nombre"].ToString();
                    user.IdTipo = int.Parse(reader["idTipoUser"].ToString());
                }
            }
            miConexion.Close();
            return user;
        }
    }
}
