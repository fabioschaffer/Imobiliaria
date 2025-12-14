using Aplicacao.Endereco.DTOs;
using Aplicacao.Interfaces.T_Orcamento;
using Dominio.Entidades.EnderecoNS;
using Dominio.Entidades.Testes;
using Repositorio.Interfaces;
using Repositorio.Repositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplicacao.Servicos.T_Orcamento
{
    public class T_OrcamentoService : IOrcamentoService
    {

        private IOrcamentoRepository OrcamentoRepository;

        public T_OrcamentoService(IOrcamentoRepository orcamentoRepository)
        {
                
            OrcamentoRepository = orcamentoRepository;
        }

        public async Task Criar()
        {

            var orcamento = new Dominio.Entidades.Testes.T_Orcamento
            {
                Numero = 10,
                Versao = 1,
                Servicos = new T_Orcamento_Servicos
                {
                    preco_hora_pintura = 120,
                    quantidade_horas_pintura = 5
                }
            };

            await OrcamentoRepository.Criar(orcamento);
        }

        public async Task ObterPorId(int? id)
        {
            if (id == null)
            {
                throw new ArgumentNullException(nameof(id), "Id cannot be null.");
            }

            var orcamento = await OrcamentoRepository.ObterPorId(id);

            if (orcamento == null)
            {
                throw new KeyNotFoundException($"Orcamento with Id {id} not found.");
            }
            orcamento.GetHashCode();
        }
    }
}