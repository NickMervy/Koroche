namespace Services
{
    public interface ILogger
    {
        void Log(string log);
        void LogWarning(string log);
        void LogError(string log);
    }
}