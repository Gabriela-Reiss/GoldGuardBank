
using System;
using BankSystem.Domain.Model;
using Microsoft.EntityFrameworkCore;

namespace BankSystem.Infraestructure.Context;

public class BankSystemDbContext : DbContext
{
    public BankSystemDbContext(DbContextOptions options) : base(options)
    {
    }

    public DbSet<Usuario> Usuarios { get; set; }
    public DbSet<Conta> Contas { get; set; }
    public DbSet<Ativo> Ativos { get; set; }
    public DbSet<Transacao> Transacoes { get; set; }
    public DbSet<Investimento> Investimentos { get; set; }



    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(BankSystemDbContext).Assembly);

    }
}
