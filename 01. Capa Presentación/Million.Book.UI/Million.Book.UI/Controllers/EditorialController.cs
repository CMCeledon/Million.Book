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
	public class EditorialController : Controller
	{
		private readonly IEditorialService _service;

		public EditorialController(IEditorialService service)
		{
			_service = service;
		}

		[HttpGet]
		public ActionResult ConsultarEditoriales()
		{
			var response = _service.ConsultarEditoriales();
			return Json(response);
		}
		[HttpGet]
		public ActionResult ConsultarEditorialesByDapper()
		{
			var response = _service.ConsultarEditorialesByDapper();
			return Json(response);
		}
		[HttpPost]
		public ActionResult InsertarEditorial(string nombreParam, string sedeParam)
		{
			EditorialDto editorial = new EditorialDto()
			{
				nombre = nombreParam,
				sede = sedeParam
			};
			var response = _service.InsertarEditorial(editorial);
			return Json(response);
		}

	}
}
