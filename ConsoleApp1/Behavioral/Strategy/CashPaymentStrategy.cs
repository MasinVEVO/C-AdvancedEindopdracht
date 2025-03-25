namespace MyApp.Behavioral.Strategy;

public class CashPaymentStrategy : IPaymentStrategy
{
    public void Pay(decimal amount)
    {
        Console.WriteLine($"Paying {amount} using Cash.");
    }
    
    public bool ProcessPayment(decimal amountPaid, decimal productPrice)
    {
        return amountPaid >= productPrice;
    }
    
    
}