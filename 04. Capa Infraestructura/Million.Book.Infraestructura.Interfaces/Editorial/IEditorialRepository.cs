using Million.Book.Modelo.EntityModel;
using System.Collections.Generic;

namespace Million.Book.Infraestructura.Interfaces
{
    public interface IEditorialRepository
    {
        List<Editorial> ConsultarEditoriales();
        List<Editorial> ConsultarEditorialesByDapper();
        int InsertarEditorial(Editorial editorial);
    }
}