using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SGC.Business.Models.Entidades;

namespace SGC.Data.Mapeamentos
{
    public class RespostaMapping : IEntityTypeConfiguration<Resposta>
    {
        public void Configure(EntityTypeBuilder<Resposta> builder)
        {
            builder.HasKey(r => r.Id);
            builder.Property(r => r.Descricao)
                .IsRequired()
                .HasColumnType("nvarchar(4000)");

            builder.ToTable("Respostas");
        }
    }
}