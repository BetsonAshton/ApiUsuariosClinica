using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UsuariosApi.Application.Models.Requests;
using UsuariosApi.Application.Models.Responses;

namespace UsuariosApi.Application.Interfaces
{
    public interface IUsuarioAppService
    {
        CriarContaResponseModel CriarConta(CriarContaRequestModel model);
        AutenticarResponseModel Autenticar(AutenticarRequestModel model);
    }
}
