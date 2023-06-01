using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using WKTechnology.Domain.Common;

public abstract class BaseEntityConfiguration<TEntity> : IEntityTypeConfiguration<TEntity> where TEntity : BaseEntity
{
    public virtual void Configure(EntityTypeBuilder<TEntity> builder)
    {
        builder.HasKey(o => o.Id);
            
        builder.Property(o => o.CriadoEm)
            .HasDefaultValue(DateTime.Now)
            .ValueGeneratedOnAdd();

        builder.Property(o => o.AtualizadoEm)
            .HasDefaultValue(DateTime.Now)
            .ValueGeneratedOnAddOrUpdate();

        builder.Property(o => o.ModificadoPor)
            .IsRequired()
            .HasDefaultValue("system")
            .HasMaxLength(50);
    }
}