using Microsoft.Extensions.DependencyInjection;
using SGC.Business.Interfaces;
using SGC.Business.Servicos;
using SGC.Data.Contexto;
using SGC.Data.Repositorios;

namespace SGD.App.Configuracoes
{
    public static class InjecaoDependenciaConfig
    {
        #region Public Methods

        public static IServiceCollection ResolveDependencies(this IServiceCollection servicos)
        {
            servicos.AddScoped<DataContext>();
            servicos.AddScoped<ICategoriaRepository, CategoriaRepository>();

            servicos.AddScoped<ICategoriaService, CategoriaService>();

            return servicos;
        }

        #endregion Public Methods
    }
}