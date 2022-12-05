using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace Gimnasio
{
    class modeloPrecio
    {
            static MySqlConnection miConexion = conexion.getConexion();
            static string sql = "";
            public bool modificarPrecio(precio Precio)
            {
                miConexion.Open();
                sql = "UPDATE veces SET PRECIO = @valor WHERE CANTIDAD = @cantidad";
                MySqlCommand comando = new MySqlCommand(sql, miConexion);
                comando.Parameters.AddWithValue("@cantidad", Precio.Cantidad);
                comando.Parameters.AddWithValue("@valor", Precio.Valor);
                int tuplas = comando.ExecuteNonQuery();
                miConexion.Close();
                if (tuplas > 0)
                    return true;
                else
                    return false;
            }
     }
}
