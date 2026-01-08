
using System.ComponentModel.DataAnnotations;
using BankSystem.Domain.Model.Enums;

namespace BankSystem.Domain.Model;

public class Conta
{
    [Key]
    public int Id { get; set; }

    [Required(ErrorMessage = "O usuário é obrigatório")]
    public int UsuarioId { get; set; }

    
    [Required(ErrorMessage = "O usuário é obrigatório")]
    public Usuario? Usuario { get; set; }

    
    [Required(ErrorMessage = "O tipo da conta é obrigatório")]
    [EnumDataType(typeof(TipoConta), ErrorMessage = "Tipo de conta inválido")]
    public TipoConta Tipo { get; set; }

    [Required]
    [Range(0, double.MaxValue)]
    public decimal SaldoTotal { get; private set; }

    [Required]
    [StringLength(12)]
    public string NumeroConta { get; private set; } = string.Empty;

    public DateTime DataCriacao { get; set; } = DateTime.Now;

    public ICollection<Transacao>? Transacoes { get; set; }
    public ICollection<Investimento>? Investimentos { get; set; }


    public Conta()
    {
        SaldoTotal = 0;
        NumeroConta = GerarNumeroConta();
    }

    public void Creditar(decimal valor)
    {
        if(valor <= 0)
        {
            throw new Exception("Valor inválido");
        }

        SaldoTotal += valor;
    }

    public void Debitar(decimal valor)
    {
        if (valor <= 0)
        {
            throw new Exception("Valor inválido");
        }

        if(SaldoTotal < valor)
        {
            throw new Exception("Saldo insuficiente");
        }

        SaldoTotal -= valor;
    }

    private static string GerarNumeroConta()
    {
        // Ex: 437921045381
        return Random.Shared.NextInt64(100_000_000_000, 999_999_999_999).ToString();
    }

}
