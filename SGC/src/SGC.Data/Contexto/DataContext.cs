using System.Linq;
using Microsoft.EntityFrameworkCore;
using SGC.Business.Models.Entidades;

namespace SGC.Data.Contexto
{
    public class DataContext : DbContext
    {
        #region Public Constructors

        public DataContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<Categoria> Categorias { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            foreach (var relationship in modelBuilder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys())) relationship.DeleteBehavior = DeleteBehavior.ClientSetNull;

            base.OnModelCreating(modelBuilder);
        }

        #endregion Public Constructors
    }
}