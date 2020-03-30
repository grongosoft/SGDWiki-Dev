using SGC.Business.Interfaces;
using SGC.Business.Models.Entidades;
using SGC.Business.Models.Validacoes;
using System.Linq;
using System.Threading.Tasks;

namespace SGC.Business.Servicos
{
    public class CategoriaService : BaseService, ICategoriaService
    {
        #region Private Fields

        private readonly ICategoriaRepository _categoriaRepository;

        #endregion Private Fields

        #region Public Constructors

        public CategoriaService(ICategoriaRepository categoriaRepository, INotificador notificador) : base(notificador)
        {
            _categoriaRepository = categoriaRepository;
        }

        #endregion Public Constructors

        #region Public Methods

        public async Task Atualizar(Categoria categoria)
        {
            if (!ExecutarValidacao(new CategoriaValidation(), categoria))
                return;
            if (_categoriaRepository.Buscar(c => c.Descricao == categoria.Descricao && c.Id != categoria.Id).Result.Any())

            {
                Notificar("Já existe uma categoria com essa descrição!");
                return;
            }

            await _categoriaRepository.Atualizar(categoria);
        }

        public async Task Criar(Categoria categoria)
        {
            if (!ExecutarValidacao(new CategoriaValidation(), categoria))
                return;

            if (_categoriaRepository.Buscar(c => c.Descricao == categoria.Descricao).Result.Any())
            {
                Notificar("Já existe uma categoria com essa descrição!");
                return;
            }

            await _categoriaRepository.Criar(categoria);
        }

        public void Dispose()
        {
            _categoriaRepository?.Dispose();
        }

        public async Task Remover(long id)
        {
            await _categoriaRepository.Excluir(id);
        }

        #endregion Public Methods
    }
}