using BankSystem.Application.DTOs;
using BankSystem.Application.Exceptions;
using BankSystem.Application.Services.Interfaces;
using BankSystem.Domain.Model;
using BankSystem.Domain.Model.Enums;
using BankSystem.Domain.Repositories.Interfaces;

namespace BankSystem.Application.Services.Implementations;

public class AuthService : IAuthService
{
    private readonly IUnityOfWork _uow;
    private readonly IJwtService _jwt;

    public AuthService(IUnityOfWork uow, IJwtService jwt)
    {
        _uow = uow;
        _jwt = jwt;
    }

    public async Task<LoginResultDto> LoginAsync(LoginDto dto)
    {
        var login = _uow.Logins.GetByCpf(dto.CPF);

        if (login == null || !login.ValidarSenha(dto.Senha))
            throw new CredencialInvalidaException();

        return _jwt.GerarToken(login.Usuario);
    }

    public async Task RegistryAsync(RegistroUsuarioDto dto)
    {
        if (_uow.Logins.GetByCpf(dto.CPF) != null)
            throw new CpfJaCadastradoException();


        var usuario = new Usuario
        {
            Nome = dto.Nome,
            CPF = dto.CPF,
            Email = dto.Email,
            Telefone = dto.Telefone,
            Endereco = new Endereco
            {
                Logradouro = dto.Endereco.Logradouro,
                Bairro = dto.Endereco.Bairro,
                Complemento = dto.Endereco.Complemento,
                Cidade = dto.Endereco.Cidade,
                Estado = dto.Endereco.Estado,
                CEP = dto.Endereco.CEP
            }
        };


        var conta = new Conta
        {
            Usuario = usuario,
            Tipo = dto.TipoConta,
            DataCriacao = DateTime.Now
        };


        var senhaHash = BCrypt.Net.BCrypt.HashPassword(dto.Senha);

        var login = new Login(
            dto.CPF,
            senhaHash,
            usuario
        );

        await _uow.Usuarios.AddAsync(usuario);
        await _uow.Contas.AddAsync(conta);
        await _uow.Logins.AddAsync(login);

 
        if (dto.DepositoInicial is > 0)
        {
            var depositoInicial = Transacao.Criar(
                conta,
                TipoTransacao.DEPOSITO,
                dto.DepositoInicial.Value,
                "Depósito inicial da conta"
            );

            await _uow.Transacoes.AddAsync(depositoInicial);
        }

        await _uow.CommitAsync();
    }
}

