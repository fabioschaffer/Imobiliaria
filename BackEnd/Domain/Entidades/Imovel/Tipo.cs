using Dominio.Enums;
using System.ComponentModel.DataAnnotations.Schema;

namespace Dominio.Entidades.Imovel;

[Table(nameof(Tipo), Schema = nameof(Schemas.Imovel))]
public class Tipo {

    public int Id { get; private set; }
    public string Descricao { get; private set; }

    public Tipo(string descricao) {
        Atualizar(descricao);
    }

    public void Atualizar(string descricao) {
        if (string.IsNullOrWhiteSpace(descricao))
            throw new ArgumentNullException(nameof(descricao));

        Descricao = descricao;
    }
}