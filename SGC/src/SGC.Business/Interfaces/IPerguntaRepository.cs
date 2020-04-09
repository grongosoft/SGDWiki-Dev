using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using SGC.Business.Models.Entidades;

namespace SGC.Business.Interfaces
{
    public interface IPerguntaRepository : IRepository<Pergunta>
    {
        Task<Pergunta> ObterPerguntaRepostaPorCategoria(long categoriaId);
        Task<Pergunta> ObterPerguntaRepostaPorUsuario(long usuarioId);
        Task<Pergunta> ObterPerguntaPorId(long perguntaId);

    }
}
