using VendingMachineApp.Models;

namespace MyApp.Behavioral.Command;

public class RefillProductCommand : ICommand
{
    private readonly VendingMachine _vendingMachine;
    private readonly string _product;
    private readonly int _quantity;
    
    public RefillProductCommand(VendingMachine vendingMachineApp, string product, int quantity)
    {
        _vendingMachine = vendingMachineApp;
        _product = product;
        _quantity = quantity;
    }

    public void Execute()
    {
        _vendingMachine.RefillProduct(_product, _quantity);
    }
}