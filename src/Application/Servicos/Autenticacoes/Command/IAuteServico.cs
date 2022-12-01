using Application.Servicos.Autenticacoes;
using FluentResults;

namespace Application.Servicos.Interfaces.Commamd
{
    public interface IAuteCommandServico
    {
        Result<AuteResult> Registro(string firstName, string lastName, string email, string password);
        Result<AuteResult> Login(string email, string password);
    }
}
