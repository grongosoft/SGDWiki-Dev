using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SGC.Business.Models.Entidades;

namespace SGC.Data.Mapeamentos
{
    public class PerguntaMapping : IEntityTypeConfiguration<Pergunta>
    {
        public void Configure(EntityTypeBuilder<Pergunta> builder)
        {
            builder.HasKey(p => p.Id);

            builder.Property(p => p.Descricao)
                .IsRequired()
                .HasColumnType("varchar(100)");
          
            builder.Property(c => c.OperadorId)
                .IsRequired();

            builder.Property(c => c.CategoriaId)
                .IsRequired();

            builder.HasOne(p => p.Resposta)
                .WithOne(p => p.Pergunta);

           

            builder.ToTable("Perguntas");
        }
    }
}