namespace Ignitis.Application.Abstractions
{
    public interface IDateTimeProvider
    {
        DateTimeOffset UtcNow();
    }
}
