using Microsoft.AspNetCore.Mvc.Rendering;
using WKTechnology.Application.Contracts;
using WKTechnology.Application.Services.Base;

namespace WKTechnology.Application.Services
{
    public class ProdutoService : BaseHttpService, IProdutoService
    {
        private readonly ICategoriaService _categoriaService;

        public ProdutoService(IClient client, ICategoriaService categoriaService) : base(client)
        {
            _categoriaService = categoriaService;
        }

        public async Task<IEnumerable<SelectListItem>> GetCategorias()
        {
            var categorias = await _categoriaService.GetCategorias();

            IList<SelectListItem> items = new List<SelectListItem>();
            foreach (var item in categorias)
            {
                items.Add(new SelectListItem
                {
                    Text = item.Nome,
                    Value = item.Id.ToString()
                });
            }

            return items;
        }
        public async Task<Response<Guid>> CreateProduto(Produto produto)
        {
            try
            {
                await _client.ApiProdutoPOSTAsync(produto);
                return new Response<Guid>() { Success = true };
            }
            catch (ApiException ex)
            {
                return ConvertApiExceptions<Guid>(ex);
            }
        }

        public async Task<Response<Guid>> DeleteProduto(int id)
        {
            try
            {
                await _client.ApiProdutoDELETEAsync(id);
                return new Response<Guid>() { Success = true };
            }
            catch (ApiException ex)
            {
                return ConvertApiExceptions<Guid>(ex);
            }
        }

        public async Task<Produto> GetProduto(int id)
        {
            var produto = await _client.ApiProdutoGETAsync(id);
            return produto;
        }

        public async Task<List<Produto>> GetProdutos()
        {
            var produtos = await _client.ApiProdutoAllAsync();
            return produtos.ToList();
        }

        public async Task<Response<Guid>> UpdateProduto(Produto produto)
        {
            try
            {
                await _client.ApiProdutoPUTAsync(produto.Id.ToString(), produto);
                return new Response<Guid>() { Success = true };
            }
            catch (ApiException ex)
            {
                return ConvertApiExceptions<Guid>(ex);
            }
        }
    }
}