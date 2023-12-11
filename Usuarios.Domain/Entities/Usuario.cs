using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UsuariosApi.Domain.Enum;

namespace UsuariosApi.Domain.Entities
{
    public class Usuario
    {
        public Guid? Id { get; set; }
        public string? Nome { get; set; }
        public string? Email { get; set; }
        public string? Senha { get; set; }
        public TipoAcesso TipoAcesso { get; set; }
        public string AccessToken { get; set; }
    }
}
