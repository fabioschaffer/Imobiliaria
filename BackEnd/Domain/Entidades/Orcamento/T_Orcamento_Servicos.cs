using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Dominio.Entidades.Testes
{
    public class T_Orcamento_Servicos
    {
        // PK e FK ao mesmo tempo
        public int OrcamentoId { get; private set; }

        public int preco_hora_pintura { get; set; }
        public int quantidade_horas_pintura { get; set; }

        // Navegação
        public T_Orcamento Orcamento { get; set; }
    }

}