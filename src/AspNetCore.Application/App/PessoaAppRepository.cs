using AspNetCore.Application.Interface;
using AspNetCore.Domain.Interface;
using AspNetCore.Domain.Entities;
using System.Collections.Generic;
using System;

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

		public void Delete(Guid Id)
		{
			_ipessoa.Delete(Id);
		}

		public Pessoa GetForId(Guid id)
		{
			return _ipessoa.GetForId(id);
		}

		public List<Pessoa> List()
		{
			return _ipessoa.List();
		}

		public void Update(Pessoa Entitie)
		{
			_ipessoa.Update(Entitie);
		}
	}
}
