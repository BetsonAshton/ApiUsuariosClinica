using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UsuariosApi.Security.Settings
{
    public class TokenSettings
    {
        /// <summary>
        /// Chave secreta para assinatura antifalsificação do token
        /// </summary>
        public static string SecretKey { get => "6E5C998C-28BD-44BE-A74A-D0E14FEA685E"; }

        /// <summary>
        /// Tempo de expiração do TOKEN
        /// </summary>
        public static int ExpirationInMinutes { get => 60; }
    }
}
