﻿using AspNetCore.Application.Interface;
using AspNetCore.Domain.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace AspNetCore.Application.App
{
    public class EnderecoAppRepository : IEnderecoAppRepository
    {
		private readonly IEndereco _iendereco;


		public EnderecoAppRepository(IEndereco iendereco)
		{
			_iendereco = iendereco;
		}

		public void Add(Endereco Entitie)
		{
			_iendereco.Add(Entitie);
		}

		public void Delete(int Id)
		{
			_iendereco.Delete(Id);
		}

		public Pessoa GetForId(int id)
		{
			return _iendereco.GetForId(id);
		}

		public List<Endereco> List()
		{
			return _iendereco.List();
		}

		public void Update(Endereco Entitie)
		{
			_iendereco.Update(Entitie);
		}
	}
}
