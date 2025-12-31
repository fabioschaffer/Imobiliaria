using Microsoft.AspNetCore.Identity;

namespace Dominio.Entidades.Seguranca;
public class User : IdentityUser {
    // Campos personalizados
    public string NomeCompleto { get; set; } = string.Empty;
    public bool Ativo { get; set; } = true;

    // Datas de auditoria (opcional)
    public DateTime CriadoEm { get; set; } = DateTime.UtcNow;
}