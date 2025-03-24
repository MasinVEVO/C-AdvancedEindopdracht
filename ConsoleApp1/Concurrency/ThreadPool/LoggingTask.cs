namespace ConsoleApp1.Concurrency.ThreadPool;

public class LoggingTask : IThreadPoolTask
{
    private readonly string _logMessage;
    
    public LoggingTask(string logMessage)
    {
        _logMessage = logMessage;
    }
    
    public void Execute()
    {
        Console.WriteLine($" LOG: {_logMessage}");
    }
}