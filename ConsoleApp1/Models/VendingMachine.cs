using MyApp.Models;
using VendingMachineApp.Models;
using System;
using ConsoleApp1.BonusPatterns.Memento;
using ConsoleApp1.Patterns.Creational.Singleton;

namespace VendingMachineApp.Models
{
    public class VendingMachine
    {
        public IVendingMachineState CurrentState { get; private set; }
        public decimal Balance { get; set; }
        public Product? SelectedProduct { get; set; }
        private string? _selectedProductCode { get; set; }

        public VendingMachine()
        {
            CurrentState = new WaitingForMoneyState(); // Start in de "Wachten op geld"-status
            Balance = 0;
            SelectedProduct = null;
        }

        public void SetState(IVendingMachineState newState)
        {
            CurrentState = newState;
            Console.WriteLine($" Status gewijzigd naar: {newState.GetType().Name}");
        }

        public void InsertMoney(decimal amount)
        {
            CurrentState.InsertMoney(this, amount);
        }

        public void SelectProduct(string productName)
        {
            var product = InventoryManager.Instance.GetProduct(productName);
            SelectedProduct = InventoryManager.Instance.GetProduct(productName);

            if (product == null)
            {
                Console.WriteLine($" {productName} is niet beschikbaar in de automaat.");
                return;
            }
            CurrentState.SelectProduct(this, product);
        }

        public void DispenseProduct(string _product)
        {
            if (!string.IsNullOrEmpty(_selectedProductCode))
            {
                Console.WriteLine($"Product {_selectedProductCode} is uitgegeven.");
                _selectedProductCode = null;
            }
            else
            {
                Console.WriteLine("Geen product geselecteerd.");
            }
        }

        public void RefillProduct(string product, int quantity)
        {
            Console.WriteLine($"Refilling product: {product} with {quantity} items");
        }

        
        public VendingMachineMemento SaveState()
        {
            int currentStock = SelectedProduct?.Stock ?? 0;
            return new VendingMachineMemento(Balance, SelectedProduct, currentStock);
        }

        
        public void RestoreState(VendingMachineMemento memento)
        {
            Balance = memento.Balance;
            SelectedProduct = memento.SelectedProduct;

            Console.WriteLine("️ Vending Machine-status hersteld naar vorige toestand.");
        }
        
        public void ShowStatus()
        {
            string productInfo = SelectedProduct != null
                ? $"{SelectedProduct.Name} - €{SelectedProduct.Price} (Voorraad: {SelectedProduct.Stock})"
                : "Geen product geselecteerd.";

            Console.WriteLine($" Saldo: €{Balance} | Product: {productInfo}");
        }

        public VendingMachineMemento CreateMemento()
        {
            return new VendingMachineMemento(Balance, SelectedProduct, SelectedProduct?.Stock ?? 0);
        }
    }
}
