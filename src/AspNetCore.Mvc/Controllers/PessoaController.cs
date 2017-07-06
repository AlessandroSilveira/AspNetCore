using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Interface;
using WebSite.Models;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

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
				Retorno.Add(new Models.PessoaModel { PessoaId = item.PessoaId, Nome = item.Nome });
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
		public IActionResult Create(PessoaModel produto)
		{
			ViewData["Title"] = "Novo Pessoa";
			_iPessoaAppRepository.Add(new Entities.Pessoa { Nome = pessoa.Nome });

			return RedirectToAction("Index");
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="id"></param>
		/// <returns></returns>
		[HttpGet]
		public IActionResult Edit(int Pessoaid)
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
		public IActionResult Edit(PessoaModel produto)
		{
			ViewData["Title"] = "Editar Pessoa";
			var pessoa = _iPessoaAppRepository.GetForId(produto.Id);
			pessoa.Nome = pessoa.Nome;
			_iPessoaAppRepository.Update(pessoa);
			return RedirectToAction("Index");
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="id"></param>
		/// <returns></returns>
		[HttpGet]
		public IActionResult Delete(int id)
		{
			ViewData["Title"] = "Exclusão de Pessoa";
			var pessoa = _iPessoaAppRepository.GetForId(id);

			return View(new PessoaModel { Id = pessoa.PessoaId, Nome = pessoa.Nome });
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
