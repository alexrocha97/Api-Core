using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Web.Autenticacao
{
    public record AutenticacaoReposta(
        Guid Id,
        string FirstName,
        string LastName,
        string Email,
        string Token)
    {
        
    }
}
