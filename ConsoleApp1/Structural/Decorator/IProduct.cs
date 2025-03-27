namespace ConsoleApp1.Structural.Decorator;

public interface IProduct
{
    string GetDescription();
    decimal GetPrice();
    string Name { get; set; }
}