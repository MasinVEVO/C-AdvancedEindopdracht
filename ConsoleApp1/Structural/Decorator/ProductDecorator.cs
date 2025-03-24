namespace ConsoleApp1.Structural.Decorator;

public class ProductDecorator : IProduct
{
    protected IProduct _product;
    
    protected ProductDecorator(IProduct product)
    {
        _product = product;
    }
    
    public virtual string GetDescription()
    {
        return _product.GetDescription();
    }
    
    public virtual decimal GetPrice()
    {
        return _product.GetPrice();
    }
}