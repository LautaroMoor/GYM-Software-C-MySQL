﻿using System.Security.Cryptography;
using System;
using System.Text;
using MySql.Data.MySqlClient;


namespace Gimnasio
{
    class controlSesion
    {
        public string ctrlLogin(String usuario, String pass)
        {
            modeloSesion modelo = new modeloSesion();
            string rta = "";
            if ((string.IsNullOrEmpty(usuario)) || string.IsNullOrEmpty(pass))
                    rta = "Datos incompletos";
            else
            {
                usuario userResult = modelo.miUsuario(usuario);
                if (userResult != null)
                {
                    if (userResult.Password == generarSHA1(pass))
                        rta = "¡Bienvenido!";
                    else
                        rta = "Clave incorrecta";
                }
                else
                    rta = "Usuario no existe";
            }
            return rta;
        }
        private string generarSHA1(string cadena)
        {
            UTF8Encoding enc = new UTF8Encoding();
            byte[] data = enc.GetBytes(cadena);
            byte[] result;
            SHA1CryptoServiceProvider sha = new SHA1CryptoServiceProvider();
            result = sha.ComputeHash(data);
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < result.Length; i++)
            {
                if (result[i] < 16)
                    sb.Append("0");
                sb.Append(result[i].ToString("x"));
            }
            return sb.ToString();
        }
    }
}
