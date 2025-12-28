using Aplicacao.Interfaces;
using Dominio.Entidades.Seguranca;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers.Auth;

[ApiController]
[Route("api/auth")]
public class AuthController : ControllerBase {
    private readonly ITokenService _tokenService;

    public AuthController(ITokenService tokenService) {
        _tokenService = tokenService;
    }

    [AllowAnonymous]
    [HttpPost("login")]
    public IActionResult Login(LoginRequest request) {
        if (request.Login != "admin" || request.Password != "admin")
            return Unauthorized();

        var user = new User {
            Id = Guid.NewGuid(),
            Login = request.Login,
            Role = "Admin"
        };

        var token = _tokenService.GenerateToken(user);
        return Ok(new { token });
    }
}

public record LoginRequest(string Login, string Password);
