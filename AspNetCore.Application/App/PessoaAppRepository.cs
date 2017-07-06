using AspNetCore.Application.Interface;
using AspNetCore.Domain.Interface;
using AspNetCore.Domain.Entities;

namespace AspNetCore.Application.App
{
	public class PessoaAppRepository : IPessoaAppRepository
	{

		private readonly IPessoa _ipessoa;

		public PessoaAppRepository(IPessoa ipessoa)
		{
			_ipessoa = ipessoa;
		}


		public void Add(Pessoa Entitie)
		{
			_ipessoa.Add(Entitie);
		}

		public void Delete(int Id)
		{
			_ipessoa.Delete(Id);
		}

		public Pessoa GetForId(int id)
		{
			return _ipessoa.GetForId(id);
		}

		public List<Produto> List()
		{
			return _ipessoa.List();
		}

		public void Update(Pessoa Entitie)
		{
			_ipessoa.Update(Entitie);
		}
	}
}
