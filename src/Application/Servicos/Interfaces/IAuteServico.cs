using Application.Common.Erros;
using Application.Servicos.Autenticacoes;
using FluentResults;

namespace Application.Servicos.Interfaces
{
    public interface IAuteServico
    {
        Result<AuteResult> Registro(string firstName, string lastName, string email, string password);
        AuteResult Login(string email, string password);
    }
}
