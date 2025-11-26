using Dominio.Entidades.Imobiliaria;

namespace Repositorio.Interfaces;

public interface IImovelRepository {
    Task<IEnumerable<Imovel>> Obter();
    Task<Imovel> ObterPorId(int? id);
    Task<int> Criar(Imovel imovel);
    Task Atualizar(Imovel imovel);
    Task Excluir(Imovel imovel);
}