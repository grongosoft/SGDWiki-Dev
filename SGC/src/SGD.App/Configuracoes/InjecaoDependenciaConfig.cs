using Microsoft.Extensions.DependencyInjection;
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
            servicos.AddTransient<DataContext>();
            servicos.AddScoped<ICategoriaRepository, CategoriaRepository>();
            servicos.AddScoped<IPerguntaRepository, PerguntaRepository>();
            servicos.AddScoped<IRespostaRepository, RespostaRepository>();

            servicos.AddScoped<IRespostaService, RespostaService>();
            servicos.AddScoped<ICategoriaService, CategoriaService>();
            servicos.AddScoped<IPerguntaService, PerguntaService>();

            servicos.AddScoped<ICustomUser, CustomUsers>();
            servicos.AddScoped<INotificador, Notificador>();

            servicos.AddHttpContextAccessor();

            return servicos;
        }

        #endregion Public Methods
    }
}