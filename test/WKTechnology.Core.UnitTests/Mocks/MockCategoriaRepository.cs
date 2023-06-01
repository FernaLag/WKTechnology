using WKTechnology.Domain;
using WKTechnology.Core.Contracts.Persistence;
using Moq;

namespace WKTechnology.Core.Tests.Mocks
{
    public static class MockCategoriaRepository
    {
        public static Mock<IGenericRepository<Categoria>> GetCategoriaRepository()
        {
            var mock = new Mock<IGenericRepository<Categoria>>();
            var categorias = new List<Categoria>
            {
                new Categoria
                {
                    Id = 1,
                    Nome = "Tecnologia"
                },
                new Categoria
                {
                    Id = 2,
                    Nome = "Roupa"
                },
                new Categoria
                {
                    Id = 3,
                    Nome = "Lazer"
                }
            };

            mock.Setup(x => x.GetAll()).ReturnsAsync(categorias);

            mock.Setup(x => x.Get(It.IsAny<int>())).ReturnsAsync((int id) =>
            {
                return categorias.Single(x => x.Id == id);
            });

            mock.Setup(x => x.Add(It.IsAny<Categoria>())).Callback((Categoria categoria) =>
            {
                categorias.Add(categoria);
            });

            mock.Setup(x => x.Update(It.IsAny<Categoria>())).Callback((Categoria categoriaAlterado) =>
            {
                var categoria = categorias.Single(x => x.Id == categoriaAlterado.Id);
                categoria = categoriaAlterado;
            });

            mock.Setup(x => x.Delete(It.IsAny<Categoria>())).Callback((Categoria categoria) =>
            {
                categorias.Remove(categoria);
            });

            return mock;
        }
    }
}
