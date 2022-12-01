using FluentResults;

namespace Application.Common.Erros
{
    public class SenhaIncorretaError : IError
    {
        public List<IError> Reasons => throw new NotImplementedException();

        public string Message => "Senha Incorreta!";

        public Dictionary<string, object> Metadata => throw new NotImplementedException();
    }
}