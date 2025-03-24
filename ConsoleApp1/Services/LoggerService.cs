namespace ConsoleApp1.Services;

public class LoggerService
{
    private const string LogFilePath = "logs.txt";

    public void Log(string message)
    {
        string logMessage = $"[{DateTime.Now}] {message}";
        Console.WriteLine(logMessage);
        File.AppendAllText(LogFilePath, logMessage + Environment.NewLine);
    }

    public void LogError(string error)
    {
        string errorMessage = $" Fout: {error}";
        Console.WriteLine(errorMessage);
        File.AppendAllText(LogFilePath, errorMessage + Environment.NewLine);
    }
}