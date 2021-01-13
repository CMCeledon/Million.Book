using System.Collections.Generic;
using System.Data.Entity;
using Million.Book.Comun.Enumerators;
using Million.Book.Comun.Helpers;
using Million.Book.Infraestructura.Interfaces;
using System.Linq;
using Million.Book.Modelo.EntityModel;

namespace Million.Book.Infraestructura.Repositorio
{
	public class EditorialRepository : IEditorialRepository
	{
		private readonly MillionEntities ctxModel;
		public EditorialRepository(MillionEntities context)
		{
			ctxModel = context;
		}
		public List<Editorial> ConsultarEditoriales()
		{
			return ctxModel.Editorial.ToList();
		}

		public List<Editorial> ConsultarEditorialesByDapper()
		{
			var nombreProcedimiento = EnumsQuerys.ConsultarEditorialesByDapper;
			var resultQuery = DapperHelper.Instance.QuerySP<Editorial>(nombreProcedimiento, null).ToList();
			return resultQuery;
		}

		public int InsertarEditorial(Editorial editorial)
		{
			ctxModel.Editorial.Add(editorial);
			return ctxModel.SaveChanges();
		}
	}
}