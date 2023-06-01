using Microsoft.AspNetCore.Mvc.Rendering;
using WKTechnology.Application.Services.Base;

namespace WKTechnology.Application.Contracts
{
    public interface ICategoriaService
    {
        Task<List<Categoria>> GetCategorias();
        //Task<bool> ExistCategoria(int id);
        Task<Categoria> GetCategoria(int id);
        Task<Response<Guid>> CreateCategoria(Categoria categoria);
        Task<Response<Guid>> UpdateCategoria(Categoria categoria);
        Task<Response<Guid>> DeleteCategoria(int id);
    }
}
