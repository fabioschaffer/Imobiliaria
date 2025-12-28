using Aplicacao.Interfaces;
using Dominio.Entidades.Seguranca;
using Repositorio.Interfaces;

namespace Aplicacao.Servicos;

public class RefreshTokenService(
    ITokenService tokenService,
    IRefreshTokenRepository repository) : IRefreshTokenService {

    public async Task<string> ExecuteAsync(string refreshToken) {
        var storedToken = await repository.GetByTokenAsync(refreshToken);

        if (storedToken == null || storedToken.IsExpired)
            throw new UnauthorizedAccessException();

        // opcional: rotating refresh token
        await repository.RevokeAsync(storedToken);

        return tokenService.GenerateToken(
            new User { Id = storedToken.UserId }
        );
    }
}
