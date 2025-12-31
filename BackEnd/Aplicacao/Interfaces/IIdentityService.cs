namespace Aplicacao.Interfaces;

public interface IIdentityService {
    Task<string?> GetUserIdAsync(string email);
    Task<bool> CheckPasswordAsync(string userId, string password);
    Task<bool> CreateUserAsync(string email, string password, string nomeCompleto);
}
