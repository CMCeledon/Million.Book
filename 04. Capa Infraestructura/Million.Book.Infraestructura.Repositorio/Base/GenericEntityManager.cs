using Million.Book.Infraestructura.Interfaces;
using Million.Book.Infraestructura.Repositorio.DBContext;

namespace Million.Book.Infraestructura.Repositorio
{
    public class GenericEntityManager : IGenericEntityManager
    {
        private readonly MillionConnectionString _baseDeDatos;

        public GenericEntityManager()
        {
            _baseDeDatos = new MillionConnectionString();
        }
        protected internal MillionConnectionString Database
        {
            get { return _baseDeDatos; }
        }
    }
}