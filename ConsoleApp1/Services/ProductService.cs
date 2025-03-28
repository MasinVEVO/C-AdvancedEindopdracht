using ConsoleApp1.Patterns.Creational.Singleton;
using MyApp.Models;

namespace ConsoleApp1.Services;

/// <summary>
/// Service klasse die productbeheer functionaliteit biedt door gebruik te maken van de InventoryManager singleton.
/// </summary>
public class ProductService
{
    /// <summary>
    /// De inventory manager die gebruikt wordt voor het beheren van de productvoorraad.
    /// </summary>
    private readonly InventoryManager _inventoryManager;

    /// <summary>
    /// Initialiseert een nieuwe instantie van de ProductService.
    /// Verkrijgt de singleton instantie van de InventoryManager.
    /// </summary>
    public ProductService()
    {
        _inventoryManager = InventoryManager.Instance;
    }

    /// <summary>
    /// Voegt een nieuw product toe aan de inventaris.
    /// </summary>
    /// <param name="product">Het toe te voegen product</param>
    public void AddProduct(Product product)
    {
        _inventoryManager.AddProduct(product);
        Console.WriteLine($" Product toegevoegd: {product.Name}");
    }

    /// <summary>
    /// Probeert een product te verwijderen op basis van naam.
    /// Momenteel niet geïmplementeerd via de InventoryManager.
    /// </summary>
    /// <param name="productName">De naam van het te verwijderen product</param>
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

    /// <summary>
    /// Werkt de voorraad van een specifiek product bij door het aantal items te verhogen.
    /// </summary>
    /// <param name="productName">De naam van het product</param>
    /// <param name="quantity">Het aantal toe te voegen items</param>
    public void UpdateStock(string productName, int quantity)
    {
        for (int i = 0; i < quantity; i++)
        {
            _inventoryManager.ReduceStock(productName);
        }
        Console.WriteLine($"✅ {quantity} items toegevoegd aan voorraad van {productName}");
    }

    /// <summary>
    /// Toont alle beschikbare producten in de inventaris.
    /// </summary>
    public void ShowAllProducts()
    {
        _inventoryManager.ShowInventory();
    }
}