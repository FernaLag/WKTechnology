using WKTechnology.Domain;
using WKTechnology.Core.Contracts.Persistence;

namespace WKTechnology.Core.Services
{
    public class CategoriaService
    {
        private readonly IGenericRepository<Categoria> _categoriaRepository;

        public CategoriaService(IGenericRepository<Categoria> genericRepository)
        {
            _categoriaRepository = genericRepository;
        }

        public async Task<IReadOnlyList<Categoria>> GetCategoriaList()
        {
            return await _categoriaRepository.GetAll();
        }

        public async Task<Categoria> GetCategoria(int id)
        {
            var categoria = await _categoriaRepository.Get(id);
            return categoria;
        }

        public async Task CreateCategoria(Categoria categoria)
        {
            await _categoriaRepository.Add(categoria);
        }

        public async Task UpdateCategoria(Categoria categoria)
        {
            await _categoriaRepository.Update(categoria);
        }

        public async Task DeleteCategoria(Categoria categoria)
        {
            await _categoriaRepository.Delete(categoria);
        }
    }
}