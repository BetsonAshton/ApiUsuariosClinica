using Bogus;
using FluentAssertions;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UsuariosApi.Application.Models.Requests;
using UsuariosApi.Application.Models.Responses;
using UsuariosApi.Tests_.Helpers;
using Xunit;

namespace UsuariosApi.Tests_.Facts
{
    public class AutenticarFact
    {
        [Fact]
        public AutenticarResponseModel Autenticar_Returns_Ok()
        {
            // Cadastrando um usuário
            var criarContaFact = new CriarContaFact();
            var usuario = criarContaFact.CriarConta_Returns_Ok();

            // Definindo os dados da requisição
            var request = new AutenticarRequestModel
            {
                Email = usuario.Email,
                Senha = usuario.Senha
            };

            // Realizando a autenticação na API
            var response = TestHelper.CreateClient().PostAsync("/api/Usuario/autenticar",
                TestHelper.CreateContent(request)).Result;

            // Verificando o resultado esperado X resultado obtido
            response.StatusCode.Should().Be(System.Net.HttpStatusCode.OK,
                $"Esperava-se o status OK, mas o status retornado foi {response.StatusCode}.\n" +
                $"Response content: {response.Content.ReadAsStringAsync().Result}");

            // Capturando o retorno da API
            return JsonConvert.DeserializeObject<AutenticarResponseModel>(
                response.Content.ReadAsStringAsync().Result);
        }

        

        [Fact]
        public void Autenticar_Returns_BadRequest()
        {
            //definindo os dados da requisição
            var request = new AutenticarRequestModel
            {
                Email = string.Empty,
                Senha = string.Empty
            };

            //realizando o cadastro na API
            var response = TestHelper.CreateClient().PostAsync("/api/Usuario/autenticar",
                TestHelper.CreateContent(request)).Result;

            //verificando o resultado esperado X resultado obtido
            response.StatusCode.Should().Be(System.Net.HttpStatusCode.BadRequest);
        }

    }
}
