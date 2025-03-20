using MyApp.Models;
using VendingMachineApp.Models;

public interface IVendingMachineState   
{
    void InsertMoney(VendingMachine vendingMachine, decimal money);
    void SelectProduct(VendingMachine vendingMachine, Product product);
    void DispenseProduct(VendingMachine vendingMachine);
}
