using Dominio.Enums;
using System.ComponentModel.DataAnnotations.Schema;

namespace Dominio.Entidades.Imobiliaria;

[Table(nameof(Caracteristica), Schema = nameof(Schemas.Imobiliaria))]
public class Caracteristica {

    public int Id { get; private set; }
    public string Descricao { get; private set; }
    public ICollection<ImovelCaracteristica> ImoveisCaracteristicas { get; private set; }

    public Caracteristica(string descricao)
    {
        Atualizar(descricao);
    }

    public void Atualizar(string descricao)
    {
        if (string.IsNullOrWhiteSpace(descricao))
            throw new ArgumentNullException(nameof(descricao));

        Descricao = descricao;
    }
}