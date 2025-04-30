namespace EsbocoEstoque.Models
{
    public class VinhoModel
    {
        public int VinhoId { get; set; }
        public string? NomeVinho { get; set; }
        public string? PaisOrigem { get; set; }
        public DateTime DataProduzido { get; set; }
        public int Preco { get; set; }
        public int Quantidade { get; set; }
        public string? TipoVinho { get; set; }
        public string? DescricaoVinho { get; set; }
    }
}