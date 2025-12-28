using Aplicacao.DTOs;
using Aplicacao.Interfaces;
using Azure.Core;
using Dominio.Entidades.Seguranca;
using Microsoft.AspNetCore.Identity.Data;
using Repositorio.Interfaces;
using RestEase.Implementation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplicacao.Servicos;

public class AtenticacaoService(ITokenService tokenService,  IRefreshTokenRepository refreshTokenRepository) : IAtenticacaoService {

    public async Task<LoginResponseDTO> Autenticar(LoginRequestDTO dto) {

        if (dto.Login != "admin" || dto.Password != "admin")
            return null;

        var user = new User {
            Id = Guid.NewGuid(),
            Login = dto.Login,
            Role = "Admin"
        };

        var newToken = await GeraToken(user);

        return new LoginResponseDTO(
            token: newToken.token,
            refreshtoken: newToken.refreshToken
        );
    }

    private  async Task<NewToken> GeraToken( User user) {
        var token = tokenService.GenerateToken(user);
        var refreshToken = tokenService.GenerateRefreshToken();

        //Salva o refreshToken no banco.  
        await refreshTokenRepository.AddAsync(new RefreshToken {
            Refresh_Token = refreshToken,
            UserId = user.Id,
            ExpiresAt = DateTime.UtcNow.AddDays(7)
        });

        return new NewToken(
            token: token,
            refreshToken: refreshToken
        );
    }

    public async Task<RefreshTokenResponseDTO> RefreshToken(string refreshToken) {
        var storedToken = await refreshTokenRepository.GetByTokenAsync(refreshToken);

        if (storedToken == null || storedToken.IsExpired)
            throw new UnauthorizedAccessException();

        await refreshTokenRepository.RevokeAsync(storedToken);

        var user = new User {
            Id = Guid.NewGuid(),
            Login = "admin",
            Role = "Admin"
        };

        var newToken = await GeraToken(user);

        return new RefreshTokenResponseDTO(
            token: newToken.token,
            refreshtoken: newToken.refreshToken
        );
    }

    private record NewToken(string token, string refreshToken);

}