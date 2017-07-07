﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspNetCore.Application.Interface
{
	public interface IAppRepository<T> where T : class
	{
		void Add(T Entitie);

		void Update(T Entitie);

		void Delete(int Id);

		List<T> List();

		T GetForId(int id);
	}
}