using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using UsuariosApi.Application.Interfaces;
using UsuariosApi.Application.Services;
using UsuariosApi.Domain.Interfaces.Repositories;
using UsuariosApi.Domain.Interfaces.Security;
using UsuariosApi.Domain.Interfaces.Services;
using UsuariosApi.Domain.Services;
using UsuariosApi.Infra.Data.Repositories;
using UsuariosApi.Security.Services;
using UsuariosApi.Security.Settings;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();


// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();



builder.Services.AddTransient<IUsuarioAppService, UsuarioAppService>();
builder.Services.AddTransient<IUsuarioDomainService, UsuarioDomainService>();
builder.Services.AddTransient<IUsuarioRepository, UsuarioRepository>();
builder.Services.AddTransient<ITokenSecurity, TokenSecurity>();

builder.Services.AddCors(
          config => config.AddPolicy("DefaultPolicy", builder =>
          {
              builder.AllowAnyOrigin() //qualquer dominio poderá acessar a API
                     .AllowAnyMethod() //permitir POST, PUT, DELETE, GET
                     .AllowAnyHeader(); //aceitar parametros de cabeçalho de requisição
          })
          );

//mapear as configurações de autenticação do projeto
builder.Services.AddAuthentication(
    auth =>
    {
        auth.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
        auth.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
    }).AddJwtBearer(
        bearer =>
        {
            bearer.RequireHttpsMetadata = false;
            bearer.SaveToken = true;
            bearer.TokenValidationParameters = new TokenValidationParameters
            {
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = new SymmetricSecurityKey
                    (Encoding.ASCII.GetBytes(TokenSettings.SecretKey)),
                ValidateIssuer = false,
                ValidateAudience = false
            };
        }
);


var app = builder.Build();

// Configure the HTTP request pipeline.


    app.UseSwagger();
    app.UseSwaggerUI();

app.UseAuthentication();
app.UseAuthorization();

app.UseCors("DefaultPolicy");
app.MapControllers();

app.Run();
public partial class Program { }
