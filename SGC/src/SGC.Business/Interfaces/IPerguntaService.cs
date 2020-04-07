using SGC.Business.Models.Entidades;
using System;
using System.Threading.Tasks;

namespace SGC.Business.Interfaces
{
    public interface IPerguntaService : IDisposable
    {
        #region Public Methods

        Task Adicionar(Pergunta resposta);

        Task Atualizar(Pergunta resposta);

        Task Remover(long id);

        #endregion Public Methods
    }
}