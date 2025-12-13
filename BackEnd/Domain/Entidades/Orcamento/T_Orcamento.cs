namespace Dominio.Entidades.Testes
{
    public class T_Orcamento
    {
        public int Id { get; private set; }

        public int Numero { get; set; }
        public int Versao { get; set; }

        // Navegação 1:1
        public T_Orcamento_Servicos Servicos { get; set; }
    }
}