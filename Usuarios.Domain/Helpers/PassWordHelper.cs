using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UsuariosApi.Domain.Helpers
{
    public class PassWordHelper
    {
        /// <summary>
        /// Gera uma senha aleatória com opções configuráveis.
        /// </summary>
        /// <param name="useCapitalLetters">Indica se a senha deve incluir letras maiúsculas.</param>
        /// <param name="useSmallLetters">Indica se a senha deve incluir letras minúsculas.</param>
        /// <param name="useNumbers">Indica se a senha deve incluir números.</param>
        /// <param name="useSymbols">Indica se a senha deve incluir caracteres especiais.</param>
        /// <param name="passLength">O comprimento desejado da senha.</param>
        /// <returns>Uma senha aleatória gerada conforme as opções especificadas.</returns>
        public static string GeneratePassword(bool useCapitalLetters, bool useSmallLetters, bool useNumbers, bool useSymbols, int passLength)
        {
            Random random = new Random();
            StringBuilder password = new StringBuilder();

            for (int i = 0; ;)
            {
                if (useCapitalLetters)
                {
                    password.Append((char)random.Next(65, 91)); // Adiciona uma letra maiúscula
                    ++i; if (i >= passLength) break;
                }
                if (useSmallLetters)
                {
                    password.Append((char)random.Next(97, 122)); // Adiciona uma letra minúscula
                    ++i; if (i >= passLength) break;
                }
                if (useNumbers)
                {
                    password.Append((char)random.Next(48, 57)); // Adiciona um número
                    ++i; if (i >= passLength) break;
                }
                if (useSymbols)
                {
                    password.Append((char)random.Next(35, 38)); // Adiciona um caractere especial
                    ++i; if (i >= passLength) break;
                }
            }

            // Embaralha os caracteres na senha
            for (int i = 0; i < password.Length; ++i)
            {
                int randomIndex1 = random.Next(password.Length);
                int randomIndex2 = random.Next(password.Length);
                char temp = password[randomIndex1];
                password[randomIndex1] = password[randomIndex2];
                password[randomIndex2] = temp;
            }

            return password.ToString();
        }
    }
}

