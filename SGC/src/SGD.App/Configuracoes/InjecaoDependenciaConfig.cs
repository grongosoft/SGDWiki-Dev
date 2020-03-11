using Microsoft.Extensions.DependencyInjection;
using SGC.Data.Contexto;

namespace SGD.App.Configuracoes
{
    public static class InjecaoDependenciaConfig
    {
        #region Public Methods

        public static IServiceCollection ResolveDependencies(this IServiceCollection servicos)
        {
            servicos.AddScoped<DataContext>();

            return servicos;
        }

        #endregion Public Methods
    }
}