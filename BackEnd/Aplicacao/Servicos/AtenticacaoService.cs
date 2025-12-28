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

public class AtenticacaoService(ITokenService tokenService, IRefreshTokenService refreshTokenService, IRefreshTokenRepository refreshTokenRepository) : IAtenticacaoService {

    public async Task<LoginResponseDTO> Autenticar(LoginRequestDTO dto) {

        if (dto.Login != "admin" || dto.Password != "admin")
            return null;

        var user = new User {
            Id = Guid.NewGuid(),
            Login = dto.Login,
            Role = "Admin"
        };

        var token = tokenService.GenerateToken(user);
        var refreshToken = tokenService.GenerateRefreshToken();

        //Salva o refreshToken no banco.  
        await refreshTokenRepository.AddAsync(new RefreshToken {
            Refresh_Token = refreshToken,
            UserId = user.Id,
            ExpiresAt = DateTime.UtcNow.AddDays(7)
        });

        return new LoginResponseDTO(
            token: token,
            refreshtoken: refreshToken
        );
    }

}
