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
    public DbSet<AtivoPerfil> AtivoPerfis { get; set; }
    public DbSet<Transacao> Transacoes { get; set; }
    public DbSet<Investimento> Investimentos { get; set; }
    public DbSet<Login> Logins { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(BankSystemDbContext).Assembly);

        SeedAtivos(modelBuilder);
        SeedAtivoPerfis(modelBuilder);
    }

    private static void SeedAtivos(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Ativo>().HasData(
            new Ativo { Id = 1, Nome = "Tesouro Selic", Simbolo = "SELIC", Tipo = TipoAtivo.RENDA_FIXA },
            new Ativo { Id = 2, Nome = "Tesouro IPCA+", Simbolo = "IPCA", Tipo = TipoAtivo.RENDA_FIXA },
            new Ativo { Id = 3, Nome = "ETF S&P 500", Simbolo = "SPY", Tipo = TipoAtivo.ETF },
            new Ativo { Id = 4, Nome = "ETF Nasdaq 100", Simbolo = "QQQ", Tipo = TipoAtivo.ETF },
            new Ativo { Id = 5, Nome = "Ações Brasileiras", Simbolo = "B3", Tipo = TipoAtivo.ACAO }
        );
    }

    private static void SeedAtivoPerfis(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<AtivoPerfil>().HasData(

            // CONSERVADOR
            new AtivoPerfil
            {
                Id = 1,
                AtivoId = 1, // Tesouro Selic
                Perfil = PerfilInvestimento.CONSERVADOR,
                NivelRisco = 2
            },

            // MODERADO
            new AtivoPerfil
            {
                Id = 2,
                AtivoId = 2, // Tesouro IPCA+
                Perfil = PerfilInvestimento.MODERADO,
                NivelRisco = 4
            },
            new AtivoPerfil
            {
                Id = 3,
                AtivoId = 3, // ETF S&P 500
                Perfil = PerfilInvestimento.MODERADO,
                NivelRisco = 6
            },

            // ARROJADO
            new AtivoPerfil
            {
                Id = 4,
                AtivoId = 4, // Nasdaq
                Perfil = PerfilInvestimento.ARROJADO,
                NivelRisco = 8
            },
            new AtivoPerfil
            {
                Id = 5,
                AtivoId = 5, // Ações
                Perfil = PerfilInvestimento.ARROJADO,
                NivelRisco = 9
            }
        );
    }
}
