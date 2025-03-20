namespace MyApp.Models;

public interface IStockObserver
{
    void Notify(string message);
}

public class Customer : IStockObserver
{
    public string Name { get; private set; }
    public decimal Balance { get; private set; }
    
    public Customer(string name, decimal initialBalance)
    {
        Name = name;
        Balance = initialBalance;
    }

    public bool PurchaseProduct(Product product)
    {
        if (product.Stock <= 0)
        {
            Console.WriteLine($" Sorry {Name}, {product.Name} is out of stock");
            return false;
        }
        
        if (Balance < product.Price)
        {
            Console.WriteLine($" Sorry {Name}, you don't have enough balance to purchase {product.Name}");
            return false;
        }
        
        Balance -= product.Price;
        product.ReduceStock();
        Console.WriteLine($" {Name} purchased {product.Name} for €{product.Price}");
        return true;
    }
    
    public void Notify(string message)
    {
        Console.WriteLine($" {Name} received notification: {message}");
    }
    
    public override string ToString()
    {
        return $"{Name} - €{Balance}";
    }
}