using WKTechnology.Core.Services;
using WKTechnology.Core.Tests.Mocks;
using WKTechnology.Domain;
using Moq;
using Shouldly;
using Xunit;
using WKTechnology.Core.Contracts.Persistence;

namespace WKTechnology.Core.UnitTests.Services
{
    public class CategoriaApplicationTests
    {
        private readonly Mock<IGenericRepository<Categoria>> mock;
        private readonly CategoriaService categoriaService;

        public CategoriaApplicationTests()
        {
            mock = MockCategoriaRepository.GetCategoriaRepository();
            categoriaService = new CategoriaService(mock.Object);
        }

        [Fact]
        public async Task GetCategoriaListTest()
        {
            var result = await categoriaService.GetCategoriaList();
            result.Count.ShouldBe(3);
            result.ShouldBeOfType<List<Categoria>>();
        }

        [Fact]
        public async Task GetCategoriaTest()
        {
            var result = await categoriaService.GetCategoria(2);
            result.Nome.ShouldBe("Roupa");
            result.ShouldBeOfType<Categoria>();
        }

        [Fact]
        public async Task CreateCategoriaTest()
        {
            var categorias = await categoriaService.GetCategoriaList();
            var categoria = new Categoria
            {
                Id = 4,
                Nome = "Esporte"
            };            

            await categoriaService.CreateCategoria(categoria);
            categorias.Count.ShouldBe(4);
        }

        [Fact]
        public async Task UpdateCategoriaTest()
        {
            var categoria = await categoriaService.GetCategoria(1);

            categoria.Nome = "Alimentos";
            await categoriaService.UpdateCategoria(categoria);

            var categoriaAlterado = await categoriaService.GetCategoria(1);

            categoriaAlterado.Id.ShouldBe(1);
            categoriaAlterado.Nome.ShouldBe("Alimentos");
        }

        [Fact]
        public async Task DeleteCategoriaTest()
        {
            var categorias = await categoriaService.GetCategoriaList();
            var categoriaExcluir = await categoriaService.GetCategoria(2);
            await categoriaService.DeleteCategoria(categoriaExcluir);

            categorias.Count.ShouldBe(2);
        }
    }
}