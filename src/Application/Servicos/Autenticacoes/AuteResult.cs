namespace Application.Servicos.Autenticacoes
{
    public record AuteResult(
        Guid Id,
        string FirstName,
        string LastName,
        string Email,
        string Token);
}
