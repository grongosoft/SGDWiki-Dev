using SGC.Business.Interfaces;
using SGC.Business.Models.Entidades;
using SGC.Data.Contexto;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace SGC.Data.Repositorios
{
    public class CategoriaRepository : Repository<Categoria>, ICategoriaRepository
    {
        public CategoriaRepository(DataContext context) : base(context)
        {

        }

        public async Task<Categoria> ObterCategoriaPorId(long id)
        {
            return await _dbContext.Categorias.AsNoTracking().FirstOrDefaultAsync(c => c.Id == id);
        }
    }
}