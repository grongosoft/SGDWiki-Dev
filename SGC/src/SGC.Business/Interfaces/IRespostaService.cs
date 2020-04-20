using SGC.Business.Models.Entidades;
using System;
using System.Threading.Tasks;

namespace SGC.Business.Interfaces
{
    public interface IRespostaService : IDisposable
    {
        #region Public Methods

        Task Adicionar(Resposta resposta);

        Task Atualizar(Resposta resposta);

        Task Remover(long id);

        #endregion Public Methods
    }
}