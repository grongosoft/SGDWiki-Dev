using SGC.Business.Interfaces;
using SGC.Business.Models.Entidades;
using SGC.Data.Contexto;

namespace SGC.Data.Repositorios
{
    public class CategoriaRepository : Repository<Categoria>, ICategoriaRepository
    {
        public CategoriaRepository(DataContext context) : base(context)
        {

        }
    }
}