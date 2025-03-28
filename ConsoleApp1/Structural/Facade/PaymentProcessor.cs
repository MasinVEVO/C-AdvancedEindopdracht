namespace ConsoleApp1.Structural.Facade;

public class PaymentProcessor
{
    public bool ProcessPayment(decimal amount)
    {
        // Process payment
        return amount > 0; // Simulate payment processing
    }
}