using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankSystem.Application.Exceptions;

public class CredencialInvalidaException : Exception
{
    public CredencialInvalidaException()
        : base("Credenciais Inválidas")
    {
    }
}
