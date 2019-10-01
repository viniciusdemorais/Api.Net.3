using System.ComponentModel.DataAnnotations;

namespace Api.Entity.Entity
{
	public class Cidade
	{
		[Key]
		public int IdCidade { get; set; }
		public string Nome { get; set; }
	}
}
