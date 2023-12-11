using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UsuariosApi.Application.Interfaces;
using UsuariosApi.Application.Models.Requests;
using UsuariosApi.Application.Models.Responses;

namespace UsuariosApi.Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private readonly IUsuarioAppService? _usuarioAppService;

        public UsuarioController(IUsuarioAppService? usuarioAppService)
        {
            _usuarioAppService = usuarioAppService;
        }

        [Route("autenticar")]
        [HttpPost]
        [ProducesResponseType(typeof(AutenticarResponseModel), 200)]
        public IActionResult Autenticar([FromBody] AutenticarRequestModel model) 
        {
            try
            {
                //executando a autenticação do usuário na camada de aplicação
                var response = _usuarioAppService?.Autenticar(model);

                //HTTP 200 (OK)
                return StatusCode(200, response);
            }
            catch (ApplicationException e)
            {
                //HTTP UNAUTHORIZED (401)
                return StatusCode(401, new { e.Message });
            }
            catch (Exception e)
            {
                //HTTP BAD REQUEST (500)
                return StatusCode(500, new { e.Message });
            }
        }

        [Route("criar-conta")]
        [HttpPost]
        [ProducesResponseType(typeof(CriarContaResponseModel), 201)]
        public IActionResult CriarConta([FromBody] CriarContaRequestModel model)
        {
            try
            {
                //executando o cadastro na camada de aplicação
                var response = _usuarioAppService?.CriarConta(model);

                //HTTP 201 (CREATED)
                return StatusCode(201, response);
            }
            catch (ApplicationException e)
            {
                //HTTP BAD REQUEST (400)
                return StatusCode(400, new { e.Message });
            }
            catch (Exception e)
            {
                //HTTP INTERNAL SERVER ERROR (500)
                return StatusCode(500, new { e.Message });
            }
        }

      
    }
}
