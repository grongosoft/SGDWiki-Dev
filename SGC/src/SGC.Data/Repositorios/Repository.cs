using Microsoft.EntityFrameworkCore;
using SGC.Business.Interfaces;
using SGC.Business.Models.Entidades;
using SGC.Data.Contexto;
using System;
using System.Collections.Generic;
using System.Linq;
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

        public virtual async Task Atualizar(TEntity entity)
        {
            _dbSet.Update(entity);
            await Salvar();
        }

        public virtual async Task<IEnumerable<TEntity>> Buscar(Expression<Func<TEntity, bool>> predicate)
        {
            return await _dbSet.AsNoTracking().Where(predicate).ToArrayAsync();
        }

        public virtual async Task Criar(TEntity entity)
        {
            _dbSet.Add(entity);
            await Salvar();
        }

        public void Dispose()
        {
            _dbContext?.Dispose();
        }

        public virtual async Task Excluir(long id)
        {
            _dbSet.Remove(new TEntity { Id = id });

            await Salvar();
        }

        public virtual async Task<List<TEntity>> Listar()
        {
            return await _dbSet.ToListAsync();
        }

        public virtual async Task<Entity> ObterPorId(long id)
        {
            return await _dbSet.FindAsync(id);
        }

        public async Task<long> Salvar()
        {
            return await _dbContext.SaveChangesAsync();
        }

        #endregion Public Methods
    }
}