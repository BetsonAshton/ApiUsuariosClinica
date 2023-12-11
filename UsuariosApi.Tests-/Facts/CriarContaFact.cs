using Bogus;
using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UsuariosApi.Application.Models.Requests;
using UsuariosApi.Tests_.Helpers;
using Xunit;

namespace UsuariosApi.Tests_.Facts
{
    public class CriarContaFact
    {
        [Fact]
        public CriarContaRequestModel CriarConta_Returns_Ok()
        {
            var faker = new Faker("pt_BR");

            // Criando os dados para realizar o cadastro do usuário
            var request = new CriarContaRequestModel
            {
                Nome = faker.Person.FullName,
                Email = faker.Internet.Email(),
                Senha = "@Teste123",
                TipoAcesso = (UsuariosApi.Domain.Enum.TipoAcesso?)MapToIntToTipoAcesso(faker.Random.Number(1, 2))
            };

            //executando uma requisição POST para cadastrar o usuário
            var response = TestHelper.CreateClient().PostAsync("/api/Usuario/criar-conta",
                TestHelper.CreateContent(request)).Result;

            //comparar o resultado obtido com o resultado esperado
            response.StatusCode.Should().Be(System.Net.HttpStatusCode.Created);

            return request;

            // Função para mapear int para enum TipoAcesso
            UsuariosApi.Domain.Enum.TipoAcesso MapToIntToTipoAcesso(int value)
            {
                // Implemente a lógica de mapeamento conforme necessário
                return (UsuariosApi.Domain.Enum.TipoAcesso)value;
            }
        }


        [Fact]
        public void CriarConta_Returns_BadRequest()
        {
            var faker = new Faker("pt_BR");

            // Criando os dados para realizar o cadastro do usuário com um TipoAcesso inválido
            var request = new CriarContaRequestModel
            {
                Nome = faker.Person.FullName,
                Email = faker.Internet.Email(),
                Senha = "@Teste123",
                TipoAcesso = (UsuariosApi.Domain.Enum.TipoAcesso)999 // Valor inválido para TipoAcesso
            };

            // Executando uma requisição POST para cadastrar o usuário
            var response = TestHelper.CreateClient().PostAsync("/api/Usuario/criar-conta",
                TestHelper.CreateContent(request)).Result;

            // Comparar o resultado obtido com o resultado esperado (BadRequest)
            response.StatusCode.Should().Be(System.Net.HttpStatusCode.BadRequest);
        }




    }

}
