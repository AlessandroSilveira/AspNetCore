using AspNetCore.Application.Interface;
using AspNetCore.Mvc.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace AspNetCore.Mvc.Controllers
{
	public class PessoaController : Controller
	{
		private readonly IPessoaAppRepository _iPessoaAppRepository;

		public PessoaController(IPessoaAppRepository iPessoaAppRepository)
		{
			_iPessoaAppRepository = iPessoaAppRepository;
		}

		/// <summary>
		/// Listagem 
		/// </summary>
		/// <returns></returns>
		public IActionResult Index()
		{
			ViewData["Title"] = "Lista de Produto";

			var Lista = _iPessoaAppRepository.List();
			var Retorno = new List<PessoaModel>();
			foreach (var item in Lista)
			{
				Retorno.Add(new PessoaModel { PessoaId = item.PessoaId, Nome = item.Nome });
			}
			return View(Retorno);
		}
		
		/// <summary>
		/// 
		/// </summary>
		/// <returns></returns>
		[HttpGet]
		public IActionResult Create()
		{
			ViewData["Title"] = "Novo Pessoa";
			return View(new PessoaModel());
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="produto"></param>
		/// <returns></returns>
		[HttpPost]
		public IActionResult Create(PessoaModel pessoa)
		{
			ViewData["Title"] = "Novo Pessoa";
			_iPessoaAppRepository.Add(new Domain.Entities.Pessoa { Nome = pessoa.Nome });

			return RedirectToAction("Index");
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="id"></param>
		/// <returns></returns>
		[HttpGet]
		public IActionResult Edit(Guid id)
		{
			ViewData["Title"] = "Editar Pessoa";
			var pessoa = _iPessoaAppRepository.GetForId(id);

			return View(new PessoaModel { PessoaId = pessoa.PessoaId, Nome = pessoa.Nome });
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="produto"></param>
		/// <returns></returns>
		[HttpPost]
		public IActionResult Edit(PessoaModel pessoa)
		{
			ViewData["Title"] = "Editar Pessoa";
			var pessoadados = _iPessoaAppRepository.GetForId(pessoa.PessoaId);
			pessoadados.Nome = pessoa.Nome;
			_iPessoaAppRepository.Update(pessoadados);
			return RedirectToAction("Index");
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="id"></param>id
		/// <returns></returns>
		[HttpGet]
		public IActionResult Delete(Guid id)
		{
			ViewData["Title"] = "Exclusão de Pessoa";
			var pessoa = _iPessoaAppRepository.GetForId(id);

			return View(new PessoaModel { PessoaId = pessoa.PessoaId, Nome = pessoa.Nome });
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="produto"></param>
		/// <returns></returns>
		[HttpPost]
		public IActionResult Delete(PessoaModel pessoa)
		{
			ViewData["Title"] = "Exclusão de Pessoa";
			_iPessoaAppRepository.Delete(pessoa.PessoaId);
			return RedirectToAction("Index");
		}

	}
}
