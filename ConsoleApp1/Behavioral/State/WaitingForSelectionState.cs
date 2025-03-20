// File: WaitingForSelectionState.cs

using MyApp.Models;
using VendingMachineApp.Models;

namespace MyApp.Behavioral.State
{
    public class WaitingForSelectionState : IVendingMachineState
    {
        public void InsertMoney(VendingMachine vendingMachine, decimal amount)
        {
            vendingMachine.Balance += amount;
            Console.WriteLine($" {amount} inserted. Current balance: {vendingMachine.Balance}");
        }

        public void SelectProduct(VendingMachine vendingMachine, Product product)
        {
            if (vendingMachine.Balance >= product.Price)
            {
                vendingMachine.SelectedProduct = product;
                vendingMachine.SetState(new DispensingProductState());
            }
            else
            {
                Console.WriteLine("Insufficient balance. Please insert more money.");
            }
        }

        public void DispenseProduct(VendingMachine vendingMachine)
        {
            Console.WriteLine("Please select a product first.");
        }
    }
}