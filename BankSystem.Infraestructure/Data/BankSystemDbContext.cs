using BankSystem.Domain.Model;
using BankSystem.Domain.Model.Enums;
using Microsoft.EntityFrameworkCore;

namespace BankSystem.Infraestructure.Context;

public class BankSystemDbContext : DbContext
{
    public BankSystemDbContext(DbContextOptions options) : base(options) { }

    public DbSet<Usuario> Usuarios { get; set; }
    public DbSet<Conta> Contas { get; set; }
    public DbSet<Ativo> Ativos { get; set; }
    public DbSet<Transacao> Transacoes { get; set; }
    public DbSet<Investimento> Investimentos { get; set; }
    public DbSet<Login> Logins { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(BankSystemDbContext).Assembly);

        SeedAtivos(modelBuilder);
    }

    private static void SeedAtivos(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Ativo>().HasData(
        new Ativo
        {
            Id = 1,
            Nome = "Tesouro Selic",
            Simbolo = "SELIC",
            Tipo = TipoAtivo.RENDA_FIXA,
            PrecoAtual = 1.00m 
        },
new Ativo
{
    Id = 2,
    Nome = "Tesouro IPCA+",
    Simbolo = "IPCA",
    Tipo = TipoAtivo.RENDA_FIXA,
    PrecoAtual = 1.05m
},
new Ativo
{
    Id = 3,
    Nome = "ETF S&P 500",
    Simbolo = "SPY",
    Tipo = TipoAtivo.ETF,
    PrecoAtual = 520.00m
},
new Ativo
{
    Id = 4,
    Nome = "ETF Nasdaq 100",
    Simbolo = "QQQ",
    Tipo = TipoAtivo.ETF,
    PrecoAtual = 450.00m
},
new Ativo
{
    Id = 5,
    Nome = "Ações Brasileiras",
    Simbolo = "PETR4",
    Tipo = TipoAtivo.ACAO,
    PrecoAtual = 38.50m
}

        );
    }

    
}
