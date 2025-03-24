using ConsoleApp1.Patterns.Creational.Singleton;

namespace ConsoleApp1.Concurrency.ProducerConsumer;

public class OrderingProcessingTask : IConsumerTask
{
    private readonly string _productName;
    private readonly int _quantity;
    
    public OrderingProcessingTask(string productName, int quantity)
    {
        _productName = productName;
        _quantity = quantity;
    }
    
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