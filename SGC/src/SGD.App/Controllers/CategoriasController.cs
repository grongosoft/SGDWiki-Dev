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
using System.Linq;
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

            //CRIAR VALIDAÇÕES
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
            var usuarioCriador = UsuarioCriadorCategoria(id);

            if (usuarioCriador.Result)
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

        public async Task<IActionResult> Edit(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var categoria = await _context.Categorias.FindAsync(id);
            if (categoria == null)
            {
                return NotFound();
            }
            return View(categoria);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(long id, [Bind("OperadorId,Descricao,Nome,Id")] Categoria categoria)
        {
            if (id != categoria.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(categoria);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CategoriaExists(categoria.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(categoria);
        }

        [Route("lista-de-categorias")]
        public async Task<IActionResult> Index()
        {
            var operadorCategoria = await ObterCategorias();

            return View(operadorCategoria);
        }

        #endregion Public Methods

        #region Private Methods

        private bool CategoriaExists(long id)
        {
            return _context.Categorias.Any(e => e.Id == id);
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

        private async Task<bool> UsuarioCriadorCategoria(long categoriaId)
        {
            var usuario = _customUsers.ObterUsuarioLogado();

            var categoria = _mapper.Map<CategoriaViewModel>(await _categoriaRepository.ObterCategoriaPorId(categoriaId));

            if (categoria.OperadorId == usuario)
            {
                return true;
            }

            return false;
        }

        #endregion Private Methods
    }
}