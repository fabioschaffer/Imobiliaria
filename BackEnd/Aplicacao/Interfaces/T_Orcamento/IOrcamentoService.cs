using Aplicacao.Endereco.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplicacao.Interfaces.T_Orcamento
{
    public interface IOrcamentoService
    {
        Task Criar();
        Task ObterPorId(int? id);
        void Processar();
    }
}
