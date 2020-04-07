using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using SGC.Business.Models.Entidades;

namespace SGC.Business.Interfaces
{
    public interface IRespostaRepository : IRepository<Resposta>
    {
        Task<Resposta> ObterRespostaPorPergunta(long perguntaId);
    }
}
