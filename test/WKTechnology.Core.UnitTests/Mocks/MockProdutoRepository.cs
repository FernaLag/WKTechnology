using WKTechnology.Domain;
using WKTechnology.Core.Contracts.Persistence;
using Moq;

namespace WKTechnology.Core.Tests.Mocks
{
    public static class MockProdutoRepository
    {
        public static Mock<IGenericRepository<Produto>> GetProdutoRepository()
        {
            var mock = new Mock<IGenericRepository<Produto>>();
            var produtos = new List<Produto> 
            {
                new Produto
                {
                    Id = 1,
                    IdCategoria = 1,
                    Nome = "Monitor"                    
                },
                new Produto
                {
                    Id = 2,
                    IdCategoria = 2,
                    Nome = "Vestido"                    
                },
                new Produto
                {
                    Id = 3,
                    IdCategoria = 3,
                    Nome = "Bumerangue"                    
                }
            };

            mock.Setup(x => x.GetAll()).ReturnsAsync(produtos);

            mock.Setup(x => x.Get(It.IsAny<int>())).ReturnsAsync((int id)  =>
            {
                return produtos.Single(x => x.Id == id);
            });

            mock.Setup(x => x.Add(It.IsAny<Produto>())).Callback((Produto produto) =>
            {
                produtos.Add(produto);
            });

            mock.Setup(x => x.Update(It.IsAny<Produto>())).Callback((Produto produtoAlterado) =>
            {
                var produto = produtos.Single(x => x.Id == produtoAlterado.Id);
                produto = produtoAlterado;
            });

            mock.Setup(x => x.Delete(It.IsAny<Produto>())).Callback((Produto produto) =>
            {
                produtos.Remove(produto);
            });

            return mock;
        }
    }
}
