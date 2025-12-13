using Dominio.Entidades.EnderecoNS;
using Dominio.Entidades.Testes;

namespace Repositorio.Interfaces;

public interface IOrcamentoRepository{
    Task Criar(T_Orcamento orcamento);
}