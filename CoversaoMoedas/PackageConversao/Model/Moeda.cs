namespace PackageConversao.Model
{
    public class Moeda
    {
        public string Nome { get; private set; }
        public double Valor { get; private set; }
        public double Cotacao { get; private set; }

        public Moeda(string nome, double valor, double cotacao)
        {
            Nome = nome;
            Valor = valor;
            Cotacao = cotacao;
        }
    }
}
