namespace BankSystem.Domain.Model;

using System.ComponentModel.DataAnnotations;
using BankSystem.Domain.Model.Enums;
public class Ativo
{
    public int Id { get; set; }
    public string Nome { get; set; } = null!;
    public string Simbolo { get; set; } = null!;
    public TipoAtivo Tipo { get; set; }
    public decimal PrecoAtual { get;  set; }




    public void AtualizarPreco(decimal novoPreco)
    {
        if (novoPreco <= 0)
            throw new Exception("Preço inválido");

        PrecoAtual = novoPreco;
    }
}


