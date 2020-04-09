using SGC.Business.Interfaces;
using SGC.Business.Models.Entidades;
using SGC.Data.Contexto;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace SGC.Data.Repositorios
{
    public class PerguntaRepository : Repository<Pergunta>, IPerguntaRepository
    {
        #region Public Constructors

        public PerguntaRepository(DataContext dbContext) : base(dbContext)
        {
        }

        public async Task<Pergunta> ObterPerguntaPorId(long perguntaId)
        {
           return _dbContext.Perguntas.FirstOrDefault(e => e.Id == perguntaId);
        }

        #endregion Public Constructors

        #region Public Methods

        public async Task<Pergunta> ObterPerguntaRepostaPorCategoria(long categoriaId)
        {
            throw new NotImplementedException();
        }

        public Task<Pergunta> ObterPerguntaRepostaPorUsuario(long usuarioId)
        {
            throw new NotImplementedException();
        }

        #endregion Public Methods
    }
}