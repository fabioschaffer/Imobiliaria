using Dominio.Entidades.EnderecoNS;
using Dominio.Entidades.Testes;
using Repositorio.Contexto;
using Repositorio.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositorio.Repositorios
{
    public class OrcamentoRepository : IOrcamentoRepository
    {

        private AplicacaoDbContext contexto;

        public OrcamentoRepository(AplicacaoDbContext contexto)
        {
            this.contexto = contexto;
        }

        public async Task Criar(T_Orcamento orcamento)
        {
            contexto.Add(orcamento);
            await contexto.SaveChangesAsync();
        }
    }
}
