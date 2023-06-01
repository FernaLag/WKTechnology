using WKTechnology.Domain;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace WKTechnology.Persistence.Configurations
{
    public class CategoriaConfiguration : BaseEntityConfiguration<Categoria>
    {
        public override void Configure(EntityTypeBuilder<Categoria> builder)
        {
            builder.Property(c => c.Nome)
                .IsRequired()
                .HasMaxLength(100);

            base.Configure(builder);
        }
    }
}