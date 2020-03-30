using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace SGD.App.Extensoes
{
    public interface ICustomUsers<TEntity> : IDisposable where TEntity : IdentityUser
    {
        Task<List<IdentityUser>> ListarUsuarios();
        string ObterUsuarioLogado();
    }
}