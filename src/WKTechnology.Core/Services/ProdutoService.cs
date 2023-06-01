using WKTechnology.Domain;
using WKTechnology.Core.Contracts.Persistence;

namespace WKTechnology.Core.Services
{
    public class ProdutoService
    {
        private readonly IGenericRepository<Produto> _produtoRepository;
        private readonly IGenericRepository<Categoria> _categoriaRepository;

        public ProdutoService(IGenericRepository<Produto> produtoRepository, IGenericRepository<Categoria> categoriaRepository)
        {
            _produtoRepository = produtoRepository;
            _categoriaRepository = categoriaRepository;
        }

        public async Task<IReadOnlyList<Produto>> GetProdutoList()
        {
            return await _produtoRepository.GetAll();
        }

        public async Task<Produto> GetProduto(int id)
        {
            var produto = await _produtoRepository.Get(id);
            return produto;
        }

        public async Task CreateProduto(Produto produto)
        {
            produto.Categoria = await _categoriaRepository.Get(produto.IdCategoria);
            await _produtoRepository.Add(produto);
        }

        public async Task UpdateProduto(Produto produto)
        {
            await _produtoRepository.Update(produto);
        }

        public async Task DeleteProduto(Produto produto)
        {
            await _produtoRepository.Delete(produto);
        }
    }
}