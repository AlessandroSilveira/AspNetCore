using AspNetCore.Domain.Entities;
using System;

namespace AspNetCore.Mvc.Models
{
	public class EnderecoModel
    {
		public EnderecoModel()
		{
			EnderecoId = Guid.NewGuid();
		}
		public Guid EnderecoId { get; set; }
		public string Logradouro { get; set; }
		public string Complemento { get; set; }
		public string Numero { get; set; }
		public string Bairro { get; set; }
		public string CEP { get; set; }
		public string Cidade { get; set; }
		public string Estado { get; set; }
		public Guid PessoaId { get; set; }
		public virtual Pessoa Pessoa { get; set; }
	}
}
