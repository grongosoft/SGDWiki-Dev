using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SGD.App.Data;

namespace SGD.App.Configuracoes
{
    public static class IdentityConfig
    {
        #region Public Methods

        public static IServiceCollection AdicionarIdentityDeConfiguracao(this IServiceCollection servicos, IConfiguration configuracoes)
        {
            servicos.Configure<CookiePolicyOptions>(options =>
            {
                options.CheckConsentNeeded = contexto => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });

            servicos.AddDefaultIdentity<IdentityUser>()
                .AddDefaultUI(UIFramework.Bootstrap4)
                .AddEntityFrameworkStores<IdentityContext>();

            servicos.AddDbContext<IdentityContext>(options =>
                options.UseSqlServer(configuracoes.GetConnectionString("DefaultConnection")));


            return servicos;
        }

        #endregion Public Methods
    }
}