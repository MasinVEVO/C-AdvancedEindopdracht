namespace MyApp.Behavioral.Strategy;

/// <summary>
/// Deze klasse implementeert het Strategy pattern voor creditcard betalingen.
/// Het biedt een concrete implementatie van de IPaymentStrategy interface
/// voor het afhandelen van betalingen via creditcard.
/// </summary>
public class CreditCardPaymentStrategy : IPaymentStrategy
{
    /// <summary>
    /// Voert een betaling uit met een creditcard.
    /// </summary>
    /// <param name="amount">Het te betalen bedrag</param>
    public void Pay(decimal amount)
    {
        Console.WriteLine($"Paying {amount} using Credit Card.");
    }

    /// <summary>
    /// Controleert of de betaling voldoende is voor de productprijs.
    /// </summary>
    /// <param name="amountPaid">Het betaalde bedrag</param>
    /// <param name="productPrice">De prijs van het product</param>
    /// <returns>True als het betaalde bedrag voldoende is, anders false</returns>
    public bool ProcessPayment(decimal amountPaid, decimal productPrice)
    {
        return amountPaid >= productPrice;
    }
}