using Application.Servicos.Autenticacoes;
using FluentResults;

namespace Application.Servicos.Interfaces.Queries
{
    public interface IAuteQueryServico
    {
        Result<AuteResult> Login(string email, string password);
    }
}
