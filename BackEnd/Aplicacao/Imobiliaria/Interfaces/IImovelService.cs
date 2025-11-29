using Aplicacao.Imobiliaria.DTOs;
using Dominio.Entidades.Imobiliaria;

namespace Aplicacao.Imobiliaria.Interfaces;

public interface IImovelService {
    Task<IEnumerable<ImovelDTO>> ObterImoveis();
    Task<ImovelDTO> ObterPorId(int? id);
    Task<Imovel> Criar(ImovelDTO ImovelDTO);
    Task Excluir(int? id);
    Task Atualizar(int id, ImovelDTO ImovelDTO);
}