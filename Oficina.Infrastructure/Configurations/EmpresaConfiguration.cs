using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OficinaOS.Domain.Entities;

namespace OficinaOS.Infrastructure.Configurations
{
    public class EmpresaConfiguration : IEntityTypeConfiguration<Empresa>
    {
        public void Configure(EntityTypeBuilder<Empresa> builder)
        {            
            builder.HasAnnotation("Relational:TableName", "empresa");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id)
                .HasAnnotation("Relational:ColumnName", "id")
                .HasConversion<int>()                              
                .ValueGeneratedOnAdd()
                .IsRequired();

            builder.Property(x => x.RazaoSocial)
                .HasAnnotation("Relational:ColumnName", "razao_social")
                .HasConversion<string>()
                .HasMaxLength(200)
                .IsRequired(true);

            builder.Property(x => x.Cnpj)
                .HasAnnotation("Relational:ColumnName", "cnpj")
                .HasConversion<string>()
                .HasMaxLength(11)
                .IsRequired(true);               
        }
    }
}
