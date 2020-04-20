using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using SGC.Business.Interfaces;
using SGC.Data.Contexto;
using SGD.App.Extensoes;
using SGD.App.ViewModel;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SGD.App.Controllers
{
    [Authorize]
    public class PerguntaRespostasController : BaseController
    {
        #region Private Fields

        private readonly ICategoriaRepository _categoriaRepository;
        private readonly DataContext _context;
        private readonly ICustomUser _customUsers;
        private readonly IPerguntaRepository _perguntaRepository;

        private readonly IPerguntaService _perguntaService;
        private readonly IRespostaRepository _respostaRepository;
        private readonly IRespostaService _respostaService;

        #endregion Private Fields

        #region Public Constructors

        public PerguntaRespostasController(DataContext context, ICategoriaRepository categoriaRepository, ICategoriaService categoriaService,
            IPerguntaService perguntaService, IRespostaService respostaService, IPerguntaRepository perguntaRepository, IRespostaRepository respostaRepository,
             ICustomUser customUser, INotificador notificador) : base(notificador)
        {
            _context = context;
            _categoriaRepository = categoriaRepository;

            _customUsers = customUser;
            _perguntaService = perguntaService;
            _perguntaRepository = perguntaRepository;
            _respostaService = respostaService;
            _respostaRepository = respostaRepository;
        }

        #endregion Public Constructors

        #region Public Methods

        [Route("filtro-pergunta_resposta")]
        public IActionResult Index()
        {
            var categoriasViewModel = BuscarCategoriasCadastradas();
            var perguntasRespostaViewModel = new List<PerguntaRespostaViewModel>();

            var perguntaRespostaViewModel = new PerguntaRespostaViewModel
            {
                CategoriasList = new SelectList(categoriasViewModel.Result, "Id", "Nome")
            };

            perguntasRespostaViewModel.Add(perguntaRespostaViewModel);

            return View(perguntasRespostaViewModel);
        }

        [Route("Pesquisar/{id:long?}")]
        public IActionResult Pesquisar(long? id, string inpPergunta, string inpEmail, long? optSelectedId, PerguntaRespostaViewModel perguntaRespostaViewModel)
        {
            var perguntasRespostas = new List<PerguntaRespostaViewModel>();

            var categoriasViewModel = BuscarCategoriasCadastradas();

            var optSelecionado = optSelectedId != null ? optSelectedId.Value : (long?)null;
            var categoriaId = perguntaRespostaViewModel != null ? perguntaRespostaViewModel.CategoriaId : null;

            var usuario = _customUsers.ObterUsuarioPorEmail(inpEmail).Result;

            var email = usuario?.Email;

            var response = _perguntaRepository.ObterPerguntaPorDescricao(inpPergunta, email, categoriaId, optSelecionado).Result;

            if (response == null || response.Count == 0)
            {
                var perguntasRespostaViewModel = new List<PerguntaRespostaViewModel>();

                perguntaRespostaViewModel = new PerguntaRespostaViewModel
                {
                    CategoriasList = new SelectList(categoriasViewModel.Result, "Id", "Nome")
                };

                perguntasRespostaViewModel.Add(perguntaRespostaViewModel);

                TempData["Success"] = "A pergunta não retornou resultados!";
                return View("Index", perguntasRespostaViewModel);
            }

            foreach (var pergunta in response)
            {
                var categoria = _categoriaRepository.ObterCategoriaPorId(pergunta.CategoriaId).Result;

                var perguntaResposta = new PerguntaRespostaViewModel
                {
                    PerguntaId = pergunta.Id,
                    DescricaoPergunta = pergunta.Descricao,
                    OperadorId = pergunta.OperadorId,
                    IdSelecionado = id,
                    CategoriasList = new SelectList(categoriasViewModel.Result, "Id", "Nome"),
                    DescricaoCategoria = categoria.Descricao
                };

                perguntasRespostas.Add(perguntaResposta);
            }

            if (id != null && id > 0)
            {
                if (perguntasRespostas.Any(e => e.PerguntaId == id))
                {
                    var pergunta = _perguntaRepository.ObterPerguntaPorId(id.Value).Result;
                    var categoria = _categoriaRepository.ObterCategoriaPorId(pergunta.CategoriaId).Result;

                    var resposta = _respostaRepository.ObterRespostaPorPergunta(id.Value).Result;
                    var perguntaRespostaRemove = perguntasRespostas.FirstOrDefault(p => p.PerguntaId == id);

                    var perguntaRespostaRenew = new PerguntaRespostaViewModel
                    {
                        PerguntaId = perguntaRespostaRemove.PerguntaId,
                        DescricaoPergunta = perguntaRespostaRemove.DescricaoPergunta,
                        OperadorId = perguntaRespostaRemove.OperadorId,
                        DescricaoResposta = resposta.Descricao,
                        CategoriasList = new SelectList(categoriasViewModel.Result, "Id", "Nome"),
                        DescricaoCategoria = categoria.Descricao
                    };

                    perguntasRespostas.Remove(perguntaRespostaRemove);

                    perguntasRespostas.Add(perguntaRespostaRenew);
                }

                return View("Index", perguntasRespostas);
            }

            return View("Index", perguntasRespostas);
        }

        #endregion Public Methods

        #region Private Methods

        private async Task<List<CategoriaViewModel>> BuscarCategoriasCadastradas()
        {
            var categoriasViewModel = new List<CategoriaViewModel>();
            var categorias = await _categoriaRepository.Listar();

            foreach (var categoria in categorias)
            {
                var categoriaViewModel = new CategoriaViewModel
                {
                    Nome = categoria.Nome,
                    Id = categoria.Id
                };

                categoriasViewModel.Add(categoriaViewModel);
            }

            return categoriasViewModel;
        }

        #endregion Private Methods
    }
}