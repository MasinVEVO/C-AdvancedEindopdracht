using ConsoleApp1.Patterns.Creational.Singleton;
using MyApp.Models;
using VendingMachineApp.Models;
using VendingMachineApp.Services;

namespace ConsoleApp1.BonusPatterns.Command;

public class RefundCommand : ICommand
{
    private readonly string _productName;
    private readonly decimal _amountRefunded;
    private readonly InventoryManager _inventoryManager;
    private readonly PaymentService _paymentService;
    
    public RefundCommand(string productName, decimal amountRefunded)
    {
        _productName = productName;
        _amountRefunded = amountRefunded;
        _inventoryManager = InventoryManager.Instance;
        _paymentService = new PaymentService();
    }

    public RefundCommand(VendingMachine vendingMachine)
    {
        throw new NotImplementedException();
    }

    public void Execute()
    {
        var product = _inventoryManager.GetProduct(_productName);
        if (product != null)
        {
            _inventoryManager.AddProduct(new Product(_productName, product.Price, 1));
            Console.WriteLine($"Refund uitgevoerd: ${_amountRefunded} voor product {_productName}");
        }
        else
        {
            Console.WriteLine($"Product {_productName} is niet gevonden in de inventaris.");
        }
    }

    public void Undo()
    {
        var product = _inventoryManager.GetProduct(_productName);

        if (product != null && product.Stock > 0) 
        {
            _inventoryManager.ReduceStock(_productName);
            Console.WriteLine($"Refund geannuleerd: ${_amountRefunded} hersteld product {_productName}");
        }
        else
        {
            Console.WriteLine($"Undo mislukt: {_productName} is niet beschikbaar in voorraad");
        }
    }
}