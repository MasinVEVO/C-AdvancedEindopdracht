using System.Collections.Concurrent;

namespace ConsoleApp1.Concurrency.ProducerConsumer;

public class OrderProcessingQueue
{
    private readonly BlockingCollection<IConsumerTask> _taskQueue = new();
    private readonly Thread[] _workers;

    public OrderProcessingQueue(int numbersOfWorkers)
    {
        _workers = new Thread[numbersOfWorkers];

        for (int i = 0; i < numbersOfWorkers; i++)
        {
            _workers[i] = new Thread(Worker);
            _workers[i].Start();
        }
    }

    public void AddTask(IConsumerTask task)
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
                Console.WriteLine($"Fout tijdens het uitvoeren van taak: {ex.Message}");
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

    public void ProcessTasks()
    {
        while (_taskQueue.Count > 0)
        {
            Thread.Sleep(100); // Sleep for a short period to avoid busy waiting
        }
        Stop();
    }
}