namespace ConsoleApp1.Structural.Decorator;

public class BasicProduct : IProduct
{
    public string GetDescription()
    { 
       return "Basic product";
    }
    
    public decimal GetPrice()
    {
        return 10.0m;
    }
}