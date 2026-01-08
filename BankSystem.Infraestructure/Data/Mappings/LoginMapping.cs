using BankSystem.Domain.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BankSystem.Infraestructure.Data.Mappings;

public class LoginMapping : IEntityTypeConfiguration<Login>
{
    public void Configure(EntityTypeBuilder<Login> builder)
    {
        builder.HasKey(l => l.Id);

        builder.Property(l => l.CPF)
            .IsRequired()
            .HasMaxLength(150);

        builder.Property(l => l.SenhaHash)
            .IsRequired()
            .HasMaxLength(255);

        builder.HasOne(l => l.Usuario)
            .WithOne(u => u.Login)
            .HasForeignKey<Login>(l => l.UsuarioId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasIndex(l => l.CPF)
            .IsUnique();
    }
}
