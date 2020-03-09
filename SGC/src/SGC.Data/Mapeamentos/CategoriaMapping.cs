using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SGC.Business.Models.Entidades;

namespace SGC.Data.Mapeamentos
{
    public class CategoriaMapping : IEntityTypeConfiguration<Categoria>
    {
        #region Public Methods

        public void Configure(EntityTypeBuilder<Categoria> builder)
        {
            builder.HasKey(c => c.Id);

            builder.Property(c => c.NomeCategoria)
                .IsRequired()
                .HasColumnType("varchar(100)");

            builder.Property(c => c.DescricaoCategoria)
                .IsRequired()
                .HasColumnType("varchar(100)");

            builder.Property(c => c.OperadorId)
                .IsRequired();

            builder.ToTable("Categorias");
        }

        #endregion Public Methods
    }
}