using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UsuariosApi.Application.Interfaces;
using UsuariosApi.Application.Models.Requests;
using UsuariosApi.Application.Models.Responses;
using UsuariosApi.Domain.Entities;
using UsuariosApi.Domain.Interfaces.Services;

namespace UsuariosApi.Application.Services
{
    public class UsuarioAppService : IUsuarioAppService
    {
        private readonly IUsuarioDomainService? _usuarioDomainService;

        public UsuarioAppService(IUsuarioDomainService? usuarioDomainService)
        {
            _usuarioDomainService = usuarioDomainService;
        }

        public CriarContaResponseModel CriarConta(CriarContaRequestModel model)
        {
            //capturar os dados do usuário
            var usuario = new Usuario
            {
                Id = Guid.NewGuid(),
                Nome = model.Nome,
                Email = model.Email,
                Senha = model.Senha,
                TipoAcesso = (Domain.Enum.TipoAcesso)model.TipoAcesso
            };

            _usuarioDomainService?.CriarConta(usuario);

            //retornando a resposta
            var response = new CriarContaResponseModel
            {
                Id = usuario.Id,
                Nome = usuario.Nome,
                Email = usuario.Email,
               TipoAcesso = (int?)usuario.TipoAcesso
            };

            return response;
        }

        public AutenticarResponseModel Autenticar(AutenticarRequestModel model)
        {
            var usuario = _usuarioDomainService?.Autenticar(model.Email, model.Senha);

            //retornar os dados do usuário autenticado
            var response = new AutenticarResponseModel
            {
                Id = usuario.Id,
                Nome = usuario.Nome,
                Email = usuario.Email,
                AccessToken = usuario.AccessToken,
               TipoAcesso = (int?)usuario.TipoAcesso
            };

            return response;
        }
    }
}
