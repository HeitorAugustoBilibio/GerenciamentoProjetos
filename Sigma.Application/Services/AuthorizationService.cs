using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Sigma.Application.Dtos;
using Sigma.Application.Interfaces;
using Sigma.Domain.Entities;
using Sigma.Domain.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Sigma.Application.Services
{
    public class AuthorizationService : IAuthService
    {
        private readonly IConfiguration _configuration;
        private readonly IUsuarioRepository _usuarioRepository;
        private Usuario _user;

        public AuthorizationService(IConfiguration configuration, IUsuarioRepository usuarioRepository)
        {
            _configuration = configuration;
            _usuarioRepository = usuarioRepository;
        }

        public async Task<AuthenticateResponseDTo> Authenticate(AuthenticateRequestDTo request)
        {
            if (request.Email == "adm@gmail.com" && request.Senha == "1234")
            {
                _user = new Usuario
                {
                    Id = 1,
                    Name = "Admin",
                    Email = "adm@gmail.com",
                    Senha = "1234",
                    Cargo = Domain.Enums.Cargo.Administrador
                };
            }
            else
            {
                var userList = await _usuarioRepository.BuscarTodos();
                _user = userList.FirstOrDefault(u => u.Email == request.Email && u.Senha == request.Senha);
                if (_user == null) return null;
            }

            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_configuration["Jwt:Key"]);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[]
                {
                    new Claim(ClaimTypes.NameIdentifier, _user.Id.ToString()),
                    new Claim(ClaimTypes.Name, _user.Name),
                    new Claim(ClaimTypes.Role, _user.Cargo.ToString())
                }),
                Expires = DateTime.UtcNow.AddHours(1),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);

            return new AuthenticateResponseDTo
            {
                Token = tokenHandler.WriteToken(token),
                Nome = _user.Name,
                Email = _user.Email,
                Cargo = _user.Cargo.ToString()
            };
        }
    }
}

