using VendingMachineApp.Services;

namespace ConsoleApp1.Concurrency.ThreadPool;

/// <summary>
/// Implementeert een taak voor het verwerken van betalingen binnen een ThreadPool patroon.
/// Deze klasse zorgt voor parallelle verwerking van betalingstransacties, wat zorgt voor 
/// betere prestaties en efficiënt gebruik van resources.
/// </summary>
public class PaymentProcessingTask : IThreadPoolTask
{
    private readonly decimal _amountPaid;
    private readonly decimal _productPrice;

    /// <summary>
    /// Initialiseert een nieuwe instantie van de <see cref="PaymentProcessingTask"/> klasse.
    /// </summary>
    /// <param name="amountPaid">Het betaalde bedrag door de klant.</param>
    /// <param name="productPrice">De prijs van het product dat wordt gekocht.</param>
    public PaymentProcessingTask(decimal amountPaid, decimal productPrice)
    {
        _amountPaid = amountPaid;
        _productPrice = productPrice;
    }

    /// <summary>
    /// Voert de betalingsverwerkingstaak uit door de betaling te verwerken en het resultaat weer te geven.
    /// Maakt gebruik van de PaymentService om te controleren of het betaalde bedrag voldoende is
    /// en toont een bericht over het resultaat van de transactie.
    /// </summary>
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