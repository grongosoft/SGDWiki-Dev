using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using SGC.Business.Models.Entidades;

namespace SGC.Business.Interfaces
{
    public interface IRespostaService : IDisposable
    {
        Task Adicionar(Resposta resposta);
        Task Atualizar(Resposta resposta);
        Task Remover(long id);
    }
}
