namespace BankSystem.Application.DTOs;

public class LoginResultDto
{
    public string Token { get; set; }
    public DateTime ExpiraEm { get; set; }

    public int UsuarioId { get; set; }
    public string Nome { get; set; }
}
