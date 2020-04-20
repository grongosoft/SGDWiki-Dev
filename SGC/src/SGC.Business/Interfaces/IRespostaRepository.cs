using SGC.Business.Models.Entidades;
using System.Threading.Tasks;

namespace SGC.Business.Interfaces
{
    public interface IRespostaRepository : IRepository<Resposta>
    {
        #region Public Methods

        Task<Resposta> ObterRespostaPorPergunta(long perguntaId);

        #endregion Public Methods
    }
}