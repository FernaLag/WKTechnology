using WKTechnology.Application.Contracts;
using WKTechnology.Application.Services.Base;

namespace WKTechnology.Application.Services
{
    public class CategoriaService : BaseHttpService, ICategoriaService
    {
        public CategoriaService(IClient client) : base(client)
        {
        }

        public async Task<Response<Guid>> CreateCategoria(Categoria categoria)
        {
            try
            {
                await _client.ApiCategoriaPOSTAsync(categoria);
                return new Response<Guid>() { Success = true };
            }
            catch (ApiException ex)
            {
                return ConvertApiExceptions<Guid>(ex);
            }
        }

        public async Task<Response<Guid>> DeleteCategoria(int id)
        {
            try
            {
                await _client.ApiCategoriaDELETEAsync(id);
                return new Response<Guid>() { Success = true };
            }
            catch (ApiException ex)
            {
                return ConvertApiExceptions<Guid>(ex);
            }
        }

        public async Task<Categoria> GetCategoria(int id)
        {
            var categoria = await _client.ApiCategoriaGETAsync(id);
            return categoria;
        }

        public async Task<List<Categoria>> GetCategorias()
        {
            var categorias = await _client.ApiCategoriaAllAsync();
            return categorias.ToList();
        }

        public async Task<Response<Guid>> UpdateCategoria(Categoria categoria)
        {
            try
            {
                await _client.ApiCategoriaPUTAsync(categoria.Id.ToString(), categoria);
                return new Response<Guid>() { Success = true };
            }
            catch (ApiException ex)
            {
                return ConvertApiExceptions<Guid>(ex);
            }
        }
    }
}