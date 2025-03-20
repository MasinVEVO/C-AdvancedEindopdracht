using MyApp.Models;
using VendingMachineApp.Models;
using System;
using ConsoleApp1.Patterns.Creational.Singleton;

namespace VendingMachineApp.Models
{
    
    public class VendingMachine
    {
        public IVendingMachineState CurrentState { get; private set; }
        public decimal Balance { get; set; }
        public Product? SelectedProduct { get; set; }

        public VendingMachine()
        {
            CurrentState = new WaitingForMoneyState(); // Start in de "Wachten op geld"-status
            Balance = 0;
            SelectedProduct = null;
        }
        
        public void SetState(IVendingMachineState newState)
        {
            CurrentState = newState;
            Console.WriteLine($"🔄 Status gewijzigd naar: {newState.GetType().Name}");
        }
        
        public void InsertMoney(decimal amount)
        {
            CurrentState.InsertMoney(this, amount);
        }
        
        public void SelectProduct(string productName)
        {
            var product = InventoryManager.Instance.GetProduct(productName);

            if (product == null)
            {
                Console.WriteLine($" {productName} is niet beschikbaar in de automaat.");
                return;
            }
            CurrentState.SelectProduct(this, product);
        }
        
        public void DispenseProduct()
        {
            CurrentState.DispenseProduct(this);
        }
    }
}