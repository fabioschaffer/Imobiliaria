using Dominio.Entidades.Seguranca;

namespace Aplicacao.Interfaces;

public interface ITokenService {
    string GenerateToken(User user);
    string GenerateRefreshToken();
}