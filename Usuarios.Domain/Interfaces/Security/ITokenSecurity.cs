using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UsuariosApi.Domain.Entities;

namespace UsuariosApi.Domain.Interfaces.Security
{
    public interface ITokenSecurity
    {
        //método para implementarmos ageração do token
        public string GenerateToken(Usuario usuario);
    }
}
