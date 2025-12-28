namespace Aplicacao.Interfaces;

public interface IRefreshTokenService {
    Task<string> ExecuteAsync(string refreshToken);
}