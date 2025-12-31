using Aplicacao.DTOs;
using Aplicacao.Interfaces;
using Aplicacao.Servicos;
using Dominio.Entidades.Seguranca;
using InfraEstrutura.Identity;
using InfraEstrutura.Seguranca;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers.Auth;

[ApiController]
[Route("api/auth")]
public class AuthController(ITokenService tokenService, IAtenticacaoService atenticacaoService, IIdentityService identityService) : ControllerBase {

    [AllowAnonymous]
    [HttpPost("login")]
    public async Task<IActionResult> Login(LoginRequestDTO request) {
        var auteticado = await atenticacaoService.Autenticar(request);
        return Ok(new { token = auteticado.token, refreshToken = auteticado.refreshtoken });
    }


    [AllowAnonymous]
    [HttpPost("refresh")]
    public async Task<IActionResult> Refresh(RefreshRequest request) {
        var newToken = await atenticacaoService.RefreshToken(request.RefreshToken);
        return Ok(new { token = newToken.token, refreshToken = newToken.refreshtoken });
    }

    [AllowAnonymous]
    [HttpPost("register")]
    public async Task<IActionResult> Register() {
        var result = await identityService.CreateUserAsync(
            "teste@email.com",
            "Senha@123",
            "Usuário Teste");

        return result ? Ok() : BadRequest();
    }

    public record RefreshRequest(string RefreshToken);

}