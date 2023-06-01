using WKTechnology.Domain;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace WKTechnology.Persistence.Configurations
{
    public class ProdutoConfiguration : BaseEntityConfiguration<Produto>
    {
        public override void Configure(EntityTypeBuilder<Produto> builder)
        {
            builder.Property(c => c.Nome)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(c => c.IdCategoria)
                .IsRequired();

            builder.HasOne(c => c.Categoria)
            .WithMany(b => b.Produtos)
            .HasForeignKey(c => c.IdCategoria);

            base.Configure(builder);
        }
    }
}