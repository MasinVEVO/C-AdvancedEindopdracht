using MyApp.Models;

namespace ConsoleApp1.Repositories;

/// <summary>
/// Implementatie van IProductRepository die producten beheert in een in-memory dictionary.
/// Biedt functionaliteit voor het toevoegen, ophalen, bijwerken en verwijderen van producten.
/// </summary>
public class ProductRepository : IProductRepository
{
    /// <summary>
    /// Interne opslag voor producten, geïndexeerd op productnaam.
    /// </summary>
    private readonly Dictionary<string, Product> _products = new();

    /// <summary>
    /// Voegt een nieuw product toe aan de repository.
    /// Controleert of het product al bestaat om duplicaten te voorkomen.
    /// </summary>
    /// <param name="product">Het toe te voegen product</param>
    public void AddProduct(Product product)
    {
        if (!_products.ContainsKey(product.Name))
        {
            _products[product.Name] = product;
            Console.WriteLine($"Product {product.Name} toegevoegd.");
        }
        else
        {
            Console.WriteLine($"Product {product.Name} bestaat al.");
        }
    }

    /// <summary>
    /// Haalt een product op uit de repository op basis van naam.
    /// </summary>
    /// <param name="name">De naam van het gezochte product</param>
    /// <returns>Het product indien gevonden, anders null</returns>
    public Product? GetProduct(string name)
    {
        return _products.TryGetValue(name, out var product) ? product : null;
    }

    /// <summary>
    /// Haalt een lijst op van alle producten in de repository.
    /// </summary>
    /// <returns>Een collectie van alle producten</returns>
    public IEnumerable<Product> GetAllProducts()
    {
        return _products.Values;
    }

    /// <summary>
    /// Werkt een bestaand product bij in de repository.
    /// </summary>
    /// <param name="product">Het bijgewerkte product</param>
    public void UpdateProduct(Product product)
    {
        if (_products.ContainsKey(product.Name))
        {
            _products[product.Name] = product;
            Console.WriteLine($"Product {product.Name} bijgewerkt.");
        }
        else
        {
            Console.WriteLine($"Product {product.Name} niet gevonden.");
        }
    }

    /// <summary>
    /// Verwijdert een product uit de repository op basis van naam.
    /// </summary>
    /// <param name="name">De naam van het te verwijderen product</param>
    public void RemoveProduct(string name)
    {
        if (_products.ContainsKey(name))
        {
            _products.Remove(name);
            Console.WriteLine($"Product {name} verwijderd.");
        }
        else
        {
            Console.WriteLine($"Product {name} niet gevonden.");
        }
    }
}