using Domain;

namespace Application.Common.Interfaces.Pesistencia
{
    public interface IUserRepository
    {
        User? GetUserByEmail(string email);
        void Add(User user);
    }
}
