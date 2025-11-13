using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class UnidadeFederacao
    {
        public int Id { get; private set; }
        public string Nome { get; private set; }

        public UnidadeFederacao(int id, string nome)
        {
            Id = id;
            Nome = nome;
        }
    }
}
