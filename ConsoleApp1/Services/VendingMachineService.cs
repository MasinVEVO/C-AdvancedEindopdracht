using VendingMachineApp.Models;

namespace ConsoleApp1.Services;


/// <summary>
/// Service klasse die functionaliteit biedt voor het beheren van een vendingmachine.
/// Fungeert als interface tussen de client en de vendingmachine.
/// </summary>
public class VendingMachineService
{
    /// <summary>
    /// De vendingmachine instantie die door deze service wordt beheerd.
    /// </summary>
    private readonly VendingMachine _vendingMachine;

    /// <summary>
    /// Initialiseert een nieuwe instantie van de VendingMachineService.
    /// Maakt een nieuwe VendingMachine instantie aan.
    /// </summary>
    public VendingMachineService()
    {
        _vendingMachine = new VendingMachine();
    }

    /// <summary>
    /// Voegt geld toe aan de vendingmachine.
    /// </summary>
    /// <param name="amount">Het bedrag dat toegevoegd wordt</param>
    public void InsertMoney(decimal amount)
    {
        _vendingMachine.InsertMoney(amount);
    }

    /// <summary>
    /// Selecteert een product in de vendingmachine op basis van naam.
    /// </summary>
    /// <param name="productName">De naam van het te selecteren product</param>
    public void SelectProduct(string productName)
    {
        _vendingMachine.SelectProduct(productName);
    }

    /// <summary>
    /// Geeft het geselecteerde product uit de vendingmachine.
    /// </summary>
    /// <param name="productName">De naam van het uit te geven product</param>
    public void DispenseProduct(string productName)
    {
        _vendingMachine.DispenseProduct(productName);
    }

    /// <summary>
    /// Toont de huidige status van de vendingmachine.
    /// </summary>
    public void ShowMachineStatus()
    {
        _vendingMachine.ShowStatus();
    }
}