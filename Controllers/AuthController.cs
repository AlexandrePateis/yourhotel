using Microsoft.AspNetCore.Mvc;
using YourHotel.Dtos.Client;
using YourHotel.Services;

namespace YourHotel.Controllers;

[ApiController]
[Route("[controller]")]
public class AuthController : ControllerBase
{
    private readonly AuthService _authService;

    public AuthController([FromServices] AuthService service)
    {
        _authService = service;
    }

    [HttpPost]
    public ActionResult<String> Login([FromBody] UserRequestDTO userRequestDTO)
    {
        try
        {
            var TokenJWT = _authService.Login(userRequestDTO);
            return StatusCode(200, TokenJWT);
        }
        catch (Exception e)
        {
            return StatusCode(401, $"Credenciais inválidas: {e.Message}");
        }
    }

}
