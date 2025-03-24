using VendingMachineApp.Services;

namespace ConsoleApp1.Concurrency.ThreadPool;

public class PaymentProcessingTask : IThreadPoolTask
{
    private readonly decimal _amountPaid;
    private readonly decimal _productPrice;
    
    public PaymentProcessingTask(decimal amountPaid, decimal productPrice)
    {
        _amountPaid = amountPaid;
        _productPrice = productPrice;
    }
    
    public void Execute()
    {
        var paymentService = new PaymentService();

        if (paymentService.ProcessPayment(_amountPaid, _productPrice))
        {
            Console.WriteLine($" Betaling van €{_amountPaid} succesvol verwerkt.");
        }
        else
        {
            Console.WriteLine($" Betaling van €{_amountPaid} mislukt (Onvoldoende saldo).");
        }
        
    }
    
}