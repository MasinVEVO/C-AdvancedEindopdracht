using ConsoleApp1.Patterns.Creational.Singleton;

namespace ConsoleApp1.Concurrency.ThreadPool;

/// <summary>
/// Representeert een taak die productvoorraad hoeveelheden bijwerkt in het inventarissysteem.
/// Ontworpen om uitgevoerd te worden door een thread pool worker thread.
/// </summary>
public class StockUpdateTask : IThreadPoolTask
{
    private readonly string _productName;
    private readonly int _quantity;

    /// <summary>
    /// Initialiseert een nieuwe instantie van de <see cref="StockUpdateTask"/> klasse.
    /// </summary>
    /// <param name="productName">De naam van het product waarvan de voorraad moet worden bijgewerkt</param>
    /// <param name="quantity">De hoeveelheid waarmee de voorraad moet worden verlaagd</param>
    public StockUpdateTask(string productName, int quantity)
    {
        _productName = productName;
        _quantity = quantity;
    }

    /// <summary>
    /// Voert de voorraad-update taak uit door de voorraad van het product te verlagen.
    /// Gebruikt de singleton InventoryManager om de voorraadvermindering uit te voeren.
    /// </summary>
    public void Execute()
    {
        // Verkrijg singleton instantie van inventory manager
        var inventory = InventoryManager.Instance;

        // Voer individuele voorraadverminderingen uit
        // OPMERKING: Overweeg een batch-operatie voor betere prestaties
        for (int i = 0; i < _quantity; i++)
        {
            inventory.ReduceStock(_productName);
        }

        // Log voltooiing
        Console.WriteLine($" {_quantity} voorraadupdates voor {_productName} verwerkt.");
    }
}