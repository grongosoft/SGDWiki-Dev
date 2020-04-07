using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SGC.Business.Interfaces;
using SGC.Business.Models.Entidades;
using SGC.Data.Contexto;

namespace SGC.Data.Repositorios
{
    public class RespostaRepository : Repository<Resposta>, IRespostaRepository
    {
        public RespostaRepository(DataContext dbContext) : base(dbContext)
        {
        }

        public async Task<Resposta> ObterRespostaPorPergunta(long perguntaId)
        {
            return await _dbContext.Respostas.AsNoTracking()
                .FirstOrDefaultAsync(e => e.PerguntaId == perguntaId);
        }
    }
}