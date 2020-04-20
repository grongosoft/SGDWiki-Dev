using SGC.Business.Interfaces;
using SGC.Business.Models.Entidades;
using SGC.Common.Enum;
using SGC.Data.Contexto;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SGC.Data.Repositorios
{
    public class PerguntaRepository : Repository<Pergunta>, IPerguntaRepository
    {
        #region Private Fields

        private ELike like;

        #endregion Private Fields

        #region Public Constructors

        public PerguntaRepository(DataContext dbContext) : base(dbContext)
        {
        }

        #endregion Public Constructors

        #region Public Methods

        public Task<List<Pergunta>> ObterPerguntaPorDescricao(string descricao, string email, long? categoriaId, long? likeId)
        {
            var perguntaResult = new List<Pergunta>();

            if (!string.IsNullOrEmpty(descricao) && categoriaId == null && string.IsNullOrEmpty(email))
                perguntaResult = RespostaComPesquisa(descricao, email, null, likeId);
            else if (!string.IsNullOrEmpty(descricao) && categoriaId != null)
                perguntaResult = RespostaComPesquisa(descricao, email, categoriaId, likeId);
            else if (string.IsNullOrEmpty(email) && categoriaId == null && likeId == null && string.IsNullOrEmpty(descricao))
                perguntaResult = _dbContext.Perguntas.Take(100).ToList();
            else if (!string.IsNullOrEmpty(email) && categoriaId != null)
                perguntaResult = _dbContext.Perguntas.Where(p => p.OperadorId == email && p.CategoriaId == categoriaId).ToList();
            else if (string.IsNullOrEmpty(descricao) && categoriaId == null && !string.IsNullOrEmpty(email))
                perguntaResult = _dbContext.Perguntas.Where(p => p.OperadorId == email).ToList();
            else if (!string.IsNullOrEmpty(descricao) && categoriaId != null && !string.IsNullOrEmpty(email))
                perguntaResult = RespostaComPesquisa(descricao, email, categoriaId, likeId);
            else if (!string.IsNullOrEmpty(descricao) && categoriaId == null && !string.IsNullOrEmpty(email))
                perguntaResult = RespostaComPesquisa(descricao, email, null, likeId);
            else
                perguntaResult = _dbContext.Perguntas.Take(100).ToList();

            return perguntaResult.ToAsyncEnumerable().ToList();
        }

        public async Task<Pergunta> ObterPerguntaPorId(long perguntaId)
        {
            return _dbContext.Perguntas.FirstOrDefault(p => p.Id == perguntaId);
        }

        #endregion Public Methods

        #region Private Methods

        private List<Pergunta> RespostaComPesquisa(string descricao, string email, long? categoriaId, long? likeId)
        {
            var perguntaResult = new List<Pergunta>();

            if (likeId.HasValue)
            {
                like = (ELike)likeId.Value;

                switch (like)
                {
                    case ELike.Exatamente:
                        {
                            var query = _dbContext.Perguntas.Where(p => p.Descricao.Equals(descricao)).ToList();

                            if (!string.IsNullOrWhiteSpace(email))
                            {
                                query = query.Where(p => p.OperadorId == email).ToList();
                            }

                            if (categoriaId.HasValue)
                            {
                                query = query.Where(p => p.CategoriaId == categoriaId.Value).ToList();
                            }

                            perguntaResult = query;
                            break;
                        }

                    case ELike.ComecandoCom:
                        {
                            var query = _dbContext.Perguntas.Where(p => p.Descricao.StartsWith(descricao)).ToList();

                            if (!string.IsNullOrWhiteSpace(email))
                            {
                                query = query.Where(p => p.OperadorId == email).ToList();
                            }

                            if (categoriaId.HasValue)
                            {
                                query = query.Where(p => p.CategoriaId == categoriaId.Value).ToList();
                            }

                            perguntaResult = query;
                            break;
                        }

                    case ELike.TerminandoCom:
                        {
                            var query = _dbContext.Perguntas.Where(p => p.Descricao.EndsWith(descricao)).ToList();

                            if (!string.IsNullOrWhiteSpace(email))
                            {
                                query = query.Where(p => p.OperadorId == email).ToList();
                            }

                            if (categoriaId.HasValue)
                            {
                                query = query.Where(p => p.CategoriaId == categoriaId.Value).ToList();
                            }

                            perguntaResult = query;
                            break;
                        }

                    case ELike.QueContenha:

                    default:
                        {
                            var query = _dbContext.Perguntas.Where(p => p.Descricao.Contains(descricao)).ToList().Take(100);

                            if (!string.IsNullOrWhiteSpace(email))
                            {
                                query = query.Where(p => p.OperadorId == email).ToList();
                            }

                            if (categoriaId.HasValue)
                            {
                                query = query.Where(p => p.CategoriaId == categoriaId.Value).ToList();
                            }

                            perguntaResult = query.ToList();
                            break;
                        }
                }
            }

            return perguntaResult;
        }

        #endregion Private Methods
    }
}