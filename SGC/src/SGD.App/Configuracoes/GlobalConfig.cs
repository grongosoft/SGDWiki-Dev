using System.Collections.Generic;
using System.Globalization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Localization;

namespace SGD.App.Configuracoes
{
    public static class GlobalConfig
    {
        public static IApplicationBuilder GlobalizationConfig(this IApplicationBuilder app)
        {
            var culturaPadrao = new CultureInfo("pt-BR");

            var opcaoDeLocalizacao = new RequestLocalizationOptions()
            {
                DefaultRequestCulture = new RequestCulture(culturaPadrao),
                SupportedCultures = new List<CultureInfo> { culturaPadrao },
                SupportedUICultures = new List<CultureInfo> { culturaPadrao }

            };
            app.UseRequestLocalization(opcaoDeLocalizacao);

            return app;
        }
    }
}