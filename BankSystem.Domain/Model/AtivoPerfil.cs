using BankSystem.Domain.Model.Enums;

namespace BankSystem.Domain.Model;

public class AtivoPerfil
{
    public int Id { get; set; }

    public int AtivoId { get; set; }
    public Ativo Ativo { get; set; } = null!;

    public PerfilInvestimento Perfil {  get; set; }
    public int NivelRisco { get; set; } // 1 a 10
}
