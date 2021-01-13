using System.Collections.Generic;
using System.Data;
using Million.Book.Aplicacion.Helpers;
using Million.Book.Comun.Dto;

namespace Million.Book.Aplicacion.Abstract
{
    public interface IEditorialService
    {
        ResponseServices<List<EditorialDto>> ConsultarEditoriales();
        ResponseServices<List<EditorialDto>> ConsultarEditorialesByDapper();
        ResponseServices<int> InsertarEditorial(EditorialDto editorial);

    }
}
