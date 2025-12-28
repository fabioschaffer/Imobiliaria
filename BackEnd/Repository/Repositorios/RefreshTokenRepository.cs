using Dominio.Entidades.Seguranca;
using Microsoft.EntityFrameworkCore;
using Repositorio.Contexto;
using Repositorio.Interfaces;

namespace Repositorio.Repositorios;

public class RefreshTokenRepository(AplicacaoDbContext context) : IRefreshTokenRepository {

    public async Task AddAsync(RefreshToken token) {
        context.RefreshTokens.Add(token);
        await context.SaveChangesAsync();
    }

    public async Task<RefreshToken?> GetByTokenAsync(string token) {
        return await context.RefreshTokens
            .FirstOrDefaultAsync(x => x.Refresh_Token == token && !x.Revoked);
    }

    public async Task RevokeAsync(RefreshToken token) {
        token.Revoked = true;
        await context.SaveChangesAsync();
    }
}