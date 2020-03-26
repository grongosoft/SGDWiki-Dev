using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.Extensions.DependencyInjection;

namespace SGD.App.Configuracoes
{
    public static class MvcConfig
    {
        public static IServiceCollection AddConfiguracoesDoMVC(this IServiceCollection servicos)
        {
            servicos.AddMvc(options =>
            {
                options.Filters.Add(new AutoValidateAntiforgeryTokenAttribute());


            }).SetCompatibilityVersion(CompatibilityVersion.Version_2_2);

            return servicos;
        }


    }
}
