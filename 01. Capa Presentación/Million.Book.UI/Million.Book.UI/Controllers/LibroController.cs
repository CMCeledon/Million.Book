using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Million.Book.Aplicacion.Abstract;
using Million.Book.Comun.Dto;
using Million.Book.UI.Models;

namespace Million.Book.UI.Controllers
{
	public class LibroController : Controller
	{
		private readonly ILibroService _service;

		public LibroController(ILibroService service)
		{
			_service = service;
		}

		public IActionResult InsertarLibro()
		{
			return View();
		}

		[HttpPost]
		public ActionResult InsertarLibro(long idEditorialParam, int isbmParam, string tituloParam, string sinpsisParam, string numeroPaginaParam)
		{
			LibroDto libro = new LibroDto()
			{
				titulo = tituloParam,
				idEditorial = idEditorialParam,
				isbn = isbmParam,
				sinopsis = sinpsisParam,
				numeroPagina = numeroPaginaParam
			};
			var response = _service.InsertarLibro(libro);
			return RedirectToAction("index", "home");
		}

	}
}
