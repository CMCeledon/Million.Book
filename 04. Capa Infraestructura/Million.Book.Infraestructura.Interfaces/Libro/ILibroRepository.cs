using Million.Book.Modelo.EntityModel;

namespace Million.Book.Infraestructura.Interfaces
{
    public interface ILibroRepository
    {
        int InsertarLibro(Libro loggerParam);
    }
}