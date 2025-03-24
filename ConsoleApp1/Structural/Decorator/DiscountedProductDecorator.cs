namespace ConsoleApp1.Structural.Decorator;

public class DiscountedProductDecorator : ProductDecorator
{
    public DiscountedProductDecorator(IProduct product) : base(product)
    {
    }
    
    public override string GetDescription()
    {
        return _product.GetDescription() + ", Discount Applied";
    }
    
    public override decimal GetPrice()
    {
        return _product.GetPrice() - 5.0m;
    }
}