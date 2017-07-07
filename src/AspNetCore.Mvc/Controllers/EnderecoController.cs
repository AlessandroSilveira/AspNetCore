using System;
using System.Collections.Generic;
using AspNetCore.Mvc.Models;
using Microsoft.AspNetCore.Mvc;
using AspNetCore.Application.Interface;

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
				Retorno.Add(new EnderecoModel {EnderecoId = item.EnderecoId, Logradouro = item.Logradouro});
			return View(Retorno);
		}


		/// <summary>
		/// </summary>
		/// <returns></returns>
		[HttpGet]
		public IActionResult Create()
		{
			ViewData["Title"] = "Novo Endereço";
			return View(new EnderecoModel());
		}

		/// <summary>
		/// </summary>
		
		/// <returns></returns>
		[HttpPost]
		public IActionResult Create(EnderecoModel endereco)
		{
			ViewData["Title"] = "Novo Endereco";
			_iEnderecoAppRepository.Add(new Domain.Entities.Endereco {Logradouro = endereco.Logradouro});

			return RedirectToAction("Index");
		}

		/// <summary>
		/// </summary>
		/// <param name="id"></param>
		/// <returns></returns>
		[HttpGet]
		public IActionResult Edit(Guid id)
		{
			ViewData["Title"] = "Editar Endereco";
			var endereco = _iEnderecoAppRepository.GetForId(id);

			return View(new EnderecoModel {EnderecoId = endereco.EnderecoId, Logradouro = endereco.Logradouro});
		}

		/// <summary>
		/// </summary>
		/// <param name="endereco"></param>
		/// <returns></returns>
		[HttpPost]
		public IActionResult Edit(EnderecoModel endereco)
		{
			ViewData["Title"] = "Editar Pessoa";
			var enderecoDados = _iEnderecoAppRepository.GetForId(endereco.EnderecoId);
			enderecoDados.Logradouro = endereco.Logradouro;
			_iEnderecoAppRepository.Update(enderecoDados);
			return RedirectToAction("Index");
		}

		/// <summary>
		/// </summary>
		/// <param name="id"></param>
		/// <returns></returns>
		[HttpGet]
		public IActionResult Delete(Guid id)
		{
			ViewData["Title"] = "Exclusão de Pessoa";
			var enderecoDados = _iEnderecoAppRepository.GetForId(id);

			return View(new EnderecoModel {EnderecoId = enderecoDados.EnderecoId, Logradouro = enderecoDados.Logradouro});
		}

		/// <summary>
		/// </summary>
		/// <param name="endereco"></param>
		/// <returns></returns>
		[HttpPost]
		public IActionResult Delete(EnderecoModel endereco)
		{
			ViewData["Title"] = "Exclusão de Pessoa";
			_iEnderecoAppRepository.Delete(endereco.EnderecoId);
			return RedirectToAction("Index");
		}
	}
}
