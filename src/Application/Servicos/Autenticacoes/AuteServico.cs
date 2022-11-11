using Application.Common.Interfaces.Autenticacao;
using Application.Servicos.Interfaces;

namespace Application.Servicos.Autenticacoes
{
    public class AuteServico : IAuteServico
    {
        private readonly IJwtTokenGenerator _jwtTokenGenerator;
        public AuteServico(IJwtTokenGenerator jwtTokenGenerator)
        {
            _jwtTokenGenerator = jwtTokenGenerator;
        }

        public AuteResult Registro(
            string firstName, 
            string lastName, 
            string email, 
            string password)
        {
            // Check if user already exists

            // Create user (generate unique ID)

            // Create JWT token
            var userId = Guid.NewGuid();
            var token = _jwtTokenGenerator
                .GenerateToken(userId,firstName,lastName);

            return new AuteResult(
                userId,
                firstName,
                lastName,
                email,
                token);
        }

        public AuteResult Login(string email, string password)
        {
            return new AuteResult(Guid.NewGuid(), "firstName", "lastName", email, "token");
        }
    }
}
