using FluentResults;

namespace Application.Common.Erros
{
    public class EmailIncorretoError : IError
    {
        public List<IError> Reasons => throw new NotImplementedException();

        public string Message => "Email incorreto...";

        public Dictionary<string, object> Metadata => throw new NotImplementedException();
    }
}