using VendingMachineApp.Models;

namespace ConsoleApp1.Services;

public class VendingMachineService
{
    private readonly VendingMachine _vendingMachine;

    public VendingMachineService()
    {
        _vendingMachine = new VendingMachine();
    }

    public void InsertMoney(decimal amount)
    {
        _vendingMachine.InsertMoney(amount);
    }

    public void SelectProduct(string productName)
    {
        _vendingMachine.SelectProduct(productName);
    }

    public void DispenseProduct(string productName)
    {
        _vendingMachine.DispenseProduct(productName);
    }

    public void ShowMachineStatus()
    {
        _vendingMachine.ShowStatus();
    }
}