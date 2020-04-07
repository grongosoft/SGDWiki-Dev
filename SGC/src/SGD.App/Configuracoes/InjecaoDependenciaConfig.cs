using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using SGC.Business.Interfaces;
using SGC.Business.Notificacoes;
using SGC.Business.Servicos;
using SGC.Data.Contexto;
using SGC.Data.Repositorios;
using SGD.App.Extensoes;

namespace SGD.App.Configuracoes
{
    public static class InjecaoDependenciaConfig
    {
        #region Public Methods

        public static IServiceCollection ResolveDependencies(this IServiceCollection servicos)
        {
            servicos.AddScoped<DataContext>();
            servicos.AddScoped<ICategoriaRepository, CategoriaRepository>();
            servicos.AddScoped<IPerguntaRepository, PerguntaRepository>();

            servicos.AddScoped<ICategoriaService, CategoriaService>();
            servicos.AddScoped<IPerguntaService, PerguntaService>();
            servicos.AddScoped<ICustomUser, CustomUsers>();
            servicos.AddScoped<INotificador, Notificador>();

            //servicos.TryAddSingleton<IHttpContextAccessor, HttpContextAccessor>();

            // Or you can also register as follows

            servicos.AddHttpContextAccessor();

            return servicos;
        }

        #endregion Public Methods
    }
}