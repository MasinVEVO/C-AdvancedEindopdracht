using ConsoleApp1.Patterns.Creational.Singleton;
using MyApp.Models;

namespace ConsoleApp1.Services;

public class ProductService
{
    private readonly InventoryManager _inventoryManager;

    public ProductService()
    {
        _inventoryManager = InventoryManager.Instance;
    }

    public void AddProduct(Product product)
    {
        _inventoryManager.AddProduct(product);
        Console.WriteLine($" Product toegevoegd: {product.Name}");
    }

    public void RemoveProduct(string productName)
    {
        var product = _inventoryManager.GetProduct(productName);

        if (product != null)
        {
            Console.WriteLine($" Verwijderen niet mogelijk via InventoryManager. Implementatie van 'RemoveProduct' vereist aanpassing.");
        }
        else
        {
            Console.WriteLine($" Product {productName} niet gevonden.");
        }
    }

    public void UpdateStock(string productName, int quantity)
    {
        for (int i = 0; i < quantity; i++)
        {
            _inventoryManager.ReduceStock(productName);
        }
        Console.WriteLine($"✅ {quantity} items toegevoegd aan voorraad van {productName}");
    }

    public void ShowAllProducts()
    {
        _inventoryManager.ShowInventory();
    }
}