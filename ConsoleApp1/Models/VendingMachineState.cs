using MyApp.Models;

namespace VendingMachineApp.Models
{
    using System;
    using VendingMachineApp.Models; // Ensure this matches the namespace of your Product class

    public interface IVendingMachineState
    {
        void InsertMoney(VendingMachine vendingMachine, decimal amount);
        void SelectProduct(VendingMachine vendingMachine, Product product);
        void DispenseProduct(VendingMachine vendingMachine);
    }

    public abstract class VendingMachineState : IVendingMachineState
    {
        public virtual void InsertMoney(VendingMachine vendingMachine, decimal amount)
        {
            Console.WriteLine("Actie niet mogelijk in de huidige status.");
        }

        public virtual void SelectProduct(VendingMachine vendingMachine, Product product)
        {
            Console.WriteLine("Je kunt nu geen product selecteren.");
        }

        public virtual void DispenseProduct(VendingMachine vendingMachine)
        {
            Console.WriteLine("Geen product om uit te geven.");
        }
    }

    public class WaitingForMoneyState : VendingMachineState
    {
        public override void InsertMoney(VendingMachine vendingMachine, decimal amount)
        {
            vendingMachine.Balance += amount;
            Console.WriteLine($"💰 Geld toegevoegd: €{amount}. Nieuw saldo: €{vendingMachine.Balance}");
            vendingMachine.SetState(new SelectingProductState());
        }
    }

    public class SelectingProductState : VendingMachineState
    {
        public override void SelectProduct(VendingMachine vendingMachine, Product product)
        {
            if (vendingMachine.Balance < product.Price)
            {
                Console.WriteLine($"Onvoldoende saldo voor {product.Name}. Voeg meer geld toe.");
                return;
            }

            vendingMachine.SelectedProduct = product;
            Console.WriteLine($"{product.Name} geselecteerd.");
            vendingMachine.SetState(new DispensingProductState());
        }
    }

    public class DispensingProductState : VendingMachineState
    {
        public override void DispenseProduct(VendingMachine vendingMachine)
        {
            if (vendingMachine.SelectedProduct == null)
            {
                Console.WriteLine("Geen product geselecteerd.");
                return;
            }

            vendingMachine.Balance -= vendingMachine.SelectedProduct.Price;
            vendingMachine.SelectedProduct.ReduceStock();
            Console.WriteLine($"{vendingMachine.SelectedProduct.Name} uitgegeven! Resterend saldo: €{vendingMachine.Balance}");

            vendingMachine.SelectedProduct = null;
            vendingMachine.SetState(new WaitingForMoneyState());
        }
    }
    
}