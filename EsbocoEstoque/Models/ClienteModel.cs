namespace EsbocoEstoque.Models
{
	public class ClienteModel
	{
		public int ClienteId { get; set; }
		public string? Nome { get; set; }
		public string? Sobrenome { get; set; }
		public string? Email { get; set; }
		public DateTime DataNascimento { get; set; }
		public string? Descricao { get; set; }

	}
}