using VendingMachineApp.Models;

namespace MyApp.Behavioral.Command;

public class DispenseProductCommand : ICommand
{
    private readonly VendingMachine _vendingMachine;
    private readonly string _product;
    
    public DispenseProductCommand(VendingMachine vendingMachine, string product)
    {
        _vendingMachine = vendingMachine;
        _product = product;
    }

    public void Execute()
    {
        _vendingMachine.DispenseProduct(_product);
    }
}