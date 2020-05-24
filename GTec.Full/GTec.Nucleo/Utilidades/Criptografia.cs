using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;

namespace GTec.Nucleo.Utilidades
{
    public class Criptografia
    {
        public static string ObtenhaHashSha256(string texto)
        {
            byte[] bytes = Encoding.UTF8.GetBytes(texto);
            SHA256Managed hashstring = new SHA256Managed();
            byte[] hash = hashstring.ComputeHash(bytes);
            string hashString = string.Empty;
            foreach (byte x in hash)
            {
                hashString += String.Format("{0:x2}", x);
            }
            return hashString;
        }
    }
}
