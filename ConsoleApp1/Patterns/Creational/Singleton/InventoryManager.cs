using MyApp.Models;
using MyApp.Behavioral.Observer;

namespace ConsoleApp1.Patterns.Creational.Singleton
{
    /// <summary>
    /// Beheert de volledige productinventaris van de applicatie als een singleton.
    /// Zorgt ervoor dat er slechts één instantie van de inventarisbeheerder bestaat.
    /// </summary>
    public sealed class InventoryManager
    {
        // Lazy instantiatie zorgt ervoor dat het object pas wordt aangemaakt wanneer het nodig is
        private static readonly Lazy<InventoryManager> _instance =
            new(() => new InventoryManager());

        // Interne opslag voor alle producten, geïndexeerd op naam
        private readonly Dictionary<string, Product> _inventory;
        // Notifier voor het informeren van geabonneerden over voorraadwijzigingen
        private readonly StockNotifier _notifier;

        /// <summary>
        /// Private constructor zorgt ervoor dat de klasse niet van buitenaf kan worden geïnstantieerd.
        /// Dit is essentieel voor het singleton pattern.
        /// </summary>
        private InventoryManager()
        {
            _inventory = new Dictionary<string, Product>();
            _notifier = new StockNotifier();
        }

        /// <summary>
        /// Geeft toegang tot de enige instantie van de InventoryManager.
        /// </summary>
        public static InventoryManager Instance => _instance.Value;

        /// <summary>
        /// Voegt een nieuw product toe aan de inventaris.
        /// Controleert of het product al bestaat om duplicaten te voorkomen.
        /// </summary>
        /// <param name="product">Het toe te voegen product</param>
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

        /// <summary>
        /// Haalt een product op uit de inventaris op basis van naam.
        /// </summary>
        /// <param name="name">De naam van het gezochte product</param>
        /// <returns>Het product indien gevonden, anders null</returns>
        public Product? GetProduct(string name)
        {
            return _inventory.TryGetValue(name, out var product) ? product : null;
        }

        /// <summary>
        /// Vermindert de voorraad van een product.
        /// Controleert of het product bestaat en of het op voorraad is.
        /// </summary>
        /// <param name="name">De naam van het product waarvan de voorraad moet afnemen</param>
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

        /// <summary>
        /// Toont een overzicht van alle producten in de inventaris met hun voorraad en prijs.
        /// </summary>
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