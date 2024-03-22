using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OficinaOS.Domain.Entities;

namespace OficinaOS.Infrastructure.Configurations
{
    public class PessoaConfiguration : IEntityTypeConfiguration<Pessoa>
    {
        public void Configure(EntityTypeBuilder<Pessoa> builder)
        {            
            builder.HasAnnotation("Relational:TableName", "pessoa");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id)
                .HasAnnotation("Relational:ColumnName", "id")
                .HasConversion<int>()                              
                .ValueGeneratedOnAdd()
                .IsRequired();

            builder.Property(x => x.Nome)
                .HasAnnotation("Relational:ColumnName", "nome")
                .HasConversion<string>()
                .HasMaxLength(300)
                .IsRequired(true);

            builder.Property(x => x.Cpf)
                .HasAnnotation("Relational:ColumnName", "cpf")
                .HasConversion<string>()
                .HasMaxLength(11)
                .IsRequired(true);

            builder.Property(x => x.Telefone)
                .HasAnnotation("Relational:ColumnName", "telefone")
                .HasConversion<string>()
                .HasMaxLength(13)
                .IsRequired(true);

            builder.Property(x => x.Email)
                .HasAnnotation("Relational:ColumnName", "email")
                .HasConversion<string>()
                .HasMaxLength(200)
                .IsRequired(true);

            builder.Property(x => x.Senha)
                .HasAnnotation("Relational:ColumnName", "senha")
                .HasConversion<string>()
                .HasMaxLength(200)
                .IsRequired(true);        
        }
    }
}
