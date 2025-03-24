using ConsoleApp1.Patterns.Creational.Singleton;

namespace ConsoleApp1.Concurrency.ProducerConsumer;

public class StockUpdateTask : IConsumerTask
{
    private readonly string _productName;
    private readonly int _quantity;
    
    public StockUpdateTask(string productName, int quantity)
    {
        _productName = productName;
        _quantity = quantity;
    }
    
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