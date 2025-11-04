using Ignitis.Application.Abstractions;

namespace Ignitis.Infrastructure
{
    public class DateTimeProvider : IDateTimeProvider
    {
        private Func<DateTimeOffset> _utcNowFunc;

        public DateTimeProvider()
        {
            _utcNowFunc = () => DateTimeOffset.UtcNow;
        }

        public virtual DateTimeOffset UtcNow
        {
            get => _utcNowFunc();
            set => _utcNowFunc = () => value;
        }

        DateTimeOffset IDateTimeProvider.UtcNow()
        {
            return DateTimeOffset.UtcNow;
        }
    }
}
