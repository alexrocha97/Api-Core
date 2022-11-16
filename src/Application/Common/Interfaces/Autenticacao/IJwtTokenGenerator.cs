using Domain;

namespace Application.Common.Interfaces.Autenticacao
{
    public interface IJwtTokenGenerator
    {
        string GenerateToken(User user);
    }
}
