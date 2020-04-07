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
        public DbSet<Pergunta> Perguntas { get; set; }
        public DbSet<Resposta> Respostas { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(DataContext).Assembly);

            foreach (var relationship in modelBuilder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys())) relationship.DeleteBehavior = DeleteBehavior.ClientSetNull;

            base.OnModelCreating(modelBuilder);
        }

        #endregion Public Constructors
    }
}