
using System.ComponentModel.DataAnnotations;
using System.Runtime;

namespace BankSystem.Domain.Model;

public class Investimento
{
    [Key]
    public int Id { get; set; }

    [Required(ErrorMessage = "A conta é obrigatória")]
    public int ContaId { get; set; }

    public Conta? Conta { get; set; }


    [Required(ErrorMessage = "O ativo é obrigatório")]
    public int AtivoId { get; set; }

    public Ativo? Ativo { get; set; }

    [Required(ErrorMessage = "A quantidade é obrigatória")]
    [Range(0.0001, double.MaxValue, ErrorMessage = "A quantidade deve ser maior que zero")]
    public decimal Quantidade { get; set; }


    [Required(ErrorMessage = "O preço de compra é obrigatório")]
    [Range(0.01, double.MaxValue, ErrorMessage = "O preço de compra deve ser maior que zero")]
    public decimal PrecoCompra { get; set; }


    public DateTime DataCompra { get; set; } = DateTime.Now;
}
