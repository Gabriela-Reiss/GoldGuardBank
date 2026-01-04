using BankSystem.Domain.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BankSystem.Infraestructure.Data.Mappings;

public class InvestimentoMapping : IEntityTypeConfiguration<Investimento>
{
    public void Configure(EntityTypeBuilder<Investimento> builder)
    {
        builder.HasKey(i => i.Id);

        builder.HasOne(i => i.Conta)
               .WithMany()
               .HasForeignKey(c => c.ContaId)
               .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(i => i.Ativo)
               .WithMany()
               .HasForeignKey(i => i.AtivoId)
               .OnDelete(DeleteBehavior.Restrict);

        builder.Property(i => i.Quantidade)
               .HasPrecision(18, 4)
               .IsRequired();

        builder.Property(i => i.PrecoCompra)
               .HasPrecision(18, 2)
               .IsRequired();

        builder.Property(i => i.DataCompra)
               .IsRequired();

    }
}
