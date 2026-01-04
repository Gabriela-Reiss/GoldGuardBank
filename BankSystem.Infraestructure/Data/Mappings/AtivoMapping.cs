using BankSystem.Domain.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BankSystem.Infraestructure.Data.Mappings;

public class AtivoMapping : IEntityTypeConfiguration<Ativo>
{
    public void Configure(EntityTypeBuilder<Ativo> builder)
    {
        builder.HasKey(a => a.Id);

        builder.Property(a => a.Codigo)
            .HasMaxLength(50)
            .IsRequired();

        builder.Property(a => a.Nome)
            .HasMaxLength(100)
            .IsRequired();

        builder.Property(a => a.Tipo)
            .HasMaxLength(100)
            .IsRequired();

        builder.Property(a => a.PrecoAtual)
            .HasPrecision(20, 2)
            .IsRequired();

    }
}
