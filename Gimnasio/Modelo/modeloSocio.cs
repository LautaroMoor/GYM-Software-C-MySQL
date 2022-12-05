using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace Gimnasio
{
    class modeloSocio
    {
        static MySqlConnection miConexion = conexion.getConexion();
        static string sql = "";
        static MySqlCommand comando;
        static MySqlDataReader reader;
        public bool existeSocio(socio user)
        {
            bool rta = false;
            miConexion.Open();
            sql = "Select * from socio where dni Like @dni";
            comando = new MySqlCommand(sql, miConexion);
            comando.Parameters.AddWithValue("@dni", user.DNI1);
            reader = comando.ExecuteReader();
            if (reader.HasRows)
                rta = true;
            miConexion.Close();
            return rta;
        }
        public bool registrarSocio(socio socioo)
        {
            miConexion.Open();
            sql = "INSERT INTO socio(dni, nombre, apellido, domicilio, cp, fecha_nac, telefono, email, activo, vieneVeces, lesionado, lesiones)" + " VALUES(@dni, @nombre, @apellido, @domicilio, @cp, @fecha, @telefono, @email, @activo, @vieneVeces, @lesionado, @lesiones)";
            MySqlCommand comando = new MySqlCommand(sql, miConexion);
            comando.Parameters.AddWithValue("@dni", socioo.DNI1);
            comando.Parameters.AddWithValue("@nombre", socioo.Nombre);
            comando.Parameters.AddWithValue("@apellido", socioo.Apellido);
            comando.Parameters.AddWithValue("@domicilio", socioo.Domicilio);
            comando.Parameters.AddWithValue("@cp", socioo.Cp);
            comando.Parameters.AddWithValue("@fecha", socioo.Fecha);
            comando.Parameters.AddWithValue("@telefono", socioo.Telefono);
            comando.Parameters.AddWithValue("@email", socioo.Email);
            comando.Parameters.AddWithValue("@activo", socioo.Activo);
            comando.Parameters.AddWithValue("@vieneVeces", socioo.VieneVeces);
            comando.Parameters.AddWithValue("@lesionado", socioo.Lesionado);
            comando.Parameters.AddWithValue("@lesiones", socioo.Lesiones);
            int tuplas = comando.ExecuteNonQuery();
            miConexion.Close();
            if (tuplas > 0)
                return true;
            else
                return false;
        }
        public bool eliminarSocio(socio socioo)
        {
            miConexion.Open();
            sql = "DELETE FROM socio WHERE DNI=@dni";
            MySqlCommand comando = new MySqlCommand(sql, miConexion);
            comando.Parameters.AddWithValue("@dni", socioo.DNI1);
            int tuplas = comando.ExecuteNonQuery();
            miConexion.Close();
            if (tuplas > 0)
                return true;
            else
                return false;
        }
            public bool modificarSocio(socio socioo)
            {
            miConexion.Open();
            sql = "UPDATE socio SET NOMBRE=@nombre,APELLIDO=@apellido, DOMICILIO=@domicilio, CP=@cp, FECHA_NAC=@fecha, TELEFONO=@telefono, EMAIL=@email, ACTIVO = @activo, VIENEVECES = @vieneVeces, LESIONADO = @lesionado, LESIONES = @lesiones WHERE DNI=@dni";
            MySqlCommand comando = new MySqlCommand(sql, miConexion);
            comando.Parameters.AddWithValue("@dni", socioo.DNI1);
            comando.Parameters.AddWithValue("@nombre", socioo.Nombre);
            comando.Parameters.AddWithValue("@apellido", socioo.Apellido);
            comando.Parameters.AddWithValue("@domicilio", socioo.Domicilio);
            comando.Parameters.AddWithValue("@cp", socioo.Cp);
            comando.Parameters.AddWithValue("@fecha", socioo.Fecha);
            comando.Parameters.AddWithValue("@telefono", socioo.Telefono);
            comando.Parameters.AddWithValue("@email", socioo.Email);
            comando.Parameters.AddWithValue("@activo", socioo.Activo);
            comando.Parameters.AddWithValue("@vieneVeces", socioo.VieneVeces);
            comando.Parameters.AddWithValue("@lesionado", socioo.Lesionado);
            comando.Parameters.AddWithValue("@lesiones", socioo.Lesiones);
            int tuplas = comando.ExecuteNonQuery();
            miConexion.Close();
            if (tuplas > 0)
                return true;
            else
                return false;
            }

    }
}
