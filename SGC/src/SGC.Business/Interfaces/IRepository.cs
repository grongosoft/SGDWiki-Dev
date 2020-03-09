using SGC.Business.Models.Entidades;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace SGC.Business.Interfaces
{
    public interface IRepository<TEntity> : IDisposable where TEntity : Entity
    {
        #region Public Methods

        Task Atualizar(TEntity entity);

        Task<IEnumerable<TEntity>> Buscar(Expression<Func<TEntity, bool>> predicate);

        Task Criar(TEntity entity);

        Task Excluir(long id);

        Task<List<TEntity>> Listar();

        Task<Entity> ObterPorId(long id);

        Task<long> Salvar();

        #endregion Public Methods
    }
}