using MySql.Data.MySqlClient;

namespace Gimnasio
{ 
public class conexion
{
    static string servidor = "datasource=127.0.0.1";
    static string puerto = "port=3306";
    static string username = "username = root";
    static string password = "password=";
    static string bd = "database=gimnasio";
    public static MySqlConnection getConexion()
    {
            string cadenaConexion = servidor + ";" + puerto + ";" + username + ";" + password + ";" + bd + ";SSL Mode=0; convert zero datetime=True";
            return new MySqlConnection(cadenaConexion);
    }
}
}