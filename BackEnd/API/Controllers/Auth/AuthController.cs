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
public class AuthController(ITokenService tokenService, IRefreshTokenService refreshTokenService, IAtenticacaoService atenticacaoService) : ControllerBase {

    [AllowAnonymous]
    [HttpPost("login")]
    public async Task<IActionResult> Login(LoginRequestDTO request) {
        var auteticado = await atenticacaoService.Autenticar(request);
        return Ok(new { token = auteticado.token, refreshToken = auteticado.refreshtoken });
    }

    [HttpPost("refresh")]
    [AllowAnonymous]
    public async Task<IActionResult> Refresh(RefreshRequest request) {
        var newAccessToken = await refreshTokenService.ExecuteAsync(
            request.RefreshToken
        );

        var refreshToken = tokenService.GenerateRefreshToken();

        return Ok(new { token = newAccessToken, refreshToken });
    }

    public record RefreshRequest(string RefreshToken);

}