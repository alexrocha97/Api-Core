using Application.Common.Interfaces.Services;

namespace Infra.Servicos
{
    public class DateTimeProvider : IDateTimeProvider
    {
        public DateTime UtcNow => DateTime.UtcNow;
    }
}
