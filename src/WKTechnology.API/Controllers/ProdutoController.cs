using Microsoft.AspNetCore.Mvc;
using WKTechnology.Core.Services;
using WKTechnology.Domain;

namespace WKTechnology.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ApiProdutoController : ControllerBase
    {
        private readonly ProdutoService _produtoService;

        public ApiProdutoController(ProdutoService produtoService)
        {
            _produtoService = produtoService;
        }

        // GETLIST: api/Produto
        [HttpGet]
        public async Task<ActionResult<List<Produto>>> Get()
        {
            var produtos = await _produtoService.GetProdutoList();
            return Ok(produtos);
        }

        // GET api/Produto/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Produto>> Get(int id)
        {
            var produto = await _produtoService.GetProduto(id);
            return Ok(produto);
        }

        // CREATE api/Produto
        [HttpPost]
        public async Task<ActionResult> Create([FromBody] Produto produto)
        {
            await _produtoService.CreateProduto(produto);
            return NoContent();
        }

        // UPDATE api/Produto
        [HttpPut("{id}")]
        public async Task<ActionResult> Update([FromBody] Produto produto)
        {
            await _produtoService.UpdateProduto(produto);
            return NoContent();
        }

        // DELETE api/Produto/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var produto = await _produtoService.GetProduto(id);
            await _produtoService.DeleteProduto(produto);

            return NoContent();
        }
    }
}