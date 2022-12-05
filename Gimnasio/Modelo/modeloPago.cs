using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace Gimnasio
{
    class modeloPago
    {
        static MySqlConnection miConexion = conexion.getConexion();
        static string sql = "";
        static MySqlCommand comando;
        static MySqlDataReader reader;
        public bool existePago(pago Pago)
        {
            bool rta = false;
            miConexion.Open();
            sql = "Select * FROM pagos WHERE EXTRACT(YEAR_MONTH FROM fechaPago) = EXTRACT(YEAR_MONTH FROM @fechaPago) AND dniSocio = @dniSocio";
            comando = new MySqlCommand(sql, miConexion);

            comando.Parameters.AddWithValue("@fechaPago", Pago.FechaPago);
            comando.Parameters.AddWithValue("@dniSocio", Pago.DniSocio);
            reader = comando.ExecuteReader();
            if (reader.HasRows)
                rta = true;
            miConexion.Close();
            return rta;
        }
        public bool registrarPago(pago Pago)
        {
            miConexion.Open();
            try 
            {
                sql = "INSERT INTO pagos(fechaPago, dniSocio, pago)" + "VALUES(@fechaPago, @dniSocio, @pago)";
                MySqlCommand comando = new MySqlCommand(sql, miConexion);
                comando.Parameters.AddWithValue("@fechaPago", Pago.FechaPago);
                comando.Parameters.AddWithValue("@dniSocio", Pago.DniSocio);
                comando.Parameters.AddWithValue("@pago", Pago.Precio);
                int tuplas = comando.ExecuteNonQuery();
                miConexion.Close();
                if (tuplas > 0)
                    return true;
                else
                    return false;
            }
            catch(MySqlException ex) 
            {
                miConexion.Close();
                throw new Exception("Ese DNI no existe");
            }
            
        }
    }
}
