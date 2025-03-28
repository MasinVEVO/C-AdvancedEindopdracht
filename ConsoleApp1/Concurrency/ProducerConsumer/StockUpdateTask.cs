using ConsoleApp1.Patterns.Creational.Singleton;

namespace ConsoleApp1.Concurrency.ProducerConsumer;

/// <summary>
/// Implementeert een taak voor het bijwerken van de voorraad in een producer-consumer patroon.
/// Deze klasse verlaagt de voorraad van een product met een specifieke hoeveelheid.
/// </summary>
public class StockUpdateTask : IConsumerTask
{
    private readonly string _productName;
    private readonly int _quantity;

    /// <summary>
    /// Initialiseert een nieuwe instantie van de <see cref="StockUpdateTask"/> klasse.
    /// </summary>
    /// <param name="productName">De naam van het product waarvan de voorraad moet worden bijgewerkt.</param>
    /// <param name="quantity">De hoeveelheid waarmee de voorraad moet worden verlaagd.</param>
    public StockUpdateTask(string productName, int quantity)
    {
        _productName = productName;
        _quantity = quantity;
    }
    
    /// <summary>
    /// Voert de voorraad-update taak uit door de voorraad van het opgegeven product te verlagen.
    /// Maakt gebruik van de InventoryManager singleton om de voorraad bij te werken.
    /// </summary>
    public void Execute()
    {
        var inventory = InventoryManager.Instance;

        for (int i = 0; i < _quantity; i++)
        {
            inventory.ReduceStock(_productName);
        }

        Console.WriteLine($"{_quantity} voorraadupdates voor {_productName} verwerkt");
    }
}