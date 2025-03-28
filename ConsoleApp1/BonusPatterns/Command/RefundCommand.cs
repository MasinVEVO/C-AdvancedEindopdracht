using System.Diagnostics;
using ConsoleApp1.Patterns.Creational.Singleton;
using MyApp.Models;
using VendingMachineApp.Models;
using VendingMachineApp.Services;

namespace ConsoleApp1.BonusPatterns.Command;

/// <summary>
/// Deze klasse implementeert het Command pattern voor het verwerken van refunds.
/// Het biedt functionaliteit om een product terug te nemen en het aankoopbedrag terug te geven,
/// met de mogelijkheid om deze actie ongedaan te maken.
/// </summary>
public class RefundCommand : ICommand
{
    private readonly string _productName;
    private readonly decimal _amountRefunded;
    private readonly InventoryManager _inventoryManager;
    private readonly PaymentService _paymentService;
    private readonly VendingMachine _vendingMachine;

    /// <summary>
    /// Initialiseert een nieuwe instance van de RefundCommand klasse met expliciete product informatie.
    /// </summary>
    /// <param name="productName">De naam van het product dat wordt gerefund</param>
    /// <param name="amountRefunded">Het bedrag dat wordt terugbetaald</param>
    public RefundCommand(string productName, decimal amountRefunded)
    {
        _productName = productName;
        _amountRefunded = amountRefunded;
        _inventoryManager = InventoryManager.Instance;
        _paymentService = new PaymentService();
    }

    /// <summary>
    /// Initialiseert een nieuwe instance van de RefundCommand klasse op basis van een VendingMachine.
    /// Gebruikt het geselecteerde product en diens prijs voor de refund.
    /// </summary>
    /// <param name="vendingMachine">De automaat waarvan het geselecteerde product wordt gerefund</param>
    public RefundCommand(VendingMachine vendingMachine)
    {
        _vendingMachine = vendingMachine ?? throw new ArgumentNullException(nameof(vendingMachine));
        _inventoryManager = InventoryManager.Instance;
        _paymentService = new PaymentService();

        if (vendingMachine.SelectedProduct != null)
        {
            _productName = vendingMachine.SelectedProduct.Name;
            _amountRefunded = vendingMachine.SelectedProduct.Price;
        }
        else
        {
            _productName = string.Empty;
            _amountRefunded = 0;
        }
         

    }

    /// <summary>
    /// Voert de refund uit door het product terug te voegen aan de inventaris
    /// en het aankoopbedrag terug te geven.
    /// </summary>
    public void Execute()
    {
        if (_vendingMachine != null)
        {
            _vendingMachine.Balance = 0;
            Console.WriteLine($"Refund uitgevoerd: ${_amountRefunded} voor product {_productName}");
            return;
        }

        // Original product-based refund logic
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

    /// <summary>
    /// Maakt de refund ongedaan door het product weer uit de inventaris te verwijderen.
    /// Dit is de inverse operatie van Execute().
    /// </summary>
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