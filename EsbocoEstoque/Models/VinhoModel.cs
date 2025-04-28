namespace EsbocoEstoque.Models
{
    public class VinhoModel
    {
        public int VinhoId { get; set; }
        public string? Nome { get; set; }
        public string? Descricao { get; set; }
        public string? PaisOrigem { get; set; }
        public DateTime DataProduzido { get; set; }
        public int Preco { get; set; }
        public int Quantidade { get; set; }
        public string? Tipo { get; set; }
    }
}