using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspNetCore.Mvc.Controllers
{
    public class EnderecoController : Controller
    {
		private readonly IEnderecoAppRepository _iEnderecoAppRepository;

		public EnderecoController(IEnderecoAppRepository iEnderecoAppRepository)
		{
			_iEnderecoAppRepository = iEnderecoAppRepository;
		}

		public IActionResult Index()
		{
			ViewData["Title"] = "Lista de Endereço";

			var Lista = _iEnderecoAppRepository.List();
			var Retorno = new List<EnderecoModel>();
			foreach (var item in Lista)
			{
				Retorno.Add(new Models.EnderecoModel { EnderecoId = item.EnderecoId, Logradouro = item.Logradouro });
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
			ViewData["Title"] = "Novo Endereço";
			return View(new EnderecoModel());
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="produto"></param>
		/// <returns></returns>
		[HttpPost]
		public IActionResult Create(EnderecoModel endereco)
		{
			ViewData["Title"] = "Novo Endereco";
			_iEnderecoAppRepository.Add(new Entities.Endereco { Logradouro = endereco.Logradouro });

			return RedirectToAction("Index");
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="id"></param>
		/// <returns></returns>
		[HttpGet]
		public IActionResult Edit(int EnderecoId)
		{
			ViewData["Title"] = "Editar Endereco";
			var pessoa = _iEnderecoAppRepository.GetForId(id);

			return View(new EnderecoModel { EnderecoId = pessoa.PessoaId, Nome = pessoa.Nome });
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
