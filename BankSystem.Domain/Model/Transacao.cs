
using System.ComponentModel.DataAnnotations;
using BankSystem.Domain.Model.Enums;

namespace BankSystem.Domain.Model;

public class Transacao
{
    [Key]
    public int Id { get; set; }

    [Required(ErrorMessage = "A conta é obrigatória")]
    public int ContaId { get; set; }

    [Required(ErrorMessage = "A conta é obrigatória")]
    public Conta? Conta { get; set; }

    [Required(ErrorMessage = "O tipo da transação é obrigatório")]
    [EnumDataType(typeof(TipoTransacao), ErrorMessage = "Tipo de transação inválido")]
    public TipoTransacao Tipo { get; set; }


    [Required(ErrorMessage = "O valor é obrigatório")]
    [Range(0.01, double.MaxValue, ErrorMessage = "O valor deve ser maior que zero")]
    [DataType(DataType.Currency)]
    public decimal Valor { get; set; }



    public DateTime Data { get; set; } = DateTime.Now;


    [StringLength(255, ErrorMessage = "A descrição pode ter no máximo 255 caracteres")]
    public string? Descricao { get; set; }


    public static Transacao Criar(Conta conta, TipoTransacao tipo, decimal valor, string descricao)
    {
        return new Transacao
        {
            ContaId = conta.Id,
            Tipo = tipo,
            Valor = valor,
            Data = DateTime.Now,
            Descricao = descricao
        };
    }

}
