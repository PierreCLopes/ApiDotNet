namespace ApiDotNet.Models
{
    public class ProdutoPost
    {
        public string Nome { get; set; }
        public float Valor { get; set; }
    }

    public class Produto : ProdutoPost
    {
        public int Id { get; set; }

        public Produto(int id, string nome, float valor)
        {
            Id = id;
            Nome = nome;
            Valor = valor;
        }
    }    
}
