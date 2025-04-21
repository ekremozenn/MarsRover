namespace Nexum.MarsRover.Core.Interfaces
{
    public interface ILogger
    {
        void Log(string message);  // Info
        void LogError(string message);   // Error
    }

}