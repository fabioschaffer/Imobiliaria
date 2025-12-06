using Aplicacao.DTOs.Imovel;
using Aplicacao.Endereco.DTOs;
using Aplicacao.Endereco.Interfaces;
using Aplicacao.Interfaces.ImovelNS;
using Dominio.Entidades.EnderecoNS;
using Repositorio.Interfaces;
using Repositorio.Interfaces.ImovelNS;

namespace Aplicacao.Servicos.Imovel;
public class TipoService : ITipoService {

    private ITipoRepository repository;

    public TipoService(ITipoRepository repository) {
        this.repository = repository;   
    }

    public async Task<IEnumerable<TipoDTO>> ObterTodos() {
        var tipos = await repository.ObterTodos();

        return tipos.Select(uf => new TipoDTO {
            Id = uf.Id,
            Descricao = uf.Descricao
        });
    }
}
