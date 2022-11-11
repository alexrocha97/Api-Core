namespace Web.Autenticacao
{
    public record RegisterSolicitar(
        string FirstName,
        string LastName,
        string Email,
        string Password)
    {
        
    }
}
