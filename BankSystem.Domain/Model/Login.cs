namespace BankSystem.Domain.Model;

public class Login
{
    public int Id { get; set; }
    public string CPF { get; set; }
    public string SenhaHash { get; set; }
    public int UsuarioId { get; set; }
    public Usuario Usuario { get; set; } 

    public Login()
    {

    }

    public Login(string cpf, string senhaHash, Usuario usuario)
    {
        CPF = cpf;
        SenhaHash = senhaHash;
        Usuario = usuario;

    }

    public bool ValidarSenha(string senha)
    {
        return BCrypt.Net.BCrypt.Verify(senha, SenhaHash);
    }
}
