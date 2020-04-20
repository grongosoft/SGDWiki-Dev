using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;

namespace SGD.App.Configuracoes
{
    public static class MvcConfig
    {
        #region Public Methods

        public static IServiceCollection AddConfiguracoesDoMVC(this IServiceCollection servicos)
        {
            servicos.AddMvc(options =>
            {
                options.Filters.Add(new AutoValidateAntiforgeryTokenAttribute());
            }).SetCompatibilityVersion(CompatibilityVersion.Version_2_2);

            return servicos;
        }

        #endregion Public Methods
    }
}