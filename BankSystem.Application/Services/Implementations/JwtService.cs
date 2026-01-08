using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using BankSystem.Application.DTOs;
using BankSystem.Application.Services.Interfaces;
using BankSystem.Domain.Model;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace BankSystem.Application.Services.Implementations;

public class JwtService : IJwtService
{

    private readonly IConfiguration _config;

    public JwtService(IConfiguration config)
    {
        _config = config;
    }

    public LoginResultDto GerarToken(Usuario usuario)
    {
        var claims = new List<Claim>
    {
        new Claim(ClaimTypes.NameIdentifier, usuario.Id.ToString()),
        new Claim(ClaimTypes.Name, usuario.Nome),
        new Claim("cpf", usuario.CPF)
    };

        var key = new SymmetricSecurityKey(
            Encoding.UTF8.GetBytes(_config["Jwt:Key"])
        );

        var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

        var expires = DateTime.UtcNow.AddHours(2);

        var token = new JwtSecurityToken(
            issuer: _config["Jwt:Issuer"],
            audience: _config["Jwt:Audience"],
            claims: claims,
            expires: expires,
            signingCredentials: creds
        );

        return new LoginResultDto
        {
            Token = new JwtSecurityTokenHandler().WriteToken(token),
            ExpiraEm = expires
        };
    }

}
