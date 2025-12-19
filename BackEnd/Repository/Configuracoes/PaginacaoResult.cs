using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositorio.Configuracoes
{
    public class PaginacaoResult<T>
    {
        public int PaginaAtual { get; set; }
        public int TamanhoPagina { get; set; }
        public int TotalRegistros { get; set; }
        public int TotalPaginas =>
            (int)Math.Ceiling((double)TotalRegistros / TamanhoPagina);

        public List<T> Itens { get; set; } = new();
    }
}
