
using BankSystem.Domain.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BankSystem.Infraestructure.Data.Mappings;

public class UsuarioMapping : IEntityTypeConfiguration<Usuario>
{
    public void Configure(EntityTypeBuilder<Usuario> builder)
    {
        builder.HasKey(u => u.Id);

        builder.Property(u => u.Nome)
            .HasMaxLength(100)
            .IsRequired();

        builder.Property(u => u.CPF)
            .HasMaxLength(14)
            .IsRequired();

        builder.Property(u => u.Email)
            .HasMaxLength(150)
            .IsRequired();

        builder.Property(u => u.Telefone)
            .HasMaxLength(20)
            .IsRequired();

        builder.OwnsOne(u => u.Endereco, endereco =>
        {
            endereco.Property(e => e.Logradouro)
                    .HasColumnName("Logradouro")
                    .HasMaxLength(150)
                    .IsRequired();

            endereco.Property(e => e.Bairro)
                    .HasColumnName("Bairro")
                    .HasMaxLength(100)
                    .IsRequired();

            endereco.Property(e => e.Complemento)
                    .HasColumnName("Complemento")
                    .HasMaxLength(100);

            endereco.Property(e => e.Cidade)
                    .HasColumnName("Cidade")
                    .HasMaxLength(100)
                    .IsRequired();

            endereco.Property(e => e.Estado)
                    .HasMaxLength(2)
                    .IsRequired();

            endereco.Property(e => e.CEP)
                    .HasMaxLength(9)
                    .IsRequired();
        });

    }
}
