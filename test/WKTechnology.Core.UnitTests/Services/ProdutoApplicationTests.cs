using WKTechnology.Core.Services;
using WKTechnology.Core.Tests.Mocks;
using WKTechnology.Domain;
using Moq;
using Shouldly;
using Xunit;
using WKTechnology.Core.Contracts.Persistence;

namespace WKTechnology.Core.UnitTests.Services
{
    public class ProdutoApplicationTests
    {
        private readonly Mock<IGenericRepository<Produto>> mockProduto;
        private readonly Mock<IGenericRepository<Categoria>> mockCategoria;
        private readonly ProdutoService produtoService;

        public ProdutoApplicationTests()
        {
            mockCategoria = new Mock<IGenericRepository<Categoria>>();
            mockProduto = MockProdutoRepository.GetProdutoRepository();
            produtoService = new ProdutoService(mockProduto.Object, mockCategoria.Object);
        }

        [Fact]
        public async Task GetProdutoListTest()
        {
            var result = await produtoService.GetProdutoList();
            result.Count.ShouldBe(3);
            result.ShouldBeOfType<List<Produto>>();
        }

        [Fact]
        public async Task GetProdutoTest()
        {
            var result = await produtoService.GetProduto(2);
            result.Nome.ShouldBe("Vestido");
            result.ShouldBeOfType<Produto>();
        }

        [Fact]
        public async Task CreateProdutoTest()
        {
            var produtos = await produtoService.GetProdutoList();
            var produto = new Produto
            {
                Id = 4,
                Nome = "Parkour",
                IdCategoria = 3
            };

            await produtoService.CreateProduto(produto);
            produtos.Count.ShouldBe(4);
        }

        [Fact]
        public async Task UpdateProdutoTest()
        {
            var produto = await produtoService.GetProduto(1);

            produto.Nome = "Notebook";
            await produtoService.UpdateProduto(produto);

            var produtoAlterado = await produtoService.GetProduto(1);

            produtoAlterado.Id.ShouldBe(1);
            produtoAlterado.Nome.ShouldBe("Notebook");
        }

        [Fact]
        public async Task DeleteProdutoTest()
        {
            var produtos = await produtoService.GetProdutoList();
            var produtoExcluir = await produtoService.GetProduto(2);
            await produtoService.DeleteProduto(produtoExcluir);

            produtos.Count.ShouldBe(2);
        }
    }
}