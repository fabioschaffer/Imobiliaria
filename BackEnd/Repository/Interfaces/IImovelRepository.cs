using Dominio.Entidades.Imobiliaria;
using Repositorio.Configuracoes;

namespace Repositorio.Interfaces;

public interface IImovelRepository {
    Task<PaginacaoResult<Imovel>> Obter(int pagina);
    Task<Imovel> ObterPorId(int? id);
    Task Criar(Imovel imovel);
    Task Atualizar(Imovel imovel);
    Task Excluir(Imovel imovel);
}