using System.Collections.Concurrent;

namespace ConsoleApp1.Concurrency.ProducerConsumer;

/// <summary>
/// Implementeert een wachtrij voor het verwerken van bestellingen volgens het producer-consumer patroon.
/// Deze klasse beheert een collectie van taken die door meerdere worker threads parallel worden uitgevoerd.
/// </summary>
public class OrderProcessingQueue
{
    private readonly BlockingCollection<IConsumerTask> _taskQueue = new();
    private readonly Thread[] _workers;

    /// <summary>
    /// Initialiseert een nieuwe instantie van de <see cref="OrderProcessingQueue"/> klasse.
    /// </summary>
    /// <param name="numbersOfWorkers">Het aantal worker threads dat parallel taken zal verwerken.</param>
    public OrderProcessingQueue(int numbersOfWorkers)
    {
        _workers = new Thread[numbersOfWorkers];

        for (int i = 0; i < numbersOfWorkers; i++)
        {
            _workers[i] = new Thread(Worker);
            _workers[i].Start();
        }
    }

    /// <summary>
    /// Voegt een nieuwe taak toe aan de verwerkingswachtrij.
    /// </summary>
    /// <param name="task">De taak die moet worden uitgevoerd door een worker thread.</param>
    public void AddTask(IConsumerTask task)
    {
        _taskQueue.Add(task);
    }

    /// <summary>
    /// De methode die door elke worker thread wordt uitgevoerd om taken uit de wachtrij te consumeren.
    /// Blijft draaien totdat de wachtrij wordt gemarkeerd als voltooid en verwerkt elke taak die beschikbaar komt.
    /// Vangt eventuele fouten op die tijdens de uitvoering van een taak optreden.
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
                Console.WriteLine($"Fout tijdens het uitvoeren van taak: {ex.Message}");
            }
        }
    }

    /// <summary>
    /// Stopt de verwerking van taken door de wachtrij te markeren als voltooid en wacht totdat alle worker threads zijn beëindigd.
    /// </summary>
    private void Stop()
    {
        _taskQueue.CompleteAdding();
        foreach (var worker in _workers)
        {
            worker.Join();
        }
    }

    /// <summary>
    /// Wacht tot alle taken in de wachtrij zijn verwerkt en stopt vervolgens de worker threads.
    /// Controleert periodiek of de wachtrij leeg is om overmatig CPU-gebruik te voorkomen.
    /// </summary>
    public void ProcessTasks()
    {
        while (_taskQueue.Count > 0)
        {
            Thread.Sleep(100); // Korte pauze om busy waiting te voorkomen
        }
        Stop();
    }
}