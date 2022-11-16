using Application.Common.Interfaces.Autenticacao;
using Application.Common.Interfaces.Pesistencia;
using Application.Servicos.Interfaces;
using Domain;

namespace Application.Servicos.Autenticacoes
{
    public class AuteServico : IAuteServico
    {
        private readonly IJwtTokenGenerator _jwtTokenGenerator;
        private readonly IUserRepository _userRepository;
        public AuteServico(
            IJwtTokenGenerator jwtTokenGenerator,
            IUserRepository userRepository)
        {
            _jwtTokenGenerator = jwtTokenGenerator;
            _userRepository = userRepository;
        }

        public AuteResult Registro(
            string firstName, 
            string lastName, 
            string email, 
            string password)
        {
            // Check if user already exists
            if(_userRepository.GetUserByEmail(email) is not null)
            {
                throw new Exception("O usuário com e-mail fornecido já existe.");
            }

            // Create user (generate unique ID)
            var user = new User
            {
                FirstName = firstName,
                LastName = lastName,
                Email = email,
                Password = password
            };
            _userRepository.Add(user);
            // Create JWT token
            var token = _jwtTokenGenerator
                .GenerateToken(user);

            return new AuteResult(
                user,
                token);
        }

        public AuteResult Login(string email, string password)
        {
            // 1 - Validar se o usuário existe
            if(_userRepository.GetUserByEmail(email) is not User user){
                throw new Exception("O e-mail fornecido não existe.");
            }
            // 2 - Validar se password(senha) está correto
            if(user.Password != password){
                throw new Exception("Senha inválida..");
            }
            // 3 - Criação do token jwt
            var token = _jwtTokenGenerator.GenerateToken(user);

            return new AuteResult(
                user, 
                token
            );
        }
    }
}
