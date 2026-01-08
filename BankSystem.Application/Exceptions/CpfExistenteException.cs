using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http.HttpResults;

namespace BankSystem.Application.Exceptions;

public class CpfJaCadastradoException : Exception
{
    public CpfJaCadastradoException()
        : base("CPF já cadastrado no sistema.")
    {
    }
}

