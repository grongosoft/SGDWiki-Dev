using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using SGD.App.Data;

namespace SGD.App.Extensoes
{
    public abstract class UserContext<TEntity> : ICustomUsers<TEntity> where TEntity : IdentityUser, new()
    {
        private readonly IdentityContext _idContext;
        protected readonly DbSet<IdentityUser> _dbSet;
        private readonly IHttpContextAccessor _contextAccessor;

        public UserContext(IdentityContext idContext, IHttpContextAccessor contextAccessor)
        {
            _idContext = idContext;
            _contextAccessor = contextAccessor;
            _dbSet = _idContext.Set<IdentityUser>();
        }

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
           return   _contextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier);
        }
    }
}