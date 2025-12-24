using Aplicacao.Imobiliaria.DTOs;

namespace Aplicacao.Imobiliaria.Interfaces;

public interface IPesquisaImovelService {
    Task<ImovelPesquisaPaginacaoDTO> Pesquisar(int pagina, int? quartos, decimal? valorInicial, decimal? valorFinal);
    Task<ImovelPesquisaDTO> ObterPorId(int? id);
}