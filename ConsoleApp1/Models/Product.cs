namespace MyApp.Models;


public interface IProduct
{
    string Name { get; }
    decimal Price { get; }
    decimal Stock { get; }
    void ReduceStock();
}

// Het implementeren van een interface maakt uitbreiding mogelijk via de Decorator Pattern

public class Product : IProduct
{
    public string Name { get; private set; }
    public decimal Price { get; private set; }
    public decimal Stock { get; private set; }
    
    public Product(string name, decimal price, decimal stock)
    {
        Name = name;
        Price = price;
        Stock = stock;
    }
    
    public void ReduceStock()
    {
        if (Stock > 0)
        {
            Stock--;
            Console.WriteLine($"Stock of {Name} reduced to {Stock}");
        }
        else
        {
            Console.WriteLine($"Stock of {Name} is empty");
        }
    }
    
    public override string ToString()
    {
        return $"{Name} - €{Price} ({Stock} op voorraad)";
    }
}