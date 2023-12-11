using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UsuariosApi.Domain.Entities;
using UsuariosApi.Domain.Helpers;
using UsuariosApi.Domain.Interfaces.Repositories;
using UsuariosApi.Domain.Interfaces.Security;
using UsuariosApi.Domain.Interfaces.Services;

namespace UsuariosApi.Domain.Services
{
    public class UsuarioDomainService:IUsuarioDomainService
    {
        private readonly IUsuarioRepository? _usuarioRepository;
        private readonly ITokenSecurity? _tokenSecurity;

        public UsuarioDomainService(IUsuarioRepository? usuarioRepository, ITokenSecurity? tokenSecurity)
        {
            _usuarioRepository = usuarioRepository;
            _tokenSecurity = tokenSecurity;
        }

        public void CriarConta(Usuario usuario)
        {
            if (_usuarioRepository.Get(usuario.Email) != null)
                throw new ArgumentException("O email informado já está cadastrado, tente outro.");

            //criptografar a senha do usuário
            usuario.Senha = MD5Helper.Encrypt(usuario.Senha);

            //gravar o usuário no banco de dados
            _usuarioRepository.Create(usuario);
        }

        public Usuario Autenticar(string email, string senha)
        {
            senha = MD5Helper.Encrypt(senha);
            var usuario = _usuarioRepository.GetByEmail(email, senha);

            //gerando o token do usuário
            usuario.AccessToken = _tokenSecurity?.GenerateToken(usuario);

            //retornando os dados do usuário
            return usuario;
        }
    }
}
