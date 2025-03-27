namespace ConsoleApp1.Structural.Decorator;

public class BasicProduct(string? productName, decimal @decimal) : IProduct
{
    public string GetDescription()
    { 
       return "Basic product";
    }
    
    public decimal GetPrice()
    {
        return 10.0m;
    }

    public string Name { get; set; }
}