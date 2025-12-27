using Aplicacao.DTOs.Ibge;
using Aplicacao.Endereco.DTOs;
using Aplicacao.Endereco.Interfaces;
using Dominio.Entidades.EnderecoNS;
using Microsoft.Extensions.Logging;
using Repositorio.Interfaces;

namespace Aplicacao.Endereco.Servicos;

public class UnidadeFederacaoService(
        IUnidadeFederacaoRepository unidadeFederacaoRepository,
        IIbgeApi ibgeApi,
        ILogger<UnidadeFederacaoService> logger) : IUnidadeFederacaoService {

    public async Task<int> Criar(UnidadeFederacaoDTO unidadeFederacaoDTO) {

        var unidadeFederacao = new UnidadeFederacao(unidadeFederacaoDTO.Nome);

        await unidadeFederacaoRepository.Criar(unidadeFederacao);

        return unidadeFederacao.Id;
    }

    public async Task Atualizar(int id, UnidadeFederacaoDTO unidadeFederacaoDTO) {
        var unidadeFederacao = await unidadeFederacaoRepository.ObterPorId(id);

        if (unidadeFederacao == null)
            throw new KeyNotFoundException($"UnidadeFederacao with Id {id} not found.");

        unidadeFederacao.Atualizar(unidadeFederacaoDTO.Nome);

        await unidadeFederacaoRepository.Atualizar(unidadeFederacao);
        //logger.LogInformation($"UnidadeFederacao com Id {id} atualizada com sucesso. Dados recebidos do Dto: {@unidadeFederacaoDTO}");
        //logger.LogInformation("Unidade Federativa atualizada " + $"ID: {id}" + ": {@UF}", unidadeFederacaoDTO);

        //Exemplo via serilog. Salva o objeto e seus valores no log.
        logger.LogInformation("Unidade Federativa atualizada, v2, {@id}, {@UF}", id, unidadeFederacaoDTO);
    }

    public async Task Excluir(int? id) {
        var unidadeFederacao = await unidadeFederacaoRepository.ObterPorId(id);

        if (unidadeFederacao == null)
            throw new KeyNotFoundException($"UnidadeFederacao with Id {id} not found.");

        await unidadeFederacaoRepository.Excluir(unidadeFederacao);
    }

    public async Task ExcluirTudo() {
        await unidadeFederacaoRepository.ExcluirTudo();
    }

    public async Task<UnidadeFederacaoDTO> ObterPorId(int? id) {
        if (id == null) {
            throw new ArgumentNullException(nameof(id), "Id cannot be null.");
        }

        var unidadeFederacao = await unidadeFederacaoRepository.ObterPorId(id);

        if (unidadeFederacao == null) {
            throw new KeyNotFoundException($"UnidadeFederacao with Id {id} not found.");
        }

        return new UnidadeFederacaoDTO {
            Id = unidadeFederacao.Id,
            Nome = unidadeFederacao.Nome
        };
    }
    public async Task<IEnumerable<UnidadeFederacaoDTO>> ObterUnidadesFederacao() {
        var unidadesFederacao = await unidadeFederacaoRepository.ObterUnidadesFederacao();

        return unidadesFederacao.Select(uf => new UnidadeFederacaoDTO {
            Id = uf.Id,
            Nome = uf.Nome
        });
    }

    public async Task ObterUfsDoIbge() {
        var ufs = await ibgeApi.GetUfsAsync();

        foreach (var item in ufs) {
            var ufACriar = new UnidadeFederacaoDTO() {
                Id = item.Id,
                Nome = item.Nome
            };

            await Criar(ufACriar);
        }
    }
}