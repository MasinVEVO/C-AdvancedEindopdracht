using ConsoleApp1.Patterns.Creational.Singleton;
using System;

namespace ConsoleApp1.Concurrency.ProducerConsumer;

/// <summary>
/// Implementeert een taak voor het verwerken van bestellingen in een producer-consumer patroon.
/// Deze klasse handelt de verwerking van productbestellingen af door de voorraad aan te passen.
/// </summary>
public class OrderingProcessingTask : IConsumerTask
{
    private readonly string _productName;
    private readonly int _quantity;

    /// <summary>
    /// Initialiseert een nieuwe instantie van de <see cref="OrderingProcessingTask"/> klasse.
    /// </summary>
    /// <param name="productName">De naam van het product dat besteld wordt.</param>
    /// <param name="quantity">De hoeveelheid van het product dat besteld wordt.</param>
    public OrderingProcessingTask(string productName, int quantity)
    {
        _productName = productName;
        _quantity = quantity;
    }

    /// <summary>
    /// Voert de bestellingsverwerkingstaak uit door de voorraad aan te passen voor het opgegeven product.
    /// Als het product niet bestaat in de inventaris, wordt een melding weergegeven.
    /// </summary>
    public void Execute()
    {
        var inventory = InventoryManager.Instance;
        var product = inventory.GetProduct(_productName);

        if (product == null)
        {
            Console.WriteLine($"Product {_productName} is niet gevonden in de inventaris.");
            return;
        }

        for(int i = 0; i < _quantity; i++)
        {
            inventory.ReduceStock(_productName);
        }

        Console.WriteLine($"Bestelling voor {_quantity} {_productName} is verwerkt.");
    }
}