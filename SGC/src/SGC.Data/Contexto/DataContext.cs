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


        //TODO ADICIONAR RESTANTE DA IMPLEMENTAÇÃO

        #endregion Public Constructors
    }
}