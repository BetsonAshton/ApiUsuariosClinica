using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace UsuariosApi.Domain.Helpers
{
    public class MD5Helper
    {
        /// <summary>
        /// Criptografa uma string usando o algoritmo MD5.
        /// </summary>
        /// <param name="input">A string a ser criptografada.</param>
        /// <returns>A representação hexadecimal do hash MD5 da string de entrada.</returns>
        public static string Encrypt(string input)
        {
            // Cria uma instância do algoritmo de hash MD5
            using (var md5 = MD5.Create())
            {
                // Converte a string de entrada em bytes usando a codificação UTF-8
                var inputBytes = Encoding.UTF8.GetBytes(input);

                // Calcula o hash MD5 dos bytes de entrada
                var hashBytes = md5.ComputeHash(inputBytes);

                // Converte os bytes do hash em uma representação hexadecimal
                var stringBuilder = new StringBuilder();
                for (var i = 0; i < hashBytes.Length; i++)
                {
                    stringBuilder.Append(hashBytes[i].ToString("x2"));
                }

                // Retorna a representação hexadecimal do hash MD5
                return stringBuilder.ToString();
            }
        }
    }
}
