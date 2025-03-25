using MyApp.Models;
using MyApp.Behavioral.Observer;

namespace ConsoleApp1.Patterns.Creational.Singleton
    
{
    // Singleton for inventory management in the vending machine
    public sealed class InventoryManager
    {
        private static readonly Lazy<InventoryManager> _instance =
            new(() => new InventoryManager());

        private readonly Dictionary<string, Product> _inventory;
        private readonly StockNotifier _notifier;

        private InventoryManager()
        {
            _inventory = new Dictionary<string, Product>();
            _notifier = new StockNotifier();
        }

        public static InventoryManager Instance => _instance.Value;

        public void AddProduct(Product product)
        {
            if (_inventory.ContainsKey(product.Name))
            {
                Console.WriteLine($"{product.Name} is already in stock.");
                return;
            }

            _inventory[product.Name] = product;
            Console.WriteLine($"{product.Name} added to inventory.");
        }

        public Product? GetProduct(string name)
        {
            return _inventory.TryGetValue(name, out var product) ? product : null;
        }

        public void ReduceStock(string name)
        {
            if (_inventory.TryGetValue(name, out var product) && product.Stock > 0)
            {
                product.ReduceStock();
                Console.WriteLine($"{name} stock reduced. Remaining stock: {product.Stock}");
            }
            else
            {
                Console.WriteLine($"{name} is not in stock.");
            }
        }

        public void ShowInventory()
        {
            Console.WriteLine("\nCurrent inventory:");
            foreach (var product in _inventory.Values)
            {
                Console.WriteLine($"- {product.Name}: {product.Stock} units - €{product.Price}");
            }
        }
    }
}