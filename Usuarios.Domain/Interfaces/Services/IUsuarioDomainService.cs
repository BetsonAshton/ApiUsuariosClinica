using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UsuariosApi.Domain.Entities;

namespace UsuariosApi.Domain.Interfaces.Services
{
    public interface IUsuarioDomainService
    {
        //método para criação da conta do usuário
        void CriarConta(Usuario usuario);

        //método para autenticar o usuário
        Usuario Autenticar(string email, string senha);
    }
}
