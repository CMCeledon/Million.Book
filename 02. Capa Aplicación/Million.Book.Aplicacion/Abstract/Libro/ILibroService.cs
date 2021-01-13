using System.Data;
using Million.Book.Aplicacion.Helpers;
using Million.Book.Comun.Dto;

namespace Million.Book.Aplicacion.Abstract
{
    public interface ILibroService
    {
        ResponseServices<int> InsertarLibro(LibroDto libro);
    }
}
