using Domain;

namespace Application.Servicos.Autenticacoes
{
    public record AuteResult(
        User user,
        string Token);
}
