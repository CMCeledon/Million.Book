using System.Data.Entity;
using Million.Book.Infraestructura.Interfaces;
using Million.Book.Modelo.EntityModel;

namespace Million.Book.Infraestructura.Repositorio
{
    public class ExceptionControlRepository : GenericEntityManager, IExceptionControlRepository
    {
        public int InsertarExceptionControl(ExceptionControl loggerParam)
        {
            Database.ExceptionControl.Add(loggerParam);
            return Database.SaveChanges();
        }
    }
}