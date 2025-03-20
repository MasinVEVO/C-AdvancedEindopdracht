namespace MyApp.Behavioral.Strategy;

public class PaypalPaymentStrategy : IPaymentStrategy
{
    public void Pay(decimal amount)
    {
        Console.WriteLine($"Paying {amount} using Paypal.");
    }
}