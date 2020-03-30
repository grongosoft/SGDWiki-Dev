using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SGC.Business.Interfaces;
using SGC.Business.Models.Entidades;
using SGC.Data.Contexto;
using SGD.App.Extensoes;
using SGD.App.ViewModel;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SGD.App.Controllers
{
    [Authorize]
    public class CategoriasController : Controller
    {
        #region Private Fields

        private readonly ICategoriaRepository _categoriaRepository;
        private readonly ICategoriaService _categoriaService;
        private readonly DataContext _context;
        private readonly ICustomUser _customUsers;
        private readonly IMapper _mapper;

        #endregion Private Fields

        #region Public Constructors

        public CategoriasController(DataContext context, ICategoriaRepository categoriaRepository, ICategoriaService categoriaService, IMapper mapper, ICustomUser customUsers)
        {
            _context = context;
            _mapper = mapper;
            _categoriaRepository = categoriaRepository;
            _categoriaService = categoriaService;
            _customUsers = customUsers;
        }

        #endregion Public Constructors

        #region Public Methods

        [Route("nova-categoria")]
        public IActionResult Create()
        {
            return View();
        }

        [Route("nova-categoria")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CategoriaViewModel categoriaViewModel)
        {
            if (!ModelState.IsValid)
                return View(categoriaViewModel);

            categoriaViewModel.OperadorId = _customUsers.ObterUsuarioLogado();

            var categoria = _mapper.Map<Categoria>(categoriaViewModel);
            await _categoriaService.Criar(categoria);

            //TODO: CRIAR VALIDAÇÕES
            return RedirectToAction(nameof(Index));
        }

        [Route("excluir-categoria/{id:long}")]
        public async Task<IActionResult> Delete(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var categoria = await _context.Categorias
                .FirstOrDefaultAsync(m => m.Id == id);

            var categoriaViewModel = new CategoriaViewModel
            {
                Id = categoria.Id,
                OperadorId = categoria.OperadorId,
                Descricao = categoria.Descricao,
                Nome = categoria.Nome
            };

            return View(categoriaViewModel);
        }

        [Route("excluir-categoria/{id:long}")]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(long id)
        {
            var categoriaViewModel = ObterCategoria(id);

            var usuario = _customUsers.ObterUsuarioLogado();

            if (categoriaViewModel.Result.OperadorId == usuario)
            {
                await _categoriaService.Remover(id);
            }
            else
            {
                return NotFound();
            }

            //TODO VALIDAR OPERAÇÃO

            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Details(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var categoria = await _context.Categorias
                .FirstOrDefaultAsync(m => m.Id == id);

            if (categoria == null)
            {
                return NotFound();
            }

            return View(categoria);
        }

        [Route("editar-categoria/{id:long}")]
        public async Task<IActionResult> Edit(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var categoria = await _context.Categorias
                .FirstOrDefaultAsync(m => m.Id == id);

            var categoriaViewModel = new CategoriaViewModel
            {
                Id = categoria.Id,
                OperadorId = categoria.OperadorId,
                Descricao = categoria.Descricao,
                Nome = categoria.Nome
            };

            return View(categoriaViewModel);
        }

        [HttpPost]
        [Route("editar-categoria/{id:long}")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(long id, CategoriaViewModel categoriaViewModel)
        {
            if (id != categoriaViewModel.Id)
                return NotFound();

            var categoriaAtualizacao = await ObterCategoria(id);

            //TODO: VALIDAR USUARIO CRIADOR

            if (!ModelState.IsValid)
                return View(categoriaViewModel);

            categoriaAtualizacao.OperadorId = categoriaViewModel.OperadorId;
            categoriaAtualizacao.Descricao = categoriaViewModel.Descricao;
            categoriaAtualizacao.Nome = categoriaViewModel.Nome;

            await _categoriaService.Atualizar(_mapper.Map<Categoria>(categoriaAtualizacao));
            //TODO: VALIDAR OPERAÇÃO

            return RedirectToAction("Index");
        }

        [Route("lista-de-categorias")]
        public async Task<IActionResult> Index()
        {
            var operadorCategoria = await ObterCategorias();

            return View(operadorCategoria);
        }

        #endregion Public Methods

        #region Private Methods

        private async Task<CategoriaViewModel> ObterCategoria(long categoriaId)
        {
            var categoria = _mapper.Map<CategoriaViewModel>(await _categoriaRepository.ObterCategoriaPorId(categoriaId));

            return categoria;
        }

        private async Task<List<CategoriaViewModel>> ObterCategorias()
        {
            var categoriaUsuario = new List<CategoriaViewModel>();
            var categorias = await _categoriaRepository.Listar();
            var usuarios = await _customUsers.ListarUsuarios();

            foreach (var categoria in categorias)
            {
                foreach (var usuario in usuarios)
                {
                    if (usuario.Id == categoria.OperadorId)
                    {
                        categoriaUsuario.Add(new CategoriaViewModel
                        {
                            Id = categoria.Id,
                            OperadorId = categoria.OperadorId,
                            Descricao = categoria.Descricao,
                            Nome = categoria.Nome,
                            NomeOperador = usuario.UserName
                        });
                    }
                }
            }

            return categoriaUsuario;
        }

        #endregion Private Methods
    }
}