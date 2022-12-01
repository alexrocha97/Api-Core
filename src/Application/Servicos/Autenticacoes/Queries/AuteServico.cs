using Application.Common.Erros;
using Application.Common.Interfaces.Autenticacao;
using Application.Common.Interfaces.Pesistencia;
using Application.Servicos.Interfaces.Queries;
using Domain;
using FluentResults;

namespace Application.Servicos.Autenticacoes.Queries
{
    public class AuteQueryServico : IAuteQueryServico
    {
        private readonly IJwtTokenGenerator _jwtTokenGenerator;
        private readonly IUserRepository _userRepository;
        public AuteQueryServico(
            IJwtTokenGenerator jwtTokenGenerator,
            IUserRepository userRepository)
        {
            _jwtTokenGenerator = jwtTokenGenerator;
            _userRepository = userRepository;
        }

        public Result<AuteResult> Login(string email, string password)
        {
            // 1 - Validar se o usuário existe
            if(_userRepository.GetUserByEmail(email) is not User user){

                return Result.Fail<AuteResult>(new[] { new EmailIncorretoError() });
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
