using Application.Common.Erros;
using Application.Common.Interfaces.Autenticacao;
using Application.Common.Interfaces.Pesistencia;
using Application.Servicos.Interfaces.Commamd;
using Domain;
using FluentResults;

namespace Application.Servicos.Autenticacoes.Commamd
{
    public class AuteCommandServico : IAuteCommandServico
    {
        private readonly IJwtTokenGenerator _jwtTokenGenerator;
        private readonly IUserRepository _userRepository;
        public AuteCommandServico(
            IJwtTokenGenerator jwtTokenGenerator,
            IUserRepository userRepository)
        {
            _jwtTokenGenerator = jwtTokenGenerator;
            _userRepository = userRepository;
        }

        public Result<AuteResult> Registro(
            string firstName, 
            string lastName, 
            string email, 
            string password)
        {
            // Check if user already exists
            if(_userRepository.GetUserByEmail(email) is not null)
            {
                return Result.Fail<AuteResult>(new[]  { new DuplicateEmailError() });
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

        public Result<AuteResult> Login(string email, string password)
        {
            // 1 - Validar se o usuário existe
            if(_userRepository.GetUserByEmail(email) is not User user){

                throw new Exception("O e-mail fornecido não existe.");
                // throw new DuplicateEmailExcepetion();
            }
            // 2 - Validar se password(senha) está correto
            if(user.Password != password){
                return Result.Fail<AuteResult>(new[] { new SenhaIncorretaError() });
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
