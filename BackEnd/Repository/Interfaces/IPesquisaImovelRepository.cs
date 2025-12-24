using Dominio.Entidades.Imobiliaria;
using Repositorio.Configuracoes;

namespace Repositorio.Interfaces;

public interface IPesquisaImovelRepository {
    Task<PaginacaoResult<Imovel>> Obter(int pagina, int? quartos, decimal? valorInicial, decimal? valorFinal);
    Task<Imovel> ObterPorId(int? id);
}