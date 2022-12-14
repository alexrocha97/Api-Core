using System.Net;
using FluentResults;

namespace Application.Common.Erros
{
    public class DuplicateEmailError : IError
    {
        public List<IError> Reasons => throw new NotImplementedException();

        public string Message => "Email já existe!";

        public Dictionary<string, object> Metadata => throw new NotImplementedException();
    }
}