using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using Million.Book.Comun.Helpers;
using Million.Book.Modelo.EntityModel;

namespace Million.Book.Infraestructura.Repositorio.DBContext
{
    public class MillionConnectionString : DbContext
    {
        public MillionConnectionString(): base(CommonHelpers.Instance.MillionEntitiesConnectionString)
        {
            ((IObjectContextAdapter)this).ObjectContext.CommandTimeout = 0;
        }

        public virtual DbSet<ExceptionControl> ExceptionControl { get; set; }
        public virtual DbSet<Libro> Libro { get; set; }
        public virtual DbSet<Editorial> Editorial { get; set; }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            Database.SetInitializer<MillionConnectionString>(null);
            base.OnModelCreating(modelBuilder);
        }
    }
}