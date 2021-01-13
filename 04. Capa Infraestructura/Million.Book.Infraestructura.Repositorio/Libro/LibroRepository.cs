using System.Data.Entity;
using Million.Book.Infraestructura.Interfaces;
using Million.Book.Modelo.EntityModel;

namespace Million.Book.Infraestructura.Repositorio
{
	public class LibroRepository : ILibroRepository
	{
		private readonly MillionEntities ctxModel;
		public LibroRepository(MillionEntities context)
		{
			ctxModel = context;
		}
		public int InsertarLibro(Libro libro)
		{
			ctxModel.Libro.Add(libro);
			return ctxModel.SaveChanges();
		}

	}
}