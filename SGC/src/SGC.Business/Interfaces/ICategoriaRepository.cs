using System.Threading.Tasks;
using SGC.Business.Models.Entidades;

namespace SGC.Business.Interfaces
{
    public interface ICategoriaRepository : IRepository<Categoria>
    {
        Task<Categoria> ObterCategoriaPorId(long id);
    }
}