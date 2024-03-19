using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OficinaOS.Domain.Entities;

namespace OficinaOS.Infrastructure.Configurations
{
    public class PecaConfiguration : IEntityTypeConfiguration<Peca>
    {
        public void Configure(EntityTypeBuilder<Peca> builder)
        {            
            builder.HasAnnotation("Relational:TableName", "peca");

            builder.HasKey(x => x.Codigo);

            builder.Property(x => x.Codigo)
                .HasAnnotation("Relational:ColumnName", "id")
                .HasConversion<int>()                              
                .ValueGeneratedOnAdd()
                .IsRequired();

            builder.Property(x => x.Descricao)
                .HasAnnotation("Relational:ColumnName", "descricao")
                .HasConversion<string>()
                .HasMaxLength(300)
                .IsRequired(true);

            builder.Property(x => x.Quantidade)
                .HasAnnotation("Relational:ColumnName", "quantidade")
                .HasConversion<int>()
                .IsRequired(true);

            builder.Property(x => x.Marca)
                .HasAnnotation("Relational:ColumnName", "marca")
                .HasConversion<string>()
                .HasMaxLength(100)
                .IsRequired(true);

            builder.Property(x => x.Valor_unit)
                .HasAnnotation("Relational:ColumnName", "valor_unit")
                .HasConversion<decimal>()
                .HasMaxLength(18)
                .IsRequired(true);          
        }
    }
}
