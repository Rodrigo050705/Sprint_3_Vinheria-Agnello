namespace EsbocoEstoque.Models
{
    public class MovimentacoesModel
    {
        public int MovimentacaoId { get; set; }
        public int ProdutoId { get; set; }
        public string? TipoMovimentacao { get; set; }
        public int QtnMovimentada { get; set; }
        public boolean? Validacao { get; set; }

    }
}