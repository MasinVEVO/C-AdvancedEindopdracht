using System;
using ConsoleApp1.BonusPatterns.Command;
using ConsoleApp1.Concurrency.ProducerConsumer;
using ConsoleApp1.Concurrency.ThreadPool;
using ConsoleApp1.Patterns.Creational.Singleton;
using MyApp.Models;
using VendingMachineApp.Models;
using VendingMachineApp.Services;
using VendingMachineApp.Patterns.Structural.Facade;

namespace ConsoleApp1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // ✅ Vooraf gedefinieerde producten voor initiële data
            InventoryManager.Instance.AddProduct(new Product("Coca-Cola", 2.50m, 10));
            InventoryManager.Instance.AddProduct(new Product("Sprite", 2.20m, 8));
            InventoryManager.Instance.AddProduct(new Product("Chips", 1.80m, 15));
            InventoryManager.Instance.AddProduct(new Product("Snoep", 1.00m, 20));
            InventoryManager.Instance.AddProduct(new Product("Water", 1.50m, 12));

            var vendingMachine = new VendingMachine();
            var facade = new VendingMachineFacade();
            RefundCommand refundCommand = null;
            var orderQueue = new OrderProcessingQueue(10);
            var taskManager = new TaskManager(10);

            bool running = true;

            while (running)
            {
                Console.Clear();
                Console.WriteLine("=== Vending Machine Menu ===");
                Console.WriteLine("1. Toon producten");
                Console.WriteLine("2. Voeg geld toe");
                Console.WriteLine("3. Selecteer product");
                Console.WriteLine("4. Geef product uit");
                Console.WriteLine("5. Voorraad aanvullen");
                Console.WriteLine("6. Restitutie uitvoeren");
                Console.WriteLine("7. Stoppen");
                Console.Write("Kies een optie: ");

                var input = Console.ReadLine();

                switch (input)
                {
                    case "1":
                        InventoryManager.Instance.ShowInventory();
                        break;

                    case "2":
                        Console.Write("Voer het bedrag in: ");
                        if (decimal.TryParse(Console.ReadLine(), out decimal amount))
                        {
                            vendingMachine.InsertMoney(amount);
                        }
                        else
                        {
                            Console.WriteLine("Ongeldig bedrag.");
                        }
                        break;

                    case "3":
                        Console.Write("Voer de productnaam in: ");
                        var productName = Console.ReadLine();
                        vendingMachine.SelectProduct(productName);
                        break;

                    case "4":
                        Console.Write("Voer de productnaam in voor uitgifte: ");
                        var dispenseProduct = Console.ReadLine();
                        vendingMachine.DispenseProduct(dispenseProduct);
                        break;

                    case "5":
                        Console.Write("Voer de productnaam in: ");
                        var refillProduct = Console.ReadLine();
                        Console.Write("Voer de hoeveelheid in: ");
                        if (int.TryParse(Console.ReadLine(), out int quantity))
                        {
                            vendingMachine.RefillProduct(refillProduct, quantity);
                        }
                        else
                        {
                            Console.WriteLine("Ongeldige hoeveelheid.");
                        }
                        break;

                    case "6":
                        if (vendingMachine.SelectedProduct != null)
                        {
                            refundCommand = new RefundCommand(vendingMachine);
                            refundCommand.Execute();
                        }
                        else
                        {
                            Console.WriteLine("Geen product geselecteerd voor restitutie.");
                        }
                        break;

                    case "7":
                        running = false;
                        Console.WriteLine("Programma afgesloten.");
                        break;

                    default:
                        Console.WriteLine("Ongeldige keuze. Probeer opnieuw.");
                        break;
                }

                Console.WriteLine("Druk op een toets om door te gaan...");
                Console.ReadKey();
            }
        }
    }
}