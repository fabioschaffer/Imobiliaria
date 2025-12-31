namespace Dominio.Entidades.Seguranca;

public class RefreshToken {
    public Guid Id { get; set; }
    public string UserId { get; set; }
    public string Refresh_Token { get; set; } = string.Empty;
    public DateTime ExpiresAt { get; set; }
    public bool Revoked { get; set; }

    public bool IsExpired => DateTime.UtcNow >= ExpiresAt;
}