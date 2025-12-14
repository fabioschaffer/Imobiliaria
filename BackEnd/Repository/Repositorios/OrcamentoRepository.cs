using Dominio.Entidades.EnderecoNS;
using Dominio.Entidades.Testes;
using Microsoft.EntityFrameworkCore;
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

        public async Task<T_Orcamento> ObterPorId(int? id)
        {
            if (id == null)
            {
                throw new ArgumentNullException(nameof(id), "O ID não pode ser nulo.");
            }

            var orcamento = await contexto.Orcamentos.Include(x => x.Servicos).FirstOrDefaultAsync(x => x.Id == id);

            if (orcamento == null)
            {
                throw new KeyNotFoundException($"Nenhum Orcamento encontrado com o ID {id}.");
            }

            return orcamento;
        }
    }
}
