namespace ConsoleApp1.Structural.Decorator;

public class PremiumProductDecorator : ProductDecorator
{
    public PremiumProductDecorator(IProduct product) : base(product)
    {
    }

    public override string GetDescription()
    {
        return _product.GetDescription() + ", Premium Features";
    }
    
    public override decimal GetPrice()
    {
        return _product.GetPrice() + 20.0m;
    }

    public string GetName()
    {
        return _product.Name;
    }
}