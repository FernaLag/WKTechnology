using Microsoft.AspNetCore.Mvc.Rendering;
using WKTechnology.Application.Services.Base;

namespace WKTechnology.Application.Contracts
{
    public interface IProdutoService
    {
        Task<List<Produto>> GetProdutos();
        //Task<bool> ExistProduto(int id);
        Task<Produto> GetProduto(int id);
        Task<Response<Guid>> CreateProduto(Produto produto);
        Task<Response<Guid>> UpdateProduto(Produto produto);
        Task<Response<Guid>> DeleteProduto(int id);
        Task<IEnumerable<SelectListItem>> GetCategorias();
    }
}
