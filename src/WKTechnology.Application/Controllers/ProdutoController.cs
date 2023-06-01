using Microsoft.AspNetCore.Mvc;
using WKTechnology.Application.Contracts;
using WKTechnology.Application.Services.Base;

namespace WKTechnology.Application.Controllers
{
    public class ProdutoController : Controller
    {
        private readonly IProdutoService _produtoService;

        public ProdutoController(IProdutoService produtoService)
        {
            _produtoService = produtoService;
        }
        public async Task<ActionResult> Index()
        {
            var produtos = await _produtoService.GetProdutos();
            return View(produtos);
        }

        public async Task<ActionResult> Create()
        {
            ViewBag.Categorias = await _produtoService.GetCategorias();
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(Produto produto)
        {
            try
            {
                await _produtoService.CreateProduto(produto);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        public async Task<ActionResult> Edit(int id)
        {
            var produto = await _produtoService.GetProduto(id);
            ViewBag.Categorias = await _produtoService.GetCategorias();
            return View(produto);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]

        public async Task<ActionResult> Edit(Produto produto)
        {
            try
            {
                await _produtoService.UpdateProduto(produto);
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
                await _produtoService.DeleteProduto(id);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}