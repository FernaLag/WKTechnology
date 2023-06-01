using WKTechnology.Domain;
using Microsoft.EntityFrameworkCore;
using WKTechnology.Persistence.Configurations;
using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore.Design;

namespace WKTechnology.Persistence
{
    public class WKTechnologyDbContext : DbContext
    {
        public WKTechnologyDbContext(DbContextOptions<WKTechnologyDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(WKTechnologyDbContext).Assembly);

            modelBuilder.ApplyConfiguration(new CategoriaConfiguration());
            modelBuilder.ApplyConfiguration(new ProdutoConfiguration());
        }

        public DbSet<Categoria> Categoria { get; set; }
        public DbSet<Produto> Produto { get; set; }
    }


    public class WKTechnologyDbContextFactory : IDesignTimeDbContextFactory<WKTechnologyDbContext>
    {
        public WKTechnologyDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<WKTechnologyDbContext>();

            string? mySqlConnection = "Server=localhost;port=3306;Database=WKTechnologyDb;User=root;Password=123123";
            optionsBuilder.UseMySql(mySqlConnection, ServerVersion.AutoDetect(mySqlConnection));

            return new WKTechnologyDbContext(optionsBuilder.Options);
        }
    }
}