
using BankSystem.Domain.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BankSystem.Infraestructure.Data.Mappings;

public class AtivoPerfilMap : IEntityTypeConfiguration<AtivoPerfil>
{
    public void Configure(EntityTypeBuilder<AtivoPerfil> builder)
    {
        builder.ToTable("AtivoPerfis");

        builder.HasKey(ap => ap.Id);

        builder.HasOne(ap => ap.Ativo)
            .WithMany(a => a.Perfis)
            .HasForeignKey(ap => ap.AtivoId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.Property(ap => ap.Perfil)
            .IsRequired();

        builder.Property(ap => ap.NivelRisco)
            .IsRequired();
    }
}
