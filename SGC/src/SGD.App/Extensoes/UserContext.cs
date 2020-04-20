using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using SGD.App.Data;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;

namespace SGD.App.Extensoes
{
    public abstract class UserContext<TEntity> : ICustomUsers<TEntity> where TEntity : IdentityUser, new()
    {
        #region Protected Fields

        protected readonly DbSet<IdentityUser> _dbSet;

        #endregion Protected Fields

        #region Private Fields

        private readonly IHttpContextAccessor _contextAccessor;
        private readonly IdentityContext _idContext;

        #endregion Private Fields

        #region Public Constructors

        public UserContext(IdentityContext idContext, IHttpContextAccessor contextAccessor)
        {
            _idContext = idContext;
            _contextAccessor = contextAccessor;
            _dbSet = _idContext.Set<IdentityUser>();
        }

        #endregion Public Constructors

        #region Public Methods

        public void Dispose()
        {
            _idContext?.Dispose();
        }

        public async Task<List<IdentityUser>> ListarUsuarios()
        {
            return await _dbSet.ToListAsync();
        }

        public string ObterUsuarioLogado()
        {
            return _contextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier);
        }

        public async Task<IdentityUser> ObterUsuarioPorEmail(string email)
        {
            return _dbSet.Find(email);
        }

        #endregion Public Methods
    }
}