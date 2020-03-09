using Microsoft.EntityFrameworkCore;
using SGC.Business.Interfaces;
using SGC.Business.Models.Entidades;
using SGC.Data.Contexto;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace SGC.Data.Repositorios
{
    public abstract class Repository<TEntity> : IRepository<TEntity> where TEntity : Entity, new()
    {
        #region Protected Fields

        protected readonly DataContext _dbContext;
        protected readonly DbSet<TEntity> _dbSet;

        #endregion Protected Fields

        #region Public Constructors

        public Repository(DataContext dbContext)
        {
            _dbContext = dbContext;
            _dbSet = dbContext.Set<TEntity>();
        }

        #endregion Public Constructors

        #region Public Methods

        //TODO ADICIONAR RESTANTE DA IMPLEMENTAÇÃO
        public Task Atualizar(TEntity entity)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<TEntity>> Buscar(Expression<Func<TEntity, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public Task Criar(TEntity entity)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public Task Excluir(long id)
        {
            throw new NotImplementedException();
        }

        public Task<List<TEntity>> Listar()
        {
            throw new NotImplementedException();
        }

        public Task<Entity> ObterPorId(long id)
        {
            throw new NotImplementedException();
        }

        public Task<long> Salvar()
        {
            throw new NotImplementedException();
        }

        #endregion Public Methods
    }
}