using ConsoleApp1.Structural.Facade;
using VendingMachineApp.Models;


namespace VendingMachineApp.Patterns.Structural.Facade;

public class VendingMachineFacade
{
    private readonly VendingMachine _vendingMachine;
    private readonly PaymentProcessor _paymentProcessor;

    public VendingMachineFacade()
    {
        _vendingMachine = new VendingMachine();
        _paymentProcessor = new PaymentProcessor();
    }

    public void PurchaseProduct(string productCode, decimal amount)
    {
        _vendingMachine.SelectProduct(productCode);
        if (_paymentProcessor.ProcessPayment(amount))
        {
            _vendingMachine.DispenseProduct(productCode);
        }
        else
        {
            Console.WriteLine("Betaling mislukt.");
        }
    }

    public void StartVendingMachine()
    {
        Console.WriteLine("Vending machine is gestart.");
    }
}