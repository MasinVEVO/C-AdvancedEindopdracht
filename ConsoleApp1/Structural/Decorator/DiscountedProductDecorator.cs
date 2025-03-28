namespace ConsoleApp1.Structural.Decorator;

/// <summary>
/// Decorator klasse die een korting toepast op een product.
/// Implementatie van het Decorator pattern om functionaliteit toe te voegen aan een bestaand product.
/// </summary>
public class DiscountedProductDecorator : ProductDecorator
{
    /// <summary>
    /// Initialiseert een nieuwe instantie van de DiscountedProductDecorator.
    /// </summary>
    /// <param name="product">Het product waarop de korting wordt toegepast</param>
    public DiscountedProductDecorator(IProduct product) : base(product)
    {
    }

    /// <summary>
    /// Geeft de beschrijving van het product terug met een indicatie dat er korting is toegepast.
    /// </summary>
    /// <returns>De uitgebreide beschrijving van het product</returns>
    public override string GetDescription()
    {
        return _product.GetDescription() + ", Discount Applied";
    }

    /// <summary>
    /// Berekent de prijs van het product na toepassing van de korting.
    /// </summary>
    /// <returns>De prijs van het product verminderd met 5 euro</returns>
    public override decimal GetPrice()
    {
        return _product.GetPrice() - 5.0m;
    }
}