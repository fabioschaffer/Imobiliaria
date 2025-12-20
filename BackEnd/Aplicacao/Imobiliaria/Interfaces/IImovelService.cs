using Aplicacao.Imobiliaria.DTOs;
using Dominio.Entidades.Imobiliaria;

namespace Aplicacao.Imobiliaria.Interfaces;

public interface IImovelService {
    Task<IEnumerable<ImovelPaginacaoDTO>> ObterImoveis(int pagina, int? quartos, decimal? valorInicial, decimal? valorFinal);
    Task<ImovelDTO> ObterPorId(int? id);
    Task<Imovel> Criar(ImovelDTO ImovelDTO);
    Task<Imovel> Atualizar(int id, ImovelDTO ImovelDTO);
    Task Excluir(int? id);
}