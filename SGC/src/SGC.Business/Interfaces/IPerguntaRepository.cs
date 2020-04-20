using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using SGC.Business.Models.Entidades;

namespace SGC.Business.Interfaces
{
    public interface IPerguntaRepository : IRepository<Pergunta>
    {
        Task<Pergunta> ObterPerguntaPorId(long perguntaId);
        Task<List<Pergunta>> ObterPerguntaPorDescricao(string descricao, string email, long? categoriaId, long? likeId);

    }
}
