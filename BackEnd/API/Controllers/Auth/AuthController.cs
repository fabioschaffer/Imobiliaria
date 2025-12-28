using Aplicacao.DTOs;
using Aplicacao.Interfaces;
using Aplicacao.Servicos;
using Dominio.Entidades.Seguranca;
using InfraEstrutura.Seguranca;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers.Auth;

[ApiController]
[Route("api/auth")]
public class AuthController(ITokenService tokenService, IAtenticacaoService atenticacaoService) : ControllerBase {

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

    public record RefreshRequest(string RefreshToken);

}