using Microsoft.AspNetCore.Mvc;
using WKTechnology.Application.Contracts;
using WKTechnology.Application.Services.Base;

namespace WKTechnology.Application.Controllers
{
    public class CategoriaController : Controller
    {
        private readonly ICategoriaService _categoriaService;

        public CategoriaController(ICategoriaService categoriaService)
        {
            _categoriaService = categoriaService;
        }
        public async Task<ActionResult> Index()
        {
            var categorias = await _categoriaService.GetCategorias();
            return View(categorias);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(Categoria categoria)
        {
            try
            {
                await _categoriaService.CreateCategoria(categoria);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        public async Task<ActionResult> Edit(int id)
        {
            var categoria = await _categoriaService.GetCategoria(id);
            return View(categoria);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]

        public async Task<ActionResult> Edit(Categoria categoria)
        {
            try
            {
                await _categoriaService.UpdateCategoria(categoria);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]

        public async Task<ActionResult> Delete(int id)
        {
            try
            {
                await _categoriaService.DeleteCategoria(id);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}