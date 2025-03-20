using MyApp.Behavioral.State;
using System;
using ConsoleApp1.Patterns.Creational.Singleton;
using MyApp.Models;

namespace VendingMachineApp.Models
{
    public class VendingMachine
    {
        public IVendingMachineState CurrentState { get; private set; }
        public decimal Balance { get; set; }
        public Product? SelectedProduct { get; set; }

        public VendingMachine()
        {
            CurrentState = new WaitingForMoneyState(); // Start in the "Waiting for Money" state
            Balance = 0;
            SelectedProduct = null;
        }

        public void SetState(IVendingMachineState newState)
        {
            CurrentState = newState;
            Console.WriteLine($"🔄 State changed to: {newState.GetType().Name}");
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
                Console.WriteLine($"{productName} is not available in the machine.");
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