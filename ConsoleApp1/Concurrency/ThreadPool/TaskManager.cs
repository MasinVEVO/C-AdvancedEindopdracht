using System.Collections.Concurrent;

namespace ConsoleApp1.Concurrency.ThreadPool;

/// <summary>
/// Beheert de uitvoering van taken via een threadpool mechanisme.
/// Verdeelt taken over meerdere threads voor parallelle verwerking.
/// </summary>
public class TaskManager
{
    private int _maxTasks; // OPMERKING: Deze variabele wordt niet geïnitialiseerd
    private readonly BlockingCollection<IThreadPoolTask> _taskQueue = new();
    private readonly Thread[] _workers;

    /// <summary>
    /// Initialiseert een nieuwe instantie van de <see cref="TaskManager"/> klasse.
    /// </summary>
    /// <param name="numbersOfThreads">Het aantal worker threads dat moet worden aangemaakt.</param>
    public TaskManager(int numbersOfThreads)
    {
        _workers = new Thread[numbersOfThreads];

        for(int i = 0; i < numbersOfThreads; i++)
        {
            _workers[i] = new Thread(Worker);
            _workers[i].Start();
        }
    }

    /// <summary>
    /// Voegt een nieuwe taak toe aan de wachtrij voor verwerking.
    /// Gooit een exceptie wanneer de wachtrij vol is.
    /// </summary>
    /// <param name="task">De actie die moet worden uitgevoerd.</param>
    /// <exception cref="InvalidOperationException">Wanneer de taakwachtrij vol is.</exception>
    public void EnqueueTask(Action task)
    {
        if (_taskQueue.Count < _maxTasks)
        {
            _taskQueue.Add(new ThreadPoolTask(task));
        }
        else
        {
            throw new InvalidOperationException("Task queue is full.");
        }
    }

    /// <summary>
    /// Start de verwerking van taken in de wachtrij.
    /// OPMERKING: Deze methode verwerkt taken in de hoofdthread, wat mogelijk niet de bedoeling is.
    /// </summary>
    public void StartProcessing()
    {
        while (_taskQueue.Count > 0)
        {
            var task = _taskQueue.Take();
            task.Execute();
        }
    }

    /// <summary>
    /// Worker methode die door elke thread wordt uitgevoerd om taken te verwerken.
    /// Blijft taken consumeren uit de wachtrij totdat deze leeg is.
    /// </summary>
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

    /// <summary>
    /// Interface die een uitvoerbare taak voor de threadpool definieert.
    /// OPMERKING: Deze interface is ook al gedefinieerd in een apart bestand (IThreadPoolTask.cs).
    /// </summary>
    public interface IThreadPoolTask
    {
        void Execute();
    }

    /// <summary>
    /// Implementatie van IThreadPoolTask die een Action omvat.
    /// </summary>
    public class ThreadPoolTask : IThreadPoolTask
    {
        private readonly Action _action;

        /// <summary>
        /// Initialiseert een nieuwe instantie van de <see cref="ThreadPoolTask"/> klasse.
        /// </summary>
        /// <param name="action">De actie die moet worden uitgevoerd.</param>
        public ThreadPoolTask(Action action)
        {
            _action = action;
        }

        /// <summary>
        /// Voert de opgegeven actie uit.
        /// </summary>
        public void Execute()
        {
            _action();
        }
    }
    
}