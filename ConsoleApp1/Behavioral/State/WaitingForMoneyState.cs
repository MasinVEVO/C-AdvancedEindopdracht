// File: WaitingForMoneyState.cs

using MyApp.Models;
using VendingMachineApp.Models;

namespace MyApp.Behavioral.State
{
    public class WaitingForMoneyState : IVendingMachineState
    {
        public void InsertMoney(VendingMachine vendingMachine, decimal amount)
        {
            vendingMachine.Balance += amount;
            Console.WriteLine($" {amount} inserted. Current balance: {vendingMachine.Balance}");
            vendingMachine.SetState(new VendingMachineApp.Models.WaitingForMoneyState());
        }

        public void SelectProduct(VendingMachine vendingMachine, Product product)
        {
            Console.WriteLine("Please insert money first.");
        }

        public void DispenseProduct(VendingMachine vendingMachine)
        {
            Console.WriteLine("Please insert money first.");
        }
    }
}