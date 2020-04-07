using System.Linq;
using SGC.Business.Interfaces;
using SGC.Business.Models.Entidades;
using System.Threading.Tasks;

namespace SGC.Business.Servicos
{
    public class PerguntaService : BaseService, IPerguntaService
    {
        private readonly IPerguntaRepository _perguntaRepository;
        public PerguntaService(IPerguntaRepository perguntaRepository, INotificador notificador) : base(notificador)
        {
            _perguntaRepository = perguntaRepository;
        }

        public async Task Adicionar(Pergunta pergunta)
        {
            if (_perguntaRepository.Buscar(f => f.Descricao == pergunta.Descricao).Result.Any())
            {
                Notificar("Já existe uma pergunta com essa descrição!");
                return;
            }

            await _perguntaRepository.Criar(pergunta);
        }

        public Task Atualizar(Pergunta pergunta)
        {
            throw new System.NotImplementedException();
        }

        public void Dispose()
        {
           
            _perguntaRepository?.Dispose();
        }

        public Task Remover(long id)
        {
            throw new System.NotImplementedException();
        }
    }
}