using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using YourHotel.Dtos.Client;
using YourHotel.Models;
using YourHotel.Repository;

namespace YourHotel.Services;

public class AuthService
{
    private readonly ClientRepository _clientRepository;
    private readonly IConfiguration _configuration;

    public AuthService(
        [FromServices] ClientRepository repository,
        [FromServices] IConfiguration configuration
        )
    {
        _clientRepository = repository;
        _configuration = configuration;
    }

    public string Login(UserRequestDTO userRequestDTO)
    {
        var client = _clientRepository.SearchByEmail(userRequestDTO.Email);

        if ((client == null || (!BCrypt.Net.BCrypt.Verify(userRequestDTO.Password, client.Password))))
        {
            throw new Exception("Invalid credentials");
        }

        var TokenJWT = GenerateToken(client);
        return TokenJWT;
    }

    private string GenerateToken(Client client)
    {
        //Pegando a chave JWT
        var JWTKey = Encoding.ASCII.GetBytes(_configuration["JWTKey"]);

        //Criando as credenciais
        var credenciais = new SigningCredentials(
                new SymmetricSecurityKey(JWTKey),
                SecurityAlgorithms.HmacSha256);

        var claims = new List<Claim>();
        claims.Add(new Claim(ClaimTypes.Name, client.FirstName));
        claims.Add(new Claim(ClaimTypes.NameIdentifier, client.Id.ToString()));

        //Criando o token
        var tokenJWT = new JwtSecurityToken(
            expires: DateTime.Now.AddHours(8),
            signingCredentials: credenciais,
            claims: claims
        );

        //Escrevendo o token e retornando
        return new JwtSecurityTokenHandler().WriteToken(tokenJWT);
    }
}
