using System;
using SGC.Business.Models.Entidades;
using System.Threading.Tasks;

namespace SGC.Business.Interfaces
{
    public interface ICategoriaService : IDisposable
    {
        #region Public Methods

        Task Atualizar(Categoria categoria);

        Task Criar(Categoria categoria);

        Task Remover(long Id);

        #endregion Public Methods
    }
}