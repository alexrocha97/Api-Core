using Application.Servicos.Autenticacoes;

namespace Application.Servicos.Interfaces
{
    public interface IAuteServico
    {
        AuteResult Registro(string firstName, string lastName, string email, string password);
        AuteResult Login(string email, string password);
    }
}
