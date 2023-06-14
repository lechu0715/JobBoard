using JobBoard.Application.Common.Interfaces.Services;

namespace JobBoard.Infrastructure.Services
{
    public class DateTimeProvider : IDateTimeProvider
    {
        public DateTime UtcNow => DateTime.UtcNow;
    }
}
