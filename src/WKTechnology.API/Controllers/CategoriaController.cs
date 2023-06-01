using Microsoft.AspNetCore.Mvc;
using WKTechnology.Core.Services;
using WKTechnology.Domain;

namespace WKTechnology.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ApiCategoriaController : ControllerBase
    {
        private readonly CategoriaService _categoriaService;

        public ApiCategoriaController(CategoriaService categoriaService)
        {
            _categoriaService = categoriaService;
        }

        // GETLIST: api/Categoria
        [HttpGet]
        public async Task<ActionResult<List<Categoria>>> GetList()
        {
            var categorias = await _categoriaService.GetCategoriaList();
            return Ok(categorias);
        }

        // GET api/Categoria/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Categoria>> Get(int id)
        {
            var categoria = await _categoriaService.GetCategoria(id);
            return Ok(categoria);
        }

        // CREATE api/Categoria
        [HttpPost]
        public async Task<ActionResult> Create([FromBody] Categoria categoria)
        {
            await _categoriaService.CreateCategoria(categoria);
            return NoContent();
        }

        // UPDATE api/Categoria
        [HttpPut("{id}")]
        public async Task<ActionResult> Update([FromBody] Categoria categoria)
        {
            await _categoriaService.UpdateCategoria(categoria);
            return NoContent();
        }

        // DELETE api/Categoria/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var categoria = await _categoriaService.GetCategoria(id);
            await _categoriaService.DeleteCategoria(categoria);

            return NoContent();
        }
    }
}