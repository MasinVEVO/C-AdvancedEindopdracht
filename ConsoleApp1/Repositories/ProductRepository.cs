using MyApp.Models;

namespace ConsoleApp1.Repositories;

public class ProductRepository : IProductRepository
{
    private readonly Dictionary<string, Product> _products = new();

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

    public Product? GetProduct(string name)
    {
        return _products.TryGetValue(name, out var product) ? product : null;
    }
    
    public IEnumerable<Product> GetAllProducts()
    {
        return _products.Values;
    }

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