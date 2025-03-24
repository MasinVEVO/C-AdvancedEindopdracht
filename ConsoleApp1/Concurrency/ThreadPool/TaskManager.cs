using System.Collections.Concurrent;

namespace ConsoleApp1.Concurrency.ThreadPool;

public class TaskManager
{
    private readonly BlockingCollection<IThreadPoolTask> _taskQueue = new();
    private readonly Thread[] _workers;

    public TaskManager(int numbersOfThreads)
    {
        _workers = new Thread[numbersOfThreads];
        
        for(int i = 0; i < numbersOfThreads; i++)
        {
            _workers[i] = new Thread(Worker);
            _workers[i].Start();
        }
    }
    
    public void AddTask(IThreadPoolTask task)
    {
        _taskQueue.Add(task);
    }
    
    private void Worker()
    {
        foreach (var task in _taskQueue.GetConsumingEnumerable())
        {
            try
            {
                task.Execute();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }
    }

    private void Stop()
    {
        _taskQueue.CompleteAdding();
        foreach (var worker in _workers)
        {
            worker.Join();
        }
        
    }
}