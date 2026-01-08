
using BankSystem.Domain.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BankSystem.Infraestructure.Data.Mappings;

public class TransacaoMapping : IEntityTypeConfiguration<Transacao>
{
    public void Configure(EntityTypeBuilder<Transacao> builder)
    {
        builder.HasKey(t => t.Id);

        builder.HasOne(t => t.Conta)
       .WithMany(c => c.Transacoes)
       .HasForeignKey(t => t.ContaId);


        builder.Property(t => t.Tipo)
               .HasConversion<string>()
               .IsRequired();

        builder.Property(t => t.Valor)
               .HasPrecision(18, 2)
               .IsRequired();

        builder.Property(t => t.Data)
               .IsRequired();

        builder.Property(t => t.Descricao)
               .HasMaxLength(255);
    }
}
