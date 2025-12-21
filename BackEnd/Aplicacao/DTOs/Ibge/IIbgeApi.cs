using RestEase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplicacao.DTOs.Ibge;

public record UFIbgeDTO(int Id, string Sigla, string Nome);

public interface IIbgeApi
{
    // Retorna a lista de todas as UFs
    [Get("localidades/estados")]
    Task<List<UFIbgeDTO>> GetUfsAsync();

    // Exemplo de busca por sigla específica
    [Get("localidades/estados/{uf}")]
    Task<UFIbgeDTO> GetUfBySiglaAsync([Path] string uf);
}